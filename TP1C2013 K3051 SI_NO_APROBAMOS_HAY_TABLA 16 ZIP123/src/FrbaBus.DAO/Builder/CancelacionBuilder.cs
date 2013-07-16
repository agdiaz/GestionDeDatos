using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using System.Data;

namespace FrbaBus.DAO.Builder
{
    public class CancelacionBuilder : IBuilder<Cancelacion>
    {
        #region Miembros de IBuilder<Cancelacion>

        public Cancelacion Build(DataRow row)
        {

            Cancelacion c = new Cancelacion();
            c.IdCancelacion = Convert.ToInt32(row["id_cancelacion"].ToString());
            c.FechaCancelacion = Convert.ToDateTime(row["fecha_cancel"].ToString());
            c.Motivo = row["motivo_cancel"].ToString();
            
            return c;

        }

        #endregion
    }
}
