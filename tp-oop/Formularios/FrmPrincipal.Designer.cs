namespace tp_oop.Formularios
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();

            mnuInicio = new ToolStripMenuItem();
            mnuReservas = new ToolStripMenuItem();
            mnuNuevaReserva = new ToolStripMenuItem();
            mnuConsultarReservas = new ToolStripMenuItem();
            mnuCancelarReserva = new ToolStripMenuItem();

            mnuAdministracion = new ToolStripMenuItem();
            mnuGestionLaboratorios = new ToolStripMenuItem();
            mnuGestionUsuarios = new ToolStripMenuItem();

            mnuReportes = new ToolStripMenuItem();
            mnuCerrarSesion = new ToolStripMenuItem();

            pnlEncabezado = new Panel();
            lblTitulo = new Label();
            lblUsuarioActual = new Label();
            lblRolActual = new Label();

            pnlFiltros = new Panel();
            lblLaboratorio = new Label();
            cboLaboratorio = new ComboBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            btnActualizar = new Button();

            dgvReservas = new DataGridView();

            barraEstado = new StatusStrip();
            lblEstado = new ToolStripStatusLabel();
            lblCantidadReservas = new ToolStripStatusLabel();

            menuStrip1.SuspendLayout();
            pnlEncabezado.SuspendLayout();
            pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).BeginInit();
            barraEstado.SuspendLayout();
            SuspendLayout();

            // menuStrip1
            menuStrip1.Items.AddRange(new ToolStripItem[]
            {
                mnuInicio,
                mnuReservas,
                mnuAdministracion,
                mnuReportes,
                mnuCerrarSesion
            });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1100, 24);
            menuStrip1.TabIndex = 0;

            // mnuInicio
            mnuInicio.Name = "mnuInicio";
            mnuInicio.Text = "Inicio";

            // mnuReservas
            mnuReservas.DropDownItems.AddRange(new ToolStripItem[]
            {
                mnuNuevaReserva,
                mnuConsultarReservas,
                mnuCancelarReserva
            });
            mnuReservas.Name = "mnuReservas";
            mnuReservas.Text = "Reservas";

            // mnuNuevaReserva
            mnuNuevaReserva.Name = "mnuNuevaReserva";
            mnuNuevaReserva.Text = "Nueva reserva";

            // mnuConsultarReservas
            mnuConsultarReservas.Name = "mnuConsultarReservas";
            mnuConsultarReservas.Text = "Consultar reservas";

            // mnuCancelarReserva
            mnuCancelarReserva.Name = "mnuCancelarReserva";
            mnuCancelarReserva.Text = "Cancelar reserva";

            // mnuAdministracion
            mnuAdministracion.DropDownItems.AddRange(new ToolStripItem[]
            {
                mnuGestionLaboratorios,
                mnuGestionUsuarios
            });
            mnuAdministracion.Name = "mnuAdministracion";
            mnuAdministracion.Text = "Administración";

            // mnuGestionLaboratorios
            mnuGestionLaboratorios.Name = "mnuGestionLaboratorios";
            mnuGestionLaboratorios.Text = "Gestión de laboratorios";

            // mnuGestionUsuarios
            mnuGestionUsuarios.Name = "mnuGestionUsuarios";
            mnuGestionUsuarios.Text = "Gestión de usuarios";

            // mnuReportes
            mnuReportes.Name = "mnuReportes";
            mnuReportes.Text = "Reportes";

            // mnuCerrarSesion
            mnuCerrarSesion.Name = "mnuCerrarSesion";
            mnuCerrarSesion.Text = "Cerrar sesión";

            // pnlEncabezado
            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Controls.Add(lblUsuarioActual);
            pnlEncabezado.Controls.Add(lblRolActual);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 24);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(1100, 100);
            pnlEncabezado.TabIndex = 1;

            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(340, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Sistema de Reservas de Laboratorios";

            // lblUsuarioActual
            lblUsuarioActual.AutoSize = true;
            lblUsuarioActual.Location = new Point(22, 48);
            lblUsuarioActual.Name = "lblUsuarioActual";
            lblUsuarioActual.Size = new Size(61, 15);
            lblUsuarioActual.TabIndex = 1;
            lblUsuarioActual.Text = "Usuario: -";

            // lblRolActual
            lblRolActual.AutoSize = true;
            lblRolActual.Location = new Point(22, 72);
            lblRolActual.Name = "lblRolActual";
            lblRolActual.Size = new Size(36, 15);
            lblRolActual.TabIndex = 2;
            lblRolActual.Text = "Rol: -";

            // pnlFiltros
            pnlFiltros.Controls.Add(lblLaboratorio);
            pnlFiltros.Controls.Add(cboLaboratorio);
            pnlFiltros.Controls.Add(lblFecha);
            pnlFiltros.Controls.Add(dtpFecha);
            pnlFiltros.Controls.Add(btnActualizar);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(0, 124);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Size = new Size(1100, 70);
            pnlFiltros.TabIndex = 2;

            // lblLaboratorio
            lblLaboratorio.AutoSize = true;
            lblLaboratorio.Location = new Point(22, 12);
            lblLaboratorio.Name = "lblLaboratorio";
            lblLaboratorio.Size = new Size(71, 15);
            lblLaboratorio.TabIndex = 0;
            lblLaboratorio.Text = "Laboratorio:";

            // cboLaboratorio
            cboLaboratorio.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLaboratorio.FormattingEnabled = true;
            cboLaboratorio.Location = new Point(22, 32);
            cboLaboratorio.Name = "cboLaboratorio";
            cboLaboratorio.Size = new Size(260, 23);
            cboLaboratorio.TabIndex = 1;

            // lblFecha
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(320, 12);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha:";

            // dtpFecha
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(320, 32);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(150, 23);
            dtpFecha.TabIndex = 3;

            // btnActualizar
            btnActualizar.Location = new Point(500, 29);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(110, 30);
            btnActualizar.TabIndex = 4;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;

            // dgvReservas
            dgvReservas.AllowUserToAddRows = false;
            dgvReservas.AllowUserToDeleteRows = false;
            dgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservas.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservas.Dock = DockStyle.Fill;
            dgvReservas.Location = new Point(0, 194);
            dgvReservas.MultiSelect = false;
            dgvReservas.Name = "dgvReservas";
            dgvReservas.ReadOnly = true;
            dgvReservas.RowHeadersVisible = false;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservas.Size = new Size(1100, 434);
            dgvReservas.TabIndex = 3;

            // barraEstado
            barraEstado.Items.AddRange(new ToolStripItem[]
            {
                lblEstado,
                lblCantidadReservas
            });
            barraEstado.Location = new Point(0, 628);
            barraEstado.Name = "barraEstado";
            barraEstado.Size = new Size(1100, 22);
            barraEstado.TabIndex = 4;

            // lblEstado
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(73, 17);
            lblEstado.Text = "Sistema listo";

            // lblCantidadReservas
            lblCantidadReservas.Name = "lblCantidadReservas";
            lblCantidadReservas.Spring = true;
            lblCantidadReservas.Text = "Reservas mostradas: 0";
            lblCantidadReservas.TextAlign = ContentAlignment.MiddleRight;

            // FrmPrincipal
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 650);
            Controls.Add(dgvReservas);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlEncabezado);
            Controls.Add(barraEstado);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(900, 550);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Reservas - Principal";
            WindowState = FormWindowState.Maximized;

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).EndInit();
            barraEstado.ResumeLayout(false);
            barraEstado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private MenuStrip menuStrip1;

        private ToolStripMenuItem mnuInicio;
        private ToolStripMenuItem mnuReservas;
        private ToolStripMenuItem mnuNuevaReserva;
        private ToolStripMenuItem mnuConsultarReservas;
        private ToolStripMenuItem mnuCancelarReserva;

        private ToolStripMenuItem mnuAdministracion;
        private ToolStripMenuItem mnuGestionLaboratorios;
        private ToolStripMenuItem mnuGestionUsuarios;

        private ToolStripMenuItem mnuReportes;
        private ToolStripMenuItem mnuCerrarSesion;

        private Panel pnlEncabezado;
        private Label lblTitulo;
        private Label lblUsuarioActual;
        private Label lblRolActual;

        private Panel pnlFiltros;
        private Label lblLaboratorio;
        private ComboBox cboLaboratorio;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Button btnActualizar;

        private DataGridView dgvReservas;

        private StatusStrip barraEstado;
        private ToolStripStatusLabel lblEstado;
        private ToolStripStatusLabel lblCantidadReservas;
    }
}