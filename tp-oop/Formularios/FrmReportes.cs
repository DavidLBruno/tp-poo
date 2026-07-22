using tp_oop.Modelos;
using tp_oop.Repositorios;

namespace tp_oop.Formularios;

public partial class FrmReportes : Form
{
    private sealed class ReporteUsoLaboratorio
    {
        public int IdLaboratorio { get; init; }
        public string Laboratorio { get; init; } = string.Empty;
        public string Ubicacion { get; init; } = string.Empty;
        public int TotalReservas { get; init; }
        public int ReservasConfirmadas { get; init; }
        public double HorasReservadas { get; init; }
    }

    private sealed class ReporteReservaDia
    {
        public int IdReserva { get; init; }
        public string Laboratorio { get; init; } = string.Empty;
        public string Usuario { get; init; } = string.Empty;
        public string RolUsuario { get; init; } = string.Empty;
        public DateTime Inicio { get; init; }
        public DateTime Fin { get; init; }
        public string Estado { get; init; } = string.Empty;
        public string Motivo { get; init; } = string.Empty;
    }

    private sealed class ReporteRankingLab
    {
        public int Ranking { get; init; }
        public string Laboratorio { get; init; } = string.Empty;
        public int Capacidad { get; init; }
        public int TotalSolicitudes { get; init; }
        public double HorasTotales { get; init; }
    }

    public FrmReportes()
    {
        InitializeComponent();

        cboTipoReporte.Items.AddRange(new object[]
        {
            "Uso por Laboratorio (GroupBy)",
            "Reservas del Día",
            "Ranking de Laboratorios Más Solicitados"
        });

        cboTipoReporte.SelectedIndex = 0;
        cboTipoReporte.SelectedIndexChanged += (_, _) => HabilitarFiltros();
        btnGenerar.Click += (_, _) => GenerarReporte();
        dtpFecha.Value = DateTime.Today;

        HabilitarFiltros();
        GenerarReporte();
    }

    private void HabilitarFiltros()
    {
        // El filtro de fecha solo aplica para "Reservas del Día"
        dtpFecha.Enabled = cboTipoReporte.SelectedIndex == 1;
    }

