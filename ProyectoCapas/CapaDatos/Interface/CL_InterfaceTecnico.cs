using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaDatos.SQL;

namespace CapaDatos.Interface
{
    public class CL_InterfaceTecnico
    {
        private CL_ManagementSql obj_db = new CL_ManagementSql();


        public DataTable GetAllTecnicos()
        {
            return obj_db.ejecutaSP_Query("SP_GET_TECNICOS", new List<Parametros>());
        }
        public bool CreateTecnico(string cedula, string nombre, string telefono, string email)
        {
            List<Parametros> lista_parametros = new List<Parametros>();

            lista_parametros.Add(new Parametros("@Cedula", SqlDbType.VarChar, cedula));
            lista_parametros.Add(new Parametros("@Nombre_tecnico", SqlDbType.VarChar, nombre));
            lista_parametros.Add(new Parametros("@Telefono_tecnico", SqlDbType.VarChar, telefono));
            lista_parametros.Add(new Parametros("@Email_tecnico", SqlDbType.VarChar, email));


            return obj_db.ejecutaSP_NonQuery("SP_INSERT_TECNICO", lista_parametros);
        }

        public bool AssignEquipoToTecnico(int codigoTecnico, int codigoEquipo, string cedulaTecnico, string imei)
        {
            List<Parametros> lista_parametros = new List<Parametros>();

            lista_parametros.Add(new Parametros("@Codigo_Tecnico", SqlDbType.Int, codigoTecnico));
            lista_parametros.Add(new Parametros("@Codigo_Equipo", SqlDbType.Int, codigoEquipo));
            lista_parametros.Add(new Parametros("@Cedula_tecnico", SqlDbType.VarChar, cedulaTecnico));
            lista_parametros.Add(new Parametros("@IMEI", SqlDbType.VarChar, imei));
            return obj_db.ejecutaSP_NonQuery("SP_ASIGNAR_EQUIPO_A_TECNICO", lista_parametros);
        }
        public bool DeleteTecnico(string cedula)
        {
            List<Parametros> lista_parametros = new List<Parametros>();

            lista_parametros.Add(new Parametros("@Cedula_tecnico", SqlDbType.VarChar, cedula));


            return obj_db.ejecutaSP_NonQuery("SP_DELETE_TECNICO", lista_parametros);
        }
        public bool UpdateTecnico(string cedula, string nuevoNombre, string nuevoTelefono, string nuevoEmail)
        {
            List<Parametros> lista_parametros = new List<Parametros>();

            if (!string.IsNullOrEmpty(nuevoNombre))
                lista_parametros.Add(new Parametros("@Nuevo_nombre_tecnico", SqlDbType.VarChar, nuevoNombre));


            if (!string.IsNullOrEmpty(nuevoTelefono))
                lista_parametros.Add(new Parametros("@Nuevo_telefono_tecnico", SqlDbType.VarChar, nuevoTelefono));

            if (!string.IsNullOrEmpty(nuevoEmail))
                lista_parametros.Add(new Parametros("@Nuevo_email_tecnico", SqlDbType.VarChar, nuevoEmail));

            lista_parametros.Add(new Parametros("@Cedula_tecnico", SqlDbType.VarChar, cedula));

            return obj_db.ejecutaSP_NonQuery("SP_UPDATE_TECNICO", lista_parametros);
        }
        public bool ExisteCedula(string cedula)
        {
            List<Parametros> lista_parametros = new List<Parametros>();
            lista_parametros.Add(new Parametros("@Cedula", SqlDbType.VarChar, cedula));


            DataTable resultado = obj_db.ejecutaSP_Query("SP_GET_CEDULAS_PERSONA", lista_parametros);
            return resultado.Rows.Count > 0;
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
        public DataTable ObtenerDatosPersonalesTecnico(string cedula)
        {
            List<Parametros> lista_parametros = new List<Parametros>();
            lista_parametros.Add(new Parametros("@Cedula_Tecnico", SqlDbType.VarChar, cedula));
            return obj_db.ejecutaSP_Query("SP_GET_DATOS_PERSONALES_TECNICO", lista_parametros);
        }


        //NUEVAS OPCIONES
        public DataTable GetEquiposAsignados(string cedulaTecnico)
        {
            List<Parametros> lista_parametros = new List<Parametros>();
            lista_parametros.Add(new Parametros("@Cedula_Tecnico", SqlDbType.VarChar, cedulaTecnico));
            return obj_db.ejecutaSP_Query("SP_OBTENER_EQUIPOS_ASIGNADOS", lista_parametros);
        }

        public DataTable GetTecnicosPaginado(int idReparacion, int pagina, int tecnicosPorPagina)
        {
            List<Parametros> lista_parametros = new List<Parametros>();
            lista_parametros.Add(new Parametros("@Id_Reparacion", SqlDbType.Int, idReparacion));
            lista_parametros.Add(new Parametros("@Pagina", SqlDbType.Int, pagina));
            lista_parametros.Add(new Parametros("@TecnicosPorPagina", SqlDbType.Int, tecnicosPorPagina));

            return obj_db.ejecutaSP_Query("SP_OBTENER_TECNICOS_REPARACION_PAGINADO", lista_parametros);
        }

    }
}