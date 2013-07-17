using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.DAO;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Manager
{
    public class ViajeManager
    {
        private ViajeDAO _dao;

        public ViajeManager()
        {
            _dao = new ViajeDAO();
        }

        public IList<Viaje> Listar()
        {
            return _dao.Listar();
        }
    }
}
