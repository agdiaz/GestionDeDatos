using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Cancelacion
    {
        public int IdCancelacion { get; set; }
        public DateTime FechaCancelacion { get; set; }
        public string Motivo { get; set; }

        public override string ToString()
        {
            return IdCancelacion.ToString();
        }

        public Cancelacion()
        {
            IdCancelacion = 0;
            FechaCancelacion = DateTime.MinValue;
            Motivo = string.Empty;
        }
    }
}
