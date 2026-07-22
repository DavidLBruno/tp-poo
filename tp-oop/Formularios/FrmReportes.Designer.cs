namespace tp_oop.Formularios
{
    partial class FrmReportes
    {
        private System.ComponentModel.IContainer components = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlFiltros = new Panel();
            lblTipoReporte = new Label();
            cboTipoReporte = new ComboBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            btnGenerar = new Button();
            pnlResumen = new Panel();
            lblResumen = new Label();
            dgvReporte = new DataGridView();
            pnlFiltros.SuspendLayout();
            pnlResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            SuspendLayout();
            // 
            // pnlFiltros
            // 
            pnlFiltros.Controls.Add(lblTipoReporte);
            pnlFiltros.Controls.Add(cboTipoReporte);
            pnlFiltros.Controls.Add(lblFecha);
            pnlFiltros.Controls.Add(dtpFecha);
            pnlFiltros.Controls.Add(btnGenerar);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(0, 0);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Size = new Size(884, 65);
            pnlFiltros.TabIndex = 0;
            // 
            // lblTipoReporte
            // 
            lblTipoReporte.AutoSize = true;
            lblTipoReporte.Location = new Point(16, 12);
            lblTipoReporte.Name = "lblTipoReporte";
            lblTipoReporte.Size = new Size(92, 15);
            lblTipoReporte.TabIndex = 0;
            lblTipoReporte.Text = "Tipo de Reporte:";
            // 
            // cboTipoReporte
            // 
            cboTipoReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoReporte.FormattingEnabled = true;
            cboTipoReporte.Location = new Point(16, 30);
            cboTipoReporte.Name = "cboTipoReporte";
            cboTipoReporte.Size = new Size(320, 23);
            cboTipoReporte.TabIndex = 1;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(355, 12);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(355, 30);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(130, 23);
            dtpFecha.TabIndex = 3;
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(505, 27);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(120, 28);
            btnGenerar.TabIndex = 4;
            btnGenerar.Text = "Generar Reporte";
            btnGenerar.UseVisualStyleBackColor = true;
            // 
            // pnlResumen
            // 
            pnlResumen.Controls.Add(lblResumen);
            pnlResumen.Dock = DockStyle.Bottom;
            pnlResumen.Location = new Point(0, 481);
            pnlResumen.Name = "pnlResumen";
            pnlResumen.Size = new Size(884, 40);
            pnlResumen.TabIndex = 1;
            // 
            // lblResumen
            // 
            lblResumen.AutoSize = true;
            lblResumen.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblResumen.Location = new Point(16, 12);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(130, 15);
            lblResumen.TabIndex = 0;
            lblResumen.Text = "Seleccione un reporte.";
            // 
            // dgvReporte
            // 
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.AllowUserToDeleteRows = false;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Dock = DockStyle.Fill;
            dgvReporte.Location = new Point(0, 65);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.ReadOnly = true;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporte.Size = new Size(884, 416);
            dgvReporte.TabIndex = 2;
            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 521);
            Controls.Add(dgvReporte);
            Controls.Add(pnlResumen);
            Controls.Add(pnlFiltros);
            MinimumSize = new Size(800, 450);
            Name = "FrmReportes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reportes y Estadísticas del Sistema";
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            pnlResumen.ResumeLayout(false);
            pnlResumen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlFiltros;
        private Label lblTipoReporte;
        private ComboBox cboTipoReporte;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Button btnGenerar;
        private Panel pnlResumen;
        private Label lblResumen;
        private DataGridView dgvReporte;
    }
}
