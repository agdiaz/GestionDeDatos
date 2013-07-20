using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.DAO;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Manager
{
    public class PasajeManager
    {
        private PasajeDAO _dao;
        public PasajeManager()
        {
            _dao = new PasajeDAO();
        }

        public decimal BuscarPrecio(Recorrido recorrido, decimal nroDni)
        {
            return _dao.BuscarPrecio(recorrido, nroDni);
        }
    }
}
