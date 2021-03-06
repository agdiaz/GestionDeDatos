﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Funcionalidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activa { get; set; }

        public override string ToString()
        {
            return Nombre;
        }

        public Funcionalidad()
        {
            Id = 0;
            Nombre = string.Empty;
            Activa = false;
        }
    }
}
