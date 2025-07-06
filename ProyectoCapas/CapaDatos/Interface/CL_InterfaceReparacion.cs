using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data;
using CapaDatos.SQL;

namespace CapaDatos.Interface
{
    public class CL_InterfaceReparacion
    {
        private CL_ManagementSql obj_db = new CL_ManagementSql();

        public DataTable GetAllEquipos()
        {
            return obj_db.ejecutaSP_Query("SP_GET_EQUIPOS", new List<Parametros>());
        }
        //servicios
        public DataTable GetServicios()
        {
            return obj_db.ejecutaSP_Query("SP_GET_SERVICIOS", new List<Parametros>());
        }

        public DataTable GetRepuestos()
        {
            CL_ManagementSql sql = new CL_ManagementSql();
            return sql.ejecutaSP_Query("SP_GET_REPUESTOS", new List<Parametros>());
        }

        public DataTable GetAllReparaciones()
        {
            return obj_db.ejecutaSP_Query("SP_GET_REPARACIONES", new List<Parametros>());
        }

        public bool UpdateEstadoEquipo(int idEquipo, string nuevoEstado, DateTime nuevaFechaIngreso)
        {
            List<Parametros> lista_parametros = new List<Parametros>();

            lista_parametros.Add(new Parametros("@Codigo_equipo", SqlDbType.Int, idEquipo));
            lista_parametros.Add(new Parametros("@nuevo_estado", SqlDbType.VarChar, nuevoEstado));
            lista_parametros.Add(new Parametros("@nueva_fecha_ingreso", SqlDbType.DateTime, nuevaFechaIngreso));

            return obj_db.ejecutaSP_NonQuery("SP_UPDATE_EQUIPO", lista_parametros);
        }
        public bool UpdateReparacion(int idReparacion, string nuevadescripcion, decimal nuevocosto, string nuevoEstado, DateTime nuevaFechaIngreso, string nuevaFechaEntrega, string idsTecnicos)
        {
            List<Parametros> lista_parametros = new List<Parametros>();

            lista_parametros.Add(new Parametros("@Codigo_reparacion", SqlDbType.Int, idReparacion));
            lista_parametros.Add(new Parametros("@nueva_descripcion", SqlDbType.VarChar, nuevadescripcion));
            lista_parametros.Add(new Parametros("@nuevo_costo", SqlDbType.Decimal, nuevocosto));
            lista_parametros.Add(new Parametros("@nuevo_estado", SqlDbType.VarChar, nuevoEstado));
            lista_parametros.Add(new Parametros("@nueva_fecha_ingreso", SqlDbType.DateTime, nuevaFechaIngreso));
            lista_parametros.Add(new Parametros("@nueva_fecha_entrega", SqlDbType.VarChar, nuevaFechaEntrega));
            lista_parametros.Add(new Parametros("@nuevos_tecnicos", SqlDbType.NVarChar, idsTecnicos)); 
            return obj_db.ejecutaSP_NonQuery("SP_UPDATE_REPARACION", lista_parametros);
        }
        
        public bool CreateReparacion(int codigoCliente, int codigoEquipo, string cedulaCliente, string imei, string descripcion, decimal costo)
        {
            List<Parametros> lista_parametros = new List<Parametros>();

            lista_parametros.Add(new Parametros("@Codigo_cliente", SqlDbType.Int, codigoCliente));
            lista_parametros.Add(new Parametros("@Codigo_equipo", SqlDbType.Int, codigoEquipo));
            lista_parametros.Add(new Parametros("@Cedula_cliente", SqlDbType.VarChar, cedulaCliente));
            lista_parametros.Add(new Parametros("@IMEI", SqlDbType.VarChar, imei));
            lista_parametros.Add(new Parametros("@descripcion", SqlDbType.VarChar, descripcion));
            lista_parametros.Add(new Parametros("@costo", SqlDbType.Decimal, costo));

            return obj_db.ejecutaSP_NonQuery("SP_INSERT_REPARACION", lista_parametros);
        }
        
        
        public bool DeleteReparacion(int idReparacion)
        {
            List<Parametros> lista_parametros = new List<Parametros>();

            lista_parametros.Add(new Parametros("@Codigo_reparacion", SqlDbType.Int, idReparacion));
            return obj_db.ejecutaSP_NonQuery("SP_ELIMINAR_REPARACION", lista_parametros);
        }
        public DataTable GetCedulasTecnicos()
        {
            return obj_db.ejecutaSP_Query("SP_GET_CEDULAS_TECNICO", new List<Parametros>());
        }

        public DataRow GetTecnicoCedula(string cedula)
        {
            List<Parametros> lista_parametros = new List<Parametros>();

            lista_parametros.Add(new Parametros("@Cedula", SqlDbType.VarChar, cedula));
            var resultado = obj_db.ejecutaSP_Query("SP_GET_TECNICO_POR_CEDULA", lista_parametros);
            return resultado.Rows.Count > 0 ? resultado.Rows[0] : null;
        }




        public DataTable GetCedulasClientes()
        {
            return obj_db.ejecutaSP_Query("SP_GET_CEDULAS_CLIENTE", new List<Parametros>());
        }

        public DataRow GetClienteCedula(string cedula)
        {
            List<Parametros> lista_parametros = new List<Parametros>();

            lista_parametros.Add(new Parametros("@Cedula", SqlDbType.VarChar, cedula));

            var resultado = obj_db.ejecutaSP_Query("SP_GET_CLIENTE_POR_CEDULA", lista_parametros);
            return resultado.Rows.Count > 0 ? resultado.Rows[0] : null;
        }

