using tp_oop.Modelos;
using tp_oop.Repositorios;
using tp_oop.Servicios;

namespace tp_oop.Formularios;

public partial class FrmAltaReserva : Form
{
    // Delegado + evento para notificar a la pantalla principal (desacople lógica/UI).
    public delegate void ReservaCreadaEventHandler(object sender, Reserva reserva);
    public event ReservaCreadaEventHandler? ReservaCreada;

    public FrmAltaReserva()
    {
        InitializeComponent();
        Load += FrmAltaReserva_Load;
    }

    private void FrmAltaReserva_Load(object? sender, EventArgs e)
    {
        CargarLaboratorios();

        // Valores iniciales razonables: hoy, de 08:00 a 10:00.
        dtpFecha.Value = DateTime.Today;
        dtpHoraInicio.Value = DateTime.Today.AddHours(8);
        dtpHoraFin.Value = DateTime.Today.AddHours(10);
    }

    private void CargarLaboratorios()
    {
        using var repoLabs = RepositorioFactory.CrearRepositorioLaboratorios();
        var disponibles = repoLabs.ObtenerTodos()
            .Where(l => l.Disponible)
            .OrderBy(l => l.Nombre)
            .ToList();

        cboLaboratorio.DataSource = disponibles;
        cboLaboratorio.DisplayMember = nameof(Laboratorio.Nombre);
        cboLaboratorio.ValueMember = nameof(Laboratorio.Id);
    }

    private void btnConfirmar_Click(object? sender, EventArgs e)
    {
        if (Sesion.UsuarioActual is null)
        {
            MessageBox.Show("No hay un usuario en sesión.", "Reserva",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (cboLaboratorio.SelectedValue is not int laboratorioId)
        {
            MessageBox.Show("Seleccione un laboratorio.", "Reserva",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var inicio = dtpFecha.Value.Date + dtpHoraInicio.Value.TimeOfDay;
        var fin = dtpFecha.Value.Date + dtpHoraFin.Value.TimeOfDay;

        try
        {
            using var repoReservas = RepositorioFactory.CrearRepositorioReservas();
            using var repoLabs = RepositorioFactory.CrearRepositorioLaboratorios();
            var servicio = new ServicioReservas(repoReservas, repoLabs);

            var reserva = servicio.CrearReserva(
                laboratorioId, Sesion.UsuarioActual, inicio, fin, txtMotivo.Text.Trim());

            ReservaCreada?.Invoke(this, reserva);

            MessageBox.Show("Reserva creada correctamente.", "Reserva",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "No se pudo crear la reserva",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancelar_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
