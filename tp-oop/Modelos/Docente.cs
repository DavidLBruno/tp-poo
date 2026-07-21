namespace tp_oop.Modelos;

public sealed class Docente : Usuario
{
    public Docente(int id, string nombre, string email)
        : base(id, nombre, email)
    {
    }

    public override string ObtenerRol() => "Docente";

    // El docente puede reservar más veces por semana que el alumno.
    public override int ObtenerLimiteReservasSemanales() => 10;

    // Puede reservar con mayor anticipación.
    public override int ObtenerDiasAnticipacionMaxima() => 30;
}
