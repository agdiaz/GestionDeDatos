using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Canje
    {
        public int IdCanje { get; set; }
        public decimal NroDni { get; set; }
        public int IdRecompensa { get; set; }

        public IList<Recompensa> Recomensa{ get; set; }
    }
}
