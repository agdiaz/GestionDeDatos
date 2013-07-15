using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;

namespace FrbaBus.DAO.Builder
{
    public class RolUsuarioBuilder : IBuilder<RolUsuario>
    {
        #region Miembros de IBuilder<RolUsuario>

        public RolUsuario Build(System.Data.DataRow row)
        {
            return new RolUsuario()
            {
                IdRol = Convert.ToInt32(row["id_rol"].ToString()),
                Nombre = row["nombre"].ToString()
            };
        }

        #endregion
    }
}
