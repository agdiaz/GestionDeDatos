using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.DAO;
using FrbaBus.Common.Entidades;
using System.Data;

namespace FrbaBus.Manager
{
    public class CiudadManager
    {
        private CiudadDAO _dao;
        
        public CiudadManager()
        {
            this._dao = new CiudadDAO();
        }

        public Ciudad Obtener(int id)
        {
            return _dao.Obtener(id);    
        }
        
        public void Alta(Ciudad c)
        {
            _dao.Alta(c);
        }

        public void Baja(Ciudad c)
        {
            _dao.Baja(c);
        }

        public void Modificar(Ciudad c)
        {
            _dao.Modificacion(c);
        }

        public IList<Ciudad> Listar()
        {
            return _dao.Listar();
        }

        public IList<Ciudad> ObtenerListado(string nombre)
        {
            return _dao.ListarRegistrosFiltrados(nombre);
        }
    }
}
