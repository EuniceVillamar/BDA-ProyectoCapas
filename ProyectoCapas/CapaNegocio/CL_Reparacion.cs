using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos.Interface;
using CapaDatos.SQL;

namespace CapaNegocio
{
    public class CL_Reparacion
    {
        private int idReparacion;
        public int idEquipo;
        private string descripcionReparacion;
        private decimal costo;
        private string estado;
        private DateTime fechaIngreso;
        private string fechaEntrega;
        public List<CL_Tecnico> TecnicosAsignados { get; set; }

        private CL_InterfaceReparacion obj_reparacion = new CL_InterfaceReparacion();
        private CL_InterfaceFactura obj_factura = new CL_InterfaceFactura(); 
        public CL_Reparacion()
        {
            idReparacion = 0;
            idEquipo = 0;
            descripcionReparacion = string.Empty;
            costo = 0;
            estado = string.Empty;
            fechaIngreso = DateTime.Now;
            fechaEntrega = string.Empty;
            TecnicosAsignados = new List<CL_Tecnico>();

        }

        public CL_Reparacion(int idReparacion, int idEquipo, string descripcionReparacion, decimal costo, string estado, DateTime fechaIngreso, string fechaEntrega)
        {
            this.idReparacion = idReparacion;
            this.idEquipo = idEquipo;
            this.descripcionReparacion = descripcionReparacion;
            this.costo = costo;
            this.estado = estado;
            this.fechaIngreso = fechaIngreso;
            this.fechaEntrega = fechaEntrega;
        }

        public int IdReparacion
        {
            get { return idReparacion; }
            set { idReparacion = value; }
        }
        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }

        public string FechaEntrega
        {
            get { return fechaEntrega; }
            set { fechaEntrega = value; }
        }

        public int IdEquipo
        {
            get { return idEquipo; }
            set { idEquipo = value; }
        }

        public string DescripcionReparacion
        {
            get { return descripcionReparacion; }
            set { descripcionReparacion = value; }
        }

        public decimal Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        //servicios
        public DataTable ObtenerServicios()
        {
            return obj_reparacion.GetServicios();
        }

        public DataTable ObtenerEquipos()
        {
            return obj_reparacion.GetAllEquipos();
        }

        public DataTable ObtenerRepuestos()
        {
            return obj_reparacion.GetRepuestos();  // si lo hiciste en CL_InterfaceReparacion
        }

        public DataTable ObtenerReparaciones()
        {
            return obj_reparacion.GetAllReparaciones();
        }

        public bool CambiarEstadoEquipo(int idEquipo, string nuevoEstado, DateTime nuevaFechaIngreso)
        {
            if (string.IsNullOrWhiteSpace(nuevoEstado))
                throw new ArgumentException("El nuevo estado no puede estar vacío.");

            return obj_reparacion.UpdateEstadoEquipo(idEquipo, nuevoEstado, nuevaFechaIngreso);
        }
        
        public bool RegistrarReparacion(int codigoCliente, int codigoEquipo, string cedulaCliente, string imei, string descripcion, decimal costo)
        {
            if (codigoEquipo <= 0)
                throw new ArgumentException("El código del equipo no puede ser menor o igual a cero.");
            if (costo <= 0)
                throw new ArgumentException("El costo debe ser mayor que cero.");

            return obj_reparacion.CreateReparacion(codigoCliente, codigoEquipo, cedulaCliente, imei, descripcion, costo);
        }

       
        
        public bool ActualizarReparacion(int idReparacion, string nuevadescripcion, decimal nuevocosto, string nuevoEstado, DateTime nuevaFechaIngreso, string nuevaFechaEntrega, string idsTecnicos)
        {
            if (idReparacion <= 0)
                throw new ArgumentException("El código de la reparación no puede ser menor o igual a cero.");

            if (nuevocosto <= 0)
                throw new ArgumentException("El costo debe ser mayor que cero.");

            return obj_reparacion.UpdateReparacion(idReparacion, nuevadescripcion, nuevocosto, nuevoEstado, nuevaFechaIngreso, nuevaFechaEntrega, idsTecnicos);
        }


        public bool EliminarReparacion(int idReparacion)
        {
            if (idReparacion <= 0)
                throw new ArgumentException("El código de la reparación no puede ser menor o igual a cero.");

            return obj_reparacion.DeleteReparacion(idReparacion);
        }
        public DataTable ObtenerCedulasTecnicos()
        {
            return obj_reparacion.GetCedulasTecnicos();
        }

        public DataRow ObtenerTecnicoPorCedula(string cedula)
        {
            return obj_reparacion.GetTecnicoCedula(cedula);
        }
        public DataTable ObtenerCedulasCliente()
        {
            return obj_reparacion.GetCedulasClientes();
        }

        public DataRow ObtenerClientePorCedula(string cedula)
        {
            return obj_reparacion.GetClienteCedula(cedula);
        }
        public DataTable ObtenerTecnicosReparacionPaginado(int idReparacion, int pagina, int tecnicosPorPagina)
        {
            // Llama al método de la capa de acceso a datos
            return obj_reparacion.ObtenerTecnicosReparacionPaginado(idReparacion, pagina, tecnicosPorPagina);
        }
        /// <summary>
        /// //
        /// </summary>
        /// <param name="idEquipo"></param>
        /// <param name="idsTecnicos"></param>
        public void AsignarTecnicosAReparacion(int idEquipo, string idsTecnicos)
        {
            obj_reparacion.AsignarTecnicosAReparacion(idEquipo, idsTecnicos); // Llamada a la capa de datos
        }
        /// <summary>
        /// //
        /// </summary>
        /// <returns></returns>
        // En la clase CL_Reparacion, cambia el tipo de retorno a bool
        public bool AsignarEquipoATecnico(int codigoTecnico, int codigoEquipo, string cedulaTecnico, string imei, string cedulaCliente, string descripcionEquipo)
        {
            // Llamamos al método de CL_InterfaceReparacion que ya devuelve un bool
            return obj_reparacion.AsignarEquipoATecnico(codigoTecnico, codigoEquipo, cedulaTecnico, imei, cedulaCliente, descripcionEquipo);
        }






        public int ObtenerUltimoIdReparacion()
        {
            return obj_reparacion.ObtenerUltimoIdReparacion();
        }


        public bool ValidarIdEquipo(int idEquipo)
        {
            return obj_reparacion.ValidarIdEquipo(idEquipo);
        }
 
        public DataRow ObtenerDetallesEquipoMovil(string imei)
        {
            try
            {
                return obj_reparacion.ObtenerDetallesEquipo(imei); // Método del InterfaceReparacion
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los detalles del equipo móvil: " + ex.Message);
            }
        }

        public bool DesasignarTecnico(int idTecnico, int idEquipo)
        {
            try
            {
                bool resultado = obj_reparacion.DesasignarTecnicoDeReparacion(idEquipo, idTecnico);

                if (resultado)
                {
                    // Remover el técnico de la lista local
                    this.TecnicosAsignados.RemoveAll(t => t.Id == idTecnico);
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al desasignar técnico: " + ex.Message);
            }
        }
        public DataTable ObtenerTecnicosReparacion(int idEquipo)
        {
            try
            {
                return obj_reparacion.ObtenerTecnicosReparacion(idEquipo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener técnicos asignados: " + ex.Message);
            }
        }

        public bool ExisteReparacion(int idEquipo)
        {
            return obj_reparacion.ExisteReparacion(idEquipo);
        }
        public bool ValidarTecnicoExistente(string cedula)
        {
            var tecnico = obj_reparacion.GetTecnicoCedula(cedula);
            return tecnico != null;
        }


    }
}
