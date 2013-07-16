using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;

namespace FrbaBus.DAO.Builder
{
    public class RecompensaBuilder : IBuilder<Recompensa>
    {
        #region Miembros de IBuilder<Recompensa>

        public Recompensa Build(System.Data.DataRow row)
        {
            Recompensa r = new Recompensa();

            r.IdRecompensa = Convert.ToInt32(row["id_recompensa"].ToString());
            r.Descripcion = row["descripcion"].ToString();
            r.Stock = Convert.ToInt32(row["stock"].ToString());
            r.Costo = Convert.ToInt32(row["puntos_costo"].ToString());

            return r;
        }

        #endregion
    }
}
