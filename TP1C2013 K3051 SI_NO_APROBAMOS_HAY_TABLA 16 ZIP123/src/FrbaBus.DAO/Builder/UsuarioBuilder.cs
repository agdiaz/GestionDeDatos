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
            Usuario u = new Usuario();

            u.IdUsuario = Convert.ToInt32(row["id_usuario"].ToString());
            u.IdRol = Convert.ToInt32(row["id_rol"].ToString());
            u.NroDni= Convert.ToDecimal(row["dni"].ToString());
            u.Username = row["username"].ToString();
//            u.HashPassword = Convert.ToByte(row["hash_password"].ToString()); 

            return u;
        }

        #endregion
    }
}
