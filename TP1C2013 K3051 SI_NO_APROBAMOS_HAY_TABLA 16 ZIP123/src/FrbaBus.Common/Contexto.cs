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
            this.Limpiar();
        }
        public void RegistrarUsuario(Usuario u)
        {
            this._usuarioActual = u;
            this.ConSesionIniciada = true;
        }
        /// <summary>
        /// Quita el usuario actual para que se use el genérico con rol de cliente
        /// </summary>
        public void Limpiar()
        {
            RegistrarUsuario(

            new Usuario()
            {
                RolAsignado = new RolUsuario()
                {

                }
            });

            ConSesionIniciada = false;
        }
    }
}
