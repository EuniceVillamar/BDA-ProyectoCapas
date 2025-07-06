using CapaDatos.Interface;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmSeleccionarCedula : Form
    {
        public string CedulaSeleccionada { get; private set; }
        private CL_InterfaceReparacion obj_reparacion = new CL_InterfaceReparacion();

        public frmSeleccionarCedula()
        {
            InitializeComponent();
            CargarCedulasClientes();
        }

        // Método para cargar las cédulas de los clientes
        private void CargarCedulasClientes()
        {
            // Obtener todas las cédulas de los clientes
            var dtCedulas = obj_reparacion.GetCedulasClientes();
            cmbCedulasCliente.DataSource = dtCedulas;
            cmbCedulasCliente.DisplayMember = "cedula_cliente";
            cmbCedulasCliente.ValueMember = "cedula_cliente";
        }

        // Evento que se dispara cuando se selecciona una cédula en el ComboBox
        private void cmbCedulasCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si hay una cédula seleccionada
            if (cmbCedulasCliente.SelectedValue != null)
            {
                // Obtener la cédula seleccionada
                string cedula = cmbCedulasCliente.SelectedValue.ToString();

                // Obtener los detalles del cliente con la cédula seleccionada
                var cliente = obj_reparacion.GetClienteCedula(cedula);

                // Verificar si el cliente fue encontrado
                if (cliente != null)
                {
                    // Rellenar los campos con los datos del cliente
                    txtNombreCliente.Text = cliente["nombre_cliente"].ToString();  // Acceder a la columna 'Nombre'
                    txtTelefonoCliente.Text = cliente["telefono_cliente"].ToString(); // Acceder a la columna 'Telefono'
                    txtEmailCliente.Text = cliente["email_cliente"].ToString(); // Acceder a la columna 'Email'

                }
                else
                {
                    // Limpiar los campos si no se encuentra el cliente
                    txtNombreCliente.Clear();
                    
                    txtTelefonoCliente.Clear();
                    txtEmailCliente.Clear();
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CedulaSeleccionada = cmbCedulasCliente.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(CedulaSeleccionada))
            {
                MessageBox.Show("Debe seleccionar una cédula.");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
