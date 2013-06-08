﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public long DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public bool EsDiscapacitado { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}