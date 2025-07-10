

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
            string sql = "SELECT * FROM tb_equipo";
            return obj_db.ExecuteSQLQuery(sql);
        }

        public bool UpdateEstadoEquipo(int idEquipo, string nuevoEstado)
        {
            string sql = $"UPDATE tb_equipo SET estado = '{nuevoEstado}' WHERE id_equipo = {idEquipo};";
            return obj_db.ExecuteSQLNonQuery(sql);
        }

        public bool CreateReparacion(int idEquipo, string descripcion, decimal costo)
        {
            string sql = $"INSERT INTO tb_reparacion (id_equipo, descripcion_reparacion, costo) VALUES ({idEquipo}, '{descripcion}', {costo});";
            return obj_db.ExecuteSQLNonQuery(sql);
        }
    }
}
