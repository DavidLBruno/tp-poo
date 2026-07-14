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

    private void InitializeComponent()
    {
        SuspendLayout();
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(520, 320);
        Name = nameof(FrmAltaReserva);
        Text = "Alta de Reserva";
        ResumeLayout(false);
    }

    public void NotificarReservaCreada(Reserva reserva)
    {
        ReservaCreada?.Invoke(this, reserva);
    }
}
