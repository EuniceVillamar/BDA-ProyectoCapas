using CapaDatos.Interface;
using CapaDatos.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CL_Repuestos
    {
        public int IdRepuesto { get; set; }
        public string DescripcionRepuesto { get; set; }
        public int CantidadRepuesto { get; set; }
        public decimal CostoIndividual { get; set; }
        public decimal CostoTotal { get; set; }
        private CL_InterfaceRepuestos obj_repuestos = new CL_InterfaceRepuestos();

        public DataTable ObtenerRepuestosPorFactura(int idFactura)
        {
            return obj_repuestos.GetRepuestosPorFactura(idFactura);
        }

        // Método para actualizar los costos de repuestos por equipo
        public bool ActualizarRepuestosPorEquipo(int idEquipo)
        {
            return obj_repuestos.ActualizarRepuestosPorEquipo(idEquipo);
        }
        public bool AgregarRepuesto(int idEquipo, string descripcion, int cantidad, decimal costo)
        {
            return obj_repuestos.AgregarRepuesto(idEquipo, descripcion, cantidad, costo);
        }

        public List<CL_Repuestos> ConvertirDataTableARepuestos(DataTable dtRepuestos)
        {
            List<CL_Repuestos> listaRepuestos = new List<CL_Repuestos>();

            foreach (DataRow row in dtRepuestos.Rows)
            {
                CL_Repuestos repuesto = new CL_Repuestos
                {
                    IdRepuesto = Convert.ToInt32(row["id_repuesto"]),
                    DescripcionRepuesto = row["descripcion_repuesto"].ToString(),
                    CantidadRepuesto = Convert.ToInt32(row["cantidad_repuesto"]),
                    CostoIndividual = Convert.ToDecimal(row["costo_individual"]),
                    CostoTotal = Convert.ToDecimal(row["costo_total"])
                };

                listaRepuestos.Add(repuesto);
            }

            return listaRepuestos;
        }
        public List<CL_Repuestos> ObtenerRepuestosPorEquipo(int idEquipo)
        {
            // Obtener el DataTable desde el método en CL_InterfaceRepuestos
            DataTable dtRepuestos = obj_repuestos.ObtenerRepuestosPorEquipo(idEquipo);

            // Convertir el DataTable a una lista de objetos CL_Repuestos
            List<CL_Repuestos> listaRepuestos = ConvertirDataTableARepuestos(dtRepuestos);

            return listaRepuestos;
        }


        public void EliminarRepuesto(int idRepuesto)
        {
            obj_repuestos.EliminarRepuesto(idRepuesto);
        }
        public decimal ObtenerCostoTotalRepuestos(int idEquipo)
        {
            return obj_repuestos.ObtenerCostoTotalRepuestos(idEquipo);
        }

            public decimal CalcularCostoTotalConIVA(int idEquipo)
        {
            // Calcular el costo total de los repuestos
            decimal costoTotal = obj_repuestos.ObtenerCostoTotalRepuestos(idEquipo);

            // Calcular IVA (15%)
            decimal iva = costoTotal * 0.15M;

            // Retornar el costo total con IVA
            return costoTotal + iva;
        }



    }
}
