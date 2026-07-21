namespace tp_oop.Modelos;

public sealed class Administrador : Usuario
{
    public Administrador(int id, string nombre, string email)
        : base(id, nombre, email)
    {
    }

    public override string ObtenerRol() => "Administrador";

    public override bool PuedeGestionarLaboratorios() => true;

    // Sin límite de reservas semanales.
    public override int ObtenerLimiteReservasSemanales() => int.MaxValue;

    // Sin límite de anticipación.
    public override int ObtenerDiasAnticipacionMaxima() => int.MaxValue;

    // El administrador puede cancelar cualquier reserva.
    public override bool PuedeCancelar(Reserva reserva) => true;

    // El administrador es quien confirma las reservas pendientes.
    public override bool PuedeConfirmarReservas() => true;
}
