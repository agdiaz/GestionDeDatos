using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Cliente
    {
        public decimal NroDni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool EsDiscapacitado { get; set; }
        public string Sexo { get; set; }

        public IList<Puntaje> Puntaje { get; set; }
        public IList<Canje> Canjes{ get; set; }
    }
}
