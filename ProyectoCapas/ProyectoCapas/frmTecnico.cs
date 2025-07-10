using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CapaPresentacion
{
    public partial class frmTecnico : Form
    {
        private CL_Tecnico obj_tecnico;
        public frmTecnico()
        {
            InitializeComponent();
        }

        private void frmTecnico_Load(object sender, EventArgs e)
        {
            obj_tecnico = new CL_Tecnico(0, "", "", "", "");
            CargarCedulasTecnicos();
            CargarListadoTecnicos();
            ConfigurarComboBoxOpciones();

            //refrescarTabla();
            MostrarMensajeEncabezado("TECNICO");

        }

        /*
        private void refrescarTabla()
        {
            dgvTecnicos.SelectionChanged += dgvTecnicos_SelectionChanged;
            CargarCedulasTecnicos();
            ActualizarTabla();

        }*/
        private void ConfigurarComboBoxOpciones()
        {
            cmbOpciones.Items.Add("POR DEFECTO");
            cmbOpciones.Items.Add("Datos personales");
            cmbOpciones.Items.Add("Todos los registros");
            // cmbOpciones.Items.Add("Mostrar detalles reparaciones");
            cmbOpciones.Items.Add("Mostrar moviles asignados");
            cmbOpciones.SelectedIndex = 0; // Selecciona la primera opción por defecto
            cmbOpciones.SelectedIndexChanged += cmbOpciones_SelectedIndexChanged;
        }

        private void cmbOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTabla();
        }
        private void ActualizarTabla()
        {
            if (cmbOpciones.SelectedItem.ToString() == "Datos personales")
            {
                MostrarDatosPersonales();
                dgvTecnicos.ReadOnly = false;
                dgvTecnicos.Enabled = true;
            }
            else if (cmbOpciones.SelectedItem.ToString() == "Todos los registros")
            {
                MostrarTodosLosRegistros();
                dgvTecnicos.ReadOnly = false;
                dgvTecnicos.Enabled = true;
            }
            else if (cmbOpciones.SelectedItem.ToString() == "Mostrar moviles asignados")
            {
                mostrarMovilesAsignados();
                dgvTecnicos.Enabled = false;
            }
            else if (cmbOpciones.SelectedItem.ToString() == "POR DEFECTO")
            {
                MostrarTodosLosRegistros();

                dgvTecnicos.Enabled = true;

                setearControles2();
                CargarListadoTecnicos();
            }
        }

        private void MostrarDatosPersonales()
        {
            string cedula = cmbCedulasTecnico.SelectedValue?.ToString(); // Obtener la cédula del ComboBox

            try
            {
                if (!string.IsNullOrEmpty(cedula))
                {
                    dgvTecnicos.DataSource = obj_tecnico.ObtenerDatosPersonales(cedula);
                }
                else
                {
                    MessageBox.Show("Sección de tecnico cargando", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error al obtener los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarTodosLosRegistros()
        {
            dgvTecnicos.DataSource = obj_tecnico.ObtenerTecnicos();
        }

        private void mostrarMovilesAsignados()
        {
            string cedula = cmbCedulasTecnico.SelectedValue?.ToString(); // Obtener la cédula del ComboBox

            try
            {
                if (!string.IsNullOrEmpty(cedula))
                {
                    dgvTecnicos.DataSource = obj_tecnico.ObtenerEquiposAsignados(cedula);
                    dgvTecnicos.ReadOnly = true;
                    dgvTecnicos.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Sección de tecnico cargando", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error al obtener los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarListadoTecnicos()
        {
            dgvTecnicos.DataSource = obj_tecnico.ObtenerTecnicos();
            setearControles();
           // btnNuevo.Enabled = true;
            //btnGrabar.Enabled = false;
            //btnEliminar.Enabled = false;
        }

        /*private void btnNuevo_Click(object sender, EventArgs e)
        {
            setearControles();
            btnNuevo.Enabled = false;
            btnGrabar.Enabled = true;
            btnEliminar.Enabled = false;
            MostrarMensajeEncabezado("REGISTRO DE TECNICOS"); // Encabezado para btnNuevo

        }*/

        /*private void btnGrabar_Click(object sender, EventArgs e)
        {
            string nuevoNombre = txtNombre.Text.Trim();
            string nuevoTelefono = txtTelefono.Text.Trim();
            string nuevoEmail = txtEmail.Text.Trim();
            string nuevaCedula = txtCedula.Text.Trim();
            string opcioncedula = cmbCedulasTecnico.SelectedValue?.ToString(); // Obtener la cédula del ComboBox

            if (string.IsNullOrEmpty(nuevoNombre) || string.IsNullOrEmpty(nuevoTelefono) || string.IsNullOrEmpty(nuevoEmail))
            {
                MessageBox.Show("Por favor, ingrese todos los campos correctamente.");
                return;
            }


            if (!ValidarTelefono(nuevoTelefono))
            {
                MessageBox.Show("El número de teléfono debe contener exactamente 10 números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidarCorreo(nuevoEmail))
            {
                MessageBox.Show("El correo electrónico debe contener un '@' y terminar en '.com'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.TryParse(txtIdTecnico.Text, out int idTecnico) && idTecnico > 0)
            {

                obj_tecnico = new CL_Tecnico(idTecnico, nuevoNombre, nuevoTelefono, nuevoEmail, nuevaCedula);

                bool result = obj_tecnico.UpdatePersona(nuevaCedula, nuevoNombre, nuevoTelefono, nuevoEmail);

                if (result)
                {
                    MessageBox.Show("Técnico actualizado con éxito.");
                    MostrarMensajeEncabezado("ACTUALIZACIÓN DE DATOS DE TECNICO");
                }
                else
                {
                    MessageBox.Show("Error al actualizar el técnico.");
                }
            }
            else
            {
                if (!ValidarCedula(nuevaCedula))
                {
                    return;
                }
                obj_tecnico = new CL_Tecnico(0, nuevoNombre, nuevoTelefono, nuevoEmail, nuevaCedula);
                bool result = obj_tecnico.RegistrarPersona(nuevaCedula, nuevoNombre, nuevoTelefono, nuevoEmail);

                if (result)
                {
                    MessageBox.Show("Técnico registrado con éxito.");
                    MostrarMensajeEncabezado("REGISTRO DE DATOS DE TECNICO");

                }
                else
                {
                    MessageBox.Show("Error al registrar el técnico.");
                }
            }
            CargarCedulasTecnicos();
            CargarListadoTecnicos();
            setearControles();
            btnNuevo.Enabled = true;
            btnGrabar.Enabled = false;
            btnEliminar.Enabled = false;
        }*/

       /* private void btnEliminar_Click(object sender, EventArgs e)
        {
            string cedulaTecnico = txtCedula.Text.Trim();
            string opcioncedulaTecnico = cmbCedulasTecnico.SelectedValue?.ToString(); // Obtener la cédula del ComboBox

            DialogResult confirm = MessageBox.Show("¿Está seguro de eliminar este técnico?", "Confirmación", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                bool result = obj_tecnico.DeletePersona(cedulaTecnico);

                if (result)
                {
                    MessageBox.Show("Técnico eliminado con éxito.");
                    CargarListadoTecnicos();
                    MostrarMensajeEncabezado("ELIMINACIÓN DE DATOS DE TECNICOS");

                }
                else
                {
                    MessageBox.Show("Error al eliminar el técnico.");
                }
            }

            btnEliminar.Enabled = false;
            btnGrabar.Enabled = false;
            btnNuevo.Enabled = true;
        }*/

       /* private void dgvTecnicos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTecnicos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvTecnicos.SelectedRows[0];
                txtIdTecnico.Text = row.Cells["id_tecnico"].Value?.ToString();
                txtCedula.Text = row.Cells["cedula_tecnico"].Value?.ToString();
                txtNombre.Text = row.Cells["nombre_tecnico"].Value?.ToString();
                txtTelefono.Text = row.Cells["telefono_tecnico"].Value?.ToString();
                txtEmail.Text = row.Cells["email_tecnico"].Value?.ToString();
                cmbCedulasTecnico.Text = row.Cells["cedula_tecnico"].Value?.ToString();
                btnNuevo.Enabled = true;
                btnGrabar.Enabled = true;
                btnEliminar.Enabled = true;
                MostrarMensajeEncabezado("ACTUALIZACIÓN DE DATOS DE TECNICO"); // Encabezado al seleccionar una fila

            }
        }*/

        private void setearControles()
        {
            /*txtIdTecnico.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;*/

        }
        private void setearControles2()
        {
            cmbCedulasTecnico.Text = string.Empty;
            cmbOpciones.Text = string.Empty;
        }
        private void dgvTecnicos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private bool ValidarCedula(string cedula)
        {
            if (cedula.Length != 10 || !cedula.All(char.IsDigit))
            {
                MessageBox.Show("La cédula debe contener exactamente 10 números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (obj_tecnico.ValidarCedulaExistente(cedula))
            {
                MessageBox.Show("La cédula ya está registrada en el sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidarTelefono(string telefono)
        {
            return telefono.Length == 10 && telefono.All(char.IsDigit);
        }

        private bool ValidarCorreo(string email)
        {
            return email.Contains("@") && (email.EndsWith(".com") || email.EndsWith("ug.edu.ec"));
        }
        private void CargarCedulasTecnicos()
        {
            var dtCedulas = obj_tecnico.ObtenerCedulas();
            cmbCedulasTecnico.DataSource = dtCedulas;
            cmbCedulasTecnico.DisplayMember = "cedula_tecnico";
            cmbCedulasTecnico.ValueMember = "cedula_tecnico";
            cmbCedulasTecnico.SelectedIndex = -1; // No selecciona nada al inicio
        }
       /* private void cmbCedulasTecnico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCedulasTecnico.SelectedIndex != -1)
            {
                string cedulaSeleccionada = cmbCedulasTecnico.SelectedValue.ToString();
                var datosTecnico = obj_tecnico.ObtenerTecnicoPorCedula(cedulaSeleccionada);

                if (datosTecnico != null)
                {
                    txtIdTecnico.Text = datosTecnico["id_tecnico"].ToString();
                    txtCedula.Text = datosTecnico["cedula_tecnico"].ToString();
                    txtNombre.Text = datosTecnico["nombre_tecnico"].ToString();
                    txtTelefono.Text = datosTecnico["telefono_tecnico"].ToString();
                    txtEmail.Text = datosTecnico["email_tecnico"].ToString();
                    setearControles2();

                    Load += frmTecnico_Load;
                    btnNuevo.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEliminar.Enabled = true;

                }
            }
        }*/
        private void MostrarMensajeEncabezado(string mensaje)
        {
            lblEncabezado.Text = mensaje;
            lblEncabezado.Visible = true;
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbOpciones_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir números y teclas de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter
                return;
            }

            // Limitar a 10 caracteres (solo si no es una tecla de control)
            TextBox txt = sender as TextBox;
            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 10)
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir números y teclas de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter
                return;
            }

            // Limitar a 10 caracteres (solo si no es una tecla de control)
            TextBox txt = sender as TextBox;
            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 10)
            {
                e.Handled = true; // Bloquea el carácter
            }
        }
    }
}