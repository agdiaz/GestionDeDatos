using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades.Estadisticas
{
    public class MicroConMasDiasFueraDeServicio : IListadoEstadistico
    {
        public int Id { get; set; }
        public string Patente { get; set; }
        public int DiasFueraServicio { get; set; }
    }
}
