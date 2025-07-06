using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmMovil : Form
    {
        private CL_Cliente obj_cliente;
        private CL_Movil obj_movil = new CL_Movil();
        private bool bandera_nuevo = false;
        public frmMovil()
        {
            InitializeComponent();

        }
        private void cargarListaEquipoMovil()
        {
            dgvEquipoMovil.DataSource = obj_movil.GetAllEquiposMoviles();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmMovil_Load(object sender, EventArgs e)
        {
            obj_cliente = new CL_Cliente(0, "", "", "", "");
            cargarListaEquipoMovil();
            BtnGrabar.Enabled = false;
            BtnEliminar.Enabled = false;
            CargarCedulasClientes();
            MostrarMensajeEncabezado("EQUIPO MOVIL");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvEquipoMovil.SelectedRows.Count == 1)
            {
                // Obtener el IMEI del equipo seleccionado
                //string imei = dgvEquipoMovil.CurrentRow.Cells["imei_celular"].Value.ToString();
                string imei = txtImei.Text.Trim();
                // Llamar al método DeleteEquipoMovil para eliminar el equipo
                bool eliminado = obj_movil.DeleteEquipoMovil(imei);

                if (eliminado)
                {
                    MessageBox.Show("El equipo ha sido eliminado correctamente.");

                    cargarListaEquipoMovil();
                    MostrarMensajeEncabezado("ELIMINACIÓN DE DATOS DE EQUIPO MOVIL");

                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el equipo.");
                }
            }
            else
            {
                // Si no se seleccionó una fila o se seleccionaron varias
                MessageBox.Show("Por favor, selecciona un equipo para eliminar.");
            }

            cargarListaEquipoMovil();
            BtnEliminar.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnNuevo.Enabled = true;
            setearControles();
        }


        private void dgvEquipoMovil_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgvEquipoMovil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Verificar que se haya seleccionado una fila válida
                {
                    txtId.Text = dgvEquipoMovil.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtImei.Text = dgvEquipoMovil.Rows[e.RowIndex].Cells[1].Value.ToString();
                    cmbCedulasCliente.Text = dgvEquipoMovil.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtDescripcion.Text = dgvEquipoMovil.Rows[e.RowIndex].Cells[3].Value.ToString();
                    cmbEstado.Text = dgvEquipoMovil.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtFechaIngreso.Text = dgvEquipoMovil.Rows[e.RowIndex].Cells[5].Value.ToString();

                    // Activar botones para editar y eliminar
                    BtnGrabar.Enabled = false;  // Desactivar botón de guardar
                    BtnEliminar.Enabled = true; // Activar botón de eliminar
                    BtnNuevo.Enabled = true;  // Desactivar botón nuevo

                    bandera_nuevo = false; // Modo edición
                    MostrarMensajeEncabezado("ACTUALIZACION DE DATOS DE EQUIPOS MOVILES");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar la fila: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setearControles();
            BtnNuevo.Enabled = false;
            BtnGrabar.Enabled = true;
            BtnEliminar.Enabled = false;
            bandera_nuevo = true;
            MostrarMensajeEncabezado("REGISTRO DE EQUIPOS MOVILES");


        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que todos los campos estén llenos
                if (!CamposLlenos())
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear un objeto CL_Movil con los datos del formulario
                var movil = new CL_Movil
                {
                    IMEI = txtImei.Text.Trim(),
                    CedulaCliente = cmbCedulasCliente.SelectedValue.ToString(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Estado = cmbEstado.Text.Trim(),
                    FechaIngreso = DateTime.Parse(txtFechaIngreso.Text)
                };

                // Llamar al método de inserción
                bool resultado = obj_movil.CreateEquipoMovil(movil);

                // Verificar el resultado
                if (resultado)
                {
                    MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarListaEquipoMovil(); // Refrescar el DataGridView
                    setearControles();        // Limpiar los controles
                    BtnGrabar.Enabled = false;
                    BtnEliminar.Enabled = false;
                    BtnNuevo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Hubo un error al guardar los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarMensajeEncabezado("ACTUALIZACIÓN DE DATOS DE EQUIPOS MOVILES"); // Encabezado para btnGrabar

        }





        private void setearControles()
        {
            txtId.Text = string.Empty;
            txtImei.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            TxtCedula.Text = string.Empty;
            txtFechaIngreso.Text = string.Empty;
            cmbEstado.Text = string.Empty;
            cmbCedulasCliente.Text = string.Empty;
        }
        private bool CamposLlenos()
        {
            //Verificar que los campos obligatorios no estén vacíos
            if (string.IsNullOrWhiteSpace(txtImei.Text) || //IMEI
                string.IsNullOrWhiteSpace(txtDescripcion.Text) || //Descripción
                string.IsNullOrWhiteSpace(txtFechaIngreso.Text) || //Fecha de ingreso
                string.IsNullOrWhiteSpace(cmbCedulasCliente.Text) || //Cedula Cliente (combobox)
                string.IsNullOrWhiteSpace(cmbEstado.Text)) // Estado
            {
                return false; //Falta llenar uno o más campos
            }

            return true; //Todos los campos están llenos
        }

        private void txtImei_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un número 
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;  // Si no es un número  lo bloquea
            }
        }

        private void CargarCedulasClientes()
        {
            try
            {
                DataTable dtCedulas = obj_movil.ObtenerCedulasCliente();
                cmbCedulasCliente.DataSource = dtCedulas;
                cmbCedulasCliente.DisplayMember = "cedula_cliente";
                cmbCedulasCliente.ValueMember = "cedula_cliente";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cédulas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCedulasCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnActu.Enabled = true;
        }

        private void btnActu_Click(object sender, EventArgs e)
        {

            try
            {
                // Verificar si hay una fila seleccionada en el DataGridView
                if (dgvEquipoMovil.SelectedRows.Count != 1)
                {
                    MessageBox.Show("Por favor, seleccione una fila válida para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que todos los campos estén completos
                if (!CamposLlenos())
                {
                    MessageBox.Show("Por favor, complete todos los campos antes de actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Capturar los datos actualizados desde los controles
                var movil = new CL_Movil
                {
                    IdEquipo = int.Parse(txtId.Text), // ID del equipo seleccionado
                    IMEI = txtImei.Text.Trim(), // IMEI nuevo
                    CedulaCliente = cmbCedulasCliente.SelectedValue.ToString(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Estado = cmbEstado.Text.Trim(),
                    FechaIngreso = DateTime.Parse(txtFechaIngreso.Text)
                };

                // Llamar al método para actualizar los datos
                bool resultado = obj_movil.UpdateEquipoMovil(movil);

                if (resultado)
                {
                    MessageBox.Show("Los datos se actualizaron correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarListaEquipoMovil(); // Refrescar el DataGridView
                    setearControles();        // Limpiar los controles
                    btnActu.Enabled = false;  // Deshabilitar el botón hasta que se detecten nuevos cambios
                }
                else
                {
                    MessageBox.Show("Error al actualizar los datos. Verifique la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarMensajeEncabezado("ACTUALIZACIÓN DE DATOS DE EQUIPO MOVIL"); // Encabezado para btnGrabar

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            btnActu.Enabled = true;
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnActu.Enabled = true;
        }

        private void txtImei_TextChanged(object sender, EventArgs e)
        {
            btnActu.Enabled = true;
        }

        private void txtFechaIngreso_TextChanged(object sender, EventArgs e)
        {
            btnActu.Enabled = true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void MostrarMensajeEncabezado(string mensaje)
        {
            lblEncabezado.Text = mensaje;
            lblEncabezado.Visible = true;
        }

        private void txtFechaIngreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                // Permitir solo números, slash (/) y teclas de control (como backspace)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/')
                {
                    e.Handled = true; // Bloquea el carácter
                }

        }
    }
}

