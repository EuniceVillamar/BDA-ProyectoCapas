namespace CapaPresentacion
{
    partial class frmFactura
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
            btnPrimeraPagina = new Button();
            btnUltimaPagina = new Button();
            dgvFacturas = new DataGridView();
            panel1 = new Panel();
            toPdf = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            SuspendLayout();
            // 
            // btnPrimeraPagina
            // 
            btnPrimeraPagina.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnPrimeraPagina.Location = new Point(12, 390);
            btnPrimeraPagina.Name = "btnPrimeraPagina";
            btnPrimeraPagina.Size = new Size(130, 33);
            btnPrimeraPagina.TabIndex = 0;
            btnPrimeraPagina.Text = "Primera pagina";
            btnPrimeraPagina.UseVisualStyleBackColor = true;
            btnPrimeraPagina.Click += btnPrimeraPagina_Click;
            // 
            // btnUltimaPagina
            // 
            btnUltimaPagina.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnUltimaPagina.Location = new Point(148, 390);
            btnUltimaPagina.Name = "btnUltimaPagina";
            btnUltimaPagina.Size = new Size(119, 33);
            btnUltimaPagina.TabIndex = 3;
            btnUltimaPagina.Text = "Ultima pagina";
            btnUltimaPagina.UseVisualStyleBackColor = true;
            btnUltimaPagina.Click += btnUltimaPagina_Click;
            // 
            // dgvFacturas
            // 
            dgvFacturas.BackgroundColor = Color.FromArgb(224, 224, 224);
            dgvFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturas.Location = new Point(12, 26);
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.RowTemplate.Height = 25;
            dgvFacturas.Size = new Size(428, 338);
            dgvFacturas.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DeepSkyBlue;
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(428, 14);
            panel1.TabIndex = 5;
            // 
            // toPdf
            // 
            toPdf.BackColor = Color.MintCream;
            toPdf.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            toPdf.Location = new Point(273, 390);
            toPdf.Name = "toPdf";
            toPdf.Size = new Size(153, 33);
            toPdf.TabIndex = 6;
            toPdf.Text = "Exportar a PDF";
            toPdf.UseVisualStyleBackColor = false;
            toPdf.Click += toPdf_Click;
            // 
            // frmFactura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(449, 433);
            Controls.Add(toPdf);
            Controls.Add(panel1);
            Controls.Add(dgvFacturas);
            Controls.Add(btnUltimaPagina);
            Controls.Add(btnPrimeraPagina);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "frmFactura";
            Text = "Historial de facturas del cliente";
            Load += frmFactura_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnPrimeraPagina;
        private Button btnUltimaPagina;
        private DataGridView dgvFacturas;
        private Panel panel1;
        private Button toPdf;
    }
}