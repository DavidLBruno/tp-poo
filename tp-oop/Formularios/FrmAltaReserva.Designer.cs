namespace tp_oop.Formularios
{
    partial class FrmAltaReserva
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
            lblLaboratorio = new Label();
            cboLaboratorio = new ComboBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblHoraInicio = new Label();
            dtpHoraInicio = new DateTimePicker();
            lblHoraFin = new Label();
            dtpHoraFin = new DateTimePicker();
            lblMotivo = new Label();
            txtMotivo = new TextBox();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            //
            // lblLaboratorio
            //
            lblLaboratorio.AutoSize = true;
            lblLaboratorio.Location = new Point(30, 30);
            lblLaboratorio.Name = "lblLaboratorio";
            lblLaboratorio.Size = new Size(71, 15);
            lblLaboratorio.TabIndex = 0;
            lblLaboratorio.Text = "Laboratorio:";
            //
            // cboLaboratorio
            //
            cboLaboratorio.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLaboratorio.Location = new Point(160, 27);
            cboLaboratorio.Name = "cboLaboratorio";
            cboLaboratorio.Size = new Size(320, 23);
            cboLaboratorio.TabIndex = 1;
            //
            // lblFecha
            //
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(30, 70);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha:";
            //
            // dtpFecha
            //
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(160, 66);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(150, 23);
            dtpFecha.TabIndex = 3;
            //
            // lblHoraInicio
            //
            lblHoraInicio.AutoSize = true;
            lblHoraInicio.Location = new Point(30, 110);
            lblHoraInicio.Name = "lblHoraInicio";
            lblHoraInicio.Size = new Size(67, 15);
            lblHoraInicio.TabIndex = 4;
            lblHoraInicio.Text = "Hora inicio:";
            //
            // dtpHoraInicio
            //
            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.Location = new Point(160, 106);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraInicio.Size = new Size(150, 23);
            dtpHoraInicio.TabIndex = 5;
            //
            // lblHoraFin
            //
            lblHoraFin.AutoSize = true;
            lblHoraFin.Location = new Point(30, 150);
            lblHoraFin.Name = "lblHoraFin";
            lblHoraFin.Size = new Size(52, 15);
            lblHoraFin.TabIndex = 6;
            lblHoraFin.Text = "Hora fin:";
            //
            // dtpHoraFin
            //
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.Location = new Point(160, 146);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.ShowUpDown = true;
            dtpHoraFin.Size = new Size(150, 23);
            dtpHoraFin.TabIndex = 7;
            //
            // lblMotivo
            //
            lblMotivo.AutoSize = true;
            lblMotivo.Location = new Point(30, 190);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new Size(48, 15);
            lblMotivo.TabIndex = 8;
            lblMotivo.Text = "Motivo:";
            //
            // txtMotivo
            //
            txtMotivo.Location = new Point(160, 187);
            txtMotivo.MaxLength = 120;
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new Size(320, 23);
            txtMotivo.TabIndex = 9;
            //
            // btnConfirmar
            //
            btnConfirmar.Location = new Point(160, 250);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(150, 35);
            btnConfirmar.TabIndex = 10;
            btnConfirmar.Text = "Confirmar reserva";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            //
            // btnCancelar
            //
            btnCancelar.Location = new Point(330, 250);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(150, 35);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            //
            // FrmAltaReserva
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 320);
            Controls.Add(lblLaboratorio);
            Controls.Add(cboLaboratorio);
            Controls.Add(lblFecha);
            Controls.Add(dtpFecha);
            Controls.Add(lblHoraInicio);
            Controls.Add(dtpHoraInicio);
            Controls.Add(lblHoraFin);
            Controls.Add(dtpHoraFin);
            Controls.Add(lblMotivo);
            Controls.Add(txtMotivo);
            Controls.Add(btnConfirmar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAltaReserva";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Alta de Reserva";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblLaboratorio;
        private ComboBox cboLaboratorio;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblHoraInicio;
        private DateTimePicker dtpHoraInicio;
        private Label lblHoraFin;
        private DateTimePicker dtpHoraFin;
        private Label lblMotivo;
        private TextBox txtMotivo;
        private Button btnConfirmar;
        private Button btnCancelar;
    }
}
