﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.DAO;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Manager
{
    public class ButacaManager
    {
        private ButacaDAO _dao;

        public ButacaManager()
        {
            this._dao = new ButacaDAO();
        }

        public Butaca Obtener(int id)
        {
            return this._dao.Obtener(id);
        }

        public Butaca Alta(Butaca butaca)
        {
            int id = _dao.Alta(butaca);
            butaca.Id = id;
            return butaca;
        }

        public IList<Butaca> Listar(Micro micro)
        {
            return _dao.Listar(micro.Id);
        }

        public IList<Butaca> ObtenerButacasMicro(Micro m)
        {
            return new List<Butaca>();
        }

        public IList<Butaca> ListarLibres(Viaje viaje)
        {
            return _dao.ListarLibres(viaje);
        }

        public IList<Butaca> ListarOcupadas(Viaje viaje)
        {
            return _dao.ListarOcupadas(viaje);
        }
    }
}
