using tp_oop.Modelos;
using tp_oop.Repositorios;

namespace tp_oop.Formularios;

public partial class FrmGestionLaboratorios : Form
{
    private int _idSeleccionado;

    public FrmGestionLaboratorios()
    {
        InitializeComponent();
        Load += (_, _) => CargarLaboratorios();
    }

    private void CargarLaboratorios()
    {
        using var repo = RepositorioFactory.CrearRepositorioLaboratorios();
        dgvLaboratorios.DataSource = repo.ObtenerTodos()
            .OrderBy(l => l.Id)
            .ToList();
    }

    private void dgvLaboratorios_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvLaboratorios.CurrentRow?.DataBoundItem is not Laboratorio lab)
            return;

        _idSeleccionado = lab.Id;
        txtNombre.Text = lab.Nombre;
        txtUbicacion.Text = lab.Ubicacion;
        numCapacidad.Value = Math.Clamp(lab.Capacidad, (int)numCapacidad.Minimum, (int)numCapacidad.Maximum);
        txtEquipamiento.Text = lab.Equipamiento;
        chkDisponible.Checked = lab.Disponible;
    }

    private void btnAgregar_Click(object? sender, EventArgs e)
    {
        try
        {
            using var repo = RepositorioFactory.CrearRepositorioLaboratorios();
            var lab = new Laboratorio(
                repo.ProximoId(),
                txtNombre.Text.Trim(),
                txtUbicacion.Text.Trim(),
                (int)numCapacidad.Value,
                txtEquipamiento.Text.Trim(),
                chkDisponible.Checked);

            repo.Agregar(lab);
            CargarLaboratorios();
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
            MessageBox.Show("Seleccione un laboratorio de la lista.", "Modificar",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            using var repo = RepositorioFactory.CrearRepositorioLaboratorios();
            var lab = new Laboratorio(
                _idSeleccionado,
                txtNombre.Text.Trim(),
                txtUbicacion.Text.Trim(),
                (int)numCapacidad.Value,
                txtEquipamiento.Text.Trim(),
                chkDisponible.Checked);

            repo.Actualizar(lab);
            CargarLaboratorios();
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
            MessageBox.Show("Seleccione un laboratorio de la lista.", "Eliminar",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirmar = MessageBox.Show(
            $"¿Eliminar el laboratorio '{txtNombre.Text}'?",
            "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (confirmar != DialogResult.Yes)
            return;

        try
        {
            using var repo = RepositorioFactory.CrearRepositorioLaboratorios();
            repo.Eliminar(_idSeleccionado);
            CargarLaboratorios();
            LimpiarCampos();
        }
        catch (Exception ex)
        {
            MostrarError(ex);
        }
    }

    private void btnLimpiar_Click(object? sender, EventArgs e) => LimpiarCampos();

    private void LimpiarCampos()
    {
        _idSeleccionado = 0;
        txtNombre.Clear();
        txtUbicacion.Clear();
        numCapacidad.Value = numCapacidad.Minimum;
        txtEquipamiento.Clear();
        chkDisponible.Checked = true;
        dgvLaboratorios.ClearSelection();
    }

    private static void MostrarError(Exception ex)
    {
        MessageBox.Show(ex.Message, "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
