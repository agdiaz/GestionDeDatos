﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades.Estadisticas
{
    public class ClienteConMasPuntos : IListadoEstadistico
    {
        public int Dni { get; set; }
        public int PuntosTotales { get; set; }
    }
}
