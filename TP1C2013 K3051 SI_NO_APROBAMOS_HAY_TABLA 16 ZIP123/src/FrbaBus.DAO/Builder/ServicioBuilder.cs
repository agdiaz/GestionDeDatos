using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;

namespace FrbaBus.DAO.Builder
{
    public class ServicioBuilder : IBuilder<Servicio>
    {
        #region Miembros de IBuilder<Servicio>

        public Servicio Build(System.Data.DataRow row)
        {
            Servicio s = new Servicio()
            {
                Id = Convert.ToInt32(row["id_servicio"].ToString()),
                TipoServicio = row["tipo_servicio"].ToString(),
                Adicional = Convert.ToDecimal(row["pocent_adic"].ToString())
            };
            return s;
        }

        #endregion
    }
}
