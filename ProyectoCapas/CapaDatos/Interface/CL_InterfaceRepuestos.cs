using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaDatos.Interface;
using CapaDatos.SQL;

namespace CapaDatos.Interface
{
    public class CL_InterfaceRepuestos
    {
        private CL_ManagementSql obj_db = new CL_ManagementSql();

        public DataTable GetRepuestosPorFactura(int idFactura)
        {
            List<Parametros> lista_parametros = new List<Parametros>
            {
                new Parametros("@id_factura", SqlDbType.Int, idFactura)
            };

            return obj_db.ejecutaSP_Query("SP_GET_REPUESTOS_FACTURA", lista_parametros);
        }

        public bool AgregarRepuesto(int idEquipo, string descripcion, int cantidad, decimal costoIndividual)
        {
            List<Parametros> lista_parametros = new List<Parametros>
            {
                new Parametros("@id_equipo", SqlDbType.Int, idEquipo),
                new Parametros("@descripcion_repuesto", SqlDbType.NVarChar, descripcion),
                new Parametros("@cantidad_repuesto", SqlDbType.Int, cantidad),
                new Parametros("@costo_individual", SqlDbType.Decimal, costoIndividual)
            };

            return obj_db.ejecutaSP_NonQuery("SP_AGREGAR_REPUESTO", lista_parametros);
        }
        public DataTable ObtenerRepuestosPorEquipo(int idEquipo)
        {
            DataTable dtRepuestos = new DataTable();

            try
            {
                List<Parametros> lista_parametros = new List<Parametros>
                {
                    new Parametros("@id_equipo", SqlDbType.Int, idEquipo)
                };

                dtRepuestos = obj_db.ejecutaSP_Query("SP_OBTENER_REPUESTOS_POR_EQUIPO", lista_parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener repuestos: {ex.Message}");
            }

            return dtRepuestos;
        }



        public bool EliminarRepuesto(int idRepuesto)
        {
            try
            {
                // Usar la conexión existente a través de obj_db
                List<Parametros> lista_parametros = new List<Parametros>
                {
                    new Parametros("@id_repuesto", SqlDbType.Int, idRepuesto)
                };

                // Ejecuta el procedimiento almacenado para eliminar el repuesto
                return obj_db.ejecutaSP_NonQuery("SP_ELIMINAR_REPUESTO", lista_parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar repuesto: {ex.Message}");
                return false;
            }
        }
        // Método para actualizar los repuestos asociados a un equipo
        public bool ActualizarRepuestosPorEquipo(int idEquipo)
        {
            List<Parametros> lista_parametros = new List<Parametros>
            {
                new Parametros("@id_equipo", SqlDbType.Int, idEquipo)
            };

            return obj_db.ejecutaSP_NonQuery("SP_ACTUALIZAR_REPUESTOS", lista_parametros);
        }
        public decimal ObtenerCostoTotalRepuestos(int idEquipo)
        {
            // Crear lista de parámetros
            List<Parametros> lista_parametros = new List<Parametros>
            {
                new Parametros("@id_equipo", SqlDbType.Int, idEquipo)
            };

            DataTable dtResultado = obj_db.ejecutaSP_Query("SP_CALCULAR_COSTO_TOTAL_FACTURA", lista_parametros);
            if (dtResultado.Rows.Count > 0 && dtResultado.Rows[0][0] != DBNull.Value)
            {
                return Convert.ToDecimal(dtResultado.Rows[0][0]);
            }

            return 0; 
        }



    }

}

