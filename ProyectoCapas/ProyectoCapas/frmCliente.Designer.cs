using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    partial class frmCliente : Form
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
            lblID = new Label();
            txtIdCliente = new TextBox();
            lblNombre = new Label();
            txtNombreCliente = new TextBox();
            lblEmail = new Label();
            txtEmailCliente = new TextBox();
            btnGrabar = new Button();
            btnEliminar = new Button();
            dgvClientes = new DataGridView();
            btnNuevo = new Button();
            cmbCedulasCliente = new ComboBox();
            cmbOpciones = new ComboBox();
            groupBox1 = new GroupBox();
            lblConsultarEstadoMovil = new Label();
            lblOpciones = new Label();
            lblCedulaCliente2 = new Label();
            cmbEstadoEquipos = new ComboBox();
            txtTelefonoCliente = new TextBox();
            lblTelefono = new Label();
            txtCedulaCliente = new TextBox();
            lblCedulaCliente = new Label();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            btnMostrarFactura = new Button();
            btnNuevoMovil = new Button();
            lblEncabezado = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblID.Location = new Point(10, 37);
            lblID.Margin = new Padding(4, 0, 4, 0);
            lblID.Name = "lblID";
            lblID.Size = new Size(22, 15);
            lblID.TabIndex = 0;
            lblID.Text = "ID:";
            // 
            // txtIdCliente
            // 
            txtIdCliente.Enabled = false;
            txtIdCliente.Location = new Point(145, 32);
            txtIdCliente.Margin = new Padding(4, 3, 4, 3);
            txtIdCliente.Name = "txtIdCliente";
            txtIdCliente.ReadOnly = true;
            txtIdCliente.Size = new Size(132, 23);
            txtIdCliente.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombre.Location = new Point(9, 70);
            lblNombre.Margin = new Padding(4, 0, 4, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(109, 15);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre completo:";
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(145, 66);
            txtNombreCliente.Margin = new Padding(4, 3, 4, 3);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.Size = new Size(132, 23);
            txtNombreCliente.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblEmail.Location = new Point(9, 105);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(42, 15);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // txtEmailCliente
            // 
            txtEmailCliente.Location = new Point(145, 101);
            txtEmailCliente.Margin = new Padding(4, 3, 4, 3);
            txtEmailCliente.Name = "txtEmailCliente";
            txtEmailCliente.Size = new Size(132, 23);
            txtEmailCliente.TabIndex = 5;
            // 
            // btnGrabar
            // 
            btnGrabar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnGrabar.Location = new Point(101, 25);
            btnGrabar.Margin = new Padding(4, 3, 4, 3);
            btnGrabar.Name = "btnGrabar";
            btnGrabar.Size = new Size(88, 27);
            btnGrabar.TabIndex = 6;
            btnGrabar.Text = "Grabar";
            btnGrabar.UseVisualStyleBackColor = true;
            btnGrabar.Click += btnGrabar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnEliminar.Location = new Point(49, 58);
            btnEliminar.Margin = new Padding(4, 3, 4, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(88, 27);
            btnEliminar.TabIndex = 7;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(12, 390);
            dgvClientes.Margin = new Padding(4, 3, 4, 3);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(614, 160);
            dgvClientes.TabIndex = 8;
            dgvClientes.CellContentClick += dgvClientes_CellContentClick_1;
            // 
            // btnNuevo
            // 
            btnNuevo.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnNuevo.Location = new Point(6, 24);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(88, 29);
            btnNuevo.TabIndex = 9;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // cmbCedulasCliente
            // 
            cmbCedulasCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCedulasCliente.FormattingEnabled = true;
            cmbCedulasCliente.Location = new Point(6, 57);
            cmbCedulasCliente.Name = "cmbCedulasCliente";
            cmbCedulasCliente.Size = new Size(86, 23);
            cmbCedulasCliente.TabIndex = 10;
            cmbCedulasCliente.SelectedIndexChanged += cmbCedulasCliente_SelectedIndexChanged;
            // 
            // cmbOpciones
            // 
            cmbOpciones.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOpciones.FormattingEnabled = true;
            cmbOpciones.Location = new Point(133, 57);
            cmbOpciones.Name = "cmbOpciones";
            cmbOpciones.Size = new Size(151, 23);
            cmbOpciones.TabIndex = 11;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblConsultarEstadoMovil);
            groupBox1.Controls.Add(lblOpciones);
            groupBox1.Controls.Add(lblCedulaCliente2);
            groupBox1.Controls.Add(cmbOpciones);
            groupBox1.Controls.Add(cmbEstadoEquipos);
            groupBox1.Controls.Add(cmbCedulasCliente);
            groupBox1.Location = new Point(13, 292);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(612, 92);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtro de busqueda";
            // 
            // lblConsultarEstadoMovil
            // 
            lblConsultarEstadoMovil.AutoSize = true;
            lblConsultarEstadoMovil.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblConsultarEstadoMovil.Location = new Point(312, 32);
            lblConsultarEstadoMovil.Name = "lblConsultarEstadoMovil";
            lblConsultarEstadoMovil.Size = new Size(173, 15);
            lblConsultarEstadoMovil.TabIndex = 19;
            lblConsultarEstadoMovil.Text = "Consultar estado de movil";
            // 
            // lblOpciones
            // 
            lblOpciones.AutoSize = true;
            lblOpciones.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblOpciones.Location = new Point(133, 32);
            lblOpciones.Name = "lblOpciones";
            lblOpciones.Size = new Size(67, 15);
            lblOpciones.TabIndex = 18;
            lblOpciones.Text = "Opciones";
            // 
            // lblCedulaCliente2
            // 
            lblCedulaCliente2.AutoSize = true;
            lblCedulaCliente2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCedulaCliente2.Location = new Point(6, 32);
            lblCedulaCliente2.Name = "lblCedulaCliente2";
            lblCedulaCliente2.Size = new Size(52, 15);
            lblCedulaCliente2.TabIndex = 17;
            lblCedulaCliente2.Text = "Cedula";
            // 
            // cmbEstadoEquipos
            // 
            cmbEstadoEquipos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoEquipos.Items.AddRange(new object[] { "En revision", "Reparado", "En proceso", "POR DEFECTO" });
            cmbEstadoEquipos.Location = new Point(312, 57);
            cmbEstadoEquipos.Name = "cmbEstadoEquipos";
            cmbEstadoEquipos.Size = new Size(145, 23);
            cmbEstadoEquipos.TabIndex = 10;
            cmbEstadoEquipos.SelectedIndexChanged += cmbEstadoEquipos_SelectedIndexChanged;
            // 
            // txtTelefonoCliente
            // 
            txtTelefonoCliente.Location = new Point(144, 135);
            txtTelefonoCliente.Name = "txtTelefonoCliente";
            txtTelefonoCliente.Size = new Size(133, 23);
            txtTelefonoCliente.TabIndex = 13;
            txtTelefonoCliente.KeyPress += txtTelefonoCliente_KeyPress;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblTelefono.Location = new Point(10, 143);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(55, 15);
            lblTelefono.TabIndex = 14;
            lblTelefono.Text = "Telefono";
            // 
            // txtCedulaCliente
            // 
            txtCedulaCliente.Location = new Point(143, 174);
            txtCedulaCliente.Name = "txtCedulaCliente";
            txtCedulaCliente.Size = new Size(134, 23);
            txtCedulaCliente.TabIndex = 15;
            txtCedulaCliente.KeyPress += txtCedulaCliente_KeyPress;
            // 
            // lblCedulaCliente
            // 
            lblCedulaCliente.AutoSize = true;
            lblCedulaCliente.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblCedulaCliente.Location = new Point(10, 182);
            lblCedulaCliente.Name = "lblCedulaCliente";
            lblCedulaCliente.Size = new Size(46, 15);
            lblCedulaCliente.TabIndex = 16;
            lblCedulaCliente.Text = "Cédula";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblCedulaCliente);
            groupBox2.Controls.Add(txtCedulaCliente);
            groupBox2.Controls.Add(lblTelefono);
            groupBox2.Controls.Add(txtTelefonoCliente);
            groupBox2.Controls.Add(txtEmailCliente);
            groupBox2.Controls.Add(lblEmail);
            groupBox2.Controls.Add(txtNombreCliente);
            groupBox2.Controls.Add(lblNombre);
            groupBox2.Controls.Add(txtIdCliente);
            groupBox2.Controls.Add(lblID);
            groupBox2.Location = new Point(12, 69);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(294, 208);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos personales";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnMostrarFactura);
            groupBox3.Controls.Add(btnNuevoMovil);
            groupBox3.Controls.Add(btnNuevo);
            groupBox3.Controls.Add(btnEliminar);
            groupBox3.Controls.Add(btnGrabar);
            groupBox3.Location = new Point(426, 74);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(200, 170);
            groupBox3.TabIndex = 18;
            groupBox3.TabStop = false;
            // 
            // btnMostrarFactura
            // 
            btnMostrarFactura.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnMostrarFactura.Location = new Point(21, 103);
            btnMostrarFactura.Name = "btnMostrarFactura";
            btnMostrarFactura.Size = new Size(74, 43);
            btnMostrarFactura.TabIndex = 11;
            btnMostrarFactura.Text = "Mostrar factura";
            btnMostrarFactura.UseVisualStyleBackColor = true;
            btnMostrarFactura.Click += btnMostrarFactura_Click;
            // 
            // btnNuevoMovil
            // 
            btnNuevoMovil.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnNuevoMovil.Location = new Point(101, 103);
            btnNuevoMovil.Name = "btnNuevoMovil";
            btnNuevoMovil.Size = new Size(72, 43);
            btnNuevoMovil.TabIndex = 10;
            btnNuevoMovil.Text = "Registrar movil";
            btnNuevoMovil.UseVisualStyleBackColor = true;
            btnNuevoMovil.Click += btnNuevoMovil_Click;
            // 
            // lblEncabezado
            // 
            lblEncabezado.Dock = DockStyle.Top;
            lblEncabezado.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblEncabezado.Location = new Point(0, 0);
            lblEncabezado.Name = "lblEncabezado";
            lblEncabezado.Size = new Size(648, 66);
            lblEncabezado.TabIndex = 0;
            lblEncabezado.TextAlign = ContentAlignment.MiddleCenter;
            lblEncabezado.Visible = false;
            lblEncabezado.Click += lblEncabezado_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DeepSkyBlue;
            panel1.Location = new Point(-2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1283, 10);
            panel1.TabIndex = 13;
            // 
            // frmCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(648, 560);
            Controls.Add(panel1);
            Controls.Add(lblEncabezado);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dgvClientes);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmCliente";
            Text = "Gestión de Clientes";
            Load += frmCliente_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Label lblID;
        private TextBox txtIdCliente;
        private Label lblNombre;
        private TextBox txtNombreCliente;
        private Label lblEmail;
        private TextBox txtEmailCliente;
        private Button btnGrabar;
        private Button btnEliminar;
        private DataGridView dgvClientes;
        private Button btnNuevo;
        private ComboBox cmbCedulasCliente;
        private ComboBox cmbOpciones;
        private GroupBox groupBox1;
        private TextBox txtTelefonoCliente;
        private Label lblTelefono;
        private TextBox txtCedulaCliente;
        private Label lblCedulaCliente;
        private Label lblOpciones;
        private Label lblCedulaCliente2;
        private ComboBox cmbEstadoEquipos;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label lblConsultarEstadoMovil;
        private Button btnNuevoMovil;
        private Button btnMostrarFactura;
        private Label lblEncabezado;



        private Panel panel1;

    }
}
