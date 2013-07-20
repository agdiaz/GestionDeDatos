using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.DAO;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Manager
{
    public class CompraManager
    {
        private CompraDAO _dao;

        public CompraManager()
        {
            this._dao = new CompraDAO();
        }

        public Compra Alta(Compra compra)
        {
            int id = this._dao.Alta(compra);
            compra.IdCompra = id;
            return compra;
        }
    }
}
