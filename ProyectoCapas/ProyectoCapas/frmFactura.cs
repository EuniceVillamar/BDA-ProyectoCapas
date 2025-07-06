using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;

namespace CapaPresentacion
{
    public partial class frmFactura : Form
    {
        private CL_Factura obj_factura = new CL_Factura(); // Clase de negocio para manejar facturas
        private DataTable facturasCliente; // Tabla con todas las facturas del cliente
        private int paginaActual = 0; // Índice de la página actual
        private int filasPorPagina = 1; // Número de facturas mostradas por página

        public frmFactura(string cedulaCliente)
        {
            InitializeComponent();
            CargarFacturasCliente(cedulaCliente);
        }

        public void frmFactura_Load(object sender, EventArgs e)
        {
        }

        private void CargarFacturasCliente(string cedulaCliente)
        {
            facturasCliente = obj_factura.ObtenerFacturas(cedulaCliente);

            if (facturasCliente.Rows.Count == 0)
            {
                MessageBox.Show("El cliente no tiene facturas registradas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            // Mostrar la primera página de facturas
            MostrarPagina(paginaActual);
        }

        private void MostrarPagina(int indicePagina)
        {
            if (indicePagina < 0 || indicePagina >= facturasCliente.Rows.Count)
                return;

            DataTable dtVertical = new DataTable();
            dtVertical.Columns.Add("Campo");
            dtVertical.Columns.Add("Valor");

            DataRow factura = facturasCliente.Rows[indicePagina];

            foreach (DataColumn columna in facturasCliente.Columns)
            {
                dtVertical.Rows.Add(columna.ColumnName, factura[columna]);
            }

            dgvFacturas.DataSource = dtVertical;

            ActualizarBotones();
        }

        private void ActualizarBotones()
        {
            btnPrimeraPagina.Enabled = paginaActual > 0;
            btnUltimaPagina.Enabled = paginaActual < facturasCliente.Rows.Count - 1;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 0)
            {
                paginaActual--;
                MostrarPagina(paginaActual);
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual < facturasCliente.Rows.Count - 1)
            {
                paginaActual++;
                MostrarPagina(paginaActual);
            }
        }

        private void btnPrimeraPagina_Click(object sender, EventArgs e)
        {
            paginaActual = 0; // Ir a la primera página
            MostrarPagina(paginaActual);
        }

        private void btnUltimaPagina_Click(object sender, EventArgs e)
        {
            paginaActual = facturasCliente.Rows.Count - 1; // Ir a la última página
            MostrarPagina(paginaActual);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toPdf_Click(object sender, EventArgs e)
        {
            if (facturasCliente == null || facturasCliente.Rows.Count == 0)
            {
                MessageBox.Show("No hay facturas para generar PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow facturaActual = facturasCliente.Rows[paginaActual];
            var resultado = obj_factura.GenerarPDF(facturaActual);
            
            if (resultado.success)
            {
                MessageBox.Show(resultado.message, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Preguntar si desea abrir el PDF
                if (MessageBox.Show("¿Desea abrir el archivo PDF generado?", "Abrir PDF", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(resultado.fileName) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al abrir el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(resultado.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}