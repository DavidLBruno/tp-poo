# Diseño — Módulo de Reservas y Administración

**Fecha:** 2026-07-21
**Alcance:** Secciones de *Reservas* y *Administración* del TP Integrador (Sistema de Reservas de Laboratorios).
**Fuera de alcance (otro desarrollador):** Login, Reportes, menú Inicio, Cerrar sesión.
**Restricción dura:** El **diseño** de `FrmPrincipal` (Designer) no se modifica. Solo se agrega code-behind.

---

## 1. Objetivo

Implementar, respetando la rúbrica del enunciado (aplicación correcta de cada tema de POO), las funcionalidades de:

- **Reservas:** alta de reserva (con validación de solapamiento y límite semanal), cancelación (según rol) y consulta (grilla + filtros en `FrmPrincipal`).
- **Administración:** ABM de laboratorios y de usuarios.

El énfasis no es solo funcional: cada tema debe verse aplicado en el lugar correcto (ver mapeo a rúbrica en §9).

---

## 2. Arquitectura

Se mantiene la estructura de carpetas/namespaces actual y se agrega `Servicios`:

```
Modelos/       Usuario (abstracta) + Administrador/Docente/Alumno, Reserva, Laboratorio, EstadoReserva
Repositorios/  IRepositorio<T>, RepositorioArchivo<T> (genérico único), RepositorioFactory
Servicios/     ServicioReservas, Sesion
Excepciones/   ReservaSolapada, LaboratorioNoDisponible, ArchivoDatosCorrupto
Formularios/   FrmPrincipal (code-behind), FrmAltaReserva, FrmGrillaReservas,
               FrmGestionLaboratorios, FrmGestionUsuarios
```

**Flujo de datos:**

```
Formulario  →  Servicio (reglas de negocio)  →  Repositorio (acceso a datos)  →  archivo .txt
```

Regla de aislamiento: el formulario **nunca** lee/escribe archivos ni contiene reglas de negocio. El acceso a archivos vive solo en `RepositorioArchivo<T>`; las reglas de negocio en `ServicioReservas` y en los métodos polimórficos de `Usuario`.

---

## 3. Modelos (compartidos — se extienden)

### 3.1 `Usuario` (abstracta) — corazón del polimorfismo

Se agregan miembros polimórficos (sin `if/switch` sobre el tipo):

- `abstract int ObtenerLimiteReservasSemanales();`
- `virtual int ObtenerDiasAnticipacionMaxima();`
- `virtual bool PuedeCancelar(Reserva r) => r.UsuarioId == Id;` (solo reservas propias, por defecto)

Valores por rol (definidos por el alumno, requisito del enunciado):

| Rol | Límite semanal | Anticipación máx. | PuedeCancelar |
|-----|----------------|-------------------|---------------|
| Alumno | 3 | 7 días | solo propias (base) |
| Docente | 10 | 30 días | solo propias (base) |
| Administrador | `int.MaxValue` | `int.MaxValue` | cualquiera (override → `true`) |

`Administrador.PuedeGestionarLaboratorios()` ya devuelve `true` (existe).

### 3.2 `Reserva`

- Nuevo campo/propiedad `string Motivo`.
- Constructores sobrecargados encadenados con `: this(...)`:
  - completo: `(id, labId, usuarioId, inicio, fin, estado, motivo)`
  - con motivo, nueva: `(labId, usuarioId, inicio, fin, motivo)` → `this(0, …, Pendiente, motivo)`
  - sin motivo: `(labId, usuarioId, inicio, fin)` → `this(…, "")`
- Validación: `Fin` debe ser posterior a `Inicio` (excepción `ArgumentException` si no).
- Propiedades calculadas: `TimeSpan DuracionReserva => Fin - Inicio;` y `bool EstaVencida => Fin < DateTime.Now;`
- Se conserva `SeSolapaCon(Reserva)`.

### 3.3 `Laboratorio`

- Se agregan `string Ubicacion` y `string Equipamiento` (los menciona el enunciado).
- Validación en setters: `Nombre` no vacío, `Capacidad > 0`.

