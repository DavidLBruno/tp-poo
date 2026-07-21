using tp_oop.Modelos;
using tp_oop.Repositorios;

namespace tp_oop.Formularios;

public partial class FrmGestionUsuarios : Form
{
    private sealed class FilaUsuario
    {
        public int Id { get; init; }
        public string Nombre { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Rol { get; init; } = string.Empty;
    }

    private int _idSeleccionado;

    public FrmGestionUsuarios()
    {
        InitializeComponent();
        cboRol.Items.AddRange(new object[] { "Administrador", "Docente", "Alumno" });
        cboRol.SelectedIndex = 2;
        Load += (_, _) => CargarUsuarios();
    }

    private void CargarUsuarios()
    {
        using var repo = RepositorioFactory.CrearRepositorioUsuarios();
        dgvUsuarios.DataSource = repo.ObtenerTodos()
            .OrderBy(u => u.Id)
            .Select(u => new FilaUsuario
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Email = u.Email,
                Rol = u.ObtenerRol()
            })
            .ToList();
    }

    private void dgvUsuarios_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvUsuarios.CurrentRow?.DataBoundItem is not FilaUsuario fila)
            return;

        _idSeleccionado = fila.Id;
        txtNombre.Text = fila.Nombre;
        txtEmail.Text = fila.Email;
        cboRol.SelectedItem = fila.Rol;
    }

    private void btnAgregar_Click(object? sender, EventArgs e)
    {
        try
        {
            using var repo = RepositorioFactory.CrearRepositorioUsuarios();
            var usuario = CrearUsuario(repo.ProximoId());
            repo.Agregar(usuario);
            CargarUsuarios();
            LimpiarCampos();
        }
        catch (Exception ex)
        {
            MostrarError(ex);
        }
    }

    private void btnModificar_Click(object? sender, EventArgs e)
    {
        if (_idSeleccionado == 0)
        {
            MessageBox.Show("Seleccione un usuario de la lista.", "Modificar",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            using var repo = RepositorioFactory.CrearRepositorioUsuarios();
            var usuario = CrearUsuario(_idSeleccionado);
            repo.Actualizar(usuario);
            CargarUsuarios();
            LimpiarCampos();
        }
        catch (Exception ex)
        {
            MostrarError(ex);
        }
    }

    private void btnEliminar_Click(object? sender, EventArgs e)
    {
        if (_idSeleccionado == 0)
        {
            MessageBox.Show("Seleccione un usuario de la lista.", "Eliminar",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirmar = MessageBox.Show(
            $"¿Eliminar al usuario '{txtNombre.Text}'?",
            "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (confirmar != DialogResult.Yes)
            return;

        try
        {
            using var repo = RepositorioFactory.CrearRepositorioUsuarios();
            repo.Eliminar(_idSeleccionado);
            CargarUsuarios();
            LimpiarCampos();
        }
        catch (Exception ex)
        {
            MostrarError(ex);
        }
    }

    private void btnLimpiar_Click(object? sender, EventArgs e) => LimpiarCampos();

    // Crea la subclase de Usuario según el rol elegido (polimorfismo).
    private Usuario CrearUsuario(int id)
    {
        var nombre = txtNombre.Text.Trim();
        var email = txtEmail.Text.Trim();

        if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Nombre y email son obligatorios.");

        return (cboRol.SelectedItem?.ToString()) switch
        {
            "Administrador" => new Administrador(id, nombre, email),
            "Docente" => new Docente(id, nombre, email),
            "Alumno" => new Alumno(id, nombre, email),
            _ => throw new ArgumentException("Seleccione un rol válido.")
        };
    }

    private void LimpiarCampos()
    {
        _idSeleccionado = 0;
        txtNombre.Clear();
        txtEmail.Clear();
        cboRol.SelectedIndex = 2;
        dgvUsuarios.ClearSelection();
    }

    private static void MostrarError(Exception ex)
    {
        MessageBox.Show(ex.Message, "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
