namespace tp_oop.Formularios;

public partial class FrmLogin : Form
{
    public FrmLogin()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(420, 240);
        Name = nameof(FrmLogin);
        Text = "Login";
        ResumeLayout(false);
    }
}