---

## 4. Persistencia

Formato delimitado por `|`. La lectura/escritura vive únicamente en `RepositorioArchivo<T>`.

- `laboratorios.txt`: `id|nombre|ubicacion|capacidad|equipamiento|disponible`
- `reservas.txt`: `id|labId|usuarioId|inicio|fin|estado|motivo`
- `usuarios.txt`: `id|nombre|email|rol` (sin cambios de formato)

El campo `rol` de usuarios determina qué subclase instanciar en la deserialización (patrón *factory*, no lógica de negocio).

**Cambios a `RepositorioArchivo<T>`:**
- Envolver la deserialización de cada línea en `try/catch` y lanzar `ArchivoDatosCorruptoException` (con nº de línea y contenido) ante formato inválido.
- Agregar **destructor (finalizer)** como respaldo del patrón `Dispose` (rúbrica 5.4).

**`RepositorioFactory`** (estática): construye los tres repositorios reutilizando el **único** genérico `RepositorioArchivo<T>`, cada uno con sus lambdas de serializar/deserializar y su selector de Id. Centraliza las rutas a `ArchivosDatos/`.

Se actualizan los `.txt` semilla al nuevo formato (datos de prueba de carga inicial).

---

## 5. Servicio de reservas

`ServicioReservas` recibe los repositorios por constructor y expone:

- `Reserva CrearReserva(int labId, Usuario usuario, DateTime inicio, DateTime fin, string motivo)`
  - Lab existe y `Disponible` → si no, `LaboratorioNoDisponibleException`.
  - Sin solapamiento (LINQ sobre reservas Pendiente/Confirmada del mismo lab) → si no, `ReservaSolapadaException`.
  - Dentro del límite semanal del usuario (LINQ contando reservas de la semana + `usuario.ObtenerLimiteReservasSemanales()`).
  - Dentro de la anticipación máxima del rol.
  - Persiste vía repo y devuelve la `Reserva` creada.
- `void CancelarReserva(int reservaId, Usuario usuario)`
  - Verifica `usuario.PuedeCancelar(reserva)`; si no, excepción. Marca `Estado = Cancelada` y actualiza.
- `IEnumerable<Reserva> ReservasPorLabYFecha(int labId, DateTime fecha)` — LINQ; alimenta la grilla de `FrmPrincipal`.

---

## 6. Sesión / integración con login

`Sesion` (estática): `Usuario? UsuarioActual`.

El login **no se modifica en comportamiento** (sigue pasando con cualquier credencial). En `Program.cs`, tras `DialogResult.OK`:

1. Se lee el texto ingresado en el login (se expone en `FrmLogin` una propiedad de solo lectura `UsuarioIngresado` — único agregado, no altera el flujo).
2. Se busca ese texto en `usuarios.txt` (match por `Email`, sin distinguir mayúsculas).
3. Si coincide → ese `Usuario`; si no → primer `Administrador`. Se asigna a `Sesion.UsuarioActual` y se abre `FrmPrincipal`.

Esto permite demostrar el polimorfismo real en la defensa (iniciar como Alumno vs. Administrador cambia límites, cancelación y menú disponible).

---

## 7. Formularios

### 7.1 `FrmPrincipal` (solo code-behind; Designer intacto)

- **Load:** setea `lblUsuarioActual`/`lblRolActual` desde `Sesion`; puebla `cboLaboratorio` desde el repo; habilita/deshabilita `mnuAdministracion`/`mnuGestionLaboratorios` según `UsuarioActual.PuedeGestionarLaboratorios()` (polimorfismo visible en UI, rúbrica §6).
- **Reservas:** `mnuNuevaReserva` abre `FrmAltaReserva` y se suscribe a su evento `ReservaCreada` para refrescar la grilla. `mnuConsultarReservas` refresca la grilla. `mnuCancelarReserva` abre `FrmGrillaReservas`.
- **Administración:** `mnuGestionLaboratorios` / `mnuGestionUsuarios` abren sus ABM.
- **Filtros/grilla:** `btnActualizar` (y cambio de lab/fecha) recargan `dgvReservas` vía `ServicioReservas.ReservasPorLabYFecha`; actualiza `lblCantidadReservas`.
- **No se cablean** `mnuInicio`, `mnuReportes`, `mnuCerrarSesion` (otro desarrollador).

