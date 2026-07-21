using tp_oop.Modelos;
using tp_oop.Repositorios;
using tp_oop.Servicios;

namespace tp_oop.Formularios;

public partial class FrmGrillaReservas : Form
{
    // Modelo de vista para mostrar nombres en lugar de Ids en la grilla.
    private sealed class FilaReserva
    {
        public int Id { get; init; }
        public string Laboratorio { get; init; } = string.Empty;
        public string Usuario { get; init; } = string.Empty;
        public DateTime Inicio { get; init; }
        public DateTime Fin { get; init; }
        public string Estado { get; init; } = string.Empty;
        public string Motivo { get; init; } = string.Empty;
    }

    public FrmGrillaReservas()
    {
        InitializeComponent();
        Load += (_, _) =>
        {
            // Confirmar es una acción de gestión: solo se habilita si el rol lo permite.
            btnConfirmarReserva.Enabled = Sesion.UsuarioActual?.PuedeConfirmarReservas() ?? false;
            CargarReservas();
        };
    }

    private void CargarReservas()
    {
        using var repoReservas = RepositorioFactory.CrearRepositorioReservas();
        using var repoLabs = RepositorioFactory.CrearRepositorioLaboratorios();
        using var repoUsuarios = RepositorioFactory.CrearRepositorioUsuarios();

        var laboratorios = repoLabs.ObtenerTodos().ToList();
        var usuarios = repoUsuarios.ObtenerTodos().ToList();

        var filas = repoReservas.ObtenerTodos()
            .OrderByDescending(r => r.Inicio)
            .Select(r => new FilaReserva
            {
                Id = r.Id,
                Laboratorio = laboratorios.FirstOrDefault(l => l.Id == r.LaboratorioId)?.Nombre ?? $"#{r.LaboratorioId}",
                Usuario = usuarios.FirstOrDefault(u => u.Id == r.UsuarioId)?.Nombre ?? $"#{r.UsuarioId}",
                Inicio = r.Inicio,
                Fin = r.Fin,
                Estado = r.Estado.ToString(),
                Motivo = r.Motivo
            })
            .ToList();

        dgvReservas.DataSource = filas;
        ColorearPorEstado();
    }

    private void ColorearPorEstado()
    {
        foreach (DataGridViewRow fila in dgvReservas.Rows)
        {
            if (fila.DataBoundItem is not FilaReserva reserva)
                continue;

            fila.DefaultCellStyle.BackColor = reserva.Estado switch
            {
                nameof(EstadoReserva.Confirmada) => Color.FromArgb(198, 239, 206),
                nameof(EstadoReserva.Pendiente) => Color.FromArgb(255, 235, 156),
                _ => Color.FromArgb(230, 230, 230) // Cancelada: gris
            };
        }
    }

    private void btnConfirmarReserva_Click(object? sender, EventArgs e)
    {
        if (Sesion.UsuarioActual is null)
        {
            MessageBox.Show("No hay un usuario en sesión.", "Confirmar reserva",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (dgvReservas.CurrentRow?.DataBoundItem is not FilaReserva fila)
        {
            MessageBox.Show("Seleccione una reserva.", "Confirmar reserva",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            using var repoReservas = RepositorioFactory.CrearRepositorioReservas();
            using var repoLabs = RepositorioFactory.CrearRepositorioLaboratorios();
            var servicio = new ServicioReservas(repoReservas, repoLabs);

            servicio.ConfirmarReserva(fila.Id, Sesion.UsuarioActual);

            MessageBox.Show("Reserva confirmada.", "Confirmar reserva",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarReservas();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "No se pudo confirmar",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancelarReserva_Click(object? sender, EventArgs e)
    {
        if (Sesion.UsuarioActual is null)
        {
            MessageBox.Show("No hay un usuario en sesión.", "Cancelar reserva",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (dgvReservas.CurrentRow?.DataBoundItem is not FilaReserva fila)
        {
            MessageBox.Show("Seleccione una reserva.", "Cancelar reserva",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirmar = MessageBox.Show(
            $"¿Cancelar la reserva #{fila.Id} del laboratorio {fila.Laboratorio}?",
            "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (confirmar != DialogResult.Yes)
            return;

        try
        {
            using var repoReservas = RepositorioFactory.CrearRepositorioReservas();
            using var repoLabs = RepositorioFactory.CrearRepositorioLaboratorios();
            var servicio = new ServicioReservas(repoReservas, repoLabs);

            servicio.CancelarReserva(fila.Id, Sesion.UsuarioActual);

            MessageBox.Show("Reserva cancelada.", "Cancelar reserva",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarReservas();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "No se pudo cancelar",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCerrar_Click(object? sender, EventArgs e)
    {
        Close();
    }
}
