namespace tp_oop.Modelos;

public sealed class Alumno : Usuario
{
    public Alumno(int id, string nombre, string email)
        : base(id, nombre, email)
    {
    }

    public override string ObtenerRol() => "Alumno";

    // El alumno tiene el límite semanal más bajo.
    public override int ObtenerLimiteReservasSemanales() => 3;

    // Solo puede reservar con poca anticipación.
    public override int ObtenerDiasAnticipacionMaxima() => 7;
}
