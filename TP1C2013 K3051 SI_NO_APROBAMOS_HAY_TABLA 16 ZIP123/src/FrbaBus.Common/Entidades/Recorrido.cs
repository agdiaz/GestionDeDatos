using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Recorrido
    {
        public int Id { get; set; }
        public int IdCiudadOrigen { get; set; }
        public Ciudad CiudadOrigen { get; set; }
        public int IdCiudadDestino { get; set; }
        public Ciudad CiudadDestino { get; set; }
        public decimal PrecioBaseKG { get; set; }
        public decimal PrecioBasePasaje { get; set; }
        public int IdServicio { get; set; }
        public Servicio Servicio { get; set; }
    }
}
