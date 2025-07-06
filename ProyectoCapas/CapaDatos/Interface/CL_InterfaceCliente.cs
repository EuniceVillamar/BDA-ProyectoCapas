using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaDatos.SQL;

namespace CapaDatos.Interface
{
    public class CL_InterfaceCliente
    {
        private CL_ManagementSql obj_db = new CL_ManagementSql();

        public DataTable GetAllClientes()
        {
            return obj_db.ejecutaSP_Query("SP_GET_CLIENTES", new List<Parametros>());
        }
        public bool CreateCliente(string cedula, string nombre, string telefono, string email)
        {
            List<Parametros> lista_parametros= new List<Parametros>();

            lista_parametros.Add(new Parametros("@Cedula", SqlDbType.VarChar, cedula));
            lista_parametros.Add(new Parametros("@Nombre", SqlDbType.VarChar, nombre));
            lista_parametros.Add(new Parametros("@Telefono", SqlDbType.VarChar, telefono));
            lista_parametros.Add(new Parametros("@Email", SqlDbType.VarChar, email));

            return obj_db.ejecutaSP_NonQuery("SP_INSERT_CLIENTE", lista_parametros);
        }
        public bool UpdateCliente(string cedula, string nuevoNombre, string nuevoTelefono, string nuevoEmail)
        {
            List<Parametros> lista_parametros = new List<Parametros>();
           

            if (!string.IsNullOrEmpty(nuevoNombre))
                lista_parametros.Add(new Parametros("@Nombre_cliente", SqlDbType.VarChar, nuevoNombre));

            if (!string.IsNullOrEmpty(nuevoTelefono))
                lista_parametros.Add(new Parametros("@Telefono_cliente", SqlDbType.VarChar, nuevoTelefono));

            if (!string.IsNullOrEmpty(nuevoEmail))
                lista_parametros.Add(new Parametros("@Email_cliente", SqlDbType.VarChar, nuevoEmail));

            lista_parametros.Add(new Parametros("@Cedula_cliente", SqlDbType.VarChar, cedula));

            return obj_db.ejecutaSP_NonQuery("SP_UPDATE_CLIENTE", lista_parametros);
        }

        public bool DeleteCliente(string cedula)
        {
            List<Parametros> lista_parametros = new List<Parametros>();
            lista_parametros.Add(new Parametros("@Cedula_cliente", SqlDbType.VarChar, cedula));

            return obj_db.ejecutaSP_NonQuery("SP_DELETE_CLIENTE", lista_parametros);
        }
        
        public DataRow GetClienteCedula(string cedula)
        {
            List<Parametros> lista_parametros = new List<Parametros>();
            lista_parametros.Add(new Parametros("@Cedula", SqlDbType.VarChar, cedula));

            var resultado = obj_db.ejecutaSP_Query("SP_GET_CLIENTE_POR_CEDULA", lista_parametros);
            return resultado.Rows.Count > 0 ? resultado.Rows[0] : null;
        }

        public bool ExisteCedula(string cedula)
        {
            List<Parametros> lista_parametros = new List<Parametros>();
            lista_parametros.Add(new Parametros("@Cedula", SqlDbType.VarChar, cedula));

            DataTable resultado = obj_db.ejecutaSP_Query("SP_GET_CEDULAS_PERSONA", lista_parametros);
            return resultado.Rows.Count > 0;
        }

        public DataTable GetCedulasClientes()
        {
            return obj_db.ejecutaSP_Query("SP_GET_CEDULAS_CLIENTE", new List<Parametros>());

        }
        public DataTable ObtenerDatosPersonalesCliente(string cedula)
        {
            List<Parametros> lista_parametros = new List<Parametros>();
            lista_parametros.Add(new Parametros("@Cedula_Cliente", SqlDbType.VarChar, cedula));

            return obj_db.ejecutaSP_Query("SP_GET_DATOS_PERSONALES_CLIENTE", lista_parametros);
        }
        public DataTable ObtenerEquiposPorCliente(string cedulaCliente)
        {
            List<Parametros> lista_parametros = new List<Parametros>();
            lista_parametros.Add(new Parametros("@Cedula_Cliente", SqlDbType.VarChar, cedulaCliente));

            return obj_db.ejecutaSP_Query("SP_GET_EQUIPO_MOVIL_CLIENTE", lista_parametros);
        }
        public DataTable ObtenerEquiposPorEstado(string estado)
        {
            List<Parametros> lista_parametros = new List<Parametros>();
            lista_parametros.Add(new Parametros("@Estado", SqlDbType.VarChar, estado));

            return obj_db.ejecutaSP_Query("SP_GET_ESTADO_EQUIPO_ESPECIFICO", lista_parametros);
        }
        public DataTable ObtenerEquipoEstadoCliente(string cedulaCliente, string estado)
        {
            List<Parametros> lista_parametros = new List<Parametros>();
            lista_parametros.Add(new Parametros("@Cedula_Cliente", SqlDbType.VarChar, cedulaCliente));
            lista_parametros.Add(new Parametros("@Estado", SqlDbType.VarChar, estado));
            return obj_db.ejecutaSP_Query("SP_OBTENER_EQUIPO_ESTADO_CLIENTE", lista_parametros);



        }

    }
}
