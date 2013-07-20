using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using FrbaBus.DAO;

namespace FrbaBus.Manager
{
    public class CancelacionManager
    {
        private CancelacionDAO _dao;
        public CancelacionManager()
        {
            _dao = new CancelacionDAO();
        }

        public void CancelarCompra(Compra compra, string motivo)
        {
            _dao.CancelarCompra(compra, motivo);
        }

        public void CancelarPasaje(Pasaje pasaje, string motivo)
        {
            _dao.CancelarPasaje(pasaje, motivo);
        }

        public void CancelarEncomienda(Encomienda encomienda, string motivo)
        {
            _dao.CancelarEncomienda(encomienda, motivo);
        }
    }
}
