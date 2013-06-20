using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace FrbaBus.Common.Excepciones
{
    public class AccesoBDException : Exception
    {
        public Dictionary<SqlParameter, object> ParametrosUsados { get; set; }
        public string Consulta { get; set; }

        public AccesoBDException(Exception inner)
            : base("Se ha producido un error en la base de datos", inner)
        {
            this.Consulta = string.Empty;
            this.ParametrosUsados = new Dictionary<SqlParameter, object>();
        }

        public AccesoBDException(string consultaRealizada, Exception inner)
            : base("Se ha producido un error en la base de datos", inner)
        {
            this.Consulta = consultaRealizada;
        }

        public AccesoBDException(string consultaRealizada, Dictionary<SqlParameter, object> parametrosUsados, Exception inner)
            : base("Se ha producido un error en la base de datos", inner)
        {
            this.ParametrosUsados = parametrosUsados;
            this.Consulta = consultaRealizada;
        }
    }
}