### 7.2 `FrmAltaReserva`

Controles: combo laboratorio, `DateTimePicker` fecha, hora inicio, hora fin, textbox motivo, botón Confirmar / Cancelar. Al confirmar: arma inicio/fin, llama a `ServicioReservas.CrearReserva`, y ante éxito dispara el evento `ReservaCreada` (ya declarado) y cierra. Los errores de negocio se muestran con `MessageBox` (captura de las excepciones propias).

### 7.3 `FrmGrillaReservas` (cancelación)

Grilla de reservas (con nombre de lab/usuario resueltos) y botón **Cancelar** sobre la seleccionada, respetando `PuedeCancelar`. Muestra resultado/errores por `MessageBox`.

### 7.4 `FrmGestionLaboratorios` y `FrmGestionUsuarios` (ABM)

Cada uno: grilla + panel de campos + botones Alta / Modificar / Eliminar / Limpiar, usando el repositorio correspondiente. Validación en los setters del modelo; errores por `MessageBox`. `FrmGestionUsuarios` permite elegir el rol (crea la subclase correcta).

---

## 8. Manejo de errores

- Operaciones de archivo y de negocio con `try/catch/finally` donde corresponde.
- Excepciones propias con **constructores completos** (por defecto, `message`, `message + innerException`).
- En los formularios, las excepciones de negocio se traducen a `MessageBox` claros; nunca se filtran sin manejar.

---

## 9. Mapeo a la rúbrica (100 pts)

| Tema | Dónde queda cubierto |
|------|----------------------|
| Clases/atributos/propiedades (10) | Modelos con campos privados, validación en setters, `DuracionReserva`/`EstaVencida` |
| Constructores y sobrecarga (8) | `Reserva` con constructores encadenados `: this(...)` (con/sin motivo) |
| Herencia y polimorfismo (12) | `ObtenerLimiteReservasSemanales`, `PuedeCancelar`, `PuedeGestionarLaboratorios` (override, sin if/switch) |
| Destructores / IDisposable (8) | `RepositorioArchivo<T>`: `Dispose` + finalizer de respaldo |
| Excepciones personalizadas (10) | Tres excepciones con constructores completos + try/catch/finally |
| Interfaces (10) | `IRepositorio<T>` implementada por el genérico |
| Delegados/eventos/lambda (10) | Evento `ReservaCreada` refresca la grilla; lambdas en filtros/serialización |
| Genéricos (12) | Único `RepositorioArchivo<T>` reutilizado para las 3 entidades |
| LINQ (12) | Solapamiento, reservas por lab/fecha, límite semanal |
| Persistencia/integración (8) | Robustez ante archivo inexistente/corrupto (`ArchivoDatosCorruptoException`) |

> Nota: el reporte con `GroupBy` (parte de los 12 de LINQ) corresponde a la sección **Reportes**, a cargo del otro desarrollador. El diseño de datos/servicios queda preparado para que lo consuma.

---

## 10. Coordinación con el otro desarrollador

- **Compartido:** carpeta `Modelos` (se extienden clases; no se rompen las firmas existentes salvo `Reserva`, que es del dominio de reservas), `Repositorios`, `Excepciones`.
- **De este módulo:** `Servicios/`, `FrmAltaReserva`, `FrmGrillaReservas`, `FrmGestionLaboratorios`, `FrmGestionUsuarios`, y el **code-behind de Reservas/Administración** en `FrmPrincipal`.
- **Del otro dev:** `FrmLogin` (comportamiento), Reportes, menú Inicio/Cerrar sesión. Punto de contacto: `Sesion.UsuarioActual` (lo setea `Program.cs`) y `FrmLogin.UsuarioIngresado`.
