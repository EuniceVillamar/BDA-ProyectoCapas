using System;
using System.Collections.Generic;
using System.Data;
using CapaDatos.Interface;

namespace CapaNegocio
{
    public class CL_Tecnico : CL_Persona
    {
        private List<CL_Movil> equipos;
        public List<CL_Reparacion> ReparacionesAsignadas { get; set; }
        private CL_InterfaceTecnico obj_tecnico = new CL_InterfaceTecnico();
        public CL_Tecnico(int id, string nombre, string telefono, string email, string cedula)
            : base(id, nombre, telefono, email, cedula)
        {
            equipos = new List<CL_Movil>();
            ReparacionesAsignadas = new List<CL_Reparacion>();
        }

        public List<CL_Movil> Equipos
        {
            get { return equipos; }
        }

        public DataTable ObtenerTecnicos()
        {
            return obj_tecnico.GetAllTecnicos();
        }

        

        public bool AsignarEquipoATecnico(int codigoTecnico, CL_Movil equipo)
        {
            if (codigoTecnico <= 0)
                throw new ArgumentException("El código del técnico no puede ser menor o igual a cero.");
            if (equipo == null)
                throw new ArgumentException("El equipo no puede ser nulo.");

            equipos.Add(equipo);

            return obj_tecnico.AssignEquipoToTecnico(codigoTecnico, equipo.CodigoEquipo, equipo.CedulaTecnico, equipo.IMEI);
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

            return obj_tecnico.CreateTecnico(cedula, nombre, telefono, email);
        }

        public override bool UpdatePersona(string cedula, string nombre, string telefono, string email)
        {
            return obj_tecnico.UpdateTecnico(cedula, nombre, telefono, email);
        }

        public override bool DeletePersona(string cedula)
        {
            return obj_tecnico.DeleteTecnico(cedula);
        }


        public override bool ValidarCedulaExistente(string cedula)
        {
            return obj_tecnico.ExisteCedula(cedula);
        }

        public override DataTable ObtenerCedulas()
        {
            return obj_tecnico.GetCedulasTecnicos();
        }


        public override DataTable ObtenerDatosPersonales(string cedula)
        {
            return obj_tecnico.ObtenerDatosPersonalesTecnico(cedula);
        }
        public DataRow ObtenerTecnicoPorCedula(string cedula)
        {
            return obj_tecnico.GetTecnicoCedula(cedula);
        }
        //NUEVAS OPCIONES

        public DataTable ObtenerEquiposAsignados(string cedulaTecnico)
        {
            return obj_tecnico.GetEquiposAsignados(cedulaTecnico);
        }
        public DataTable ObtenerTecnicosPaginado(int idReparacion, int pagina, int tecnicosPorPagina)
        {
            return obj_tecnico.GetTecnicosPaginado(idReparacion, pagina, tecnicosPorPagina);

        }

    }
}
