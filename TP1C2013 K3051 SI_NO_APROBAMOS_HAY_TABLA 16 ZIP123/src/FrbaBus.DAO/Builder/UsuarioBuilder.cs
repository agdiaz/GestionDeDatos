using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using System.Data;

namespace FrbaBus.DAO.Builder
{
    public class UsuarioBuilder : IBuilder<Usuario>
    {
        #region Miembros de IBuilder<UsuarioBuilder>

        public Usuario Build(DataRow row)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
