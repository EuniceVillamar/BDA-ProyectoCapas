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
    public partial class frmInventario : Form
    {
        private frmReparaciones frmPrincipal;
        public frmInventario(frmReparaciones formularioPrincipal)
        {
            InitializeComponent();
            this.frmPrincipal = formularioPrincipal;
        }

        private void CargarRepuestos()
        {
            CL_Reparacion logica = new CL_Reparacion();
            DataTable dt = logica.ObtenerRepuestos();
            dgvInventario.DataSource = dt;
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {

            CargarRepuestos();

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvInventario.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvInventario.SelectedRows[0];

                string descripcion = fila.Cells["descripcion_repuesto"].Value.ToString();
                string cantidad = fila.Cells["cantidad_repuesto"].Value.ToString();
                string costo = fila.Cells["costo_individual"].Value.ToString();
                string total = fila.Cells["costo_total_repuesto"].Value.ToString();

                // Solo llenar los campos del formulario de reparaciones
                frmPrincipal.TxtDescripcionRepuesto.Text = descripcion;
                frmPrincipal.TxtCostoIndividual.Text = costo;

                this.Close(); // Cierra el inventario después de seleccionar
            }
            else
            {
                MessageBox.Show("Selecciona una fila del inventario primero.");
            }
        }

    }
}

