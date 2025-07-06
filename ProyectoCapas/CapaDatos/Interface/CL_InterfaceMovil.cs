using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDatos.SQL;

namespace CapaDatos.Interface
{
    public class CL_InterfaceMovil
    {
        private CL_ManagementSql obj_db = new CL_ManagementSql();

        public DataTable getAllEquiposMoviles()
        {
            return obj_db.ejecutaSP_Query("SP_GET_EQUIPOS_MOVILES", new List<Parametros>());
        }


        public bool createEquipoMovil(string imei, string cedula_cliente, string descripcion, string estado)
        {
            var parametros = new List<Parametros>
            {
                //new Parametros("@id_equipo", SqlDbType.Int, id_equipo),
                new Parametros("@IMEI", SqlDbType.VarChar, imei),
                new Parametros("@Cedula_cliente", SqlDbType.VarChar, cedula_cliente),
                new Parametros("@Descripcion", SqlDbType.VarChar, descripcion),
                new Parametros("@Estado", SqlDbType.VarChar, estado)


            };

            return obj_db.ejecutaSP_NonQuery("SP_INSERT_EQUIPO", parametros);
        }
        public bool updateEquipoMovil(string descripcion, string estado, string imei, DateTime fecha_ingreso)
        {
            var parametros = new List<Parametros>
            {
                new Parametros("@nueva_descripcion", SqlDbType.VarChar, descripcion),
                new Parametros("@nuevo_estado", SqlDbType.VarChar, estado),
                new Parametros("@nuevo_imei_celular", SqlDbType.VarChar, imei),
                new Parametros("@nueva_fecha_ingreso", SqlDbType.DateTime, fecha_ingreso)
            };

            return obj_db.ejecutaSP_NonQuery("SP_UPDATE_EQUIPO", parametros);
        }
        public bool DeleteEquipo(string IMEI)
        {
            List<Parametros> lista_parametros = new List<Parametros>();

            lista_parametros.Add(new Parametros("@IMEI", SqlDbType.VarChar, IMEI));


            return obj_db.ejecutaSP_NonQuery("SP_ELIMINAR_EQUIPO", lista_parametros);
        }
        public DataTable GetCedulasClientes()
        {
            return obj_db.ejecutaSP_Query("SP_GET_CEDULAS_CLIENTE", new List<Parametros>());
        }

    }


}
