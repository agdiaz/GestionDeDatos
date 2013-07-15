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
        private UsuarioDAO _dao;
        private RolUsuarioManager _rolUsuarioManager;

        public UsuarioManager()
        {
            this._dao = new UsuarioDAO();
            this._rolUsuarioManager= new RolUsuarioManager();
        }

        public ResultadoLoginEnum RealizarIdentificacion(string username, string password)
        {
            byte[] hashPassword = PasswordHelper.GetSHA256Value(password);

            ResultadoLoginEnum resultadoIdentificacion;

            int resultado = _dao.RealizarIdentificacion(username, hashPassword);
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

            u.RolAsignado = this._rolUsuarioManager.ObtenerRolAsociado(u);

            return u;
        }

        public void Insertar(string username, string password)
        {
            byte[] hashPassword = PasswordHelper.GetSHA256Value(password);
            Usuario u = new Usuario()
            {
                Username = username,
                HashPassword = hashPassword
            };

            _dao.Alta(u);
        }

        public Usuario ObtenerUsuarioGenerico()
        {
            Usuario u = new Usuario("Sin identificación");
            u.RolAsignado = this.ObtenerRol("Cliente");
            return u;
        }

        private RolUsuario ObtenerRol(string nombreRol)
        {
            RolUsuario ru = new RolUsuario(nombreRol);
            return ru;
        }
    }
}
