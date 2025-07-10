using CapaNegocio;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
namespace CapaPresentacion
{
    public partial class frmReparaciones : Form
    {

        private CL_Repuestos obj_repuestos;

        private CL_Movil obj_Movil;
        private CL_Reparacion obj_reparacion = new CL_Reparacion();
        private CL_Factura obj_factura = new CL_Factura();
        private CL_Cliente obj_cliente;
        private CL_Tecnico obj_tecnico;
        private List<CL_Tecnico> listaTecnicos;
        private int tecnicoActual = 0;
        private int paginaActual = 1;
        private int tecnicosPorPagina = 1;
        private static List<CL_Tecnico> tecnicosAsignados = new List<CL_Tecnico>();
        private int idFacturaActual = 0; // Para almacenar el ID de factura actual
        public TextBox TxtDescripcionRepuesto => txtDescripcionRepuesto;
        // public TextBox TxtCantidadRepuesto => txtCantidad;
        public TextBox TxtCostoIndividual => txtCostoRepuesto;
        // public TextBox TxtCostoTotal => txtTotal;
        public TextBox TxtIdEquipo => txtIdEquipo;

        public frmReparaciones()
        {
            InitializeComponent();
        }


        private void frmReparaciones_Load(object sender, EventArgs e)
        {
            listaTecnicos = new List<CL_Tecnico>();
            obj_repuestos = new CL_Repuestos();
            CargarListadoReparaciones();
            obj_cliente = new CL_Cliente(0, "", "", "", "");
            obj_tecnico = new CL_Tecnico(0, "", "", "", "");
            obj_Movil = new CL_Movil();

            setearControles();
            ActualizarCombos();
            refrescarTabla();
            CargarTecnicosAsignados(paginaActual);

            CargarServicios();

            // Deshabilitar completamente la selección manual del usuario
            // DeshabilitarSeleccionManual(); // Comentado para permitir visualización
        }

        // Método para deshabilitar completamente la selección manual
        private void DeshabilitarSeleccionManual()
        {
            dgvReparaciones.Enabled = false; // Deshabilitar completamente la interacción
            dgvReparaciones.TabStop = false; // Evitar que reciba foco con Tab
        }

        // Método para habilitar solo la visualización (si es necesario)
        private void HabilitarSoloVisualizacion()
        {
            dgvReparaciones.Enabled = true;
            dgvReparaciones.ReadOnly = true;
            dgvReparaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReparaciones.MultiSelect = false;
            dgvReparaciones.AllowUserToAddRows = false;
            dgvReparaciones.AllowUserToDeleteRows = false;
            dgvReparaciones.AllowUserToResizeColumns = false;
            dgvReparaciones.AllowUserToResizeRows = false;
            dgvReparaciones.StandardTab = false;
        }

