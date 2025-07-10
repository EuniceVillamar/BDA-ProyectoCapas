namespace CapaPresentacion
{
    partial class FrmSistema
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSistema));
            btnBuscar = new Button();
            searchBox = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            miniToolStrip = new MenuStrip();
            panel1 = new Panel();
            menuStrip3 = new MenuStrip();
            hOMEToolStripMenuItem = new ToolStripMenuItem();
            cLIENTESToolStripMenuItem = new ToolStripMenuItem();
            mOVILToolStripMenuItem = new ToolStripMenuItem();
            tECNICOToolStripMenuItem = new ToolStripMenuItem();
            rEPARACIONToolStripMenuItem = new ToolStripMenuItem();
            cONTACTOSToolStripMenuItem1 = new ToolStripMenuItem();
            cERRARSESIONToolStripMenuItem = new ToolStripMenuItem();
            menuStrip2 = new MenuStrip();
            panel2 = new Panel();
            label1 = new Label();
            btnAccesibilidad = new Button();
            lblNombreNegocio = new Label();
            pictureBox1 = new PictureBox();
            lblCambiarTamanhoFuente = new Label();
            txtTamanoFuente = new TextBox();
            trackBarTamanoFuente = new TrackBar();
            mdiContainerPanel = new Panel();
            panel3 = new Panel();
            progressBar1 = new ProgressBar();
            lblIdiomas = new Label();
            cbIdioma = new ComboBox();
            btnModoClaro = new Button();
            btnModoOscuro = new Button();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            flecha = new Button();
            panel1.SuspendLayout();
            menuStrip3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarTamanoFuente).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnBuscar.Location = new Point(951, 8);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(69, 24);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // searchBox
            // 
            searchBox.Location = new Point(804, 10);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(141, 21);
            searchBox.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // miniToolStrip
            // 
            miniToolStrip.AccessibleName = "Selección de nuevo elemento";
            miniToolStrip.AccessibleRole = AccessibleRole.ComboBox;
            miniToolStrip.AutoSize = false;
            miniToolStrip.Dock = DockStyle.None;
            miniToolStrip.Location = new Point(6, 2);
            miniToolStrip.Name = "miniToolStrip";
            miniToolStrip.Size = new Size(634, 24);
            miniToolStrip.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(menuStrip3);
            panel1.Location = new Point(12, 71);
            panel1.Name = "panel1";
            panel1.Size = new Size(111, 141);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // menuStrip3
            // 
            menuStrip3.BackColor = Color.LightSkyBlue;
            menuStrip3.Dock = DockStyle.Left;
            menuStrip3.Items.AddRange(new ToolStripItem[] { hOMEToolStripMenuItem, cLIENTESToolStripMenuItem, mOVILToolStripMenuItem, tECNICOToolStripMenuItem, rEPARACIONToolStripMenuItem, cONTACTOSToolStripMenuItem1, cERRARSESIONToolStripMenuItem });
            menuStrip3.Location = new Point(0, 0);
            menuStrip3.Name = "menuStrip3";
            menuStrip3.RenderMode = ToolStripRenderMode.System;
            menuStrip3.Size = new Size(136, 141);
            menuStrip3.TabIndex = 0;
            menuStrip3.Text = "menuStrip3";
            menuStrip3.ItemClicked += menuStrip3_ItemClicked;
            menuStrip3.Click += menuStrip3_Click;
            // 
            // hOMEToolStripMenuItem
            // 
            hOMEToolStripMenuItem.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            hOMEToolStripMenuItem.Name = "hOMEToolStripMenuItem";
            hOMEToolStripMenuItem.Size = new Size(123, 19);
            hOMEToolStripMenuItem.Text = "HOME";
            hOMEToolStripMenuItem.Click += hOMEToolStripMenuItem_Click;
            // 
            // cLIENTESToolStripMenuItem
            // 
            cLIENTESToolStripMenuItem.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cLIENTESToolStripMenuItem.Name = "cLIENTESToolStripMenuItem";
            cLIENTESToolStripMenuItem.Size = new Size(123, 19);
            cLIENTESToolStripMenuItem.Text = "CLIENTE";
            cLIENTESToolStripMenuItem.Click += cLIENTESToolStripMenuItem_Click;
            // 
            // mOVILToolStripMenuItem
            // 
            mOVILToolStripMenuItem.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            mOVILToolStripMenuItem.Name = "mOVILToolStripMenuItem";
            mOVILToolStripMenuItem.Size = new Size(123, 19);
            mOVILToolStripMenuItem.Text = "MOVIL";
            mOVILToolStripMenuItem.Click += mOVILToolStripMenuItem_Click;
            // 
            // tECNICOToolStripMenuItem
            // 
            tECNICOToolStripMenuItem.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            tECNICOToolStripMenuItem.Name = "tECNICOToolStripMenuItem";
            tECNICOToolStripMenuItem.Size = new Size(123, 19);
            tECNICOToolStripMenuItem.Text = "TECNICO";
            tECNICOToolStripMenuItem.Click += tECNICOToolStripMenuItem1_Click;
            // 
            // rEPARACIONToolStripMenuItem
            // 
            rEPARACIONToolStripMenuItem.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            rEPARACIONToolStripMenuItem.Name = "rEPARACIONToolStripMenuItem";
            rEPARACIONToolStripMenuItem.Size = new Size(123, 19);
            rEPARACIONToolStripMenuItem.Text = "REPARACION";
            rEPARACIONToolStripMenuItem.Click += rEPARACIONToolStripMenuItem_Click;
            // 
            // cONTACTOSToolStripMenuItem1
            // 
            cONTACTOSToolStripMenuItem1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cONTACTOSToolStripMenuItem1.Name = "cONTACTOSToolStripMenuItem1";
            cONTACTOSToolStripMenuItem1.Size = new Size(123, 19);
            cONTACTOSToolStripMenuItem1.Text = "CONTACTO";
            cONTACTOSToolStripMenuItem1.Click += cONTACTOSToolStripMenuItem1_Click;
            // 
            // cERRARSESIONToolStripMenuItem
            // 
            cERRARSESIONToolStripMenuItem.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cERRARSESIONToolStripMenuItem.Name = "cERRARSESIONToolStripMenuItem";
            cERRARSESIONToolStripMenuItem.Size = new Size(123, 19);
            cERRARSESIONToolStripMenuItem.Text = "CERRAR SESION";
            cERRARSESIONToolStripMenuItem.Click += cERRARSESIONToolStripMenuItem_Click;
            // 
            // menuStrip2
            // 
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(555, 24);
            menuStrip2.TabIndex = 0;
            menuStrip2.Text = "menuStrip2";
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightSkyBlue;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnAccesibilidad);
            panel2.Controls.Add(lblNombreNegocio);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(btnBuscar);
            panel2.Controls.Add(searchBox);
            panel2.Location = new Point(31, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1079, 40);
            panel2.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(52, 21);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 6;
            label1.Text = "POE 5-10";
            // 
            // btnAccesibilidad
            // 
            btnAccesibilidad.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAccesibilidad.Image = (Image)resources.GetObject("btnAccesibilidad.Image");
            btnAccesibilidad.Location = new Point(1026, 2);
            btnAccesibilidad.Name = "btnAccesibilidad";
            btnAccesibilidad.Size = new Size(43, 34);
            btnAccesibilidad.TabIndex = 5;
            btnAccesibilidad.UseVisualStyleBackColor = true;
            btnAccesibilidad.Click += btnAccesibilidad_Click;
            // 
            // lblNombreNegocio
            // 
            lblNombreNegocio.AutoSize = true;
            lblNombreNegocio.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblNombreNegocio.Location = new Point(52, 6);
            lblNombreNegocio.Name = "lblNombreNegocio";
            lblNombreNegocio.Size = new Size(195, 16);
            lblNombreNegocio.TabIndex = 4;
            lblNombreNegocio.Text = "JUAN SERVICIO TECNICO ";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.fondo;
            pictureBox1.Location = new Point(4, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(42, 35);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lblCambiarTamanhoFuente
            // 
            lblCambiarTamanhoFuente.AutoSize = true;
            lblCambiarTamanhoFuente.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblCambiarTamanhoFuente.Location = new Point(10, 12);
            lblCambiarTamanhoFuente.Name = "lblCambiarTamanhoFuente";
            lblCambiarTamanhoFuente.Size = new Size(166, 15);
            lblCambiarTamanhoFuente.TabIndex = 9;
            lblCambiarTamanhoFuente.Text = "Cambiar el tamaño de fuente";
            // 
            // txtTamanoFuente
            // 
            txtTamanoFuente.Location = new Point(165, 8);
            txtTamanoFuente.Name = "txtTamanoFuente";
            txtTamanoFuente.ReadOnly = true;
            txtTamanoFuente.Size = new Size(40, 21);
            txtTamanoFuente.TabIndex = 8;
            txtTamanoFuente.TextChanged += txtTamanoFuente_TextChanged;
            // 
            // trackBarTamanoFuente
            // 
            trackBarTamanoFuente.Location = new Point(224, 8);
            trackBarTamanoFuente.Minimum = 1;
            trackBarTamanoFuente.Name = "trackBarTamanoFuente";
            trackBarTamanoFuente.Size = new Size(148, 45);
            trackBarTamanoFuente.TabIndex = 7;
            trackBarTamanoFuente.Value = 1;
            trackBarTamanoFuente.Scroll += trackBarTamanoFuente_Scroll;
            // 
            // mdiContainerPanel
            // 
            mdiContainerPanel.Location = new Point(23, 101);
            mdiContainerPanel.Name = "mdiContainerPanel";
            mdiContainerPanel.Size = new Size(1281, 677);
            mdiContainerPanel.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightSkyBlue;
            panel3.Controls.Add(progressBar1);
            panel3.Controls.Add(lblIdiomas);
            panel3.Controls.Add(cbIdioma);
            panel3.Controls.Add(btnModoClaro);
            panel3.Controls.Add(btnModoOscuro);
            panel3.Controls.Add(trackBarTamanoFuente);
            panel3.Controls.Add(lblCambiarTamanhoFuente);
            panel3.Controls.Add(txtTamanoFuente);
            panel3.Location = new Point(144, 49);
            panel3.Name = "panel3";
            panel3.Size = new Size(936, 43);
            panel3.TabIndex = 10;
            panel3.Paint += panel3_Paint;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(946, 13);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(10, 13);
            progressBar1.TabIndex = 5;
            progressBar1.Visible = false;
            // 
            // lblIdiomas
            // 
            lblIdiomas.AutoSize = true;
            lblIdiomas.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblIdiomas.Location = new Point(412, 14);
            lblIdiomas.Name = "lblIdiomas";
            lblIdiomas.Size = new Size(51, 15);
            lblIdiomas.TabIndex = 13;
            lblIdiomas.Text = "Idiomas";
            // 
            // cbIdioma
            // 
            cbIdioma.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cbIdioma.FormattingEnabled = true;
            cbIdioma.Location = new Point(465, 9);
            cbIdioma.Name = "cbIdioma";
            cbIdioma.Size = new Size(105, 23);
            cbIdioma.TabIndex = 12;
            cbIdioma.SelectedIndexChanged += cbIdioma_SelectedIndexChanged;
            // 
            // btnModoClaro
            // 
            btnModoClaro.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnModoClaro.Location = new Point(770, 9);
            btnModoClaro.Name = "btnModoClaro";
            btnModoClaro.Size = new Size(137, 28);
            btnModoClaro.TabIndex = 11;
            btnModoClaro.Text = "Modo claro";
            btnModoClaro.UseVisualStyleBackColor = true;
            btnModoClaro.Click += btnModoClaro_Click;
            // 
            // btnModoOscuro
            // 
            btnModoOscuro.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnModoOscuro.Location = new Point(600, 7);
            btnModoOscuro.Name = "btnModoOscuro";
            btnModoOscuro.Size = new Size(145, 29);
            btnModoOscuro.TabIndex = 10;
            btnModoOscuro.Text = "Modo oscuro";
            btnModoOscuro.UseVisualStyleBackColor = true;
            btnModoOscuro.Click += btnModoOscuro_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.Location = new Point(208, 244);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 11;
            label2.Click += label2_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Enabled = false;
            pictureBox2.ErrorImage = null;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(334, 155);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(498, 500);
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // flecha
            // 
            flecha.Location = new Point(12, 218);
            flecha.Name = "flecha";
            flecha.Size = new Size(26, 19);
            flecha.TabIndex = 7;
            flecha.Text = "↓";
            flecha.UseVisualStyleBackColor = true;
            flecha.Click += flecha_Click;
            // 
            // FrmSistema
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1595, 853);
            Controls.Add(flecha);
            Controls.Add(pictureBox2);
            Controls.Add(label2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            MainMenuStrip = menuStrip2;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmSistema";
            Text = "Negocio de reparación de Sr. Juan de equipos celulares";
            FormClosing += FrmSistema_FormClosing;
            Load += FrmSistema_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip3.ResumeLayout(false);
            menuStrip3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarTamanoFuente).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnBuscar;
        private TextBox searchBox;
        private ContextMenuStrip contextMenuStrip1;
        private MenuStrip miniToolStrip;
        private Panel panel1;
        private MenuStrip menuStrip2;
        private MenuStrip menuStrip3;
        private ToolStripMenuItem cLIENTESToolStripMenuItem;
        private ToolStripMenuItem mOVILToolStripMenuItem;
        private ToolStripMenuItem tECNICOToolStripMenuItem;
        private ToolStripMenuItem rEPARACIONToolStripMenuItem;
        private ToolStripMenuItem cONTACTOSToolStripMenuItem1;
        private ToolStripMenuItem cERRARSESIONToolStripMenuItem;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Panel mdiContainerPanel;
        private Label lblNombreNegocio;
        private TrackBar trackBarTamanoFuente;
        private TextBox txtTamanoFuente;
        private Label lblCambiarTamanhoFuente;
        private Panel panel3;
        private Button btnModoClaro;
        private Button btnModoOscuro;
        private Label lblIdiomas;
        private ComboBox cbIdioma;
        private ProgressBar progressBar1;
        private ToolStripMenuItem hOMEToolStripMenuItem;
        private Button btnAccesibilidad;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox2;
        private Button flecha;
    }
}