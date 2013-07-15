using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using System.Data;

namespace FrbaBus.DAO.Builder
{
    public class RecorridoBuilder : IBuilder<Recorrido>
    {
        #region Miembros de IBuilder<Recorrido>

        public Recorrido Build(DataRow row)
        {
            return new Recorrido()
            {
                Id = Convert.ToInt32(row["id_recorrido"].ToString()),
                IdCiudadOrigen = Convert.ToInt32(row["id_ciudad_origen"].ToString()),
                IdCiudadDestino = Convert.ToInt32(row["id_ciudad_destino"].ToString()),
                IdServicio = Convert.ToInt32(row["id_servicio"].ToString()),
                PrecioBaseKG = Convert.ToDecimal(row["pre_base_kg"].ToString()),
                PrecioBasePasaje = Convert.ToDecimal(row["pre_base_pasaje"].ToString())
            };
        }

        #endregion
    }
}
