using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Encomienda
    {
        public int IdEncomienda { get; set; }
        public int IdCancelacion { get; set; }
        public int IdViaje { get; set; }
        public int IdCompra { get; set; }
        public decimal NroDni { get; set; }
        public decimal Peso { get; set; }
        public decimal PrecioEncomienda { get; set; }

        public override string ToString()
        {
            return IdEncomienda.ToString();
        }
    }
}
