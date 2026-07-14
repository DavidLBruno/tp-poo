using tp_oop.Modelos;

namespace tp_oop.Formularios;

public partial class FrmAltaReserva : Form
{
    public delegate void ReservaCreadaEventHandler(object sender, Reserva reserva);
    public event ReservaCreadaEventHandler? ReservaCreada;

    public FrmAltaReserva()
    {
        InitializeComponent();
    }

    public void NotificarReservaCreada(Reserva reserva)
    {
        ReservaCreada?.Invoke(this, reserva);
    }
}
