namespace tp_oop.Formularios
{
    partial class FrmGestionUsuarios
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
            dgvUsuarios = new DataGridView();
            pnlCampos = new Panel();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblRol = new Label();
            cboRol = new ComboBox();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            pnlCampos.SuspendLayout();
            SuspendLayout();
            //
            // dgvUsuarios
            //
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Dock = DockStyle.Top;
            dgvUsuarios.Location = new Point(0, 0);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(720, 200);
            dgvUsuarios.TabIndex = 0;
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
            //
            // pnlCampos
            //
            pnlCampos.Controls.Add(lblNombre);
            pnlCampos.Controls.Add(txtNombre);
            pnlCampos.Controls.Add(lblEmail);
            pnlCampos.Controls.Add(txtEmail);
            pnlCampos.Controls.Add(lblRol);
            pnlCampos.Controls.Add(cboRol);
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
            lblNombre.Location = new Point(20, 25);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(55, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            //
            // txtNombre
            //
            txtNombre.Location = new Point(120, 22);
            txtNombre.MaxLength = 60;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(280, 23);
            txtNombre.TabIndex = 1;
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(20, 65);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            //
            // txtEmail
            //
            txtEmail.Location = new Point(120, 62);
            txtEmail.MaxLength = 80;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(280, 23);
            txtEmail.TabIndex = 3;
            //
            // lblRol
            //
            lblRol.AutoSize = true;
            lblRol.Location = new Point(20, 105);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(28, 15);
            lblRol.TabIndex = 4;
            lblRol.Text = "Rol:";
            //
            // cboRol
            //
            cboRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRol.Location = new Point(120, 102);
            cboRol.Name = "cboRol";
            cboRol.Size = new Size(200, 23);
            cboRol.TabIndex = 5;
            //
            // btnAgregar
            //
            btnAgregar.Location = new Point(120, 150);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(120, 33);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            //
            // btnModificar
            //
            btnModificar.Location = new Point(250, 150);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(120, 33);
            btnModificar.TabIndex = 7;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            //
            // btnEliminar
            //
            btnEliminar.Location = new Point(380, 150);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(120, 33);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            //
            // btnLimpiar
            //
            btnLimpiar.Location = new Point(510, 150);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(120, 33);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            //
            // FrmGestionUsuarios
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 400);
            Controls.Add(pnlCampos);
            Controls.Add(dgvUsuarios);
            Name = "FrmGestionUsuarios";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Usuarios";
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            pnlCampos.ResumeLayout(false);
            pnlCampos.PerformLayout();
            ResumeLayout(false);
        }

        private DataGridView dgvUsuarios;
        private Panel pnlCampos;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblRol;
        private ComboBox cboRol;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLimpiar;
    }
}
