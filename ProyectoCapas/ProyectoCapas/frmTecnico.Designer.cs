
namespace CapaPresentacion
{
    partial class frmTecnico
    {
        private System.ComponentModel.IContainer components = null;

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
            dgvTecnicos = new DataGridView();
            txtIdTecnico = new TextBox();
            txtCedula = new TextBox();
            txtNombre = new TextBox();
            txtTelefono = new TextBox();
            txtEmail = new TextBox();
            btnNuevo = new Button();
            btnGrabar = new Button();
            btnEliminar = new Button();
            lblIdTecnico = new Label();
            lblCedula = new Label();
            lblNombre = new Label();
            lblTelefono = new Label();
            lblEmail = new Label();
            cmbCedulasTecnico = new ComboBox();
            cmbOpciones = new ComboBox();
            lblOpCedulaTecnico = new Label();
            lblOpfiltroTabla = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            lblEncabezado = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTecnicos).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvTecnicos
            // 
            dgvTecnicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTecnicos.Location = new Point(184, 290);
            dgvTecnicos.Name = "dgvTecnicos";
            dgvTecnicos.RowTemplate.Height = 25;
            dgvTecnicos.Size = new Size(677, 233);
            dgvTecnicos.TabIndex = 0;
            // 
            // txtIdTecnico
            // 
            txtIdTecnico.Enabled = false;
            txtIdTecnico.Location = new Point(122, 43);
            txtIdTecnico.Name = "txtIdTecnico";
            txtIdTecnico.ReadOnly = true;
            txtIdTecnico.Size = new Size(126, 21);
            txtIdTecnico.TabIndex = 6;
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(122, 80);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(200, 21);
            txtCedula.TabIndex = 7;
            txtCedula.TextChanged += txtCedula_TextChanged;
            txtCedula.KeyPress += txtCedula_KeyPress;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(131, 113);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 21);
            txtNombre.TabIndex = 8;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(442, 75);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(200, 21);
            txtTelefono.TabIndex = 9;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(442, 110);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 21);
            txtEmail.TabIndex = 10;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(258, 156);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 11;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGrabar
            // 
            btnGrabar.Location = new Point(343, 156);
            btnGrabar.Name = "btnGrabar";
            btnGrabar.Size = new Size(75, 23);
            btnGrabar.TabIndex = 12;
            btnGrabar.Text = "Grabar";
            btnGrabar.UseVisualStyleBackColor = true;
            btnGrabar.Click += btnGrabar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(424, 156);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblIdTecnico
            // 
            lblIdTecnico.AutoSize = true;
            lblIdTecnico.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblIdTecnico.Location = new Point(16, 43);
            lblIdTecnico.Name = "lblIdTecnico";
            lblIdTecnico.Size = new Size(68, 15);
            lblIdTecnico.TabIndex = 1;
            lblIdTecnico.Text = "ID Técnico:";
            // 
            // lblCedula
            // 
            lblCedula.AutoSize = true;
            lblCedula.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblCedula.Location = new Point(16, 83);
            lblCedula.Name = "lblCedula";
            lblCedula.Size = new Size(49, 15);
            lblCedula.TabIndex = 2;
            lblCedula.Text = "Cédula:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombre.Location = new Point(16, 116);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(109, 15);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre completo:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblTelefono.Location = new Point(378, 80);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(58, 15);
            lblTelefono.TabIndex = 4;
            lblTelefono.Text = "Teléfono:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblEmail.Location = new Point(378, 116);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(47, 15);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Correo:";
            // 
            // cmbCedulasTecnico
            // 
            cmbCedulasTecnico.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCedulasTecnico.FormattingEnabled = true;
            cmbCedulasTecnico.Location = new Point(16, 43);
            cmbCedulasTecnico.Name = "cmbCedulasTecnico";
            cmbCedulasTecnico.Size = new Size(118, 23);
            cmbCedulasTecnico.TabIndex = 14;
            cmbCedulasTecnico.SelectedIndexChanged += cmbCedulasTecnico_SelectedIndexChanged;
            // 
            // cmbOpciones
            // 
            cmbOpciones.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOpciones.FormattingEnabled = true;
            cmbOpciones.Location = new Point(16, 100);
            cmbOpciones.Name = "cmbOpciones";
            cmbOpciones.Size = new Size(121, 23);
            cmbOpciones.TabIndex = 15;
            cmbOpciones.SelectedIndexChanged += cmbOpciones_SelectedIndexChanged_1;
            // 
            // lblOpCedulaTecnico
            // 
            lblOpCedulaTecnico.AutoSize = true;
            lblOpCedulaTecnico.Location = new Point(23, 19);
            lblOpCedulaTecnico.Name = "lblOpCedulaTecnico";
            lblOpCedulaTecnico.Size = new Size(106, 15);
            lblOpCedulaTecnico.TabIndex = 16;
            lblOpCedulaTecnico.Text = "Cedula Tecnico";
            // 
            // lblOpfiltroTabla
            // 
            lblOpfiltroTabla.AutoSize = true;
            lblOpfiltroTabla.Location = new Point(23, 82);
            lblOpfiltroTabla.Name = "lblOpfiltroTabla";
            lblOpfiltroTabla.Size = new Size(96, 15);
            lblOpfiltroTabla.TabIndex = 17;
            lblOpfiltroTabla.Text = "Filtro de tabla";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblOpfiltroTabla);
            groupBox1.Controls.Add(lblOpCedulaTecnico);
            groupBox1.Controls.Add(cmbOpciones);
            groupBox1.Controls.Add(cmbCedulasTecnico);
            groupBox1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(25, 290);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(153, 163);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtro de busqueda";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblEmail);
            groupBox2.Controls.Add(lblTelefono);
            groupBox2.Controls.Add(lblNombre);
            groupBox2.Controls.Add(lblCedula);
            groupBox2.Controls.Add(lblIdTecnico);
            groupBox2.Controls.Add(btnEliminar);
            groupBox2.Controls.Add(btnGrabar);
            groupBox2.Controls.Add(btnNuevo);
            groupBox2.Controls.Add(txtEmail);
            groupBox2.Controls.Add(txtTelefono);
            groupBox2.Controls.Add(txtNombre);
            groupBox2.Controls.Add(txtCedula);
            groupBox2.Controls.Add(txtIdTecnico);
            groupBox2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(25, 65);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(836, 194);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos personales";
            // 
            // lblEncabezado
            // 
            lblEncabezado.Dock = DockStyle.Top;
            lblEncabezado.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblEncabezado.Location = new Point(0, 0);
            lblEncabezado.Name = "lblEncabezado";
            lblEncabezado.Size = new Size(889, 50);
            lblEncabezado.TabIndex = 0;
            lblEncabezado.TextAlign = ContentAlignment.MiddleCenter;
            lblEncabezado.Visible = false;
            // 
            // frmTecnico
            // 
            BackColor = Color.White;
            ClientSize = new Size(889, 537);
            Controls.Add(lblEncabezado);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dgvTecnicos);
            Name = "frmTecnico";
            Text = "Gestión de técnicos";
            Load += frmTecnico_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTecnicos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        private DataGridView dgvTecnicos;
        private TextBox txtIdTecnico;
        private TextBox txtCedula;
        private TextBox txtNombre;
        private TextBox txtTelefono;
        private TextBox txtEmail;
        private Button btnNuevo;
        private Button btnGrabar;
        private Button btnEliminar;
        private Label lblIdTecnico;
        private Label lblCedula;
        private Label lblNombre;
        private Label lblTelefono;
        private Label lblEmail;
        private ComboBox cmbCedulasTecnico;
        private ComboBox cmbOpciones;
        private Label lblOpCedulaTecnico;
        private Label lblOpfiltroTabla;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label lblEncabezado;
    }

}

