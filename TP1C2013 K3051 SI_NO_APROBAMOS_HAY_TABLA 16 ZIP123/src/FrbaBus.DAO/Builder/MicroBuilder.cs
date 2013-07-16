﻿using System;
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
                IdServicio = Convert.ToInt32(row["id_servicio"].ToString()),
                Id = Convert.ToInt32(row["id_micros"].ToString()),
                ButacasDisponibles = 0,//Convert.ToInt32(row["butacas_disponibles"].ToString()),
                ButacasTotal = 0,//Convert.ToInt32(row["butacas_total"].ToString()),
                ButacasVendidas = 0,//Convert.ToInt32(row["butacas_vendidas"].ToString()),
                KgsCapacidad = Convert.ToDecimal(row["capacidad_kg"].ToString()),
                KgsDisponibles = 0,//Convert.ToDecimal(row["kgs_disponibles"].ToString()),
                KgsVendidos = 0//Convert.ToDecimal(row["kgs_vendidos"].ToString()),

            };
        }

        #endregion
    }
}
