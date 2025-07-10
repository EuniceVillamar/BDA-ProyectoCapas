namespace CapaPresentacion
{
    partial class frmSeleccionarCedula
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">Indica si los recursos administrados deben ser eliminados.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            cmbCedulasCliente = new ComboBox();
            lblCedulaCliente = new Label();
            txtNombreCliente = new TextBox();
            lblNombreCliente = new Label();
            txtTelefonoCliente = new TextBox();
            lblTelefonoCliente = new Label();
            txtEmailCliente = new TextBox();
            lblEmailCliente = new Label();
            btnAceptar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // cmbCedulasCliente
            // 
            cmbCedulasCliente.FormattingEnabled = true;
            cmbCedulasCliente.Location = new Point(148, 20);
            cmbCedulasCliente.Name = "cmbCedulasCliente";
            cmbCedulasCliente.Size = new Size(200, 23);
            cmbCedulasCliente.TabIndex = 0;
            cmbCedulasCliente.SelectedIndexChanged += cmbCedulasCliente_SelectedIndexChanged;
            // 
            // lblCedulaCliente
            // 
            lblCedulaCliente.AutoSize = true;
            lblCedulaCliente.Font = new Font("SF Pro Display", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCedulaCliente.Location = new Point(20, 23);
            lblCedulaCliente.Name = "lblCedulaCliente";
            lblCedulaCliente.Size = new Size(109, 14);
            lblCedulaCliente.TabIndex = 1;
            lblCedulaCliente.Text = "Cédula del cliente:";
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(148, 60);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.ReadOnly = true;
            txtNombreCliente.Size = new Size(200, 23);
            txtNombreCliente.TabIndex = 2;
            // 
            // lblNombreCliente
            // 
            lblNombreCliente.AutoSize = true;
            lblNombreCliente.Font = new Font("SF Pro Display", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblNombreCliente.Location = new Point(20, 63);
            lblNombreCliente.Name = "lblNombreCliente";
            lblNombreCliente.Size = new Size(108, 14);
            lblNombreCliente.TabIndex = 3;
            lblNombreCliente.Text = "Nombre completo:";
            // 
            // txtTelefonoCliente
            // 
            txtTelefonoCliente.Location = new Point(149, 100);
            txtTelefonoCliente.Name = "txtTelefonoCliente";
            txtTelefonoCliente.ReadOnly = true;
            txtTelefonoCliente.Size = new Size(200, 23);
            txtTelefonoCliente.TabIndex = 6;
            // 
            // lblTelefonoCliente
            // 
            lblTelefonoCliente.AutoSize = true;
            lblTelefonoCliente.Font = new Font("SF Pro Display", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblTelefonoCliente.Location = new Point(21, 103);
            lblTelefonoCliente.Name = "lblTelefonoCliente";
            lblTelefonoCliente.Size = new Size(58, 14);
            lblTelefonoCliente.TabIndex = 7;
            lblTelefonoCliente.Text = "Teléfono:";
            // 
            // txtEmailCliente
            // 
            txtEmailCliente.Location = new Point(149, 140);
            txtEmailCliente.Name = "txtEmailCliente";
            txtEmailCliente.ReadOnly = true;
            txtEmailCliente.Size = new Size(200, 23);
            txtEmailCliente.TabIndex = 8;
            // 
            // lblEmailCliente
            // 
            lblEmailCliente.AutoSize = true;
            lblEmailCliente.Font = new Font("SF Pro Display", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblEmailCliente.Location = new Point(21, 143);
            lblEmailCliente.Name = "lblEmailCliente";
            lblEmailCliente.Size = new Size(40, 14);
            lblEmailCliente.TabIndex = 9;
            lblEmailCliente.Text = "Email:";
            // 
            // btnAceptar
            // 
            btnAceptar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptar.Location = new Point(131, 180);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 10;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.Location = new Point(221, 180);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmSeleccionarCedula
            // 
            BackColor = Color.White;
            ClientSize = new Size(399, 261);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(lblEmailCliente);
            Controls.Add(txtEmailCliente);
            Controls.Add(lblTelefonoCliente);
            Controls.Add(txtTelefonoCliente);
            Controls.Add(lblNombreCliente);
            Controls.Add(txtNombreCliente);
            Controls.Add(lblCedulaCliente);
            Controls.Add(cmbCedulasCliente);
            Name = "frmSeleccionarCedula";
            Text = "Seleccionar Cédula del Cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCedulasCliente;
        private System.Windows.Forms.Label lblCedulaCliente;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.TextBox txtTelefonoCliente;
        private System.Windows.Forms.Label lblTelefonoCliente;
        private System.Windows.Forms.TextBox txtEmailCliente;
        private System.Windows.Forms.Label lblEmailCliente;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
