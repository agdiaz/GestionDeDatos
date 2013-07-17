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

        public IList<Puntaje> Puntajes { get; set; }
        public IList<Canje> Canjes{ get; set; }

        public override string ToString()
        {
            return Nombre + " " + Apellido;
        }

        public Cliente()
        {
            NroDni = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Mail = string.Empty;
            FechaNacimiento = DateTime.MinValue;
            EsDiscapacitado = false;
            Sexo = string.Empty;

            Puntajes = new List<Puntaje>();
            Canjes = new List<Canje>();
        }
    }
}
