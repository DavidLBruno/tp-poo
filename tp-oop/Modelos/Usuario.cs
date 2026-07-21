namespace tp_oop.Modelos;

public abstract class Usuario
{
    protected Usuario(int id, string nombre, string email)
    {
        Id = id;
        Nombre = nombre;
        Email = email;
    }

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }

    public virtual string ObtenerRol() => "Usuario";

    public virtual bool PuedeGestionarLaboratorios() => false;

    // Límite de reservas por semana. Cada rol lo define (polimorfismo, sin if/switch).
    public abstract int ObtenerLimiteReservasSemanales();

    // Con cuántos días de anticipación puede reservar el rol.
    public virtual int ObtenerDiasAnticipacionMaxima() => 7;

    // Por defecto, un usuario solo puede cancelar sus propias reservas.
    public virtual bool PuedeCancelar(Reserva reserva) => reserva.UsuarioId == Id;

    // Por defecto, un usuario no puede confirmar reservas (es una acción de gestión).
    public virtual bool PuedeConfirmarReservas() => false;
}
