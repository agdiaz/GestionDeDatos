using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using System.Data;

namespace FrbaBus.DAO.Builder
{
    public class MicroBuilder : IBuilder<Micro>
    {
        #region Miembros de IBuilder<Micro>

        public Micro Build(DataRow row)
        {
            return new Micro()
            {
                Marca = row["nombre"].ToString(),
                Servicio = row["tipo_servicio"].ToString(),
                Id = Convert.ToInt32(row["id_micros"].ToString()),
                ButacasDisponibles = Convert.ToInt32(row["butacas_disponibles"].ToString()),
                ButacasTotal = Convert.ToInt32(row["butacas_total"].ToString()),
                ButacasVendidas = Convert.ToInt32(row["butacas_vendidas"].ToString()),
                KgsCapacidad = Convert.ToDecimal(row["capacidad_kg"].ToString()),
                KgsDisponibles = Convert.ToDecimal(row["kgs_disponibles"].ToString()),
                KgsVendidos = Convert.ToDecimal(row["kgs_vendidos"].ToString()),

            };
        }

        #endregion
    }
}
