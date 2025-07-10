
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
            cmbCedulasTecnico = new ComboBox();
            cmbOpciones = new ComboBox();
            lblOpCedulaTecnico = new Label();
            lblOpfiltroTabla = new Label();
            groupBox1 = new GroupBox();
            lblEncabezado = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTecnicos).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvTecnicos
            // 
            dgvTecnicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTecnicos.Location = new Point(184, 63);
            dgvTecnicos.Name = "dgvTecnicos";
            dgvTecnicos.RowTemplate.Height = 25;
            dgvTecnicos.Size = new Size(677, 266);
            dgvTecnicos.TabIndex = 0;
            // 
            // cmbCedulasTecnico
            //
            //

            cmbCedulasTecnico.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCedulasTecnico.FormattingEnabled = true;
            cmbCedulasTecnico.Location = new Point(16, 43);
            cmbCedulasTecnico.Name = "cmbCedulasTecnico";
            cmbCedulasTecnico.Size = new Size(118, 23);
            cmbCedulasTecnico.TabIndex = 14;
            //cmbCedulasTecnico.SelectedIndexChanged += cmbCedulasTecnico_SelectedIndexChanged;
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
            groupBox1.Location = new Point(12, 63);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(153, 163);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtro de busqueda";
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
            ClientSize = new Size(889, 412);
            Controls.Add(lblEncabezado);
            Controls.Add(groupBox1);
            Controls.Add(dgvTecnicos);
            Name = "frmTecnico";
            Text = "Gestión de técnicos";
            Load += frmTecnico_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTecnicos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        private DataGridView dgvTecnicos;
        private ComboBox cmbCedulasTecnico;
        private ComboBox cmbOpciones;
        private Label lblOpCedulaTecnico;
        private Label lblOpfiltroTabla;
        private GroupBox groupBox1;
        private Label lblEncabezado;
    }

}

