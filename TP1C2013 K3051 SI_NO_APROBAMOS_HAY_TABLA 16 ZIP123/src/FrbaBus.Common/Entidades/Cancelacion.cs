﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Cancelacion
    {
        public int IdCancelacion { get; set; }
        public DateTime FechaCancelacion { get; set; }
        public string Motivo { get; set; }
    }
}