using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using System.Data;

namespace FrbaBus.DAO.Builder
{
    public class EmpresaBuilder : IBuilder<Empresa>
    {
        #region Miembros de IBuilder<Empresa>

        public Empresa Build(DataRow row)
        {
            return new Empresa()
            {
                Id = Convert.ToInt32(row["id_marca"].ToString()),
                Descripcion = row["nombre"].ToString()
            };
        }

        #endregion
    }
}
