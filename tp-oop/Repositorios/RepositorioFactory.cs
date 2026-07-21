using System.Globalization;
using tp_oop.Modelos;

namespace tp_oop.Repositorios;

// Construye los repositorios reutilizando el único genérico RepositorioArchivo<T>,
// cada uno con su lógica de serializar / deserializar. Centraliza las rutas.
public static class RepositorioFactory
{
    private static readonly string CarpetaDatos =
        Path.Combine(AppContext.BaseDirectory, "ArchivosDatos");

    private const char Separador = '|';
    private const string FormatoFecha = "yyyy-MM-ddTHH:mm:ss";

    public static RepositorioArchivo<Laboratorio> CrearRepositorioLaboratorios()
    {
        return new RepositorioArchivo<Laboratorio>(
            Path.Combine(CarpetaDatos, "laboratorios.txt"),
            DeserializarLaboratorio,
            SerializarLaboratorio,
            lab => lab.Id);
    }

    public static RepositorioArchivo<Usuario> CrearRepositorioUsuarios()
    {
        return new RepositorioArchivo<Usuario>(
            Path.Combine(CarpetaDatos, "usuarios.txt"),
            DeserializarUsuario,
            SerializarUsuario,
            usr => usr.Id);
    }

    public static RepositorioArchivo<Reserva> CrearRepositorioReservas()
    {
        return new RepositorioArchivo<Reserva>(
            Path.Combine(CarpetaDatos, "reservas.txt"),
            DeserializarReserva,
            SerializarReserva,
            res => res.Id);
    }

    // ---- Laboratorio ----
    private static string SerializarLaboratorio(Laboratorio lab) =>
        string.Join(Separador, lab.Id, lab.Nombre, lab.Ubicacion, lab.Capacidad, lab.Equipamiento, lab.Disponible);

    private static Laboratorio DeserializarLaboratorio(string linea)
    {
        var campos = linea.Split(Separador);
        return new Laboratorio(
            int.Parse(campos[0], CultureInfo.InvariantCulture),
            campos[1],
            campos[2],
            int.Parse(campos[3], CultureInfo.InvariantCulture),
            campos[4],
            bool.Parse(campos[5]));
    }

    // ---- Usuario (deserialización polimórfica según el rol) ----
    private static string SerializarUsuario(Usuario usr) =>
        string.Join(Separador, usr.Id, usr.Nombre, usr.Email, usr.ObtenerRol());

    private static Usuario DeserializarUsuario(string linea)
    {
        var campos = linea.Split(Separador);
        var id = int.Parse(campos[0], CultureInfo.InvariantCulture);
        var nombre = campos[1];
        var email = campos[2];
        var rol = campos[3];

        return rol switch
        {
            "Administrador" => new Administrador(id, nombre, email),
            "Docente" => new Docente(id, nombre, email),
            "Alumno" => new Alumno(id, nombre, email),
            _ => throw new FormatException($"Rol desconocido: '{rol}'.")
        };
    }

    // ---- Reserva ----
    private static string SerializarReserva(Reserva res) =>
        string.Join(
            Separador,
            res.Id,
            res.LaboratorioId,
            res.UsuarioId,
            res.Inicio.ToString(FormatoFecha, CultureInfo.InvariantCulture),
            res.Fin.ToString(FormatoFecha, CultureInfo.InvariantCulture),
            res.Estado,
            res.Motivo);

    private static Reserva DeserializarReserva(string linea)
    {
        var campos = linea.Split(Separador);
        return new Reserva(
            int.Parse(campos[0], CultureInfo.InvariantCulture),
            int.Parse(campos[1], CultureInfo.InvariantCulture),
            int.Parse(campos[2], CultureInfo.InvariantCulture),
            DateTime.ParseExact(campos[3], FormatoFecha, CultureInfo.InvariantCulture),
            DateTime.ParseExact(campos[4], FormatoFecha, CultureInfo.InvariantCulture),
            Enum.Parse<EstadoReserva>(campos[5]),
            campos.Length > 6 ? campos[6] : string.Empty);
    }
}
