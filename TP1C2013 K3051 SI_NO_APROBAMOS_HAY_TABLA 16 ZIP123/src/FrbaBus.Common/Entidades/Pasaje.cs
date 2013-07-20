using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Pasaje
    {
        public decimal Id { get; set; }
        public int IdCancelacion { get; set; }
        public int IdViaje { get; set; }
        public int IdCompra { get; set; }
        public int IdButaca { get; set; }
        public decimal NroDni { get; set; }
        public decimal PrecioPasaje { get; set; }
        public bool Disponible { get; set; }
        public bool Cancel { get; set; }

        public Cancelacion Cancelacion{ get; set; }
        public Butaca Butaca { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }

        public Pasaje()
        {
            Id = 0;
            IdCancelacion = 0;
            IdViaje = 0;
            IdCompra = 0;
            IdButaca = 0;
            NroDni = 0;
            PrecioPasaje = 0;
            Disponible = false;
            Cancel = false;

            Cancelacion = new Cancelacion();
            Butaca = new Butaca();
        }
    }
}
