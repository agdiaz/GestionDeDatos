﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Entidades
{
    public class Micro
    {
        public int Id { get; set; }
        public DateTime FechaAlta { get; set; }
        public int NumeroDeMicro { get; set; }
        public string Modelo { get; set; }
        public string Patente { get; set; }
        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }
        public string Marca { get { return Empresa.Descripcion; } }
        public int IdServicio { get; set; }
        public DateTime? FechaBajaVidaUtil { get; set; }
        public int ButacasTotal { get; set; }
        public int ButacasVendidas { get; set; }
        public int ButacasDisponibles { get; set; }
        public decimal KgsCapacidad { get; set; }
        public decimal KgsVendidos { get; set; }
        public decimal KgsDisponibles { get; set; }
        public string Informacion { get { return ToString(); } }
        public Servicio Servicio { get; set; }
        public IList<Butaca> Butacas { get; set; }
        public bool BajaVidaUtil { get; set; }
        public override string ToString()
        {
            return Empresa.Descripcion + " - Pat: " + Patente + " - Serv: " + Servicio.TipoServicio;
        }

        public Micro()
        {
            Id = 0;
            FechaAlta = DateTime.MinValue.AddMilliseconds(1);
            NumeroDeMicro = 0;
            Modelo = string.Empty;
            Patente = string.Empty;
            
            IdEmpresa = 0;
            Empresa = new Empresa();
            IdServicio = 0;
            FechaBajaVidaUtil = null;

            Servicio = new Servicio();
            Butacas = new List<Butaca>();
        }
    }
}
