using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Butaca
    {
        public int Id { get; set; }
        public decimal NroButaca { get; set; }
        public int IdMicro { get; set; }
        public string TipoButaca { get; set; }
        public decimal Piso { get; set; }

        public override string ToString()
        {
            return NroButaca.ToString();
        }
    }
}
