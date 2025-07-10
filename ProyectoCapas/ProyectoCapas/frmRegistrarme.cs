using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmRegistrarme : Form
    {
        private CL_Login obj_login = new CL_Login();

        public frmRegistrarme()
        {
            InitializeComponent();
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            string usuario = txtuser.Text.Trim();
            string contraseña = txtpass.Text.Trim();

            // Validar campos vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar si el usuario ya existe
            if (obj_login.ExisteUsuario(usuario))
            {
                MessageBox.Show("El usuario ya existe. Intente con otro nombre de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Registrar el usuario
            bool resultado = obj_login.RegistrarUsuario(usuario, contraseña);

            if (resultado)
            {
                MessageBox.Show("Usuario registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtuser.Clear();
                txtpass.Clear();
            }
            else
            {
                MessageBox.Show("No se pudo registrar el usuario. Inténtelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closd_Click(object sender, EventArgs e)
        {
            // Ruta relativa
            string imagePath = "Resources/closed.png";
            closd.Image = Image.FromFile(imagePath);

            this.Close();
        }
    }
}
