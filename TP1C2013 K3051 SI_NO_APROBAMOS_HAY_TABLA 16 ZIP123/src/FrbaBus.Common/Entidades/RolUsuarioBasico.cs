using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class RolUsuarioBasico : RolUsuario
    {
        public RolUsuarioBasico()
        {
            this.Funcionalidades = new List<Funcionalidad>();
            this.Funcionalidades.Add(new Funcionalidad() { Nombre = "tsmClienteAlta" });
            this.Funcionalidades.Add(new Funcionalidad() { Nombre = "tsmClientePasajeroFrecuenteConsultar" });
            this.Funcionalidades.Add(new Funcionalidad() { Nombre = "tsmEncomiendaAlta" });
        }
    }
}
