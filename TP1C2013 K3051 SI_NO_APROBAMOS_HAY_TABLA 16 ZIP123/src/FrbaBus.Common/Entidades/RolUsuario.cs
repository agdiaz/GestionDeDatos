﻿using System;
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
            this.Funcionalidades = new List<Funcionalidad>();
        }

        public virtual bool PermiteFuncionalidad(string nombre)
        {
            var cantidad = Funcionalidades.Where(f => (f.Nombre == nombre)).Count();
            return cantidad > 0;
        }
    }
}
