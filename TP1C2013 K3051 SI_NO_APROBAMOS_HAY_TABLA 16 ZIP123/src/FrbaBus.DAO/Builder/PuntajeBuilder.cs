using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;

namespace FrbaBus.DAO.Builder
{
    public class PuntajeBuilder : IBuilder<Puntaje>
    {
        #region Miembros de IBuilder<Puntaje>

        public Puntaje Build(System.Data.DataRow row)
        {
            Puntaje p = new Puntaje();

            p.NroDni = Convert.ToDecimal(row["dni"].ToString());
            p.Puntos = Convert.ToInt32(row["puntos"].ToString());
            p.PuntosUsados= Convert.ToInt32(row["dni"].ToString());
            p.FechaOtorgacion= Convert.ToDateTime(row["fecha_otorgado"].ToString());
            p.IdPuntaje= Convert.ToInt32(row["id_puntaje"].ToString());
            p.IdCompra = Convert.ToInt32(row["id_compra"].ToString());

            return p;
        }

        #endregion
    }
}
