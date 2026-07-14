namespace tp_oop.Modelos;

public sealed class Reserva
{
    public Reserva(int id, int laboratorioId, int usuarioId, DateTime inicio, DateTime fin, EstadoReserva estado)
    {
        Id = id;
        LaboratorioId = laboratorioId;
        UsuarioId = usuarioId;
        Inicio = inicio;
        Fin = fin;
        Estado = estado;
    }

    public Reserva(int laboratorioId, int usuarioId, DateTime inicio, DateTime fin)
        : this(0, laboratorioId, usuarioId, inicio, fin, EstadoReserva.Pendiente)
    {
    }

    public int Id { get; set; }
    public int LaboratorioId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fin { get; set; }
    public EstadoReserva Estado { get; set; }

    public bool SeSolapaCon(Reserva otraReserva)
    {
        return LaboratorioId == otraReserva.LaboratorioId
               && Inicio < otraReserva.Fin
               && otraReserva.Inicio < Fin;
    }
}
