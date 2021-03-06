﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public decimal NroDni { get; set; }
        public string Username { get; set; }
        public byte[] HashPassword { get; set; }

        public RolUsuario RolAsignado { get; set; }
        
        public Usuario()
        {
            IdUsuario = 0;
            IdRol = 0;
            NroDni = 0;
            Username = "En blanco";
            HashPassword = new byte[1] { Byte.MinValue };
        }

        public Usuario(string username)
        {
            this.Username = username;
        }

        public override string ToString()
        {
            return Username;
        }
    }

}
