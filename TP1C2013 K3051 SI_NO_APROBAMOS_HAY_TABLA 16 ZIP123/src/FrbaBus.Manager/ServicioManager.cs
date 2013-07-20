using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.DAO;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Manager
{
    public class ServicioManager
    {
        private ServicioDAO _dao;
        
        public ServicioManager()
        {
            _dao = new ServicioDAO();
        }

        public Servicio Obtener(int id)
        {
            return _dao.Obtener(id);
        }

        public IList<Servicio> Listar()
        {
            return _dao.Listar();
        }

        public Servicio Alta(Servicio c)
        {
            int id = _dao.Alta(c);
            c.Id = id;
            return c;
        }
    }
}
