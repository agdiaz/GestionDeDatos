using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using System.Data;

namespace FrbaBus.DAO.Builder
{
    class CiudadBuilder : IBuilder<Ciudad>
    {
        #region Miembros de IBuilder<Ciudad>

        public Ciudad Build(DataRow row)
        {
            return new Ciudad()
            {
                Nombre = row["nombre"].ToString(),
                Id = Convert.ToInt32(row["id_ciudad"])
            };
        }

        #endregion
    }
}
