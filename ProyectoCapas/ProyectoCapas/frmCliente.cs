using CapaNegocio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace CapaPresentacion
{
    public partial class frmCliente : Form
    {
        private CL_Cliente obj_cliente;

        public frmCliente()
        {

            InitializeComponent();

        }
        public void CambiarTema(bool isDarkMode)
        {
            // Cambiar el color de fondo
            this.BackColor = isDarkMode ? Color.Black : Color.White;

            // Cambiar el color de los Labels
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.ForeColor = isDarkMode ? Color.White : Color.Black;
                    lbl.Font = new Font(lbl.Font, FontStyle.Bold); // Para hacer el texto en negrita
                }
            }
        }
        private void frmCliente_Load(object sender, EventArgs e)
        {
            obj_cliente = new CL_Cliente(0, "", "", "", "");
            CargarCedulasClientes();
            CargarListadoClientes();
            ConfigurarComboBoxOpciones();
            CargarComboBoxEstadoEquipos();
            refrescarTabla();
            MostrarMensajeEncabezado("CLIENTE");

            /*Evitar que se escriba en el combobox 
            cmbCedulasCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOpciones.DropDownStyle = ComboBoxStyle.DropDownList;*/

        }


        private void refrescarTabla()
        {
            dgvClientes.SelectionChanged += dgvClientes_SelectionChanged;
            CargarCedulasClientes();
            ActualizarTabla();

        }
        private void ConfigurarComboBoxOpciones()
        {
            cmbOpciones.Items.Add("POR DEFECTO");
            cmbOpciones.Items.Add("Datos Personales");
            cmbOpciones.Items.Add("Todos los Registros");
            cmbOpciones.Items.Add("Equipos móviles propios");
            cmbOpciones.SelectedIndex = 0; // Selecciona la primera opción por defecto
            cmbOpciones.SelectedIndexChanged += cmbOpciones_SelectedIndexChanged;
        }
        private void CargarComboBoxEstadoEquipos()
        {
            cmbEstadoEquipos.SelectedIndex = -1; // Sin selección inicial
            cmbEstadoEquipos.SelectedIndexChanged += cmbEstadoEquipos_SelectedIndexChanged;
        }
        private void cmbEstadoEquipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        private void ActualizarTabla()
        {
            if (cmbOpciones.SelectedItem.ToString() == "Datos Personales")
            {
                MostrarMensajeEncabezado("CONSULTA DE DATOS PERSONALES");

                MostrarDatosPersonales();
                dgvClientes.ReadOnly = false;
                dgvClientes.Enabled = true;
            }
            else if (cmbOpciones.SelectedItem.ToString() == "Todos los Registros")
            {
                MostrarMensajeEncabezado("CONSULTA DE REGISTROS");
                MostrarTodosLosRegistros();
                dgvClientes.ReadOnly = false;
                dgvClientes.Enabled = true;
            }
            else if (cmbOpciones.SelectedItem.ToString() == "Equipos móviles propios")
            {
                MostrarMensajeEncabezado("CONSULTA DE EQUIPOS MOVILES");
                MostrarEquiposMovilesPropios();
                dgvClientes.Enabled = false;
            }
            else if (cmbOpciones.SelectedItem.ToString() == "POR DEFECTO")
            {
                setearControles2();
                CargarListadoClientes();
                dgvClientes.ReadOnly = false;
                dgvClientes.Enabled = true;
            }
        }
        private void MostrarEstadoEquipos()
        {
            string estadoSeleccionado = cmbEstadoEquipos.SelectedItem?.ToString();
            string cedulaSeleccionada = cmbCedulasCliente.SelectedValue?.ToString();

            try
            {
                if (!string.IsNullOrEmpty(cedulaSeleccionada) && !string.IsNullOrEmpty(estadoSeleccionado))
                {
                    dgvClientes.DataSource = obj_cliente.ObtenerEquiposPorEstadoCliente(cedulaSeleccionada, estadoSeleccionado);
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un estado válido y una cédula de cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el estado de los equipos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void MostrarDatosPersonales()
        {
            string cedula = cmbCedulasCliente.SelectedValue?.ToString();

            try
            {
                if (!string.IsNullOrEmpty(cedula))
                {
                    dgvClientes.DataSource = obj_cliente.ObtenerDatosPersonales(cedula);
                }
                else
                {
                    MessageBox.Show("Sección de cliente cargando", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error al obtener los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarTodosLosRegistros()
        {
            dgvClientes.DataSource = obj_cliente.ObtenerClientes();
        }

        private void MostrarEquiposMovilesPropios()
        {
            string cedula = cmbCedulasCliente.SelectedValue?.ToString();
            string estadoSeleccionado = cmbEstadoEquipos.SelectedItem?.ToString();

            try
            {
                if (!string.IsNullOrEmpty(cedula))
                {
                    if (estadoSeleccionado == "POR DEFECTO" || string.IsNullOrEmpty(estadoSeleccionado))
                    {
                        dgvClientes.DataSource = obj_cliente.ObtenerEquiposPorCliente(cedula);
                        dgvClientes.ReadOnly = true;
                        dgvClientes.Enabled = false;
                    }
                    else
                    {
                        dgvClientes.DataSource = obj_cliente.ObtenerEquiposPorEstadoCliente(cedula, estadoSeleccionado);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una cédula válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener equipos móviles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarListadoClientes()
        {
            dgvClientes.DataSource = obj_cliente.ObtenerClientes();
            setearControles();
            btnNuevo.Enabled = true;
            btnGrabar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            setearControles();
            btnNuevo.Enabled = false;
            btnGrabar.Enabled = true;
            btnEliminar.Enabled = false;
            MostrarMensajeEncabezado("REGISTRO DE CLIENTES"); // Encabezado para btnNuevo

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            string nuevoNombre = txtNombreCliente.Text.Trim();
            string nuevoTelefono = txtTelefonoCliente.Text.Trim();
            string nuevoEmail = txtEmailCliente.Text.Trim();
            string nuevaCedula = txtCedulaCliente.Text.Trim();
            string opcioncedula = cmbCedulasCliente.SelectedValue?.ToString(); // Obtener la cédula del ComboBox

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

            if (int.TryParse(txtIdCliente.Text, out int idCliente) && idCliente > 0)
            {

                obj_cliente = new CL_Cliente(idCliente, nuevaCedula, nuevoNombre, nuevoTelefono, nuevoEmail);

                bool result = obj_cliente.UpdatePersona(nuevaCedula, nuevoNombre, nuevoTelefono, nuevoEmail);

                if (result)
                {
                    MessageBox.Show("Cliente actualizado con éxito.");

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
                obj_cliente = new CL_Cliente(0, nuevoNombre, nuevoTelefono, nuevoEmail, nuevaCedula);
                bool result = obj_cliente.RegistrarPersona(nuevaCedula, nuevoNombre, nuevoTelefono, nuevoEmail);

                if (result)
                {
                    MessageBox.Show("Cliente registrado con éxito.");
                    CargarCedulasClientes();
                    CargarListadoClientes();
                    refrescarTabla();

                }
                else
                {
                    MessageBox.Show("Error al registrar el cliente.");
                }
            }
            MostrarMensajeEncabezado("ACTUALIZACIÓN DE DATOS DE CLIENTE");

            CargarCedulasClientes();
            CargarListadoClientes();
            setearControles();

            btnNuevo.Enabled = true;
            btnGrabar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string cedulaCliente = txtCedulaCliente.Text.Trim();
            string opcioncedulaCliente = cmbCedulasCliente.SelectedValue?.ToString(); // Obtener la cédula del ComboBox

            DialogResult confirm = MessageBox.Show("¿Está seguro de eliminar este cliente?", "Confirmación", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                bool result = obj_cliente.DeletePersona(cedulaCliente);

                if (result)
                {
                    MessageBox.Show("Cliente eliminado con éxito.");
                    CargarListadoClientes();
                    refrescarTabla();
                    MostrarMensajeEncabezado("ELIMINACIÓN DE DATOS DE CLIENTE");

                }
                else
                {
                    MessageBox.Show("Error al eliminar el cliente.");
                }
            }

            btnEliminar.Enabled = false;
            btnGrabar.Enabled = false;
            btnNuevo.Enabled = true;
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvClientes.SelectedRows[0];
                txtIdCliente.Text = row.Cells["id_cliente"].Value?.ToString();
                txtCedulaCliente.Text = row.Cells["cedula_cliente"].Value?.ToString();
                txtNombreCliente.Text = row.Cells["nombre_cliente"].Value?.ToString();
                txtTelefonoCliente.Text = row.Cells["telefono_cliente"].Value?.ToString();
                txtEmailCliente.Text = row.Cells["email_cliente"].Value?.ToString();
                cmbCedulasCliente.Text = row.Cells["cedula_cliente"].Value?.ToString();
                btnNuevo.Enabled = true;
                btnGrabar.Enabled = true;
                btnEliminar.Enabled = true;
                MostrarMensajeEncabezado("ACTUALIZACIÓN DE DATOS DE CLIENTE"); // Encabezado al seleccionar una fila

            }

        }

        private void setearControles()
        {
            txtIdCliente.Text = string.Empty;
            txtCedulaCliente.Text = string.Empty;
            txtNombreCliente.Text = string.Empty;
            txtTelefonoCliente.Text = string.Empty;
            txtEmailCliente.Text = string.Empty;

        }
        private void setearControles2()
        {
            cmbCedulasCliente.Text = string.Empty;
            cmbOpciones.Text = string.Empty;
            cmbEstadoEquipos.Text = string.Empty;
        }
        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private bool ValidarCedula(string cedula)
        {
            if (cedula.Length != 10 || !cedula.All(char.IsDigit))
            {
                MessageBox.Show("La cédula debe contener exactamente 10 números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (obj_cliente.ValidarCedulaExistente(cedula))
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
        private void CargarCedulasClientes()
        {
            var dtCedulas = obj_cliente.ObtenerCedulas();
            cmbCedulasCliente.DataSource = dtCedulas;
            cmbCedulasCliente.DisplayMember = "cedula_cliente";
            cmbCedulasCliente.ValueMember = "cedula_cliente";
            cmbCedulasCliente.SelectedIndex = -1;
        }
        private void cmbCedulasCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCedulasCliente.SelectedIndex != -1)
            {
                string cedulaSeleccionada = cmbCedulasCliente.SelectedValue.ToString();
                var datosCliente = obj_cliente.ObtenerClientePorCedula(cedulaSeleccionada);

                if (datosCliente != null)
                {
                    txtIdCliente.Text = datosCliente["id_cliente"].ToString();
                    txtCedulaCliente.Text = datosCliente["cedula_cliente"].ToString();
                    txtNombreCliente.Text = datosCliente["nombre_cliente"].ToString();
                    txtTelefonoCliente.Text = datosCliente["telefono_cliente"].ToString();
                    txtEmailCliente.Text = datosCliente["email_cliente"].ToString();
                    setearControles2();

                    Load += frmCliente_Load;
                    btnNuevo.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEliminar.Enabled = true;

                }
            }
        }

        private void cmbOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTabla();
            if (cmbOpciones.SelectedItem.ToString() == "Equipos móviles propios")
            {
                MostrarMensajeEncabezado("CONSULTA DE EQUIPOS MOVILES");
                MostrarEquiposMovilesPropios();
                dgvClientes.ReadOnly = true;
                dgvClientes.Enabled = false;

            }
            else if (cmbOpciones.SelectedItem.ToString() == "Estado de Equipos")
            {
                MostrarMensajeEncabezado("CONSULTA DE MOVILES POR ESTADO");
                MostrarEstadoEquipos();
            }
            dgvClientes.ReadOnly = false;
        }
        //FACTURA
        private void btnMostrarFactura_Click(object sender, EventArgs e)
        {
            using (var dialog = new frmSeleccionarCedula())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string cedulaSeleccionada = dialog.CedulaSeleccionada;

                    if (!string.IsNullOrEmpty(cedulaSeleccionada))
                    {
                        try
                        {
                            // Intentar obtener la factura
                            MostrarFactura(cedulaSeleccionada);
                            MostrarMensajeEncabezado("CONSULTA DE FACTURAS");
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Message.Contains("No hay facturas asociadas a esta cédula"))
                            {
                                MessageBox.Show("No se encontraron facturas para la cédula seleccionada.", "Sin facturas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Ocurrió un error al buscar las facturas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró información para la cédula seleccionada.", "Cliente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void MostrarFactura(string cedulaCliente)
        {
            frmFactura facturaForm = new frmFactura(cedulaCliente);
            facturaForm.Show();
        }

        private void btnNuevoMovil_Click(object sender, EventArgs e)
        {
            frmMovil ventanaMovil = new frmMovil();

            ventanaMovil.ShowDialog();
        }
        private void MostrarMensajeEncabezado(string mensaje)
        {
            lblEncabezado.Text = mensaje;
            lblEncabezado.Visible = true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvClientes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTelefonoCliente_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCedulaCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir números y teclas de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter
                return;
            }

            // Limitar a 10 caracteres (solo si no es una tecla de control)
            System.Windows.Forms.TextBox txt = sender as TextBox;
            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 10)
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        private void lblEncabezado_Click(object sender, EventArgs e)
        {

        }
    }
}