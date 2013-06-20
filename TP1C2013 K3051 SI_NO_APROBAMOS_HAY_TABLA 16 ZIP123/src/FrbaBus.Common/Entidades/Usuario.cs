using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Usuario
    {
        public string Username { get; set; }
        public RolUsuario RolAsignado { get; set; }

        public Usuario()
        {
            this.Username = "En blanco";
        }

        public Usuario(string username)
        {
            this.Username = username;
        }
    }

}
