using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace FrbaBus.Common.Excepciones
{
    public class AccesoBDException : Exception
    {
        public override string Message
        {
            get
            {
                string mensaje = "Se ha producido un error en la base de datos.";
                mensaje += "\nConsulta realizada: " + this.Consulta;
                mensaje += "\nParametros usados: ";
                foreach (var item in this.ParametrosUsados)
                {
                    mensaje += "\n\tNombre del parámetro: " + item.Key.ParameterName;
                    mensaje += "\tValor: " + item.Value.ToString();
                }

                mensaje += "\nMensaje interno del error:\n" + this.InnerException.Message;
                return mensaje;
            }
        }

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
