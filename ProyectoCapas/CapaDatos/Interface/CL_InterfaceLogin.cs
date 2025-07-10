using CapaDatos.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos.Interface
{
    public class CL_InterfaceLogin
    {
        private CL_ManagementSql obj_db = new CL_ManagementSql();

        public bool ValidarCredenciales(string username, string password)
        {
            List<Parametros> lista_parametros = new List<Parametros>
            {
                new Parametros("@username", SqlDbType.VarChar, username),
                new Parametros("@password", SqlDbType.VarChar, password)
            };

            // Cambiamos el nombre del procedimiento almacenado
            var resultado = obj_db.ejecutaSP_Query("sp_ValidarUsuario", lista_parametros);
            return resultado.Rows.Count > 0; // Devuelve true si encuentra un registro.
        }


        public bool ExisteUsuario(string username)
        {
            List<Parametros> lista_parametros = new List<Parametros>();
            lista_parametros.Add(new Parametros("@username", SqlDbType.VarChar, username));

            var resultado = obj_db.ejecutaSP_Query("SP_EXISTE_USUARIO", lista_parametros);
            return resultado.Rows.Count > 0;
        }
        public bool RegistrarUsuario(string username, string password)
        {
            List<Parametros> lista_parametros = new List<Parametros>
            {
                new Parametros("@username", SqlDbType.VarChar, username),
                new Parametros("@password", SqlDbType.VarChar, password)
            };

            return obj_db.ejecutaSP_NonQuery("sp_InsertarUsuario", lista_parametros);
        }
    }
}
