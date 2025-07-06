using CapaDatos.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Interface
{
    public class CL_InterfaceFactura
    {
        private CL_ManagementSql obj_db = new CL_ManagementSql();

        public DataTable GetFacturasPorCedula(string cedula, int pagina, int facturasPorPagina)
        {
            List<Parametros> lista_parametros = new List<Parametros>();

            lista_parametros.Add(new Parametros("@cedulaCliente", SqlDbType.VarChar, cedula));
            lista_parametros.Add(new Parametros("@pagina", SqlDbType.Int, pagina));
            lista_parametros.Add(new Parametros("@facturasPorPagina", SqlDbType.Int, facturasPorPagina));

            return obj_db.ejecutaSP_Query("SP_GET_FACTURAS_POR_CEDULA_CLIENTE", lista_parametros);
        }

        public int ObtenerTotal(string cedulaCliente)
        {
            List<Parametros> lista_parametros = new List<Parametros>();

            lista_parametros.Add(new Parametros("@Cedula_Cliente", SqlDbType.VarChar, cedulaCliente));
            var resultado = obj_db.ejecutaSP_Query("SP_GET_FACTURAS", lista_parametros);
            return resultado.Rows.Count;
        }

        public DataTable GetFactura(string cedulaCliente)
        {
            List<Parametros> lista_parametros = new List<Parametros>();

            lista_parametros.Add(new Parametros("@Cedula_Cliente", SqlDbType.VarChar, cedulaCliente));
            return obj_db.ejecutaSP_Query("SP_GET_FACTURAS", lista_parametros);
        }

        public DataTable GetAllFacturas()
        {
            return obj_db.ejecutaSP_Query("SP_GET_TODAS_FACTURAS", new List<Parametros>());
        }

        public bool ExisteFactura(int idReparacion)
        {
            List<Parametros> parametros = new List<Parametros>
            {
                new Parametros("@id_reparacion", SqlDbType.Int, idReparacion)
            };

            // Ejecuta el procedimiento almacenado y retorna un valor booleano
            return obj_db.ejecutaSP_NonQuery("SP_EXISTE_FACTURA", parametros);
        }

        public bool InsertarFactura(string cedulaCliente, int idReparacion)
        {
            List<Parametros> parametros = new List<Parametros>
        {
                new Parametros("@cedula_cliente", SqlDbType.VarChar, cedulaCliente),
            new Parametros("@id_equipo", SqlDbType.Int, idReparacion)
        };

            // Llama al procedimiento almacenado para insertar la factura
            return obj_db.ejecutaSP_NonQuery("SP_INSERT_FACTURA", parametros);
        }
        public bool ActualizarFactura(int idFactura, string nuevosTecnicos, string cedula_cliente, string nombre_cliente, string telefono_cliente, string email_cliente,
                                       string imei_celular, string descripcion_equipo, string estado, string descripcion_reparacion, decimal costo, string fecha_entrega)
        {
            // Crear lista de parámetros para ejecutar el procedimiento almacenado
            List<Parametros> parametros = new List<Parametros>
            {
                new Parametros("@id_factura", SqlDbType.Int, idFactura),
                new Parametros("@cedula_cliente", SqlDbType.NVarChar, cedula_cliente),
                new Parametros("@nombre_cliente", SqlDbType.NVarChar, nombre_cliente),
                new Parametros("@telefono_cliente", SqlDbType.NVarChar, telefono_cliente),
                new Parametros("@email_cliente", SqlDbType.NVarChar, email_cliente),
                new Parametros("@imei_celular", SqlDbType.NVarChar, imei_celular),
                new Parametros("@descripcion_equipo", SqlDbType.NVarChar, descripcion_equipo),
                new Parametros("@estado", SqlDbType.NVarChar, estado),
                new Parametros("@descripcion_reparacion", SqlDbType.NVarChar, descripcion_reparacion),
                new Parametros("@costo", SqlDbType.Decimal, costo),
                new Parametros("@fecha_entrega", SqlDbType.NVarChar, fecha_entrega),
                new Parametros("@nuevos_tecnicos", SqlDbType.NVarChar, nuevosTecnicos) // Solo se actualiza la lista de nuevos técnicos
            };

            // Ejecutar el procedimiento almacenado SP_UPDATE_FAC
            return obj_db.ejecutaSP_NonQuery("SP_UPDATE_FACTURA", parametros);


        }
    }
 }