using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Viaje
    {
        public int Id { get; set; }
        public int IdRecorrido { get; set; }
        public int IdMicro { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaArriboEstimada { get; set; }
        public DateTime FechaArribo { get; set; }

        public Recorrido Recorrido { get; set; }
        public Micro Micro { get; set; }

        public IList<Pasaje> Pasajes { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
