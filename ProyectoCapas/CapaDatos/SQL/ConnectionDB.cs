using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos.SQL{
    
    public class ConnectionDB: IDisposable
    {
        public static string cadena_conexion = "server=DESKTOP-IJSGL25; database=DB_Reparaciones; Integrated Security=true";
        private SqlConnection connection_db = new SqlConnection(cadena_conexion);
        public SqlConnection OpenConnection(){
            if (connection_db.State == System.Data.ConnectionState.Closed)
                connection_db.Open();
            return connection_db;
        }

        public SqlConnection CloseConnection(){
            if (connection_db.State == System.Data.ConnectionState.Open)
                connection_db.Close();

            return connection_db;
        }

        //IDisposable
        public void Dispose()
        {
            if (connection_db != null)  
                connection_db.Dispose();   
        }
    }
}