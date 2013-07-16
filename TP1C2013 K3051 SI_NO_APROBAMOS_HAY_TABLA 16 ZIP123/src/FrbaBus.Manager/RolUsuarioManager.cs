using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.DAO;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Manager
{
    public class RolUsuarioManager
    {
        private RolUsuarioDAO _rolUsuarioDAO;
        private FuncionalidadManager _funcionalidadManager;

        public RolUsuarioManager()
        {
            this._rolUsuarioDAO = new RolUsuarioDAO();
            this._funcionalidadManager = new FuncionalidadManager();
        }

        public RolUsuario Obtener(int id)
        {
            return _rolUsuarioDAO.Obtener(id);
        }
        public RolUsuario Alta(RolUsuario rolUsuario)
        {
            int id = _rolUsuarioDAO.Alta(rolUsuario);
            rolUsuario.IdRol = id;
            return rolUsuario;
        }
        public void Baja(RolUsuario rolUsuario)
        {
            this.BajaRolFuncionalidades(rolUsuario);
            
            _rolUsuarioDAO.Baja(rolUsuario);
        }
        public void Modificar(RolUsuario rol)
        {
            _rolUsuarioDAO.Modificacion(rol);
            rol.Funcionalidades = _funcionalidadManager.ObtenerFuncionalidadesRol(rol);
        }
        
        public IList<RolUsuario> Listar()
        {
            IList<RolUsuario> roles = _rolUsuarioDAO.Listar();
            foreach (RolUsuario rol in roles)
            {
                rol.Funcionalidades = _funcionalidadManager.ObtenerFuncionalidadesRol(rol);
            }
            return roles;
        }
        public IList<RolUsuario> ListarFiltrado(string rolNombre, string funcionalidad)
        {
            IList<RolUsuario> roles = _rolUsuarioDAO.ListarFiltrado(rolNombre, funcionalidad);
            foreach (RolUsuario rol in roles)
            {
                rol.Funcionalidades = _funcionalidadManager.ObtenerFuncionalidadesRol(rol);
            }
            return roles;
        }

        public RolUsuario ObtenerRolAsociado(Usuario usuario)
        {
            RolUsuario rol = _rolUsuarioDAO.Obtener(usuario.IdRol);
            rol.Funcionalidades = this._funcionalidadManager.ObtenerFuncionalidadesRol(rol);
            return rol;
        }
        public void BajaRolFuncionalidades(RolUsuario rol)
        {
            _rolUsuarioDAO.BajaRolFuncionalidades(rol);
        }
    }
}
