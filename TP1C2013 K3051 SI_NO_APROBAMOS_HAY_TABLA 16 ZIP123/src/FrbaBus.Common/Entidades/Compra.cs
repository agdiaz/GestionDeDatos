using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public int IdUsuario { get; set; }
        public int IdCancelacion { get; set; }
        public DateTime FechaCompra { get; set; }

        public IList<Pasaje> Pasajes { get; set; }
        public IList<Encomienda> Encomiendas { get; set; }
        public IList<Puntaje> Puntajes { get; set; }
        public Cancelacion Cancelacion { get; set; }

        public override string ToString()
        {
            return IdCompra.ToString();
        }
    }
}
