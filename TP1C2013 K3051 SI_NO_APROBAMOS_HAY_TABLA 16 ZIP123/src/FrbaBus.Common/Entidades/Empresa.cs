using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }

        public Empresa()
        {
            Id = 0;
            Descripcion = string.Empty;
        }
    }
}
