namespace tp_oop.Formularios;

public partial class FrmGestionLaboratorios : Form
{
    public FrmGestionLaboratorios()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(720, 400);
        Name = nameof(FrmGestionLaboratorios);
        Text = "Gestión de Laboratorios";
        ResumeLayout(false);
    }
}
