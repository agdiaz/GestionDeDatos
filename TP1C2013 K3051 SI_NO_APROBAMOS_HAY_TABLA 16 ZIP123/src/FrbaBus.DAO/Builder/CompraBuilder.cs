using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;

namespace FrbaBus.DAO.Builder
{
    public class CompraBuilder :IBuilder<Compra>
    {
        #region Miembros de IBuilder<Compra>

        public Compra Build(System.Data.DataRow row)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
