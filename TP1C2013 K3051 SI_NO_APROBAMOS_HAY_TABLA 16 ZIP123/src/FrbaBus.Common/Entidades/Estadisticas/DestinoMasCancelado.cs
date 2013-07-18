using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades.Estadisticas
{
    public class DestinoMasCancelado : IListadoEstadistico
    {
        public string Nombre { get; set; }
        public int CantidadPasajesCancelados { get; set; }
    }
}
