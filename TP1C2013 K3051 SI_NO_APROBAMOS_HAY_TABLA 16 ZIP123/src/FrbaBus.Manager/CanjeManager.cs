using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.DAO;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Manager
{
    public class CanjeManager
    {
        private CanjeDAO _dao;
        public CanjeManager()
        {
            _dao = new CanjeDAO();
        }

        public Canje Obtener(int id)
        {
            return _dao.Obtener(id);
        }

        public IList<Canje> ListarPorCliente(int idCliente)
        {
            return _dao.ListarPorCliente(idCliente);
        }
    }
}
