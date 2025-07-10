using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Interface;
namespace CapaNegocio
{
    public class CL_Cliente : CL_Persona
    {
        private List<CL_Movil> equipos;
        private CL_InterfaceCliente obj_cliente = new CL_InterfaceCliente();

        public CL_Cliente(int id, string nombre, string telefono, string email, string cedula) : base(id, nombre, telefono, email, cedula)
        {
            equipos = new List<CL_Movil>();
        }

        public List<CL_Movil> Equipos { get { return equipos; } }

        public void AgregarEquipo(CL_Movil equipo)
        {
            equipos.Add(equipo);
        }
        public DataTable ObtenerClientes()
        {
            return obj_cliente.GetAllClientes();
        }
        public override bool RegistrarPersona(string cedula, string nombre, string telefono, string email)
        {
            if (string.IsNullOrWhiteSpace(cedula))
                throw new ArgumentException("La cédula no puede estar vacía.");
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException("El teléfono no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El email no puede estar vacío.");

            return obj_cliente.CreateCliente(cedula, nombre, telefono, email);
        }

        public override bool UpdatePersona(string cedula, string nombre, string telefono, string email)
        {
            return obj_cliente.UpdateCliente(cedula, nombre, telefono, email);
        }

        public override bool DeletePersona(string cedula)
        {
            return obj_cliente.DeleteCliente(cedula);
        }

        public override bool ValidarCedulaExistente(string cedula)
        {
            return obj_cliente.ExisteCedula(cedula);
        }




        public override DataTable ObtenerCedulas()
        {
            return obj_cliente.GetCedulasClientes();
        }

        public override DataTable ObtenerDatosPersonales(string cedula)
        {
            return obj_cliente.ObtenerDatosPersonalesCliente(cedula);
        }

        public DataRow ObtenerClientePorCedula(string cedula)
        {
            return obj_cliente.GetClienteCedula(cedula);
        }

        
        public DataTable ObtenerEquiposPorCliente(string cedulaCliente)
        {
            try
            {
                return obj_cliente.ObtenerEquiposPorCliente(cedulaCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener equipos por cliente: " + ex.Message);
            }
        }
        public DataTable ObtenerEquiposPorEstado(string estado)
        {
            try
            {
                return obj_cliente.ObtenerEquiposPorEstado(estado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener equipos por estado: " + ex.Message);
            }
        }
        public DataTable ObtenerEquiposPorEstadoCliente(string cedulaCliente, string estado)
        {
            return obj_cliente.ObtenerEquipoEstadoCliente(cedulaCliente, estado);   
        }



    }
}