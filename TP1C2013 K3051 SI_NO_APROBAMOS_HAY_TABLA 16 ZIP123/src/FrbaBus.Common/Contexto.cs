using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Common
{
    public class Contexto
    {
        private Usuario _usuarioActual;

        public bool ConSesionIniciada { get; set; }
        public Usuario UsuarioActual { get { return _usuarioActual; } }

        public Contexto()
        {
        }

        public void RegistrarUsuario(Usuario u, bool esGenerico)
        {
            this._usuarioActual = u;
            this.ConSesionIniciada = !esGenerico;
        }


        public void RegistrarUsuario(Usuario u)
        {
            RegistrarUsuario(u, false);
        }
        /// <summary>
        /// Quita el usuario actual para que se use el genérico con rol de cliente
        /// </summary>
        public Contexto Limpiar()
        {
            RegistrarUsuario(

            new Usuario()
            {
                RolAsignado = new RolUsuarioBasico()
                {
                }
            });

            ConSesionIniciada = false;
            return this;
        }
    }
}
