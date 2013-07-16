using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;

namespace FrbaBus.DAO.Builder
{
    public class CanjeBuilder : IBuilder<Canje>
    {
        #region Miembros de IBuilder<Canje>

        public Canje Build(System.Data.DataRow row)
        {

            Canje c = new Canje();
            c.IdCanje = Convert.ToInt32(row["id_canje"].ToString());
            c.NroDni = Convert.ToDecimal(row["dni"].ToString());
            c.IdRecompensa = Convert.ToInt32(row["id_recompensa"].ToString());

            return c;

        }

        #endregion
    }
}
