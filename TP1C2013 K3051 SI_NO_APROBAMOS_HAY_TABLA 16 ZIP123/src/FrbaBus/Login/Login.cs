using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Common.Helpers;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Login
{
    public partial class Login : Form
    {
        private Usuario _usuarioIniciado;
        public Usuario UsuarioIniciado { get { return _usuarioIniciado; } }

        public Login()
        {
            InitializeComponent();
        }

        private bool ValidarUsuario()
        {
            return this.txtUsuario.Text == "admin" && this.txtContrasena.Text == "admin";
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            this._usuarioIniciado = new Usuario() { Username = this.txtUsuario.Text, RolAsignado = new RolUsuarioAdministrativo() };
            this.Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this._usuarioIniciado = null;
            this.Close();
        }
    }
}
