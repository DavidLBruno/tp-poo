using tp_oop.Modelos;

namespace tp_oop.Formularios;

public partial class FrmReportes : Form
{
    public FrmReportes()
    {
        InitializeComponent();
    }

    public IEnumerable<IGrouping<EstadoReserva, Reserva>> AgruparPorEstado(IEnumerable<Reserva> reservas)
    {
        return reservas.GroupBy(r => r.Estado);
    }
}
