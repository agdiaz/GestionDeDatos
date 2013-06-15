using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Abm_Micro;
using FrbaBus.Rol;
using FrbaBus.Abm_Ciudad;
using FrbaBus.Abm_Clientes;
using FrbaBus.Abm_encomienda;
using FrbaBus.Abm_Recorrido;
using FrbaBus.Abm_Viaje;
using FrbaBus.Common.Entidades;

namespace FrbaBus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.RegistrarPermisos();
        }

        public void RegistrarPermisos()
        {
            this.ActualizarStatusBar();
        }

        private void ActualizarStatusBar()
        {
            this.tssUsuarioValor.Text = Program.ContextoActual.UsuarioActual.Username;
            this.tssRolValor.Text = Program.ContextoActual.UsuarioActual.RolAsignado.Nombre;
            this.tssSesion.Text = Program.ContextoActual.ConSesionIniciada ? "(Sesión iniciada)" : "(Sesión no iniciada)";
        }

        private void tsmRolListado_Click(object sender, EventArgs e)
        {
            new RolListado().ShowDialog(this);
        }

        private void tsmMicros_Click(object sender, EventArgs e)
        {

        }

        private void tsmMicroListado_Click(object sender, EventArgs e)
        {
            new MicroListado().ShowDialog(this);
        }

        private void tsmPasajero_Click(object sender, EventArgs e)
        {

        }

        private void top5ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsmMicroAlta_Click(object sender, EventArgs e)
        {
            new MicroAlta().ShowDialog(this);
        }

        private void tsmRolAlta_Click(object sender, EventArgs e)
        {
            new RolAlta().ShowDialog(this);
        }

        private void tsmCiudadListado_Click(object sender, EventArgs e)
        {
            new CiudadListado().ShowDialog(this);
        }

        private void tsmCiudadAlta_Click(object sender, EventArgs e)
        {
            new CiudadAlta().ShowDialog(this);
        }

        private void tsmArchivoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ClienteAlta().ShowDialog(this);
        }

        private void tsmAltaCliente_Click(object sender, EventArgs e)
        {
            new ClienteAlta().ShowDialog(this);
        }

        private void tsmClienteListado_Click(object sender, EventArgs e)
        {
            new ClienteListado().ShowDialog(this);
        }

        private void tsmEncomiendaAlta_Click(object sender, EventArgs e)
        {
            new EncomiendaAlta().ShowDialog(this);
        }

        private void tsmEncomiendaListado_Click(object sender, EventArgs e)
        {
            new EncomiendaListado().ShowDialog(this);
        }

        private void tsmRecorridoAlta_Click(object sender, EventArgs e)
        {
            new RecorridoAlta().ShowDialog(this);
        }

        private void tsmRecorridoListado_Click(object sender, EventArgs e)
        {
            new RecorridoListado().ShowDialog(this);
        }

        private void tsmViajeAlta_Click(object sender, EventArgs e)
        {
            new ViajeAlta().ShowDialog(this);
        }

        private void tsmViajeListado_Click(object sender, EventArgs e)
        {
            new ViajeListado().ShowDialog(this);
        }

        private void tsmSesionIniciar_Click(object sender, EventArgs e)
        {
            Usuario u = null;
            using (Login.Login formLogin = new Login.Login())
            {
                formLogin.ShowDialog(this);
                u = formLogin.UsuarioIniciado;
            }

            if (u != null && Program.ContextoActual.UsuarioActual != u)
            {
                Program.ContextoActual.RegistrarUsuario(u);
                this.RegistrarPermisos();
            }
        }

        private void tsmSesionCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Está seguro que desea cerrar su sesión?", 
                    "Cerrar sesión", 
                    MessageBoxButtons.OKCancel, 
                    MessageBoxIcon.Hand) 
                == DialogResult.OK)
            {
                Program.ContextoActual.Limpiar();
                this.RegistrarPermisos();
            }
        }

        private void tsmArchivo_DropDownOpened(object sender, EventArgs e)
        {
            tsmSesionCerrar.Enabled = Program.ContextoActual.ConSesionIniciada;
        }
    }
}
