using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.DAO;
using FrbaBus.Common.Entidades;

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
    }
}
