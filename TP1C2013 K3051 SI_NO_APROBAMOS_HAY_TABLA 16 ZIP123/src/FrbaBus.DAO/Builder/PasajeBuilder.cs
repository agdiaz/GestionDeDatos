using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using System.Data;

namespace FrbaBus.DAO.Builder
{
    public class PasajeBuilder : IBuilder<Pasaje>
    {
        #region Miembros de IBuilder<Pasaje>

        public Pasaje Build(System.Data.DataRow row)
        {
            Pasaje p = new Pasaje();

            p.Id = Convert.ToInt32(row["id_pasaje"].ToString());
            p.IdCompra = Convert.ToInt32(row["id_compra"].ToString());
            p.IdButaca = Convert.ToInt32(row["id_butaca"].ToString());
            p.IdViaje = Convert.ToInt32(row["id_viaje"].ToString());
            //p.IdCompra = Convert.ToInt32(row["id_compra"].ToString());
            p.NroDni = Convert.ToDecimal(row["dni"].ToString());
            p.PrecioPasaje = Convert.ToDecimal(row["pre_pasaje"].ToString());
            p.Disponible = Convert.ToBoolean(row["disponible"].ToString());
            p.Cancel = Convert.ToBoolean(row["cancel"].ToString());

            return p;
        }

        #endregion

        public decimal BuildPrecio(DataRow row)
        {
            decimal precio = Convert.ToDecimal(row["precio"].ToString());
            return precio;
        }

    }
}
