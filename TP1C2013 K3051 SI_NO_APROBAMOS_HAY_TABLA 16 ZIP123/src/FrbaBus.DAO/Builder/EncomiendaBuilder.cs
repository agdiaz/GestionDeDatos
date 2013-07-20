using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;

namespace FrbaBus.DAO.Builder
{
    public class EncomiendaBuilder : IBuilder<Encomienda>
    {
        #region Miembros de IBuilder<Encomienda>

        public Encomienda Build(System.Data.DataRow row)
        {
            Encomienda e = new Encomienda();

            e.IdEncomienda = Convert.ToInt32(row["id_encomienda"].ToString());
            e.IdCancelacion = Convert.ToInt32(row["id_cancelacion"].ToString());
            e.IdViaje = Convert.ToInt32(row["id_viaje"].ToString());
            e.IdCompra = Convert.ToInt32(row["id_compra"].ToString());
            e.NroDni = Convert.ToDecimal(row["dni"].ToString());
            e.Peso = Convert.ToDecimal(row["peso"].ToString());
            e.PrecioEncomienda = Convert.ToDecimal(row["pre_encomienda"].ToString());

            return e;
        }

        #endregion
    }
}
