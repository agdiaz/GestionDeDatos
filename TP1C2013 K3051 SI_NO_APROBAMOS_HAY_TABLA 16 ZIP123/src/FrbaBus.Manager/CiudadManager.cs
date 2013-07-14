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
        public void Alta(Ciudad c)
        {
            CiudadDAO ciudadDAO = new CiudadDAO();
            ciudadDAO.Alta(c);
        }

        public void Baja(Ciudad c)
        {
            CiudadDAO ciudadDAO = new CiudadDAO();
            ciudadDAO.Baja(c);
        }

        public void Modificar(Ciudad c)
        {
            CiudadDAO ciudadDAO = new CiudadDAO();
            ciudadDAO.Modificacion(c);
        }

        public IList<Ciudad> Listar()
        {
            CiudadDAO ciudadDAO = new CiudadDAO();
            return ciudadDAO.Listar();
        }

        public DataSet ObtenerRegistros()
        {
            CiudadDAO ciudadDAO = new CiudadDAO();
            return ciudadDAO.ObtenerRegistros();
        }

        public IList<Ciudad> ObtenerListado(string ciudadElegida)
        {
            return new CiudadDAO().ListarRegistrosFiltrados(ciudadElegida);
        }

        public DataSet ObtenerRegistrosCiudades(string ciudadElegida)
        {
            CiudadDAO ciudadDAO = new CiudadDAO();
            return ciudadDAO.ObtenerRegistrosFiltrados(ciudadElegida);
        }
    }
}
