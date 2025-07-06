using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Interface;

namespace CapaNegocio
{
    public class CL_Login
    {
        private CL_InterfaceLogin obj_login = new CL_InterfaceLogin();

        public bool ValidarCredenciales(string username, string password)
        {
            return obj_login.ValidarCredenciales(username, password);
        }

        public bool ExisteUsuario(string username)
        {
            return obj_login.ExisteUsuario(username);
        }
        public bool RegistrarUsuario(string username, string password)
        {
            return obj_login.RegistrarUsuario(username, password);
        }
    }
}
