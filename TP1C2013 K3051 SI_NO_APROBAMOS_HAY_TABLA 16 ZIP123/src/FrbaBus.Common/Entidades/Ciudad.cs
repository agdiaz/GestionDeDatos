using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Ciudad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }

        public Ciudad()
        {
            Id = 0;
            Nombre = string.Empty;
        }
    }
}
