using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using System.Data;

namespace FrbaBus.DAO.Builder
{
    public class ClienteBuilder : IBuilder<Cliente>
    {
        #region Miembros de IBuilder<ClienteBuilder>

        public Cliente Build(DataRow row)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
