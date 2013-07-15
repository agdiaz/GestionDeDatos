using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using System.Data;

namespace FrbaBus.DAO.Builder
{
    class ButacaBuilder : IBuilder<Butaca>
    {
        #region Miembros de IBuilder<Butaca>

        public Butaca Build(DataRow row)
        {
            Butaca b = new Butaca();
            b.Id = Convert.ToInt32(row["id_butaca"].ToString());
            b.NroButaca = Convert.ToDecimal(row["nro_butaca"].ToString());
            b.IdMicro = Convert.ToInt32(row["id_micro"].ToString());
            b.TipoButaca = row["tipo_butaca"].ToString();
            b.Piso = Convert.ToDecimal(row["piso"].ToString());
            
            return b;
        }

        #endregion
    }
}
