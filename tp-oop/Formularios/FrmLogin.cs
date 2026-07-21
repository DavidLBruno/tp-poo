namespace tp_oop.Formularios;

public partial class FrmLogin : Form
{
    public FrmLogin()
    {
        InitializeComponent();
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

        string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ArchivosDatos", "usuarios.txt");
        if (File.Exists(ruta))
        {
            var lineas = File.ReadAllLines(ruta);
            bool usuarioValido = false;
            foreach (var linea in lineas)
            {
                var partes = linea.Split('|');
                if (partes.Length >= 5 && partes[2] == txtBUsuario.Text && partes[4] == txtBContraseña.Text)
                {
                    usuarioValido = true;
                    break;
                }
            }

            if (usuarioValido)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            MessageBox.Show("No se encontró la base de datos de usuarios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
