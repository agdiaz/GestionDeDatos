using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class RolUsuario
    {
        public string Nombre { get; set; }
        public IList<Funcionalidad> Funcionalidades { get; set; }

        public RolUsuario()
        {
            this.Nombre = "En blanco";
        }
    }
}
