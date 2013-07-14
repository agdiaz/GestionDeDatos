using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades.Estadisticas
{
    public class Semestre
    {

        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }

        public string Periodo 
        { 
            get
            {
                string sIni = Inicio.ToString("yyyy/MM");
                string sFin = Fin.ToString("yyyy/MM");

                return string.Format("Desde {0} - Hasta {1}", sIni, sFin);
            } 
        }

        public override string ToString()
        {
            return Periodo;
        }
    }
}
