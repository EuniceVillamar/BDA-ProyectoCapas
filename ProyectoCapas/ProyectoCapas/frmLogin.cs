using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmLogin : Form
    {
        private CL_Login obj_login = new CL_Login();

        public frmLogin()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmRegistrar_Load);
        }

        private void frmRegistrar_Load(object sender, EventArgs e)
        {
            try
            {
                //Ruta relativa para cargar la imagen 
                string imagePath = Path.Combine(Application.StartupPath, "Resources", "user.png");

                //Verificar si el archivo existe
                if (File.Exists(imagePath))
                {
                    pictureBox1.Image = Image.FromFile(imagePath); //Cargar la imagen en el PictureBox
                }
                else
                {
                    MessageBox.Show("¡La imagen no fue encontrada en la ruta! " + imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al cargar la imagen " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void pass_TextChanged(object sender, EventArgs e)
        {//nada
        }

        //Campo USER
        private void user_Enter(object sender, EventArgs e)
        {
            if (user.Text == "Ingrese su usuario")
            {
                user.Text = ""; //Borra el texto 
                user.ForeColor = Color.Black; //Asigna el color negro al txto
            }
        }

        //Campo "PASS"
        private void pass_Enter(object sender, EventArgs e)
        {
            if (pass.Text == "Ingrese su contraseña")
            {
                pass.Text = ""; //Borra el texto
                pass.UseSystemPasswordChar = true; //Oculta la contraseña
                pass.ForeColor = Color.Black;
            }
        }

        //El usuario deja el campo "pass" sin escribir nada, no vuelve a mostrar el mensaje de "Ingrese su usuario..."
        private void user_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(user.Text))
            {
                user.Text = "Ingrese su usuario";
                user.ForeColor = Color.Gray; // Vuelve a poner el texto en color gris
            }
        }

        // Cuando el usuario deja el campo "pass" sin escribir nada vuelve al nmensaje en gris
        private void pass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pass.Text))
            {
                pass.Text = "Ingrese su contraseña";
                pass.UseSystemPasswordChar = false;
                pass.ForeColor = Color.Gray;
            }
        }




        private void checkBox_mostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_mostrar.Checked)
                pass.UseSystemPasswordChar = false;
            else
                pass.UseSystemPasswordChar = true;
        }

        private void ingresar_Click(object sender, EventArgs e)
        {
            string usuario = user.Text.Trim();
            string contrasena = pass.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar credenciales
            if (obj_login.ValidarCredenciales(usuario, contrasena))
            {
                FrmSistema sistemaForm = new FrmSistema();
                sistemaForm.Show();
                this.Hide();
            }
            else if (!obj_login.ExisteUsuario(usuario))
            {
                MessageBox.Show("No consta en el sistema, regístrese.", "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void regis_Click(object sender, EventArgs e)
        {

            this.Hide();

            //Crea una instancia del formulario frmRegistrarme
            frmRegistrarme registroForm = new frmRegistrarme();

            //Muestra el formulario de registro
            registroForm.ShowDialog();

            //Después de cerrar el formulario de registro, muestra otra vez el formulario de login
            this.Show();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Construir ruta relativa
                string imagePath = Path.Combine(Application.StartupPath, "Resources", "closed.png");

                //¿el archivo existe?
                if (File.Exists(imagePath))
                {
                    cerrar.Image = Image.FromFile(imagePath);
                }
                else
                {
                    MessageBox.Show("La imagen no fue encontrada en la ruta " + imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
