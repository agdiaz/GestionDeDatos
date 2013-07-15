using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class RolUsuario
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public bool Activado { get; set; }
        public bool Inhabilitado { get; set; }

        public IList<Funcionalidad> Funcionalidades { get; set; }
        
        public RolUsuario()
        {
            this.Inhabilitado = false;
            this.Nombre = "En blanco";
            this.Funcionalidades = new List<Funcionalidad>();
        }

        public RolUsuario(string nombre)
        {
            this.Nombre = nombre;
            this.Inhabilitado = false;
            this.Funcionalidades = new List<Funcionalidad>();
        }

        public virtual bool PermiteFuncionalidad(string nombre)
        {
            var cantidad = Funcionalidades.Where(f => (f.Nombre == nombre)).Count();
            return cantidad > 0;
        }
    }
}
