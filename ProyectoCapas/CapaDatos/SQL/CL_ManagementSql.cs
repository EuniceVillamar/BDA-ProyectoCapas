using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos.SQL
{
    public class CL_ManagementSql
    {
        private ConnectionDB conn = new ConnectionDB();

        // Método para ejecutar SP que retorna datos (SELECT).
        public DataTable ejecutaSP_Query(string nombre_sp, List<Parametros> lista_parametros)
        {
            var comando = new SqlCommand(nombre_sp, conn.OpenConnection());
            comando.CommandType = CommandType.StoredProcedure;

            foreach (var parametro in lista_parametros)
            {
                comando.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
            }

            using (var tabla = new DataTable())
            {
                SqlDataReader reader = comando.ExecuteReader();
                tabla.Load(reader);
                reader.Dispose();
                conn.CloseConnection();
                return tabla;
            }
        }

        // Método para ejecutar SP que no retornan datos (INSERT, UPDATE, DELETE).
        public bool ejecutaSP_NonQuery(string nombre_sp, List<Parametros> lista_parametros)
        {
            var comando = new SqlCommand(nombre_sp, conn.OpenConnection());
            comando.CommandType = CommandType.StoredProcedure;

            foreach (var parametro in lista_parametros)
            {
                comando.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
            }

            var result = comando.ExecuteNonQuery();
            conn.CloseConnection();
            return result > 0;
        }
    }
}

