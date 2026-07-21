namespace tp_oop.Modelos;

public sealed class Reserva
{
    private DateTime _inicio;
    private DateTime _fin;

    // Constructor completo.
    public Reserva(int id, int laboratorioId, int usuarioId, DateTime inicio, DateTime fin, EstadoReserva estado, string motivo)
    {
        if (fin <= inicio)
            throw new ArgumentException("La hora de fin debe ser posterior a la hora de inicio.");

        Id = id;
        LaboratorioId = laboratorioId;
        UsuarioId = usuarioId;
        _inicio = inicio;
        _fin = fin;
        Estado = estado;
        Motivo = motivo;
    }

    // Nueva reserva con motivo (estado Pendiente, Id a asignar).
    public Reserva(int laboratorioId, int usuarioId, DateTime inicio, DateTime fin, string motivo)
        : this(0, laboratorioId, usuarioId, inicio, fin, EstadoReserva.Pendiente, motivo)
    {
    }

    // Nueva reserva sin motivo.
    public Reserva(int laboratorioId, int usuarioId, DateTime inicio, DateTime fin)
        : this(laboratorioId, usuarioId, inicio, fin, string.Empty)
    {
    }

    public int Id { get; set; }
    public int LaboratorioId { get; set; }
    public int UsuarioId { get; set; }

    public DateTime Inicio
    {
        get => _inicio;
        set
        {
            if (value >= _fin)
                throw new ArgumentException("La hora de inicio debe ser anterior a la hora de fin.");
            _inicio = value;
        }
    }

    public DateTime Fin
    {
        get => _fin;
        set
        {
            if (value <= _inicio)
                throw new ArgumentException("La hora de fin debe ser posterior a la hora de inicio.");
            _fin = value;
        }
    }

    public EstadoReserva Estado { get; set; }
    public string Motivo { get; set; }

    // Propiedades calculadas.
    public TimeSpan DuracionReserva => _fin - _inicio;
    public bool EstaVencida => _fin < DateTime.Now;

    public bool SeSolapaCon(Reserva otraReserva)
    {
        return LaboratorioId == otraReserva.LaboratorioId
               && _inicio < otraReserva._fin
               && otraReserva._inicio < _fin;
    }
}
