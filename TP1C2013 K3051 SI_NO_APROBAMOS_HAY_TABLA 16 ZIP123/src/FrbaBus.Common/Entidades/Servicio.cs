using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Servicio
    {
        public int Id { get; set; }
        public string TipoServicio { get; set; }
        public decimal Adicional { get; set; }

        public override string ToString()
        {
            return TipoServicio;
        }

        public Servicio()
        {
            Id = 0;
            TipoServicio = string.Empty;
            Adicional = 0;
        }
    }
}
