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
        public void Alta(string descripcion)
        {
            CiudadDAO ciudadDAO = new CiudadDAO();
            Ciudad ciudad = new Ciudad() { Descripcion = descripcion };
            ciudadDAO.Alta(ciudad);
        }

        public void Baja(string descripcion)
        {
            CiudadDAO ciudadDAO = new CiudadDAO();
            Ciudad ciudad = new Ciudad() { Descripcion = descripcion };
            ciudadDAO.Baja(ciudad);
        }

        public void Modificar(string descripcion)
        {
            CiudadDAO ciudadDAO = new CiudadDAO();
            Ciudad ciudad = new Ciudad() { Descripcion = descripcion };
            ciudadDAO.Modificacion(ciudad);
        }

        public DataSet Listar()
        {
            CiudadDAO ciudadDAO = new CiudadDAO();
            return ciudadDAO.ObtenerRegistros();
        }
    }
}
