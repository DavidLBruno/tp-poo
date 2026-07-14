namespace tp_oop.Formularios;

public partial class FrmGrillaReservas : Form
{
    public FrmGrillaReservas()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(900, 450);
        Name = nameof(FrmGrillaReservas);
        Text = "Grilla de Reservas";
        ResumeLayout(false);
    }
}
