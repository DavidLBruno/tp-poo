namespace tp_oop.Formularios
{
    partial class FrmGrillaReservas
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
            dgvReservas = new DataGridView();
            pnlAcciones = new Panel();
            lblAyuda = new Label();
            btnConfirmarReserva = new Button();
            btnCancelarReserva = new Button();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).BeginInit();
            pnlAcciones.SuspendLayout();
            SuspendLayout();
            //
            // dgvReservas
            //
            dgvReservas.AllowUserToAddRows = false;
            dgvReservas.AllowUserToDeleteRows = false;
            dgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservas.Dock = DockStyle.Fill;
            dgvReservas.Location = new Point(0, 0);
            dgvReservas.MultiSelect = false;
            dgvReservas.Name = "dgvReservas";
            dgvReservas.ReadOnly = true;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservas.Size = new Size(900, 390);
            dgvReservas.TabIndex = 0;
            //
            // pnlAcciones
            //
            pnlAcciones.Controls.Add(lblAyuda);
            pnlAcciones.Controls.Add(btnConfirmarReserva);
            pnlAcciones.Controls.Add(btnCancelarReserva);
            pnlAcciones.Controls.Add(btnCerrar);
            pnlAcciones.Dock = DockStyle.Bottom;
            pnlAcciones.Location = new Point(0, 390);
            pnlAcciones.Name = "pnlAcciones";
            pnlAcciones.Size = new Size(900, 60);
            pnlAcciones.TabIndex = 1;
            //
            // lblAyuda
            //
            lblAyuda.AutoSize = true;
            lblAyuda.Location = new Point(12, 22);
            lblAyuda.Name = "lblAyuda";
            lblAyuda.Size = new Size(360, 15);
            lblAyuda.TabIndex = 0;
            lblAyuda.Text = "Seleccione una reserva. Confirmar es una acción de administrador.";
            //
            // btnConfirmarReserva
            //
            btnConfirmarReserva.Location = new Point(400, 14);
            btnConfirmarReserva.Name = "btnConfirmarReserva";
            btnConfirmarReserva.Size = new Size(150, 33);
            btnConfirmarReserva.TabIndex = 1;
            btnConfirmarReserva.Text = "Confirmar reserva";
            btnConfirmarReserva.UseVisualStyleBackColor = true;
            btnConfirmarReserva.Click += btnConfirmarReserva_Click;
            //
            // btnCancelarReserva
            //
            btnCancelarReserva.Location = new Point(560, 14);
            btnCancelarReserva.Name = "btnCancelarReserva";
            btnCancelarReserva.Size = new Size(160, 33);
            btnCancelarReserva.TabIndex = 2;
            btnCancelarReserva.Text = "Cancelar reserva";
            btnCancelarReserva.UseVisualStyleBackColor = true;
            btnCancelarReserva.Click += btnCancelarReserva_Click;
            //
            // btnCerrar
            //
            btnCerrar.Location = new Point(740, 14);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(140, 33);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            //
            // FrmGrillaReservas
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 450);
            Controls.Add(dgvReservas);
            Controls.Add(pnlAcciones);
            Name = "FrmGrillaReservas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Reservas (Confirmar / Cancelar)";
            ((System.ComponentModel.ISupportInitialize)dgvReservas).EndInit();
            pnlAcciones.ResumeLayout(false);
            pnlAcciones.PerformLayout();
            ResumeLayout(false);
        }

        private DataGridView dgvReservas;
        private Panel pnlAcciones;
        private Label lblAyuda;
        private Button btnConfirmarReserva;
        private Button btnCancelarReserva;
        private Button btnCerrar;
    }
}
