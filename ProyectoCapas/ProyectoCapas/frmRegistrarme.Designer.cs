namespace CapaPresentacion
{
    partial class frmRegistrarme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarme));
            panel1 = new Panel();
            closd = new Button();
            label1 = new Label();
            label2 = new Label();
            txtuser = new TextBox();
            txtpass = new TextBox();
            guardar = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DeepSkyBlue;
            panel1.Controls.Add(closd);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = SystemColors.ControlLightLight;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(312, 37);
            panel1.TabIndex = 0;
            // 
            // closd
            // 
            closd.BackgroundImage = (Image)resources.GetObject("closd.BackgroundImage");
            closd.FlatStyle = FlatStyle.Flat;
            closd.ForeColor = Color.Black;
            closd.Location = new Point(280, 3);
            closd.Name = "closd";
            closd.Size = new Size(29, 31);
            closd.TabIndex = 0;
            closd.UseVisualStyleBackColor = true;
            closd.Click += closd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SF Pro Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(55, 73);
            label1.Name = "label1";
            label1.Size = new Size(56, 16);
            label1.TabIndex = 1;
            label1.Text = "Usuario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("SF Pro Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(55, 121);
            label2.Name = "label2";
            label2.Size = new Size(79, 16);
            label2.TabIndex = 2;
            label2.Text = "Contraseña:";
            // 
            // txtuser
            // 
            txtuser.Font = new Font("Yu Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtuser.Location = new Point(139, 65);
            txtuser.Name = "txtuser";
            txtuser.Size = new Size(135, 28);
            txtuser.TabIndex = 3;
            txtuser.TextChanged += txtuser_TextChanged;
            // 
            // txtpass
            // 
            txtpass.Font = new Font("Yu Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtpass.Location = new Point(139, 113);
            txtpass.Name = "txtpass";
            txtpass.Size = new Size(135, 28);
            txtpass.TabIndex = 4;
            txtpass.TextChanged += txtpass_TextChanged;
            // 
            // guardar
            // 
            guardar.BackColor = Color.DeepSkyBlue;
            guardar.Font = new Font("SF Pro Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            guardar.ForeColor = Color.White;
            guardar.Location = new Point(115, 177);
            guardar.Name = "guardar";
            guardar.Size = new Size(97, 27);
            guardar.TabIndex = 5;
            guardar.Text = "Guardar";
            guardar.UseVisualStyleBackColor = false;
            guardar.Click += guardar_Click;
            // 
            // frmRegistrarme
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(312, 224);
            Controls.Add(guardar);
            Controls.Add(txtpass);
            Controls.Add(txtuser);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmRegistrarme";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmRegistrarme";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button closd;
        private Label label1;
        private Label label2;
        private TextBox txtuser;
        private TextBox txtpass;
        private Button guardar;
    }
}