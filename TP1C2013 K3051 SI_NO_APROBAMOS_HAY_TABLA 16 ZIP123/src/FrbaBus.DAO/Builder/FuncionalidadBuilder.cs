using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using System.Data;

namespace FrbaBus.DAO.Builder
{
    public class FuncionalidadBuilder : IBuilder<Funcionalidad>
    {
        #region Miembros de IBuilder<Funcionalidad>

        public Funcionalidad Build(DataRow row)
        {
            var func = new Funcionalidad();
            
            if (row["id_funcionalidad"] != null)
            {
                func.Id = Convert.ToInt32(row["id_funcionalidad"].ToString());
            }
            if (row["funcionalidad"] != null)
            {
                func.Nombre = row["funcionalidad"].ToString();
            }
            func.Activa = true;

            return func;
        }

        #endregion
    }
}
