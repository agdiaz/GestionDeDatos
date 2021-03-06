﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Recorrido
    {
        public int Id { get; set; }

        public int IdCiudadOrigen { get; set; }
        public int IdCiudadDestino { get; set; }
        public int IdServicio { get; set; }

        public Ciudad CiudadOrigen { get; set; }
        public Ciudad CiudadDestino { get; set; }
        public Servicio Servicio { get; set; }

        public decimal PrecioBaseKG { get; set; }
        public decimal PrecioBasePasaje { get; set; }
        public string Informacion { get { return this.ToString(); } }

        public Recorrido()
        {
            Id = 0;
            IdCiudadDestino = 0;
            IdCiudadOrigen = 0;
            IdServicio = 0;

            CiudadDestino = new Ciudad();
            CiudadOrigen = new Ciudad();

            Servicio = new Servicio();
            PrecioBaseKG = 0;
            PrecioBasePasaje = 0;
        }
     

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(CiudadOrigen.Nombre) && !string.IsNullOrEmpty(CiudadDestino.Nombre) && !string.IsNullOrEmpty(Servicio.TipoServicio))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("({0}) - {1} -> {2}", Servicio.TipoServicio, CiudadOrigen.Nombre, CiudadDestino.Nombre);
                return sb.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
