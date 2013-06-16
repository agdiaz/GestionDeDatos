using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class RolUsuarioAdministrativo : RolUsuario
    {
        public RolUsuarioAdministrativo()
        {
            this.Nombre = "Administrativo";
        }
        public override bool PermiteFuncionalidad(string nombre)
        {
            return true;
        }
    }
}
