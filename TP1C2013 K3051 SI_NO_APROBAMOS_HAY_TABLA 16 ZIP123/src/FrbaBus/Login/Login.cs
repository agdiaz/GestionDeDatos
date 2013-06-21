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
using FrbaBus.Manager;
using FrbaBus.Common.Excepciones;

namespace FrbaBus.Login
{
    public partial class Login : Form
    {
        private Usuario _usuarioIniciado;
        private UsuarioManager _manager;

        public Usuario UsuarioIniciado { get { return _usuarioIniciado; } }
        
        public Login()
        {
            InitializeComponent();
            this._manager = new UsuarioManager();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.btnIngresar.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                ResultadoLoginEnum resultado = _manager.RealizarIdentificacion(this.txtUsuario.Text, this.txtContrasena.Text);

                if (ResultadoLogin.IdentificacionExitosa(resultado))
                {
                    this._usuarioIniciado = _manager.Obtener(this.txtUsuario.Text);
                }
                else
                {
                    MensajePorPantalla.MensajeError(this, ResultadoLogin.Mensaje(resultado));
                    this._usuarioIniciado = null;
                }
                this.Close();
            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this._usuarioIniciado = null;
            this.Close();
        }
    }
}
