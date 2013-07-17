using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Puntaje
    {
        public int IdPuntaje { get; set; }
        public decimal NroDni { get; set; }
        public int Puntos { get; set; }
        public int PuntosUsados { get; set; }
        public DateTime FechaOtorgacion { get; set; }
        public int IdCompra { get; set; }

        public override string ToString()
        {
            return IdPuntaje.ToString();
        }

        public Puntaje()
        {
            IdPuntaje = 0;
            NroDni = 0;
            Puntos = 0;
            PuntosUsados = 0;
            FechaOtorgacion = DateTime.MinValue.AddMilliseconds(1);
            IdCompra = 0;
        }
    }
}
