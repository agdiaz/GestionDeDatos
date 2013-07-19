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
        public string Informacion { get { return "Piso " + Piso.ToString() + " - Nro " + NroButaca.ToString() + " - " + TipoButaca; } }

        public override string ToString()
        {
            if (NroButaca > 0 && Piso > 0 && !string.IsNullOrEmpty(TipoButaca))
                return Informacion;
            else
                return string.Empty;
        }

        public Butaca()
        {
            Id = 0;
            NroButaca = 0;
            IdMicro = 0;
            TipoButaca = string.Empty;
            Piso = 0;
        }
    }
}
