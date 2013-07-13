using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using FrbaBus.DAO;
using FrbaBus.Common.Helpers;
using System.Data;

namespace FrbaBus.Manager
{
    public class UsuarioManager
    {
        public void AltaRolUsuario(RolUsuario entidad)
        {
            int id = new RolUsuarioDAO().Alta(entidad);
            entidad.IdRol = id;
        }

        public void BajaRolUsuario(RolUsuario entidad)
        {
            var dao = new RolUsuarioDAO();

            dao.BajaRolFuncionalidades(entidad);
            dao.Baja(entidad);
        }

        public void ModificacionRolUsuario(RolUsuario entidad)
        {
            var dao = new RolUsuarioDAO();
            dao.Modificacion(entidad);
        }

        public DataSet ObtenerRegistrosRolUsuario()
        {
            return new RolUsuarioDAO().ObtenerRegistros();
        }
        public IList<RolUsuario> ListarRolUsuario()
        {
            var roles = new RolUsuarioDAO().Listar();
            return roles;
        }

        public void AltaFuncionalidad(Funcionalidad entidad)
        {
            throw new NotImplementedException();
        }

        public void BajaFuncionalidad(Funcionalidad entidad)
        {
            throw new NotImplementedException();
        }

        public void ModificacionFuncionalidad(Funcionalidad entidad)
        {
            throw new NotImplementedException();
        }

        public IList<Funcionalidad> ListarFuncionalidad()
        {
            return new FuncionalidadDAO().Listar();
        }

        public DataSet ObtenerRegistrosFuncionalidad()
        {
            throw new NotImplementedException();
        }

        public ResultadoLoginEnum RealizarIdentificacion(string username, string password)
        {
            //this.Insertar("admin", "w23e");

            byte[] hashPassword = PasswordHelper.GetSHA256Value(password);

            ResultadoLoginEnum resultadoIdentificacion;

            int resultado = new RolUsuarioDAO().RealizarIdentificacion(username, hashPassword);
            switch (resultado)
            {
                case -2:
                    resultadoIdentificacion = ResultadoLoginEnum.UsuarioInvalido;
                    break;
                case -1:
                    resultadoIdentificacion = ResultadoLoginEnum.UsuarioBloqueado;
                    break;
                case 0:
                    resultadoIdentificacion = ResultadoLoginEnum.UsuarioIdentificado;
                    break;
                default:
                    resultadoIdentificacion = ResultadoLoginEnum.UsuarioInvalido;
                    break;
            }
            return resultadoIdentificacion;
        }

        public Usuario Obtener(string username)
        {
            Usuario u = new Usuario(username);
            
            u.RolAsignado = new RolUsuarioDAO().ObtenerRolAsociado(u);
            u.RolAsignado.Funcionalidades = new RolUsuarioDAO().ObtenerFuncionalidadesAsociadas(u.RolAsignado);

            return u;
        }

        public void Insertar(string username, string password)
        {
            byte[] hashPassword = PasswordHelper.GetSHA256Value(password);

            new RolUsuarioDAO().InsertarUsuario(username, hashPassword);
        }

        public Usuario ObtenerUsuarioGenerico()
        {
            Usuario u = new Usuario("Sin identificación");
            u.RolAsignado = this.ObtenerRol("Cliente");
            return u;
        }

        public RolUsuario ObtenerRol(string nombreRol)
        {
            RolUsuario ru = new RolUsuario(nombreRol);
            return ru;
        }

        public DataSet ObtenerRegistrosRolUsuario(string nombreRol, string nombreFuncionalidad)
        {
            return new RolUsuarioDAO().ObtenerRegistrosRolUsuario(nombreRol, nombreFuncionalidad);
        }

        public void AltaRolFuncionalidad(RolUsuario rol, int idFuncionalidad)
        {
            new FuncionalidadDAO().AltaRolFuncionalidad(rol, idFuncionalidad);
        }

        public void BajaRolFuncionalidades(RolUsuario rol)
        {
            new RolUsuarioDAO().BajaRolFuncionalidades(rol);
            rol.Funcionalidades = new List<Funcionalidad>();
        }

        public IList<RolUsuario> ListarRegistrosRolUsuario(string nombreRol, string funcionalidadElegida)
        {
            return new RolUsuarioDAO().ListarRegistrosRolUsuario(nombreRol, funcionalidadElegida);
        }
    }
}
