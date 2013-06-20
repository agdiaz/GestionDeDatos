﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using FrbaBus.DAO;
using FrbaBus.Common.Helpers;

namespace FrbaBus.Manager
{
    public class UsuarioManager
    {

        public ResultadoLoginEnum RealizarIdentificacion(string username, string password)
        {
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
    }
}
