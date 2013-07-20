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

        public void CompraPasaje(Compra compra, Pasaje pasaje)
        {
            int id = this._dao.CompraPasaje(compra, pasaje);
            pasaje.Id = id;
        }
        
        public void CompraEncomienda(Compra compra, Encomienda encomienda)
        {
            int id = this._dao.CompraEncomienda(compra, encomienda);
            encomienda.IdEncomienda = id;
        }
    }
}
