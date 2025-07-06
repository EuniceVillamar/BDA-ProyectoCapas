using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace CapaNegocio
{
    public class CL_Persona
    {
        protected int id;
        protected string nombre;
        protected string telefono;
        protected string email;
        protected string cedula;
        public CL_Persona(int id, string nombre, string telefono, string email, string cedula)
        {
            this.id = id;
            this.nombre = nombre;
            this.telefono = telefono;
            this.email = email;
            this.cedula = cedula;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Telefono { get { return telefono; } set { telefono = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Cedula { get { return cedula; } set { cedula = value; } }

        public virtual bool ValidarCedulaExistente(string cedula)
        {
            throw new NotImplementedException("Método no implementado en la clase base.");
        }

        public virtual DataTable ObtenerCedulas()
        {
            throw new NotImplementedException("Método no implementado en la clase base.");
        }

        public virtual DataTable ObtenerDatosPersonales(string cedula)
        {
            throw new NotImplementedException("Método no implementado en la clase base.");
        }
        public virtual bool RegistrarPersona(string cedula, string nombre, string telefono, string email)
        {
            throw new NotImplementedException("Método no implementado en la clase base.");
        }

        public virtual bool UpdatePersona(string cedula, string nombre, string telefono, string email)
        {
            throw new NotImplementedException("Método no implementado en la clase base.");
        }

        public virtual bool DeletePersona(string cedula)
        {
            throw new NotImplementedException("Método no implementado en la clase base.");
        }
    }
}