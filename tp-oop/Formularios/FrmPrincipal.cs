using tp_oop.Modelos;
using tp_oop.Repositorios;
using tp_oop.Servicios;

namespace tp_oop.Formularios;

public partial class FrmPrincipal : Form
{
    // Proyección para mostrar nombres en lugar de Ids en la grilla.
    private sealed class FilaReserva
    {
        public int Id { get; init; }
        public string Usuario { get; init; } = string.Empty;
        public DateTime Inicio { get; init; }
        public DateTime Fin { get; init; }
        public string Estado { get; init; } = string.Empty;
        public string Motivo { get; init; } = string.Empty;
    }

    public FrmPrincipal()
    {
        InitializeComponent();

        Load += FrmPrincipal_Load;

        // Reservas
        mnuNuevaReserva.Click += mnuNuevaReserva_Click;
        mnuConsultarReservas.Click += (_, _) => RefrescarGrilla();
        mnuCancelarReserva.Click += mnuCancelarReserva_Click;

        // Administración
        mnuGestionLaboratorios.Click += mnuGestionLaboratorios_Click;
        mnuGestionUsuarios.Click += mnuGestionUsuarios_Click;

        // Reportes
        mnuReportes.Click += mnuReportes_Click;
        mnuCerrarSesion.Click += (_, _) => Close();

        // Filtros
        btnActualizar.Click += (_, _) => RefrescarGrilla();
        cboLaboratorio.SelectedIndexChanged += (_, _) => RefrescarGrilla();
        dtpFecha.ValueChanged += (_, _) => RefrescarGrilla();
    }

    private void FrmPrincipal_Load(object? sender, EventArgs e)
    {
        var usuario = Sesion.UsuarioActual;
        lblUsuarioActual.Text = $"Usuario: {usuario?.Nombre ?? "-"}";
        lblRolActual.Text = $"Rol: {usuario?.ObtenerRol() ?? "-"}";

        // El menú de Administración solo se habilita si el rol lo permite (polimorfismo en UI).
        bool esAdmin = usuario?.PuedeGestionarLaboratorios() ?? false;
        mnuAdministracion.Enabled = esAdmin;

        CargarLaboratorios();
        dtpFecha.Value = DateTime.Today;
        RefrescarGrilla();
    }

    private void CargarLaboratorios()
    {
        using var repoLabs = RepositorioFactory.CrearRepositorioLaboratorios();
        var labs = repoLabs.ObtenerTodos().OrderBy(l => l.Nombre).ToList();

        cboLaboratorio.DataSource = labs;
        cboLaboratorio.DisplayMember = nameof(Laboratorio.Nombre);
        cboLaboratorio.ValueMember = nameof(Laboratorio.Id);
    }

    private void RefrescarGrilla()
    {
        if (cboLaboratorio.SelectedValue is not int laboratorioId)
            return;

        try
        {
            using var repoReservas = RepositorioFactory.CrearRepositorioReservas();
            using var repoLabs = RepositorioFactory.CrearRepositorioLaboratorios();
            using var repoUsuarios = RepositorioFactory.CrearRepositorioUsuarios();

            var usuarios = repoUsuarios.ObtenerTodos().ToList();
            var servicio = new ServicioReservas(repoReservas, repoLabs);

            var filas = servicio.ReservasPorLabYFecha(laboratorioId, dtpFecha.Value)
                .Select(r => new FilaReserva
                {
                    Id = r.Id,
                    Usuario = usuarios.FirstOrDefault(u => u.Id == r.UsuarioId)?.Nombre ?? $"#{r.UsuarioId}",
                    Inicio = r.Inicio,
                    Fin = r.Fin,
                    Estado = r.Estado.ToString(),
                    Motivo = r.Motivo
                })
                .ToList();

            dgvReservas.DataSource = filas;
            ResaltarHorariosOcupados();
            lblCantidadReservas.Text = $"Reservas mostradas: {filas.Count}";
            lblEstado.Text = "Verde = Confirmada (ocupado)   ·   Naranja = Pendiente";
        }
        catch (Exception ex)
        {
            lblEstado.Text = "Error al cargar reservas";
            MessageBox.Show(ex.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Colorea cada fila según el estado para indicar visualmente los horarios ocupados.
    private void ResaltarHorariosOcupados()
    {
        foreach (DataGridViewRow fila in dgvReservas.Rows)
        {
            if (fila.DataBoundItem is not FilaReserva reserva)
                continue;

            var (fondo, texto) = reserva.Estado switch
            {
                nameof(EstadoReserva.Confirmada) => (Color.FromArgb(198, 239, 206), Color.FromArgb(0, 97, 0)),
                nameof(EstadoReserva.Pendiente) => (Color.FromArgb(255, 235, 156), Color.FromArgb(156, 101, 0)),
                _ => (Color.White, Color.Black)
            };

            fila.DefaultCellStyle.BackColor = fondo;
            fila.DefaultCellStyle.ForeColor = texto;
        }
    }

    private void mnuNuevaReserva_Click(object? sender, EventArgs e)
    {
        using var frm = new FrmAltaReserva();
        // El evento del alta refresca la grilla sin acoplar la lógica al formulario.
        frm.ReservaCreada += (_, _) => RefrescarGrilla();
        frm.ShowDialog(this);
    }

    private void mnuCancelarReserva_Click(object? sender, EventArgs e)
    {
        using var frm = new FrmGrillaReservas();
        frm.ShowDialog(this);
        RefrescarGrilla();
    }

    private void mnuGestionLaboratorios_Click(object? sender, EventArgs e)
    {
        using var frm = new FrmGestionLaboratorios();
        frm.ShowDialog(this);
        CargarLaboratorios();
        RefrescarGrilla();
    }

    private void mnuGestionUsuarios_Click(object? sender, EventArgs e)
    {
        using var frm = new FrmGestionUsuarios();
        frm.ShowDialog(this);
    }

    private void mnuReportes_Click(object? sender, EventArgs e)
    {
        using var frm = new FrmReportes();
        frm.ShowDialog(this);
    }
}
