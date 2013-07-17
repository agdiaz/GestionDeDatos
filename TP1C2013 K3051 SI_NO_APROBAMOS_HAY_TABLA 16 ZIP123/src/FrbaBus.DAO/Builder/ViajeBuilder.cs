using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;

namespace FrbaBus.DAO.Builder
{
    public class ViajeBuilder : IBuilder<Viaje>
    {
        #region Miembros de IBuilder<Viaje>

        public Viaje Build(System.Data.DataRow row)
        {
            Viaje v = new Viaje();

            v.Id = Convert.ToInt32(row["id_viaje"].ToString());
            v.IdRecorrido = Convert.ToInt32(row["id_recorrido"].ToString());
            v.IdMicro = Convert.ToInt32(row["id_micro"].ToString());
            v.FechaSalida = Convert.ToDateTime(row["fecha_salida"].ToString());
            v.FechaArriboEstimada = Convert.ToDateTime(row["fecha_arribo_estimada"].ToString());
            v.FechaArribo = Convert.ToDateTime(row["fecha_arribo"].ToString());

            return v;
        }

        #endregion
    }
}
