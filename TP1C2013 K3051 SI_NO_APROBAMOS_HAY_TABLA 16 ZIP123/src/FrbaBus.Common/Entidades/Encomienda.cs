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
        public string Informacion { get { return this.ToString(); } }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Peso: {0} - Cliente: {1}", Peso, NroDni);
            return sb.ToString();
        }

        public Encomienda()
        {
            IdEncomienda = 0;
            IdCancelacion = 0;
            IdViaje = 0;
            IdCompra = 0;
            NroDni = 0;
            Peso = 0;
            PrecioEncomienda = 0;

        }
    }
}
