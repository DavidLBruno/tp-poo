using tp_oop.Repositorios;

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

    // Texto ingresado en el campo de usuario (lo usa Program.cs para identificar el usuario).
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

        try
        {
            using var repoUsuarios = RepositorioFactory.CrearRepositorioUsuarios();
            var usuarios = repoUsuarios.ObtenerTodos();
            var usuario = usuarios.FirstOrDefault(u =>
                string.Equals(u.Email, txtBUsuario.Text.Trim(), StringComparison.OrdinalIgnoreCase) ||
                string.Equals(u.Nombre, txtBUsuario.Text.Trim(), StringComparison.OrdinalIgnoreCase));

            if (usuario != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al validar credenciales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
