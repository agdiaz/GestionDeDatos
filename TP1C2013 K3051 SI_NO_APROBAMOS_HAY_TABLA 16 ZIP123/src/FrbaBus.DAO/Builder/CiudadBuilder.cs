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
            Ciudad c = new Ciudad();
            
            c.Id = Convert.ToInt32(row["id_ciudad"].ToString());
            c.Nombre = row["nombre"].ToString();

            return c;
        }

        #endregion
    }
}