        public DataTable ObtenerTecnicosReparacionPaginado(int idEquipo, int pagina, int tecnicosPorPagina)
        {
            List<Parametros> lista_parametros = new List<Parametros>();
            lista_parametros.Add(new Parametros("@Id_Equipo", SqlDbType.Int, idEquipo));
            lista_parametros.Add(new Parametros("@Pagina", SqlDbType.Int, pagina));
            lista_parametros.Add(new Parametros("@TecnicosPorPagina", SqlDbType.Int, tecnicosPorPagina));

            return obj_db.ejecutaSP_Query("SP_OBTENER_TECNICOS_REPARACION_PAGINADO", lista_parametros);
        }

        public void AsignarTecnicosAReparacion(int idEquipo, string idsTecnicos)
        {
            List<Parametros> lista_parametros = new List<Parametros>
            {
                new Parametros("@Id_Equipo", SqlDbType.Int, idEquipo),
                new Parametros("@Tecnicos", SqlDbType.NVarChar, idsTecnicos)
            };

            obj_db.ejecutaSP_Query("SP_ASIGNAR_TECNICOS_A_REPARACION", lista_parametros);
        }
        public int ObtenerUltimoIdReparacion()
        {
            DataTable resultado = obj_db.ejecutaSP_Query("SP_OBTENER_ULTIMO_ID_REPARACION", new List<Parametros>());

            if (resultado.Rows.Count > 0)
            {
                return Convert.ToInt32(resultado.Rows[0]["id_reparacion"]);
            }

            return 0;
        }

        public DataRow ObtenerDetallesEquipo(string imei)
        {
            try
            {
                List<Parametros> lista_parametros = new List<Parametros>();
                lista_parametros.Add(new Parametros("@IMEI", SqlDbType.VarChar, imei));

                DataTable resultado = obj_db.ejecutaSP_Query("SP_GET_DETALLES_EQUIPO", lista_parametros);

                if (resultado.Rows.Count > 0)
                {
                    return resultado.Rows[0]; // Devuelve la primera fila como DataRow
                }
                else
                {
                    return null; // No se encontraron resultados
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los detalles del equipo móvil: " + ex.Message);
            }
        }
        public bool ValidarIdEquipo(int idEquipo)
        {
            List<Parametros> parametros = new List<Parametros>
            {
                new Parametros("@IdEquipo", SqlDbType.Int, idEquipo)
            };

            DataTable resultado = obj_db.ejecutaSP_Query("SP_VALIDAR_ID_EQUIPO", parametros);
            return resultado.Rows.Count > 0;
        }





        public bool AsignarEquipoATecnico(int codigoTecnico, int codigoEquipo,string cedulaTecnico,string imei,string cedulaCliente,string descripcionEquipo)
        {
            try
            {
                List<Parametros> lista_parametros = new List<Parametros>();

            lista_parametros.Add(new Parametros("@Codigo_Tecnico", SqlDbType.Int, codigoTecnico));
            lista_parametros.Add(new Parametros("@Codigo_Equipo", SqlDbType.Int, codigoEquipo));
            lista_parametros.Add(new Parametros("@Cedula_tecnico", SqlDbType.VarChar, cedulaTecnico));
            lista_parametros.Add(new Parametros("@IMEI", SqlDbType.VarChar, imei));
            lista_parametros.Add(new Parametros("@Cedula_Cliente", SqlDbType.VarChar, cedulaCliente));
            lista_parametros.Add(new Parametros("@Descripcion_Equipo", SqlDbType.VarChar, descripcionEquipo));

            obj_db.ejecutaSP_NonQuery("SP_ASIGNAR_EQUIPO_A_TECNICO", lista_parametros);
            
                return true; // Ejecución exitosa
                }
            catch (Exception ex)
            {
                // Manejar errores de ejecución aquí si es necesario (por ejemplo, loguearlos)
                Console.WriteLine($"Error: {ex.Message}");
                return false; // Ejecución fallida
            }

        }
        public bool DesasignarTecnicoDeReparacion(int idEquipo, int idTecnico)
        {
            try
            {
                List<Parametros> parametros = new List<Parametros>
                {
                    new Parametros("@IdEquipo", SqlDbType.Int, idEquipo),
                    new Parametros("@IdTecnico", SqlDbType.Int, idTecnico)
                };

                return obj_db.ejecutaSP_NonQuery("SP_DESASIGNAR_TECNICO_REPARACION", parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al desasignar técnico de la reparación: " + ex.Message);
            }
        }
        public DataTable ObtenerTecnicosReparacion(int idEquipo)
        {
            try
            {
                List<Parametros> parametros = new List<Parametros>
            {
                new Parametros("@IdEquipo", SqlDbType.Int, idEquipo)
            };

                return obj_db.ejecutaSP_Query("SP_OBTENER_TECNICOS_REPARACION", parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener técnicos de reparación: " + ex.Message);
            }
        }
        public bool ExisteReparacion(int idEquipo)
        {
            List<Parametros> parametros = new List<Parametros>
            {
                new Parametros("@IdEquipo", SqlDbType.Int, idEquipo)
            };

            return obj_db.ejecutaSP_NonQuery("SP_EXISTE_REPARACION", parametros);
        }
        }
}
