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
            throw new NotImplementedException();
        }

        #endregion
    }
}
