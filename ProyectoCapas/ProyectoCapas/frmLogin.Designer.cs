namespace CapaPresentacion
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            panel1 = new Panel();
            cerrar = new Button();
            pictureBox1 = new PictureBox();
            user = new TextBox();
            label1 = new Label();
            pass = new TextBox();
            checkBox_mostrar = new CheckBox();
            ingresar = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DeepSkyBlue;
            panel1.Controls.Add(cerrar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(345, 32);
            panel1.TabIndex = 0;
            // 
            // cerrar
            // 
            cerrar.FlatAppearance.MouseDownBackColor = Color.White;
            cerrar.FlatStyle = FlatStyle.Flat;
            cerrar.Image = (Image)resources.GetObject("cerrar.Image");
            cerrar.Location = new Point(308, 3);
            cerrar.Name = "cerrar";
            cerrar.Size = new Size(34, 26);
            cerrar.TabIndex = 0;
            cerrar.UseVisualStyleBackColor = true;
            cerrar.Click += cerrar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(104, 54);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 124);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // user
            // 
            user.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            user.Location = new Point(56, 200);
            user.Name = "user";
            user.Size = new Size(222, 22);
            user.TabIndex = 2;
            user.Text = "Ingrese su usuario";
            user.TextAlign = HorizontalAlignment.Center;
            user.Enter += user_Enter;
            user.Leave += user_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 224);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 3;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pass
            // 
            pass.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            pass.Location = new Point(56, 242);
            pass.Name = "pass";
            pass.Size = new Size(222, 22);
            pass.TabIndex = 4;
            pass.Text = "Ingrese su contraseña";
            pass.TextAlign = HorizontalAlignment.Center;
            pass.Enter += pass_Enter;
            pass.Leave += pass_Leave;
            // 
            // checkBox_mostrar
            // 
            checkBox_mostrar.AutoSize = true;
            checkBox_mostrar.Font = new Font("Yu Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox_mostrar.Location = new Point(203, 276);
            checkBox_mostrar.Name = "checkBox_mostrar";
            checkBox_mostrar.Size = new Size(75, 21);
            checkBox_mostrar.TabIndex = 5;
            checkBox_mostrar.Text = "Mostrar";
            checkBox_mostrar.UseVisualStyleBackColor = true;
            checkBox_mostrar.CheckedChanged += checkBox_mostrar_CheckedChanged;
            // 
            // ingresar
            // 
            ingresar.BackColor = Color.DeepSkyBlue;
            ingresar.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            ingresar.ForeColor = Color.White;
            ingresar.Location = new Point(121, 312);
            ingresar.Name = "ingresar";
            ingresar.Size = new Size(93, 24);
            ingresar.TabIndex = 6;
            ingresar.Text = "Ingresar";
            ingresar.UseVisualStyleBackColor = false;
            ingresar.Click += ingresar_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(345, 349);
            Controls.Add(ingresar);
            Controls.Add(checkBox_mostrar);
            Controls.Add(pass);
            Controls.Add(user);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLogin";
            Load += frmLogin_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button cerrar;
        private PictureBox pictureBox1;
        private TextBox user;
        private Label label1;
        private TextBox pass;
        private CheckBox checkBox_mostrar;
        private Button ingresar;
    }
}