using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;

namespace FrbaBus.DAO.Builder
{
    public class PasajeBuilder : IBuilder<Pasaje>
    {
        #region Miembros de IBuilder<Pasaje>

        public Pasaje Build(System.Data.DataRow row)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
