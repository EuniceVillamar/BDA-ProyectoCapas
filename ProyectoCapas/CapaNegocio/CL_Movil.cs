using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Interface;
using CapaDatos.SQL;

namespace CapaNegocio
{

    public class CL_Movil
    {
        private CL_InterfaceMovil obj_equipo = new CL_InterfaceMovil();
        // Propiedades privadas
        private int idEquipo;
        private string descripcion;
        private string estado;
        private DateTime fechaIngreso;
        private int codigoEquipo;
        private string cedulaCliente;
        private string cedulaTecnico;
        private string imei;

        public CL_Movil(int idEquipo, string descripcion, string estado, DateTime fechaIngreso, int codigoEquipo, string cedulaCliente, string imei, string cedulaTecnico)
        {
            this.idEquipo = idEquipo;
            this.descripcion = descripcion;
            this.estado = estado;
            this.fechaIngreso = fechaIngreso;
            this.codigoEquipo = codigoEquipo;
            this.cedulaCliente = cedulaCliente;
            this.imei = imei;
            this.cedulaTecnico = cedulaTecnico;
        }
        public CL_Movil()
        {
            idEquipo = 0;
            descripcion = string.Empty;
            estado = string.Empty;
            fechaIngreso = DateTime.Now;
            codigoEquipo = 0;
            cedulaCliente = string.Empty;
            imei = string.Empty;
            cedulaTecnico = string.Empty;
        }



        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public int IdEquipo
        {
            get { return idEquipo; }
            set { idEquipo = value; }
        }
        public int CodigoEquipo
        {
            get { return codigoEquipo; }
            set { codigoEquipo = value; }
        }

        public string CedulaCliente
        {
            get { return cedulaCliente; }
            set { cedulaCliente = value; }
        }
        public string CedulaTecnico
        {
            get { return cedulaTecnico; }
            set { cedulaTecnico = value; }
        }
        public string IMEI
        {
            get { return imei; }
            set { imei = value; }
        }

        public DataTable GetAllEquiposMoviles()
        {
            return obj_equipo.getAllEquiposMoviles();
        }
        public bool CreateEquipoMovil(CL_Movil movil)
        {
        return obj_equipo.createEquipoMovil(movil.IMEI, movil.CedulaCliente, movil.Descripcion, movil.Estado);
        }
        public bool UpdateEquipoMovil(CL_Movil movil)
        {
            try
            {
                using (ConnectionDB db = new ConnectionDB())
                {
                    SqlConnection connection = db.OpenConnection();
                    using (SqlCommand cmd = new SqlCommand("SP_UPDATE_EQUIPO", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Agregar los parámetros
                        cmd.Parameters.AddWithValue("@id_equipo", movil.IdEquipo); // ID del equipo
                        cmd.Parameters.AddWithValue("@nuevo_imei_celular", movil.IMEI); // Nuevo IMEI
                        cmd.Parameters.AddWithValue("@nuevo_estado", movil.Estado);
                        cmd.Parameters.AddWithValue("@nueva_fecha_ingreso", movil.FechaIngreso);
                        cmd.Parameters.AddWithValue("@nueva_descripcion", movil.Descripcion);

                        // Ejecutar el procedimiento almacenado
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el equipo móvil: " + ex.Message);
            }
        }

        public bool DeleteEquipoMovil(string imei)
        {
            return obj_equipo.DeleteEquipo(imei);
        }


        public DataTable ObtenerCedulasCliente()
        {
            return obj_equipo.GetCedulasClientes();
        }
    }

}
