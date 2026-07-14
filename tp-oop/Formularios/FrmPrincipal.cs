namespace tp_oop.Formularios;

public partial class FrmPrincipal : Form
{
    public FrmPrincipal()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Name = nameof(FrmPrincipal);
        Text = "Sistema de Reservas - Principal";
        ResumeLayout(false);
    }
}
