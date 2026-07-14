namespace tp_oop.Formularios;

public partial class FrmGestionUsuarios : Form
{
    public FrmGestionUsuarios()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(720, 400);
        Name = nameof(FrmGestionUsuarios);
        Text = "Gestión de Usuarios";
        ResumeLayout(false);
    }
}
