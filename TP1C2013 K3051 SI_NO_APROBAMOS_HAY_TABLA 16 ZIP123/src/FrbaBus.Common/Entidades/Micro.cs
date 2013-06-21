using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Micro
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public int ButacasTotal { get; set; }
        public int ButacasVendidas { get; set; }
        public int ButacasDisponibles { get; set; }
        public decimal KgsCapacidad { get; set; }
        public decimal KgsVendidos { get; set; }
        public decimal KgsDisponibles { get; set; }
        public string Servicio { get; set; }
    }
}
