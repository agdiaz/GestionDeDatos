using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Excepciones
{
    public class AccesoBDException : Exception
    {
        public Dictionary<string, object> ParametrosUsados { get; set; }
        public string Consulta { get; set; }

        public AccesoBDException(Exception inner)
            : base("Se ha producido un error en la base de datos", inner)
        {
            this.Consulta = string.Empty;
            this.ParametrosUsados = new Dictionary<string, object>();
        }

        public AccesoBDException(string consultaRealizada, Exception inner)
            : base("Se ha producido un error en la base de datos", inner)
        {
            this.Consulta = consultaRealizada;
        }

        public AccesoBDException(string consultaRealizada, Dictionary<string, object> parametrosUsados, Exception inner)
            : base("Se ha producido un error en la base de datos", inner)
        {
            this.ParametrosUsados = parametrosUsados;
            this.Consulta = consultaRealizada;
        }
    }
}