    private void GenerarReporte()
    {
        try
        {
            using var repoReservas = RepositorioFactory.CrearRepositorioReservas();
            using var repoLabs = RepositorioFactory.CrearRepositorioLaboratorios();
            using var repoUsuarios = RepositorioFactory.CrearRepositorioUsuarios();

            var reservas = repoReservas.ObtenerTodos().ToList();
            var laboratorios = repoLabs.ObtenerTodos().ToList();
            var usuarios = repoUsuarios.ObtenerTodos().ToList();

            switch (cboTipoReporte.SelectedIndex)
            {
                case 0:
                    GenerarReporteUsoPorLaboratorio(reservas, laboratorios);
                    break;
                case 1:
                    GenerarReporteReservasDelDia(reservas, laboratorios, usuarios);
                    break;
                case 2:
                    GenerarReporteRankingLaboratorios(reservas, laboratorios);
                    break;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al generar reporte: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Consulta LINQ con GroupBy para agrupar reservas por laboratorio
    public void GenerarReporteUsoPorLaboratorio(List<Reserva> reservas, List<Laboratorio> laboratorios)
    {
        var reporte = laboratorios
            .GroupJoin(
                reservas.Where(r => r.Estado != EstadoReserva.Cancelada),
                lab => lab.Id,
                res => res.LaboratorioId,
                (lab, resGrupo) => new ReporteUsoLaboratorio
                {
                    IdLaboratorio = lab.Id,
                    Laboratorio = lab.Nombre,
                    Ubicacion = lab.Ubicacion,
                    TotalReservas = resGrupo.Count(),
                    ReservasConfirmadas = resGrupo.Count(r => r.Estado == EstadoReserva.Confirmada),
                    HorasReservadas = Math.Round(resGrupo.Sum(r => r.DuracionReserva.TotalHours), 2)
                })
            .OrderBy(r => r.Laboratorio)
            .ToList();

        dgvReporte.DataSource = reporte;

        int totalReservas = reporte.Sum(r => r.TotalReservas);
        double totalHoras = Math.Round(reporte.Sum(r => r.HorasReservadas), 2);
        lblResumen.Text = $"Total de laboratorios: {reporte.Count}  |  Reservas activas totales: {totalReservas}  |  Horas totales reservadas: {totalHoras} hs";
    }

    // Consulta LINQ para filtrar reservas por fecha del día seleccionado
    private void GenerarReporteReservasDelDia(List<Reserva> reservas, List<Laboratorio> laboratorios, List<Usuario> usuarios)
    {
        DateTime fechaSel = dtpFecha.Value.Date;

        var reporte = reservas
            .Where(r => r.Inicio.Date == fechaSel)
            .OrderBy(r => r.Inicio)
            .Select(r =>
            {
                var lab = laboratorios.FirstOrDefault(l => l.Id == r.LaboratorioId);
                var usr = usuarios.FirstOrDefault(u => u.Id == r.UsuarioId);

                return new ReporteReservaDia
                {
                    IdReserva = r.Id,
                    Laboratorio = lab?.Nombre ?? $"#{r.LaboratorioId}",
                    Usuario = usr?.Nombre ?? $"#{r.UsuarioId}",
                    RolUsuario = usr?.ObtenerRol() ?? "Desconocido",
                    Inicio = r.Inicio,
                    Fin = r.Fin,
                    Estado = r.Estado.ToString(),
                    Motivo = r.Motivo
                };
            })
            .ToList();

        dgvReporte.DataSource = reporte;

        int confirmadas = reporte.Count(r => r.Estado == nameof(EstadoReserva.Confirmada));
        int pendientes = reporte.Count(r => r.Estado == nameof(EstadoReserva.Pendiente));
        lblResumen.Text = $"Reservas el {fechaSel:dd/MM/yyyy}: {reporte.Count} en total ({confirmadas} confirmadas, {pendientes} pendientes)";
    }

    // Consulta LINQ con GroupBy y OrderByDescending para ranking de laboratorios
    private void GenerarReporteRankingLaboratorios(List<Reserva> reservas, List<Laboratorio> laboratorios)
    {
        var agrupado = reservas
            .Where(r => r.Estado != EstadoReserva.Cancelada)
            .GroupBy(r => r.LaboratorioId)
            .Select(g => new
            {
                LaboratorioId = g.Key,
                Cantidad = g.Count(),
                Horas = g.Sum(r => r.DuracionReserva.TotalHours)
            })
            .OrderByDescending(x => x.Cantidad)
            .ThenByDescending(x => x.Horas)
            .ToList();

        int posicion = 1;
        var rankingList = new List<ReporteRankingLab>();

        foreach (var item in agrupado)
        {
            var lab = laboratorios.FirstOrDefault(l => l.Id == item.LaboratorioId);
            if (lab != null)
            {
                rankingList.Add(new ReporteRankingLab
                {
                    Ranking = posicion++,
                    Laboratorio = lab.Nombre,
                    Capacidad = lab.Capacidad,
                    TotalSolicitudes = item.Cantidad,
                    HorasTotales = Math.Round(item.Horas, 2)
                });
            }
        }

        // Agregar laboratorios que no han tenido reservas al final
        var labsSinReserva = laboratorios
            .Where(l => !agrupado.Any(a => a.LaboratorioId == l.Id))
            .OrderBy(l => l.Nombre);

        foreach (var lab in labsSinReserva)
        {
            rankingList.Add(new ReporteRankingLab
            {
                Ranking = posicion++,
                Laboratorio = lab.Nombre,
                Capacidad = lab.Capacidad,
                TotalSolicitudes = 0,
                HorasTotales = 0
            });
        }

        dgvReporte.DataSource = rankingList;
        lblResumen.Text = $"Ranking de {rankingList.Count} laboratorios ordenados por demanda de uso.";
    }
}
