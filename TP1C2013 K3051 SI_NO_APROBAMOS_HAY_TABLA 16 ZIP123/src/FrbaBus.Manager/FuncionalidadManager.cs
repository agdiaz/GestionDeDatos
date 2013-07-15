using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.DAO;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Manager
{
    public class FuncionalidadManager
    {
        private FuncionalidadDAO _dao;
        public FuncionalidadManager()
        {
            this._dao = new FuncionalidadDAO();
        }

        public Funcionalidad Obtener(int id)
        {
            return _dao.Obtener(id);
        }
        public IList<Funcionalidad> Listar()
        {
            return _dao.Listar();
        }
        public IList<Funcionalidad> ObtenerFuncionalidadesRol(RolUsuario rol)
        {
            return _dao.ObtenerFuncionalidadesAsociadas(rol);
        }
        public void AsociarRolFuncionalidad(RolUsuario rol, Funcionalidad func)
        {
            _dao.AltaRolFuncionalidad(rol, func.Id);
        }
    }
}
