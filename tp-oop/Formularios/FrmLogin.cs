namespace tp_oop.Formularios;

public partial class FrmLogin : Form
{
    public FrmLogin()
    {
        InitializeComponent();
        btnIniciarSesion.Click += btnIniciarSesion_Click;
        txtBUsuario.TextChanged += (_, _) => ActualizarEstadoBoton();
        txtBContraseña.TextChanged += (_, _) => ActualizarEstadoBoton();

        ActualizarEstadoBoton();
    }

    // Texto ingresado en el campo de usuario (lo usa Program.cs para identificar el rol).
    public string UsuarioIngresado => txtBUsuario.Text.Trim();

    private void ActualizarEstadoBoton()
    {
        btnIniciarSesion.Enabled =
            !string.IsNullOrWhiteSpace(txtBUsuario.Text) &&
            !string.IsNullOrWhiteSpace(txtBContraseña.Text);
    }

    private void btnIniciarSesion_Click(object? sender, EventArgs e)
    {
        if (!btnIniciarSesion.Enabled)
            return;

        DialogResult = DialogResult.OK;
        Close();
    }
}
