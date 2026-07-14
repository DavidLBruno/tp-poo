using tp_oop.Modelos;

namespace tp_oop.Formularios;

public partial class FrmReportes : Form
{
    public FrmReportes()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(820, 460);
        Name = nameof(FrmReportes);
        Text = "Reportes";
        ResumeLayout(false);
    }

    public IEnumerable<IGrouping<EstadoReserva, Reserva>> AgruparPorEstado(IEnumerable<Reserva> reservas)
    {
        return reservas.GroupBy(r => r.Estado);
    }
}
