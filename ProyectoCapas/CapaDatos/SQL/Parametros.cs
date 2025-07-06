using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace CapaDatos.SQL
{
    public class Parametros
    {
        private string _nombre;
        private SqlDbType _tipoDato;
        private object _valor;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public SqlDbType TipoDato
        {
            get { return _tipoDato; }
            set { _tipoDato = value; }
        }
        public object Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
        public Parametros(string nombre, SqlDbType tipoDato, object valor)
        {
            _nombre = nombre;
            _tipoDato = tipoDato;
            _valor = valor;
        }
    }
}

