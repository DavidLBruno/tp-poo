namespace tp_oop.Formularios
{
    partial class FrmGestionLaboratorios
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
            dgvLaboratorios = new DataGridView();
            pnlCampos = new Panel();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblUbicacion = new Label();
            txtUbicacion = new TextBox();
            lblCapacidad = new Label();
            numCapacidad = new NumericUpDown();
            lblEquipamiento = new Label();
            txtEquipamiento = new TextBox();
            chkDisponible = new CheckBox();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLaboratorios).BeginInit();
            pnlCampos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCapacidad).BeginInit();
            SuspendLayout();
            //
            // dgvLaboratorios
            //
            dgvLaboratorios.AllowUserToAddRows = false;
            dgvLaboratorios.AllowUserToDeleteRows = false;
            dgvLaboratorios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLaboratorios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLaboratorios.Dock = DockStyle.Top;
            dgvLaboratorios.Location = new Point(0, 0);
            dgvLaboratorios.MultiSelect = false;
            dgvLaboratorios.Name = "dgvLaboratorios";
            dgvLaboratorios.ReadOnly = true;
            dgvLaboratorios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLaboratorios.Size = new Size(720, 200);
            dgvLaboratorios.TabIndex = 0;
            dgvLaboratorios.SelectionChanged += dgvLaboratorios_SelectionChanged;
            //
            // pnlCampos
            //
            pnlCampos.Controls.Add(lblNombre);
            pnlCampos.Controls.Add(txtNombre);
            pnlCampos.Controls.Add(lblUbicacion);
            pnlCampos.Controls.Add(txtUbicacion);
            pnlCampos.Controls.Add(lblCapacidad);
            pnlCampos.Controls.Add(numCapacidad);
            pnlCampos.Controls.Add(lblEquipamiento);
            pnlCampos.Controls.Add(txtEquipamiento);
            pnlCampos.Controls.Add(chkDisponible);
            pnlCampos.Controls.Add(btnAgregar);
            pnlCampos.Controls.Add(btnModificar);
            pnlCampos.Controls.Add(btnEliminar);
            pnlCampos.Controls.Add(btnLimpiar);
            pnlCampos.Dock = DockStyle.Fill;
            pnlCampos.Location = new Point(0, 200);
            pnlCampos.Name = "pnlCampos";
            pnlCampos.Size = new Size(720, 200);
            pnlCampos.TabIndex = 1;
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(20, 20);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(55, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            //
            // txtNombre
            //
            txtNombre.Location = new Point(120, 17);
            txtNombre.MaxLength = 60;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(240, 23);
            txtNombre.TabIndex = 1;
            //
            // lblUbicacion
            //
            lblUbicacion.AutoSize = true;
            lblUbicacion.Location = new Point(20, 55);
            lblUbicacion.Name = "lblUbicacion";
            lblUbicacion.Size = new Size(64, 15);
            lblUbicacion.TabIndex = 2;
            lblUbicacion.Text = "Ubicación:";
            //
            // txtUbicacion
            //
            txtUbicacion.Location = new Point(120, 52);
            txtUbicacion.MaxLength = 80;
            txtUbicacion.Name = "txtUbicacion";
            txtUbicacion.Size = new Size(240, 23);
            txtUbicacion.TabIndex = 3;
            //
            // lblCapacidad
            //
            lblCapacidad.AutoSize = true;
            lblCapacidad.Location = new Point(20, 90);
            lblCapacidad.Name = "lblCapacidad";
            lblCapacidad.Size = new Size(65, 15);
            lblCapacidad.TabIndex = 4;
            lblCapacidad.Text = "Capacidad:";
            //
            // numCapacidad
            //
            numCapacidad.Location = new Point(120, 88);
            numCapacidad.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numCapacidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCapacidad.Name = "numCapacidad";
            numCapacidad.Size = new Size(100, 23);
            numCapacidad.TabIndex = 5;
            numCapacidad.Value = new decimal(new int[] { 20, 0, 0, 0 });
            //
            // lblEquipamiento
            //
            lblEquipamiento.AutoSize = true;
            lblEquipamiento.Location = new Point(400, 20);
            lblEquipamiento.Name = "lblEquipamiento";
            lblEquipamiento.Size = new Size(87, 15);
            lblEquipamiento.TabIndex = 6;
            lblEquipamiento.Text = "Equipamiento:";
            //
            // txtEquipamiento
            //
            txtEquipamiento.Location = new Point(400, 40);
            txtEquipamiento.MaxLength = 120;
            txtEquipamiento.Multiline = true;
            txtEquipamiento.Name = "txtEquipamiento";
            txtEquipamiento.Size = new Size(290, 70);
            txtEquipamiento.TabIndex = 7;
            //
            // chkDisponible
            //
            chkDisponible.AutoSize = true;
            chkDisponible.Checked = true;
            chkDisponible.Location = new Point(120, 125);
            chkDisponible.Name = "chkDisponible";
            chkDisponible.Size = new Size(88, 19);
            chkDisponible.TabIndex = 8;
            chkDisponible.Text = "Disponible";
            chkDisponible.UseVisualStyleBackColor = true;
            //
            // btnAgregar
            //
            btnAgregar.Location = new Point(120, 155);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(120, 33);
            btnAgregar.TabIndex = 9;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            //
            // btnModificar
            //
            btnModificar.Location = new Point(250, 155);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(120, 33);
            btnModificar.TabIndex = 10;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            //
            // btnEliminar
            //
            btnEliminar.Location = new Point(380, 155);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(120, 33);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            //
            // btnLimpiar
            //
            btnLimpiar.Location = new Point(510, 155);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(120, 33);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            //
            // FrmGestionLaboratorios
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 400);
            Controls.Add(pnlCampos);
            Controls.Add(dgvLaboratorios);
            Name = "FrmGestionLaboratorios";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Laboratorios";
            ((System.ComponentModel.ISupportInitialize)dgvLaboratorios).EndInit();
            pnlCampos.ResumeLayout(false);
            pnlCampos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCapacidad).EndInit();
            ResumeLayout(false);
        }

        private DataGridView dgvLaboratorios;
        private Panel pnlCampos;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblUbicacion;
        private TextBox txtUbicacion;
        private Label lblCapacidad;
        private NumericUpDown numCapacidad;
        private Label lblEquipamiento;
        private TextBox txtEquipamiento;
        private CheckBox chkDisponible;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLimpiar;
    }
}