        private void CargarServicios()
        {
            CL_Reparacion logica = new CL_Reparacion();
            DataTable dtServicios = logica.ObtenerServicios();

            cmbServicios.DataSource = dtServicios;
            cmbServicios.DisplayMember = "nombre_servicio";   // Lo que se ve
            cmbServicios.ValueMember = "costo_servicio";     // Lo que se guarda (el precio)
            cmbServicios.SelectedIndexChanged += cmbServicios_SelectedIndexChanged;
        }
        private void cmbServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServicios.SelectedIndex != -1 && cmbServicios.SelectedValue != null)
            {
                decimal precioServicio = 0;

                if (decimal.TryParse(cmbServicios.SelectedValue.ToString(), out precioServicio))
                {
                    txtPrecioServicio.Text = precioServicio.ToString("0.00");
                    MostrarTotales(int.Parse(txtIdEquipo.Text)); // Recalcula total con servicio
                }
            }
        }

        private void ActualizarCombos()
        {
            CargarCedulasTecnicos();
            CargarCedulasClientes();
        }
        private void refrescarTabla()
        {

            dgvReparaciones.SelectionChanged += dgvReparaciones_SelectionChanged;
            dgvTecnicosAsignados.SelectionChanged += dgvTecnicosAsignados_SelectionChanged;

        }

        private void CargarListadoReparaciones()
        {
            dgvReparaciones.DataSource = obj_factura.ObtenerFacturas();

            // Usar el método de visualización solo
            HabilitarSoloVisualizacion();

            dgvReparaciones.ClearSelection(); // Limpiar selección inicial

            // Cargar automáticamente la primera reparación si existe
            if (dgvReparaciones.Rows.Count > 0)
            {
                dgvReparaciones.Rows[0].Selected = true;
                dgvReparaciones.FirstDisplayedScrollingRowIndex = 0;
            }

            setearControles();
            btnGrabar.Enabled = true;
            btnEliminar.Enabled = true;

        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            tecnicosAsignados.Clear();
            idFacturaActual = 0; // Limpiar ID de factura para nueva reparación

            dgvRepuestos.Rows.Clear();
            refrescarTablaTecnicos();
            txtCedulaTecnico.Text = string.Empty;
            txtNombreTecnico.Text = string.Empty;
            txtTelefonoTecnico.Text = string.Empty;
            txtEmailTecnico.Text = string.Empty;
            txtIdTecnico.Text = string.Empty;
            cmbCedulaTecnico.Text = string.Empty;
            setearControles();
            btnNuevo.Enabled = false;
            btnGrabar.Enabled = true;
            btnEliminar.Enabled = false;
            btnSiguiente.Enabled = false;
            btnAnterior.Enabled = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            string nuevaDescripcion = txtDescripcion.Text.Trim();
            if (string.IsNullOrEmpty(nuevaDescripcion))
            {
                MessageBox.Show("Por favor, ingrese una descripción válida.");
                return;
            }

            string nuevaDescripcionMovil = txtDescripcionMovil.Text.Trim();
            if (string.IsNullOrEmpty(nuevaDescripcionMovil))
            {
                MessageBox.Show("Por favor, ingrese una descripción válida.");
                return;
            }

            decimal nuevoCosto = 0;
            string totalTexto = txtTotal.Text.Trim();

            if (!string.IsNullOrEmpty(totalTexto))
            {
                totalTexto = totalTexto.Replace("$", "").Trim();

                if (!decimal.TryParse(totalTexto, out nuevoCosto) || nuevoCosto <= 0)
                {
                    MessageBox.Show("El cálculo automático del total no es válido. Por favor, revise los repuestos ingresados.");
                    return;
                }

                txtCosto.Text = nuevoCosto.ToString("0.00");
            }
            else
            {
                string manualCosto = txtCosto.Text.Trim();

                manualCosto = manualCosto.Replace("$", "").Trim();

                if (!decimal.TryParse(manualCosto, out nuevoCosto) || nuevoCosto <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un precio válido manualmente.");
                    return;
                }

                txtCosto.Text = nuevoCosto.ToString("0.00");
            }

            string nuevoEstado = cmbEstado.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(nuevoEstado))
            {
                MessageBox.Show("Seleccione un estado válido.");
                return;
            }

            string nuevaFechaEntrega = txtFecha_entrega.Text.Trim();
            DateTime nuevaFechaIngreso = DateTime.Now;

            int idEquipo;
            if (!int.TryParse(txtIdEquipo.Text, out idEquipo) || idEquipo <= 0)
            {
                MessageBox.Show("Por favor, ingrese un ID de equipo válido.");
                return;
            }

            if (!obj_reparacion.ValidarIdEquipo(idEquipo))
            {
                MessageBox.Show("El ID del equipo no existe.");
                return;
            }

            int codigoCliente = int.Parse(txtIdCliente.Text);
            string cedulaCliente = txtCedulaCliente.Text;
            string imei = txtImeiCelular.Text;
            string nombreCliente = txtNombreCliente.Text;
            string telefonoCliente = txtTelefonoCliente.Text;
            string emailCliente = txtEmailCliente.Text;

            bool operacionExitosa = false;
            int id_equipo = idEquipo;

            if (int.TryParse(txtIdReparacion.Text.Trim(), out int idReparacion) && idReparacion > 0)
            {
                // Actualización de reparación existente
                string tecnicosAsignadosString = ObtenerTecnicosAsignadosComoString();

                if (string.IsNullOrEmpty(tecnicosAsignadosString))
                {
                    MessageBox.Show("Por favor, asigne al menos un técnico.");
                    return;
                }

                operacionExitosa = obj_reparacion.ActualizarReparacion(
                      idReparacion,
                      nuevaDescripcion,
                      nuevoCosto,
                      nuevoEstado,
                      nuevaFechaIngreso,
                      nuevaFechaEntrega,
                      tecnicosAsignadosString
                  );

                if (operacionExitosa)
                {
                    string tecnicosAsignadosStringS = ObtenerTecnicosAsignadosComoString();
                    obj_reparacion.AsignarTecnicosAReparacion(id_equipo, tecnicosAsignadosStringS);

                    // Obtener ID de factura de manera segura
                    int idFacturaParaActualizar = ObtenerIdFacturaActual();

                    bool facturaExitosa = obj_factura.ActualizarFactura(idFacturaParaActualizar, tecnicosAsignadosStringS, cedulaCliente, nombreCliente, telefonoCliente, emailCliente,
                                                                         imei, nuevaDescripcionMovil, nuevoEstado,
                                                                         nuevaDescripcion, nuevoCosto, nuevaFechaEntrega);

                    if (facturaExitosa)
                    {
                        MessageBox.Show("Reparación actualizada con éxito.");
                        refrescarTabla();
                        CargarListadoReparaciones();
                        btnNuevo.Enabled = true;
                        btnEliminar.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al actualizar la factura.");
                    }
                }
            }
            else
            {

                operacionExitosa = obj_reparacion.RegistrarReparacion(
                    codigoCliente,
                    idEquipo,
                    cedulaCliente,
                    imei,
                    nuevaDescripcion,
                    nuevoCosto
                );

                if (operacionExitosa)
                {

                    string tecnicosAsignadosString = ObtenerTecnicosAsignadosComoString();
                    obj_reparacion.AsignarTecnicosAReparacion(id_equipo, tecnicosAsignadosString);

                    // Generar factura
                    bool facturaExitosa = obj_factura.GenerarFactura(cedulaCliente, idEquipo);

                    if (facturaExitosa)
                    {
                        MessageBox.Show("Reparación registrada con éxito.");
                        refrescarTabla();
                        CargarListadoReparaciones();
                        btnNuevo.Enabled = true;
                        //      LimpiezaDespuesDeGuardar();

                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al registrar la factura.");
                    }

                }

                else
                {
                    MessageBox.Show("Ocurrió un error al registrar la reparación.");
                }

            }


        }
        private void LimpiezaDespuesDeGuardar()
        {
            // Verifica si el DataGridView está enlazado a una fuente de datos
            if (dgvRepuestos.DataSource != null)
            {
                // Si está enlazado, limpia la fuente de datos
                var dataSource = dgvRepuestos.DataSource as DataTable;
                if (dataSource != null)
                {
                    dataSource.Rows.Clear();
                }
            }
            else
            {
                // Si no está enlazado, usa Rows.Clear()
                dgvRepuestos.Rows.Clear();
            }

            // Limpia la lista de técnicos asignados
            tecnicosAsignados.Clear();

            // Limpia las filas del DataGridView de técnicos asignados
            if (dgvTecnicosAsignados.DataSource != null)
            {
                var dataSource = dgvTecnicosAsignados.DataSource as DataTable;
                if (dataSource != null)
                {
                    dataSource.Rows.Clear();
                }
            }
            else
            {
                dgvTecnicosAsignados.Rows.Clear();
            }

            // Refresca otras tablas necesarias
            refrescarTabla();

            // Carga el listado de reparaciones actualizado
            CargarListadoReparaciones();

            // Habilita los botones nuevamente
            btnNuevo.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnAgregarTecnico_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtCedulaTecnico.Text) || string.IsNullOrWhiteSpace(txtNombreTecnico.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            // Verificar si el técnico ya está asignado en la lista
            if (tecnicosAsignados.Any(t => t.Cedula == txtCedulaTecnico.Text))
            {
                MessageBox.Show("El técnico ya está asignado a esta factura.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idTecnico = 0;
            bool tecnicoExistente = obj_tecnico.ValidarCedulaExistente(txtCedulaTecnico.Text);

            if (tecnicoExistente)
            {
                var tecnico = BuscarTecnicoPorCedula(txtCedulaTecnico.Text);
                if (tecnico != null)
                {
                    idTecnico = tecnico.Id;
                }
                else
                {
                    MessageBox.Show("No se encontró el técnico con la cédula proporcionada.");
                    return;
                }
            }
            else
            {
                bool tecnicoRegistrado = obj_tecnico.RegistrarPersona(
                    txtCedulaTecnico.Text,
                    txtNombreTecnico.Text,
                    txtTelefonoTecnico.Text,
                    txtEmailTecnico.Text
                );

                if (tecnicoRegistrado)
                {
                    var tecnicoNuevo = BuscarTecnicoPorCedula(txtCedulaTecnico.Text);
                    if (tecnicoNuevo != null)
                    {
                        idTecnico = tecnicoNuevo.Id;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo obtener el ID del técnico recién registrado.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el técnico.");
                    return;
                }
            }

            if (int.TryParse(txtIdEquipo.Text, out int idEquipo) && idTecnico > 0)
            {
                string cedulaTecnico = txtCedulaTecnico.Text;
                string imei = txtImeiCelular.Text;
                string cedulaCliente = txtCedulaCliente.Text;
                string descripcionMovil = txtDescripcionMovil.Text;

                // Llamar al método de asignación
                bool asignacionExitosa = obj_reparacion.AsignarEquipoATecnico(
                    idTecnico,
                    idEquipo,
                    cedulaTecnico,
                    imei,
                    cedulaCliente,
                    descripcionMovil
                );

                if (asignacionExitosa)
                {
                    MessageBox.Show("El técnico ha sido asignado correctamente a la reparación.");
                    // Agregar el técnico a la lista de técnicos asignados
                    tecnicosAsignados.Add(BuscarTecnicoPorCedula(txtCedulaTecnico.Text));
                    refrescarTablaTecnicos();
                    LimpiarCamposTecnico();
                }
                else
                {
                    MessageBox.Show("Hubo un problema al asignar el técnico al equipo.");
                }
            }
            else
            {
                MessageBox.Show("ID de equipo o técnico no válido.");
            }

            btnSiguiente.Enabled = false;
            btnAnterior.Enabled = false;
        }


        private string ObtenerTecnicosAsignadosComoString()
        {
            if (tecnicosAsignados == null || tecnicosAsignados.Count == 0)
            {
                return string.Empty;
            }
            return string.Join(",", tecnicosAsignados.Select(t => t.Id.ToString()));
        }

        private void RestablecerControles()
        {
            txtDescripcion.Clear();
            txtCosto.Clear();
            cmbEstado.SelectedIndex = -1;
            txtFecha_entrega.Clear();
            txtIdReparacion.Clear();
            txtIdEquipo.Clear();

            btnNuevo.Enabled = true;
            btnGrabar.Enabled = false;
            btnEliminar.Enabled = false;
        }




        private List<CL_Tecnico> ConvertirDataTableATecnicos(DataTable dt)
        {

            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["id_tecnico"]);
                string nombre = row["nombre_tecnico"].ToString();
                string telefono = row["telefono_tecnico"].ToString();
                string email = row["email_tecnico"].ToString();
                string cedula = row["cedula_tecnico"].ToString();

                CL_Tecnico tecnico = new CL_Tecnico(id, nombre, telefono, email, cedula);
                tecnicosAsignados.Add(tecnico);
            }


            return tecnicosAsignados;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdReparacion.Text, out int idReparacion))
            {
                DialogResult confirm = MessageBox.Show("¿Está seguro de eliminar esta reparación?", "Confirmación", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    bool result = obj_reparacion.EliminarReparacion(idReparacion);

                    if (result)
                    {

                        CargarListadoReparaciones();
                    }
                    else
                    {
                        MessageBox.Show("Eliminacion de la reparación.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID válido.");
            }
            btnEliminar.Enabled = false;
            btnGrabar.Enabled = false;
            btnNuevo.Enabled = true;
            CargarListadoReparaciones();

        }
        private void dgvReparaciones_SelectionChanged(object? sender, EventArgs e)
        {
            DataGridViewRow row;
            if (dgvReparaciones.SelectedRows.Count > 0)
            {
                row = dgvReparaciones.SelectedRows[0];
                txtIdEquipo.Text = row.Cells["id_equipo"].Value?.ToString();
                txtIdReparacion.Text = row.Cells["id_reparacion"].Value?.ToString();
                txtIdCliente.Text = row.Cells["id_cliente"].Value?.ToString();
                txtDescripcion.Text = row.Cells["descripcion_reparacion"].Value?.ToString();
                txtCosto.Text = row.Cells["costo"].Value?.ToString();
                cmbEstado.Text = row.Cells["estado"].Value?.ToString();
                txtFecha_ingreso.Text = row.Cells["fecha_ingreso"].Value?.ToString();
                txtFecha_entrega.Text = row.Cells["fecha_entrega"].Value?.ToString();
                txtCedulaCliente.Text = row.Cells["cedula_cliente"].Value?.ToString();
                txtImeiCelular.Text = row.Cells["imei_celular"].Value?.ToString();
                txtCedulaCliente2.Text = row.Cells["cedula_cliente"].Value?.ToString();
                txtCedulaCliente.Text = row.Cells["cedula_cliente"].Value?.ToString();
                cmbCedulaCliente.Text = row.Cells["cedula_cliente"].Value?.ToString();
                txtFecha_ingreso2.Text = row.Cells["fecha_ingreso"].Value?.ToString();
                txtDescripcionMovil.Text = row.Cells["descripcion_equipo"].Value?.ToString();

                // Establecer automáticamente el ID de factura actual
                try
                {
                    if (row.Cells.Cast<DataGridViewCell>().Any(c => c.OwningColumn.Name == "id_factura"))
                    {
                        idFacturaActual = Convert.ToInt32(row.Cells["id_factura"].Value);
                    }
                    else if (row.Cells.Cast<DataGridViewCell>().Any(c => c.OwningColumn.Name == "id_reparacion"))
                    {
                        idFacturaActual = Convert.ToInt32(row.Cells["id_reparacion"].Value);
                    }
                    else
                    {
                        // Si no se encuentra ninguna columna específica, usar el ID de reparación del txtBox
                        if (int.TryParse(txtIdReparacion.Text, out int idRep))
                        {
                            idFacturaActual = idRep;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // En caso de error, usar 0 (se manejará automáticamente)
                    idFacturaActual = 0;
                }

                if (int.TryParse(row.Cells["id_equipo"].Value?.ToString(), out int idEquipo))
                {
                    CargarTecnicosReparacion(idEquipo);
                }
                else
                {
                    MessageBox.Show("El valor de 'id_equipo' no es válido o está vacío.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            btnAnterior.Enabled = true;
            btnSiguiente.Enabled = true;
            txtTotal.Text = string.Empty;
            txtIVA.Text = string.Empty;
            txtSubtotal.Text = string.Empty;
            btnNuevo.Enabled = true;
            btnEliminar.Enabled = true;
            btnGrabar.Enabled = true;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                CargarTecnicosAsignados(paginaActual);
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            paginaActual++;
            CargarTecnicosAsignados(paginaActual);
        }
        private void setearControles()
        {
            txtIdEquipo.Text = string.Empty;
            txtIdReparacion.Text = string.Empty;
            txtCosto.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtIdCliente.Text = string.Empty;
            txtFecha_ingreso.Text = string.Empty;
            txtFecha_ingreso2.Text = string.Empty;
            txtFecha_entrega.Text = string.Empty;
            cmbEstado.Text = string.Empty;
            txtCedulaCliente.Text = string.Empty;
            txtImeiCelular.Text = string.Empty;
            txtCedulaCliente2.Text = string.Empty;
            txtCedulaTecnico.Text = string.Empty;
            txtIdTecnico.Text = string.Empty;
            cmbCedulaTecnico.Text = string.Empty;
            cmbCedulaCliente.Text = string.Empty;
            cmbEquiposMoviles.Text = string.Empty;
            txtNombreCliente.Text = string.Empty;
            txtTelefonoCliente.Text = string.Empty;
            txtEmailCliente.Text = string.Empty;
            txtTelefonoTecnico.Text = string.Empty;
            txtEmailTecnico.Text = string.Empty;
            txtDescripcionMovil.Text = string.Empty;
            idFacturaActual = 0; // Limpiar ID de factura
        }

        // Método para obtener el ID de factura actual de manera segura
        private int ObtenerIdFacturaActual()
        {
            // Prioridad 1: idFacturaActual si está establecido
            if (idFacturaActual > 0)
                return idFacturaActual;

            // Prioridad 2: Intentar obtener desde el DataGridView actual
            if (dgvReparaciones.SelectedRows.Count > 0)
            {
                try
                {
                    var row = dgvReparaciones.SelectedRows[0];
                    if (row.Cells.Cast<DataGridViewCell>().Any(c => c.OwningColumn.Name == "id_factura"))
                    {
                        return Convert.ToInt32(row.Cells["id_factura"].Value);
                    }
                }
                catch { }
            }

            // Prioridad 3: ID de reparación si está disponible
            if (int.TryParse(txtIdReparacion.Text, out int idReparacion) && idReparacion > 0)
                return idReparacion;

            // Prioridad 4: ID de equipo como último recurso
            if (int.TryParse(txtIdEquipo.Text, out int idEquipo) && idEquipo > 0)
                return idEquipo;

            return 0;
        }

        // Método para navegar automáticamente a la siguiente reparación
        private void NavegarSiguienteReparacion()
        {
            if (dgvReparaciones.Rows.Count > 0)
            {
                int indiceActual = dgvReparaciones.CurrentRow?.Index ?? 0;
                int siguienteIndice = (indiceActual + 1) % dgvReparaciones.Rows.Count;
                dgvReparaciones.ClearSelection();
                dgvReparaciones.Rows[siguienteIndice].Selected = true;
                dgvReparaciones.FirstDisplayedScrollingRowIndex = siguienteIndice;
            }
        }

        // Método para navegar automáticamente a la reparación anterior
        private void NavegarAnteriorReparacion()
        {
            if (dgvReparaciones.Rows.Count > 0)
            {
                int indiceActual = dgvReparaciones.CurrentRow?.Index ?? 0;
                int anteriorIndice = indiceActual == 0 ? dgvReparaciones.Rows.Count - 1 : indiceActual - 1;
                dgvReparaciones.ClearSelection();
                dgvReparaciones.Rows[anteriorIndice].Selected = true;
                dgvReparaciones.FirstDisplayedScrollingRowIndex = anteriorIndice;
            }
        }
        private void CargarCedulasTecnicos()
        {
            var dtCedulas = obj_reparacion.ObtenerCedulasTecnicos();
            cmbCedulaTecnico.DataSource = dtCedulas;
            cmbCedulaTecnico.DisplayMember = "cedula_tecnico";
            cmbCedulaTecnico.ValueMember = "cedula_tecnico";
            cmbCedulaTecnico.SelectedIndex = -1;
        }
        private void cmbCedulaTecnico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCedulaTecnico.SelectedIndex != -1)
            {
                string cedulaSeleccionada = cmbCedulaTecnico.SelectedValue.ToString();
                var datosTecnico = obj_reparacion.ObtenerTecnicoPorCedula(cedulaSeleccionada);

                if (datosTecnico != null)
                {
                    txtIdTecnico.Text = datosTecnico["id_tecnico"].ToString();
                    txtCedulaTecnico.Text = datosTecnico["cedula_tecnico"].ToString();

                    txtNombreTecnico.Text = datosTecnico["nombre_tecnico"].ToString();
                    txtTelefonoTecnico.Text = datosTecnico["telefono_tecnico"].ToString();
                    txtEmailTecnico.Text = datosTecnico["email_tecnico"].ToString();

                    btnNuevo.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEliminar.Enabled = false;
                }
            }
        }
        private void CargarCedulasClientes()
        {
            Load += frmReparaciones_Load;
            var dtCedulas = obj_reparacion.ObtenerCedulasCliente();
            cmbCedulaCliente.DataSource = dtCedulas;
            cmbCedulaCliente.DisplayMember = "cedula_cliente";
            cmbCedulaCliente.ValueMember = "cedula_cliente";
            cmbCedulaCliente.SelectedIndex = -1;
        }
        private void cmbCedulaCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbCedulaCliente.SelectedIndex != -1)
            {
                string cedulaSeleccionada = cmbCedulaCliente.SelectedValue.ToString();
                var datosCliente = obj_reparacion.ObtenerClientePorCedula(cedulaSeleccionada);
                CargarEquiposMoviles(cedulaSeleccionada);

                if (datosCliente != null)
                {
                    txtIdCliente.Text = datosCliente["id_cliente"].ToString();
                    txtCedulaCliente.Text = datosCliente["cedula_cliente"].ToString();
                    txtCedulaCliente2.Text = datosCliente["cedula_cliente"].ToString();
                    txtNombreCliente.Text = datosCliente["nombre_cliente"].ToString();
                    txtTelefonoCliente.Text = datosCliente["telefono_cliente"].ToString();
                    txtEmailCliente.Text = datosCliente["email_cliente"].ToString();

                    btnNuevo.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEliminar.Enabled = false;
                }
            }
        }

        private void CargarEquiposMoviles(string cedulaCliente)
        {
            try
            {
                DataTable equiposMoviles = obj_cliente.ObtenerEquiposPorCliente(cedulaCliente); // Método en CL_EquipoMovil
                cmbEquiposMoviles.DataSource = equiposMoviles;
                cmbEquiposMoviles.DisplayMember = "imei_celular"; // Mostrar IMEI
                cmbEquiposMoviles.ValueMember = "imei_celular"; // Valor asociado
                cmbEquiposMoviles.SelectedIndex = -1; // Sin selección inicial
                cmbEquiposMoviles.SelectedIndexChanged += cmbEquiposMoviles_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"CARGANDO MOVILES", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CargarDetallesEquipoMovil(string imei)
        {

            DataRow equipo = obj_reparacion.ObtenerDetallesEquipoMovil(imei); // Método en CL_Reparacion

            if (equipo != null)
            {
                txtIdEquipo.Text = equipo["id_equipo"].ToString();
                txtImeiCelular.Text = equipo["imei_celular"].ToString();
                txtFecha_ingreso2.Text = equipo["fecha_ingreso"].ToString();
                cmbEstado.Text = equipo["estado"].ToString();
                txtCedulaCliente.Text = equipo["cedula_cliente"].ToString();
                txtDescripcionMovil.Text = equipo["descripcion_equipo"].ToString();

            }
            else
            {
                MessageBox.Show("No se encontraron detalles para el equipo móvil ingresado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

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

        private void LimpiarCamposTecnico()
        {
            txtCedulaTecnico.Text = string.Empty;
            txtNombreTecnico.Text = string.Empty;
            txtTelefonoTecnico.Text = string.Empty;
            txtEmailTecnico.Text = string.Empty;
            // txtIdEquipo.Text = string.Empty;
        }

        private void refrescarTablaTecnicos()
        {
            dgvTecnicosAsignados.DataSource = null;
            dgvTecnicosAsignados.DataSource = tecnicosAsignados;

            if (dgvTecnicosAsignados.Columns.Count > 0)
            {
                dgvTecnicosAsignados.Columns["Id"].HeaderText = "ID Técnico";
                dgvTecnicosAsignados.Columns["Cedula"].HeaderText = "Cédula Técnico";
                dgvTecnicosAsignados.Columns["Nombre"].HeaderText = "Nombre Técnico";
                dgvTecnicosAsignados.Columns["Telefono"].HeaderText = "Teléfono";
                dgvTecnicosAsignados.Columns["Email"].HeaderText = "Email";
            }
        }


        public CL_Tecnico BuscarTecnicoPorCedula(string cedula)
        {
            var listaTecnicos = obj_tecnico.ObtenerTecnicos();
            var tecnicoList = listaTecnicos.AsEnumerable().Select(row => new CL_Tecnico(
                row.Field<int>("id_tecnico"),
                row.Field<string>("nombre_tecnico"),
                row.Field<string>("telefono_tecnico"),
                row.Field<string>("email_tecnico"),
                row.Field<string>("cedula_tecnico")
            )).ToList();

            return tecnicoList.FirstOrDefault(t => t.Cedula == cedula);
        }




        private void CargarTecnicosAsignados(int pagina)
        {
            if (int.TryParse(txtIdEquipo.Text, out int idEquipo))
            {
                DataTable dtTecnicosOriginal = obj_reparacion.ObtenerTecnicosReparacionPaginado(idEquipo, pagina, tecnicosPorPagina);

                DataTable dtTecnicosVertical = new DataTable();
                dtTecnicosVertical.Columns.Add("Atributo", typeof(string));
                dtTecnicosVertical.Columns.Add("Valor", typeof(string));

                foreach (DataRow fila in dtTecnicosOriginal.Rows)
                {
                    foreach (DataColumn columna in dtTecnicosOriginal.Columns)
                    {
                        DataRow nuevaFila = dtTecnicosVertical.NewRow();
                        nuevaFila["Atributo"] = columna.ColumnName; // Nombre del atributo
                        nuevaFila["Valor"] = fila[columna].ToString(); // Valor del atributo
                        dtTecnicosVertical.Rows.Add(nuevaFila);
                    }
                }

                dgvTecnicosAsignados.DataSource = dtTecnicosVertical;

                btnAnterior.Enabled = pagina > 1;
                btnSiguiente.Enabled = dtTecnicosOriginal.Rows.Count == tecnicosPorPagina; // Si hay más técnicos para mostrar
            }
        }

        private void dgvTecnicosAsignados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void cmbEquiposMoviles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string imeiSeleccionado = cmbEquiposMoviles.SelectedValue?.ToString();

            CargarDetallesEquipoMovil(imeiSeleccionado);

        }

        private void dgvTecnicosAsignados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTecnicosAsignados.SelectedRows.Count > 0)
            {
                var selectedRow = dgvTecnicosAsignados.SelectedRows[0];

                // Asignar valores a los TextBox
                txtIdTecnico.Text = selectedRow.Cells["id_tecnico"].Value?.ToString();
                txtNombreTecnico.Text = selectedRow.Cells["nombre_tecnico"].Value?.ToString();
                txtTelefonoTecnico.Text = selectedRow.Cells["telefono_tecnico"].Value?.ToString();
                txtEmailTecnico.Text = selectedRow.Cells["email_tecnico"].Value?.ToString();
                txtCedulaTecnico.Text = selectedRow.Cells["cedula_tecnico"].Value?.ToString();
            }
        }

        private void btnNuevoRepuesto_Click(object sender, EventArgs e)
        {
            setearControlesRepuesto();
            btnNuevoRepuesto.Enabled = false;
            btnGrabarRepuesto.Enabled = true;
            btnEliminarRepuesto.Enabled = false;
        }

        private void setearControlesRepuesto()
        {
            txtIdRepuesto.Text = string.Empty;
            txtDescripcionRepuesto.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtCostoRepuesto.Text = string.Empty;
        }

        private void btnGrabarRepuesto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcionRepuesto.Text) ||
                string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                string.IsNullOrWhiteSpace(txtCostoRepuesto.Text) ||
                string.IsNullOrWhiteSpace(txtIdEquipo.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            // Validar entradas
            if (!int.TryParse(txtIdEquipo.Text, out int idEquipo) || idEquipo <= 0)
            {
                MessageBox.Show("Ingrese un ID de equipo válido.");
                return;
            }
            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.");
                return;
            }
            if (!decimal.TryParse(txtCostoRepuesto.Text, out decimal costo) || costo <= 0)
            {
                MessageBox.Show("Ingrese un costo válido.");
                return;
            }

            // Capturar la descripción del repuesto
            string descripcion = txtDescripcionRepuesto.Text.Trim();

            // Intentar agregar el repuesto al equipo
            bool resultado = obj_repuestos.AgregarRepuesto(idEquipo, descripcion, cantidad, costo);

            if (resultado)
            {
                MessageBox.Show("Repuesto agregado exitosamente.");

                CargarRepuestos(idEquipo);
            }
            else
            {
                MessageBox.Show("Error al agregar el repuesto.");
            }

            // Resetear los controles
            setearControlesRepuesto();
            btnNuevoRepuesto.Enabled = true;
            btnGrabarRepuesto.Enabled = false;
        }
        private void dgvRepuestos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRepuestos.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvRepuestos.SelectedRows[0];
                txtIdRepuesto.Text = fila.Cells["IdRepuesto"].Value.ToString();
                txtDescripcionRepuesto.Text = fila.Cells["DescripcionRepuesto"].Value.ToString();
                txtCantidad.Text = fila.Cells["CantidadRepuesto"].Value.ToString();
                txtCostoRepuesto.Text = fila.Cells["CostoIndividual"].Value.ToString();

                // Habilitar el botón de eliminar
                btnGrabarRepuesto.Enabled = true;
                btnEliminarRepuesto.Enabled = true;
                btnNuevoRepuesto.Enabled = true;
            }
        }

        public void CargarRepuestos(int idEquipo)
        {
            try
            {
                var listaRepuestos = obj_repuestos.ObtenerRepuestosPorEquipo(idEquipo);

                if (dgvRepuestos.Columns.Count == 0)
                {
                    dgvRepuestos.Columns.Add("IdRepuesto", "IdRepuesto");
                    dgvRepuestos.Columns.Add("DescripcionRepuesto", "DescripcionRepuesto");
                    dgvRepuestos.Columns.Add("CantidadRepuesto", "CantidadRepuesto");
                    dgvRepuestos.Columns.Add("CostoIndividual", "CostoIndividual");
                    dgvRepuestos.Columns.Add("CostoTotal", "CostoTotal");
                }

                dgvRepuestos.AutoGenerateColumns = false;
                dgvRepuestos.Columns["IdRepuesto"].DataPropertyName = "IdRepuesto";
                dgvRepuestos.Columns["DescripcionRepuesto"].DataPropertyName = "DescripcionRepuesto";
                dgvRepuestos.Columns["CantidadRepuesto"].DataPropertyName = "CantidadRepuesto";
                dgvRepuestos.Columns["CostoIndividual"].DataPropertyName = "CostoIndividual";
                dgvRepuestos.Columns["CostoTotal"].DataPropertyName = "CostoTotal";

                dgvRepuestos.DataSource = listaRepuestos;
                MostrarTotales(idEquipo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los repuestos: " + ex.Message);
            }
        }


        private void btnEliminarRepuesto_Click(object sender, EventArgs e)
        {
            if (dgvRepuestos.SelectedRows.Count > 0)
            {
                int idRepuesto = Convert.ToInt32(dgvRepuestos.SelectedRows[0].Cells["IdRepuesto"].Value);

                try
                {
                    obj_repuestos.EliminarRepuesto(idRepuesto);

                    MessageBox.Show("Repuesto eliminado exitosamente.");
                    int idEquipo = int.Parse(txtIdEquipo.Text);
                    CargarRepuestos(idEquipo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ELIMINANDO REPARACION", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un repuesto para eliminar.");
            }
        }


        private void MostrarTotales(int idEquipo)
        {
            try
            {
                decimal subtotalRepuestos = obj_repuestos.ObtenerCostoTotalRepuestos(idEquipo);

                decimal precioServicio = 0;
                if (decimal.TryParse(txtPrecioServicio.Text, out decimal tempServicio))
                    precioServicio = tempServicio;

                decimal subtotal = subtotalRepuestos + precioServicio;
                decimal iva = subtotal * 0.15M;
                decimal total = subtotal + iva;

                txtSubtotal.Text = subtotal.ToString("0.00");
                txtIVA.Text = iva.ToString("0.00");
                txtTotal.Text = total.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular totales: {ex.Message}");
            }
        }

        private void txtIdEquipo_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdEquipo.Text, out int idEquipo))
            {
                var listaRepuestos = obj_repuestos.ObtenerRepuestosPorEquipo(idEquipo);

                if (listaRepuestos != null && listaRepuestos.Count > 0)
                {
                    var bindingList = new BindingList<CL_Repuestos>(listaRepuestos);
                    dgvRepuestos.DataSource = bindingList;
                }
                else
                {
                    dgvRepuestos.DataSource = null;
                    MessageBox.Show("Cargando formulario para reparación.");
                }
            }
            else
            {
                dgvRepuestos.DataSource = null;
            }
        }

        private void CargarTecnicosReparacion(int idEquipo)
        {
            try
            {
                CL_Reparacion reparacion = new CL_Reparacion();
                DataTable tecnicos = reparacion.ObtenerTecnicosReparacion(idEquipo);

                dgvTecnicosAsignados.DataSource = tecnicos;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los técnicos: " + ex.Message);
            }
        }
        private void btnDesasignarTecnico_Click(object sender, EventArgs e)
        {
            try
            {
                int idTecnico = Convert.ToInt32(txtIdTecnico.Text);
                int idEquipo = Convert.ToInt32(txtIdEquipo.Text);

                // Obtener ID de factura de manera segura
                int idFactura = ObtenerIdFacturaActual();

                if (idFactura == 0)
                {
                    MessageBox.Show("No se puede obtener el ID de la factura.");
                    return;
                }

                CL_Reparacion reparacion = new CL_Reparacion
                {
                    idEquipo = idEquipo
                };

                // Desasignar el técnico
                if (reparacion.DesasignarTecnico(idTecnico, idEquipo))
                {
                    MessageBox.Show("El técnico ha sido desvinculado correctamente.");

                    // Remover el técnico de la lista local
                    tecnicosAsignados = tecnicosAsignados.Where(t => t.Id != idTecnico).ToList();

                    // Actualizar la factura directamente después de desasignar
                    string nuevosTecnicosAsignados = string.Join(",", tecnicosAsignados.Select(t => t.Id));

                    bool facturaActualizada = obj_factura.ActualizarFactura(
                        //idEquipo,
                        idFactura, // Aquí pasamos id_factura
                        nuevosTecnicosAsignados,
                        txtCedulaCliente.Text,
                        txtNombreCliente.Text,
                        txtTelefonoCliente.Text,
                        txtEmailCliente.Text,
                        txtImeiCelular.Text,
                        txtDescripcionMovil.Text.Trim(),
                        cmbEstado.SelectedItem?.ToString(),
                        txtDescripcion.Text.Trim(),
                        Convert.ToDecimal(txtCosto.Text),
                        txtFecha_entrega.Text.Trim()
                    );

                    if (facturaActualizada)
                    {
                        MessageBox.Show("Factura actualizada correctamente después de desasignar al técnico.");
                    }
                    else
                    {
                        MessageBox.Show("PRESIONE EL BOTON GRABAR PARA GUARDAR CAMBIOS");
                    }

                    // Refrescar la lista visual de técnicos asignados
                    CargarTecnicosReparacion(idEquipo);
                    refrescarTabla();
                    CargarListadoReparaciones();
                }
                else
                {
                    MessageBox.Show("No se pudo desvincular al técnico.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("RECOMENDACION ANTE ESTE PROBLEMA: 1. No puede desasignar al primer tecnico asignado intente con otro tecnicos si se encuentra mas tecnicos asignados a la reparacion. o 2. Debe haber al menos un técnico en la reparación, en tal caso de ya no querer a tal técnico se recomienda eliminar todos los datos de la reparación y hacer una nueva.");
            }
        }

        private void ActualizarFacturaPostDesasignacion(int idEquipo)
        {
            // Obtener ID de factura de manera segura
            int idFactura = ObtenerIdFacturaActual();

            if (idFactura == 0)
            {
                MessageBox.Show("No se puede obtener el ID de la factura.");
                return;
            }

            string nuevaDescripcion = txtDescripcion.Text.Trim();
            decimal nuevoCosto = decimal.Parse(txtCosto.Text.Trim());
            string nuevoEstado = cmbEstado.SelectedItem?.ToString();
            string nuevaFechaEntrega = txtFecha_entrega.Text.Trim();
            string cedulaCliente = txtCedulaCliente.Text;
            string imei = txtImeiCelular.Text;
            string nombreCliente = txtNombreCliente.Text;
            string telefonoCliente = txtTelefonoCliente.Text;
            string emailCliente = txtEmailCliente.Text;

            string tecnicosAsignadosStringS = ObtenerTecnicosAsignadosComoString();
            // obj_reparacion.AsignarTecnicosAReparacion(idEquipo, tecnicosAsignadosStringS);

            bool facturaExitosa = obj_factura.ActualizarFactura(
                idFactura,

            tecnicosAsignadosStringS,
            cedulaCliente,
                nombreCliente,
                telefonoCliente,
                emailCliente,
                imei,
                nuevaDescripcion,
                nuevoEstado,
                nuevaDescripcion,
                nuevoCosto,
                nuevaFechaEntrega
            );

            if (facturaExitosa)
            {
                MessageBox.Show("Factura actualizada correctamente.");
                refrescarTabla();
                CargarListadoReparaciones();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al actualizar la factura.");
            }

        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            frmInventario inventario = new frmInventario(this);
            inventario.ShowDialog();
        }

        private void txtFecha_ingreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, slash (/) y teclas de control (como backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/')
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        private void txtFecha_entrega_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, slash (/) y teclas de control (como backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/')
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        private void cmbServicios_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }

}

