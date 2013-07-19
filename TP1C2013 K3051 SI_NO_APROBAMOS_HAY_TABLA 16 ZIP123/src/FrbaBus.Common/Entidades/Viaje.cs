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

        public string Informacion { get { return FechaSalida.ToShortDateString() + " - " + FechaArriboEstimada.ToShortDateString(); } }

        public override string ToString()
        {
            return Informacion;
        }

        public Viaje()
        {
            Id = 0;
            IdRecorrido = 0;
            IdMicro = 0;
            FechaSalida = DateTime.MinValue.AddMilliseconds(1);
            FechaArribo = DateTime.MinValue.AddMilliseconds(1);
            FechaArriboEstimada = DateTime.MinValue.AddMilliseconds(1);

            Recorrido = new Recorrido();
            Micro = new Micro();

            Pasajes = new List<Pasaje>();
        }
    }
}
