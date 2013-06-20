using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common.Helpers
{
    public enum ResultadoLoginEnum
    {
        UsuarioIdentificado = 0,
        UsuarioBloqueado = -1,
        UsuarioInvalido = -2
    }
    public static class ResultadoLogin
    {
        public static bool IdentificacionExitosa(ResultadoLoginEnum res)
        {
            return res.CompareTo(ResultadoLoginEnum.UsuarioIdentificado) == 0;
        }
        public static string Mensaje(ResultadoLoginEnum res)
        {
            switch (res)
            {
                case ResultadoLoginEnum.UsuarioIdentificado:
                    return "Usuario identificado correctamente";
                case ResultadoLoginEnum.UsuarioBloqueado:
                    return "El usuario ha sido bloqueado por reiterados intentos erróneos de login";
                case ResultadoLoginEnum.UsuarioInvalido:
                    return "El usuario o la contraseña son inválidos";
                default:
                    return "Error";
            }
        }
    }
}
