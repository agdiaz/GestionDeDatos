using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Recompensa
    {
        public int IdRecompensa { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public int Puntos { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }

        public Recompensa()
        {
            IdRecompensa = 0;
            Descripcion = string.Empty;
            Stock = 0;
            Puntos = 0;
        }
    }
}
