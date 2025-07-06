using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Interface;

namespace CapaNegocio{
    public class CL_Provincia {
        private int id;
        private string nombre;
        private decimal poblacion;
        private decimal extension;
        private char estado;
        private CL_InterfaceProvincia obj_bd = new CL_InterfaceProvincia();
        public CL_Provincia() {
            id = 0;
            nombre = string.Empty;
            poblacion = 0;
            extension = 0;
            estado = 'A';
        }

        public CL_Provincia(int id, string nombre, decimal poblacion, decimal extension, char estado) {
            this.id = id;
            this.nombre = nombre;
            this.poblacion = poblacion;
            this.extension = extension;
            this.estado = estado;
        }
        public int Id {
            get { return id; } set { id = value; }
        }

        public string Nombre {
            get { return nombre; } set { nombre = value; }
        }

        public decimal Poblacion {
            get { return poblacion; } set { poblacion = value; }
        }

        public decimal Extension {
            get { return extension; } set { extension = value; }
        }

        public char Estado {
            get { return estado; } set { estado = value; }
        }
        public bool CreateProvincia(CL_Provincia provincia) {
            return obj_bd.CreateProvincia(provincia.Nombre, provincia.Poblacion, provincia.Extension);
        }

        public DataTable GetAllProvincias(){
            return obj_bd.GetAllProvincias();
        }
    }
}
