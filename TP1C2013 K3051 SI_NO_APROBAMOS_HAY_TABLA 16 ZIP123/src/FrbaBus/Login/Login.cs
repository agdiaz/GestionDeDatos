using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Common.Helpers;

namespace FrbaBus.Login
{
    public partial class Login : Form
    {
        private bool ModoCliente;

        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (this.ValidarUsuario())
            {
                new Form1().ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Inicio de sesión invalido");
            }
        }

        private bool ValidarUsuario()
        {
            return this.txtUsuario.Text == "admin" && this.txtContrasena.Text == "admin";
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
