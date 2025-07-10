using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CapaPresentacion
{
    partial class frmMovil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvEquipoMovil = new DataGridView();
            groupBox1 = new GroupBox();
            btnActu = new Button();
            BtnEliminar = new Button();
            BtnGrabar = new Button();
            BtnNuevo = new Button();
            groupBox2 = new GroupBox();
            cmbCedulasCliente = new ComboBox();
            lblCedulaCliente = new Label();
            cmbEstado = new ComboBox();
            lblFecha_ingreso = new Label();
            txtFechaIngreso = new TextBox();
            txtDescripcion = new TextBox();
            lblDescripcion = new Label();
            lblEstado = new Label();
            txtImei = new TextBox();
            txtId = new TextBox();
            label2 = new Label();
            label1 = new Label();
            TxtCedula = new TextBox();
            lblEncabezado = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEquipoMovil).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvEquipoMovil
            // 
            dgvEquipoMovil.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipoMovil.Location = new Point(8, 211);
            dgvEquipoMovil.Name = "dgvEquipoMovil";
            dgvEquipoMovil.RowTemplate.Height = 25;
            dgvEquipoMovil.Size = new Size(752, 150);
            dgvEquipoMovil.TabIndex = 0;
            dgvEquipoMovil.CellClick += dgvEquipoMovil_CellClick;
            dgvEquipoMovil.CellContentClick += dataGridView1_CellContentClick;
            dgvEquipoMovil.SelectionChanged += dgvEquipoMovil_SelectionChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnActu);
            groupBox1.Controls.Add(BtnEliminar);
            groupBox1.Controls.Add(BtnGrabar);
            groupBox1.Controls.Add(BtnNuevo);
            groupBox1.Location = new Point(8, 54);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(166, 142);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // btnActu
            // 
            btnActu.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnActu.Location = new Point(28, 76);
            btnActu.Name = "btnActu";
            btnActu.Size = new Size(104, 23);
            btnActu.TabIndex = 3;
            btnActu.Text = "Actualizar";
            btnActu.UseVisualStyleBackColor = true;
            btnActu.Click += btnActu_Click;
            // 
            // BtnEliminar
            // 
            BtnEliminar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BtnEliminar.Location = new Point(28, 102);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(104, 23);
            BtnEliminar.TabIndex = 2;
            BtnEliminar.Text = "Eliminar";
            BtnEliminar.UseVisualStyleBackColor = true;
            BtnEliminar.Click += button3_Click;
            // 
            // BtnGrabar
            // 
            BtnGrabar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BtnGrabar.Location = new Point(28, 51);
            BtnGrabar.Name = "BtnGrabar";
            BtnGrabar.Size = new Size(104, 23);
            BtnGrabar.TabIndex = 1;
            BtnGrabar.Text = "Grabar";
            BtnGrabar.UseVisualStyleBackColor = true;
            BtnGrabar.Click += BtnGuardar_Click;
            // 
            // BtnNuevo
            // 
            BtnNuevo.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BtnNuevo.Location = new Point(28, 22);
            BtnNuevo.Name = "BtnNuevo";
            BtnNuevo.Size = new Size(104, 23);
            BtnNuevo.TabIndex = 0;
            BtnNuevo.Text = "Nuevo";
            BtnNuevo.UseVisualStyleBackColor = true;
            BtnNuevo.Click += button1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cmbCedulasCliente);
            groupBox2.Controls.Add(lblCedulaCliente);
            groupBox2.Controls.Add(cmbEstado);
            groupBox2.Controls.Add(lblFecha_ingreso);
            groupBox2.Controls.Add(txtFechaIngreso);
            groupBox2.Controls.Add(txtDescripcion);
            groupBox2.Controls.Add(lblDescripcion);
            groupBox2.Controls.Add(lblEstado);
            groupBox2.Controls.Add(txtImei);
            groupBox2.Controls.Add(txtId);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(197, 54);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(563, 142);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // cmbCedulasCliente
            // 
            cmbCedulasCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCedulasCliente.FormattingEnabled = true;
            cmbCedulasCliente.Location = new Point(131, 68);
            cmbCedulasCliente.Name = "cmbCedulasCliente";
            cmbCedulasCliente.Size = new Size(145, 23);
            cmbCedulasCliente.TabIndex = 12;
            cmbCedulasCliente.SelectedIndexChanged += cmbCedulasCliente_SelectedIndexChanged;
            // 
            // lblCedulaCliente
            // 
            lblCedulaCliente.AutoSize = true;
            lblCedulaCliente.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblCedulaCliente.Location = new Point(6, 76);
            lblCedulaCliente.Name = "lblCedulaCliente";
            lblCedulaCliente.Size = new Size(90, 15);
            lblCedulaCliente.TabIndex = 10;
            lblCedulaCliente.Text = "Cedula Cliente:";
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "En revision", "En proceso", "Reparado" });
            cmbEstado.Location = new Point(439, 36);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(109, 23);
            cmbEstado.TabIndex = 9;
            cmbEstado.SelectedIndexChanged += cmbEstado_SelectedIndexChanged;
            // 
            // lblFecha_ingreso
            // 
            lblFecha_ingreso.AutoSize = true;
            lblFecha_ingreso.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblFecha_ingreso.Location = new Point(332, 76);
            lblFecha_ingreso.Name = "lblFecha_ingreso";
            lblFecha_ingreso.Size = new Size(88, 15);
            lblFecha_ingreso.TabIndex = 8;
            lblFecha_ingreso.Text = "Fecha Ingreso:";
            // 
            // txtFechaIngreso
            // 
            txtFechaIngreso.Enabled = false;
            txtFechaIngreso.Location = new Point(439, 73);
            txtFechaIngreso.Name = "txtFechaIngreso";
            txtFechaIngreso.Size = new Size(109, 23);
            txtFechaIngreso.TabIndex = 7;
            txtFechaIngreso.TextChanged += txtFechaIngreso_TextChanged;
            txtFechaIngreso.KeyPress += txtFechaIngreso_KeyPress;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(102, 112);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(287, 23);
            txtDescripcion.TabIndex = 6;
            txtDescripcion.TextChanged += txtDescripcion_TextChanged;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescripcion.Location = new Point(6, 120);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(75, 15);
            lblDescripcion.TabIndex = 5;
            lblDescripcion.Text = "Descripcion:";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblEstado.Location = new Point(332, 39);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(48, 15);
            lblEstado.TabIndex = 4;
            lblEstado.Text = "Estado:";
            // 
            // txtImei
            // 
            txtImei.Location = new Point(196, 33);
            txtImei.Name = "txtImei";
            txtImei.Size = new Size(124, 23);
            txtImei.TabIndex = 3;
            txtImei.TextChanged += txtImei_TextChanged;
            txtImei.KeyPress += txtImei_KeyPress;
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(60, 33);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(66, 23);
            txtId.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(157, 36);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 1;
            label2.Text = "IMEI:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(33, 36);
            label1.Name = "label1";
            label1.Size = new Size(22, 15);
            label1.TabIndex = 0;
            label1.Text = "ID:";
            // 
            // TxtCedula
            // 
            TxtCedula.Location = new Point(99, 73);
            TxtCedula.Name = "TxtCedula";
            TxtCedula.Size = new Size(69, 23);
            TxtCedula.TabIndex = 11;
            // 
            // lblEncabezado
            // 
            lblEncabezado.Dock = DockStyle.Top;
            lblEncabezado.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblEncabezado.Location = new Point(0, 0);
            lblEncabezado.Name = "lblEncabezado";
            lblEncabezado.Size = new Size(772, 50);
            lblEncabezado.TabIndex = 0;
            lblEncabezado.TextAlign = ContentAlignment.MiddleCenter;
            lblEncabezado.Visible = false;
            // 
            // frmMovil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 373);
            Controls.Add(lblEncabezado);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dgvEquipoMovil);
            Name = "frmMovil";
            Text = "Movil";
            Load += frmMovil_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEquipoMovil).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvEquipoMovil;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button BtnEliminar;
        private Button BtnGrabar;
        private Button BtnNuevo;
        private TextBox txtImei;
        private TextBox txtId;
        private Label label2;
        private Label label1;
        private Label lblEstado;
        private Label lblDescripcion;
        private ComboBox cmbEstado;
        private Label lblFecha_ingreso;
        private TextBox txtFechaIngreso;
        private TextBox txtDescripcion;
        private TextBox TxtCedula;
        private Label lblCedulaCliente;
        private ComboBox cmbCedulasCliente;
        private Button btnActu;
        private Label lblEncabezado;
    }
}
