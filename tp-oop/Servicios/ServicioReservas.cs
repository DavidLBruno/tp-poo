using tp_oop.Excepciones;
using tp_oop.Modelos;
using tp_oop.Repositorios;

namespace tp_oop.Servicios;

// Reglas de negocio de reservas. Los formularios solo llaman a este servicio;
// no contienen lógica de negocio ni acceso a archivos.
public sealed class ServicioReservas
{
    private readonly RepositorioArchivo<Reserva> _repoReservas;
    private readonly RepositorioArchivo<Laboratorio> _repoLaboratorios;

    public ServicioReservas(
        RepositorioArchivo<Reserva> repoReservas,
        RepositorioArchivo<Laboratorio> repoLaboratorios)
    {
        _repoReservas = repoReservas;
        _repoLaboratorios = repoLaboratorios;
    }

    public Reserva CrearReserva(int laboratorioId, Usuario usuario, DateTime inicio, DateTime fin, string motivo)
    {
        if (fin <= inicio)
            throw new ArgumentException("La hora de fin debe ser posterior a la hora de inicio.");

        if (inicio < DateTime.Now)
            throw new ArgumentException("No se puede reservar en una fecha/hora pasada.");

        var laboratorio = _repoLaboratorios.ObtenerPorId(laboratorioId)
            ?? throw new LaboratorioNoDisponibleException("El laboratorio seleccionado no existe.");

        if (!laboratorio.Disponible)
            throw new LaboratorioNoDisponibleException($"El laboratorio '{laboratorio.Nombre}' no está disponible.");

        ValidarAnticipacion(usuario, inicio);
        ValidarSolapamiento(laboratorioId, inicio, fin);
        ValidarLimiteSemanal(usuario, inicio);

        // La reserva nace como solicitud pendiente; un administrador la confirma luego.
        var reserva = new Reserva(laboratorioId, usuario.Id, inicio, fin, motivo)
        {
            Id = _repoReservas.ProximoId(),
            Estado = EstadoReserva.Pendiente
        };

        _repoReservas.Agregar(reserva);
        return reserva;
    }

    public void ConfirmarReserva(int reservaId, Usuario usuario)
    {
        if (!usuario.PuedeConfirmarReservas())
            throw new InvalidOperationException("No tiene permisos para confirmar reservas.");

        var reserva = _repoReservas.ObtenerPorId(reservaId)
            ?? throw new InvalidOperationException("La reserva no existe.");

        if (reserva.Estado == EstadoReserva.Cancelada)
            throw new InvalidOperationException("No se puede confirmar una reserva cancelada.");

        if (reserva.Estado == EstadoReserva.Confirmada)
            throw new InvalidOperationException("La reserva ya está confirmada.");

        reserva.Estado = EstadoReserva.Confirmada;
        _repoReservas.Actualizar(reserva);
    }

    public void CancelarReserva(int reservaId, Usuario usuario)
    {
        var reserva = _repoReservas.ObtenerPorId(reservaId)
            ?? throw new InvalidOperationException("La reserva no existe.");

        if (reserva.Estado == EstadoReserva.Cancelada)
            throw new InvalidOperationException("La reserva ya está cancelada.");

        if (!usuario.PuedeCancelar(reserva))
            throw new InvalidOperationException("No tiene permisos para cancelar esta reserva.");

        reserva.Estado = EstadoReserva.Cancelada;
        _repoReservas.Actualizar(reserva);
    }

    // Reservas de un laboratorio en una fecha (no canceladas), ordenadas por hora.
    public IEnumerable<Reserva> ReservasPorLabYFecha(int laboratorioId, DateTime fecha)
    {
        return _repoReservas.ObtenerTodos()
            .Where(r => r.LaboratorioId == laboratorioId
                        && r.Inicio.Date == fecha.Date
                        && r.Estado != EstadoReserva.Cancelada)
            .OrderBy(r => r.Inicio)
            .ToList();
    }

    public IEnumerable<Reserva> ObtenerTodas() => _repoReservas.ObtenerTodos();

    private void ValidarAnticipacion(Usuario usuario, DateTime inicio)
    {
        var dias = usuario.ObtenerDiasAnticipacionMaxima();
        if (dias == int.MaxValue)
            return;

        var diasHastaReserva = (inicio.Date - DateTime.Now.Date).Days;
        if (diasHastaReserva > dias)
            throw new InvalidOperationException(
                $"Como {usuario.ObtenerRol()} solo puede reservar con hasta {dias} días de anticipación.");
    }

    private void ValidarSolapamiento(int laboratorioId, DateTime inicio, DateTime fin)
    {
        var nueva = new Reserva(laboratorioId, 0, inicio, fin);

        var haySolapamiento = _repoReservas.ObtenerTodos()
            .Where(r => r.Estado != EstadoReserva.Cancelada)
            .Any(r => r.SeSolapaCon(nueva));

        if (haySolapamiento)
            throw new ReservaSolapadaException(
                "Ya existe una reserva en ese laboratorio para el horario seleccionado.");
    }

    private void ValidarLimiteSemanal(Usuario usuario, DateTime inicio)
    {
        var limite = usuario.ObtenerLimiteReservasSemanales();
        if (limite == int.MaxValue)
            return;

        var inicioSemana = InicioDeSemana(inicio.Date);
        var finSemana = inicioSemana.AddDays(7);

        var reservasEnSemana = _repoReservas.ObtenerTodos()
            .Count(r => r.UsuarioId == usuario.Id
                        && r.Estado != EstadoReserva.Cancelada
                        && r.Inicio >= inicioSemana
                        && r.Inicio < finSemana);

        if (reservasEnSemana >= limite)
            throw new InvalidOperationException(
                $"Alcanzó el límite de {limite} reservas semanales para el rol {usuario.ObtenerRol()}.");
    }

    // Lunes de la semana que contiene a la fecha dada.
    private static DateTime InicioDeSemana(DateTime fecha)
    {
        int diff = (7 + (int)fecha.DayOfWeek - (int)DayOfWeek.Monday) % 7;
        return fecha.AddDays(-diff);
    }
}
