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
        private bool _esModoKiosco;

        public Usuario UsuarioIniciado { get { return _usuarioIniciado; } }

        public Login(bool esModoKiosco)
        {
            InitializeComponent();
            this._manager = new UsuarioManager();
            this._esModoKiosco = esModoKiosco;
        }
        public Login()
            :this(false)
        {
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (_esModoKiosco)
            {
                txtContrasena.Visible = false;
                label2.Visible = false;
            }
            this.btnIngresar.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_esModoKiosco)
                {
                    try
                    {
                        this._usuarioIniciado = _manager.Obtener(this.txtUsuario.Text);
                    }
                    catch (Exception)
                    {
                        this._usuarioIniciado = null;
                    }
                }
                else
                {

                    ResultadoLoginEnum resultado = _manager.RealizarIdentificacion(this.txtUsuario.Text, this.txtContrasena.Text);

                    if (ResultadoLogin.IdentificacionExitosa(resultado))
                    {
                        try
                        {
                            this._usuarioIniciado = _manager.Obtener(this.txtUsuario.Text);
                        }
                        catch (Exception)
                        {
                            this._usuarioIniciado = null;
                        }
                    }
                    else
                    {
                        MensajePorPantalla.MensajeError(this, ResultadoLogin.Mensaje(resultado));
                        this._usuarioIniciado = null;
                    }
                }
                this.Close();
            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);

            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this._usuarioIniciado = null;
            this.Close();
        }
    }
}
