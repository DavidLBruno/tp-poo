namespace tp_oop.Formularios
{
    partial class FrmLogin
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
            txtBContraseña = new TextBox();
            txtBUsuario = new TextBox();
            btnIniciarSesion = new Button();
            lblUsuario = new Label();
            lblContraseña = new Label();
            SuspendLayout();
            // 
            // txtBContraseña
            // 
            txtBContraseña.Location = new Point(70, 122);
            txtBContraseña.Name = "txtBContraseña";
            txtBContraseña.Size = new Size(275, 23);
            txtBContraseña.TabIndex = 1;
            txtBContraseña.UseSystemPasswordChar = true;
            // 
            // txtBUsuario
            // 
            txtBUsuario.Location = new Point(70, 78);
            txtBUsuario.Name = "txtBUsuario";
            txtBUsuario.Size = new Size(275, 23);
            txtBUsuario.TabIndex = 0;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.Location = new Point(155, 188);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(107, 40);
            btnIniciarSesion.TabIndex = 2;
            btnIniciarSesion.Text = "Iniciar Sesion";
            btnIniciarSesion.UseVisualStyleBackColor = true;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(70, 60);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(47, 15);
            lblUsuario.TabIndex = 3;
            lblUsuario.Text = "Usuario";
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Location = new Point(70, 104);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(67, 15);
            lblContraseña.TabIndex = 4;
            lblContraseña.Text = "Contraseña";
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 240);
            Controls.Add(lblContraseña);
            Controls.Add(lblUsuario);
            Controls.Add(btnIniciarSesion);
            Controls.Add(txtBUsuario);
            Controls.Add(txtBContraseña);
            Name = "FrmLogin";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtBContraseña;
        private TextBox txtBUsuario;
        private Button btnIniciarSesion;
        private Label lblUsuario;
        private Label lblContraseña;
    }
}
