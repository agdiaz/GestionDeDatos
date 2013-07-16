﻿using System;
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
using FrbaBus.Manager;

namespace FrbaBus
{
    public partial class Form1 : Form
    {
        private MicroManager _microManager;
        private UsuarioManager _managerUsuario;
        private CiudadManager _ciudadManager;

        public Form1()
        {
            InitializeComponent();
            this._microManager = new MicroManager();
            this._managerUsuario = new UsuarioManager();
            this._ciudadManager = new CiudadManager();

            this.RegistrarPermisos();
            SetearCustomFormatDataTimePicker();
        }

        #region Formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            this.IniciarFormulario();
        }

        private void IniciarFormulario()
        {
            var now = Helpers.FechaHelper.Ahora();
            this.tssFecha.Text = now.ToString("dd/MM/yyyy");
            this.tssHora.Text = now.ToString("HH:mm:ss");
            this.dtpFechaSalida.Value = now;

            gbPasajeros.Enabled = (cbPasajes.Checked);
            gbEncomiendas.Enabled = (cbPasajes.Checked);

            this.ListarCiudadesOrigen();
            this.ListarCiudadesDestino();

        }
        #endregion

        #region Menues
        private void tsmAyudaUsuarios_Click(object sender, EventArgs e)
        {
            using (Ayuda.AyudaUsuarios frm = new FrbaBus.Ayuda.AyudaUsuarios())
            {
                frm.ShowDialog(this);
            }
        }

        private void tsmEstadisticasListados_Click(object sender, EventArgs e)
        {
            using (Estadisticas.Estadisticas frm = new FrbaBus.Estadisticas.Estadisticas())
            {
                frm.ShowDialog(this);
            }
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

        private void tsmPasajeEncomiendaCancelar_Click(object sender, EventArgs e)
        {
            new Cancelar().ShowDialog(this);
        }

        private void tsmPasajeEncomiendaComprar_Click(object sender, EventArgs e)
        {
            new Comprar().ShowDialog(this);
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
                Program.ContextoActual.Limpiar().RegistrarUsuario(_managerUsuario.ObtenerUsuarioGenerico(), true);
                this.RegistrarPermisos();
            }
        }

        private void tsmArchivo_DropDownOpened(object sender, EventArgs e)
        {
            tsmSesionCerrar.Enabled = Program.ContextoActual.ConSesionIniciada;
        }

        #endregion

        #region Botones
        private void btnElegirMicro_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarMicros_Click(object sender, EventArgs e)
        {
            gbMicros.Enabled = true;
            gbDetalles.Enabled = true;
            gbMedioDePago.Enabled = true;
            var origen = Convert.ToInt32(this.cbbCiudadOrigen.SelectedValue.ToString());
            var destino = Convert.ToInt32(this.cbbCiudadDestino.SelectedValue.ToString());

            IList<Micro> microsDisponibles = _microManager.ListarDisponibles(origen, destino, this.dtpFechaSalida.Value);

            this.cbbMicro.DataSource = microsDisponibles;
            cbbMicro.DisplayMember = "Marca";
            cbbMicro.ValueMember = "Id";

            if (microsDisponibles.Count > 0)
            {
                var Micro = cbbMicro.SelectedValue as Micro;
                if (Micro != null)
                {
                    txtButacasLibres.Text = Micro.ButacasDisponibles.ToString();
                    txtKgsDisp.Text = Micro.KgsDisponibles.ToString();
                    txtTipoServicio.Text = Micro.Servicio.ToString();
                }
            }
        }
        private void btnAgregarPasajero_Click(object sender, EventArgs e)
        {
            new ClienteAlta().ShowDialog(this);
        }
        #endregion

        public void RegistrarPermisos()
        {
            this.ActualizarStatusBar();
            this.RegistrarFuncionalidades();
        }

        private void RegistrarFuncionalidades()
        {
            //Menú Archivo:
            tsmSesionIniciar.Enabled = !Program.ContextoActual.ConSesionIniciada;

            //Menú Rol:
            tsmRolAlta.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmRolAlta");
            tsmRolListado.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmRolListado");
            tsmRol.Enabled = tsmRolAlta.Enabled || tsmRolListado.Enabled;

            //Menú Ciudad:
            tsmCiudadAlta.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmCiudadAlta");
            tsmCiudadListado.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmCiudadListado");
            tsmCiudad.Enabled = tsmCiudadAlta.Enabled || tsmCiudadListado.Enabled;
            
            //Menú Recorrido:
            tsmRecorridoAlta.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmRecorridoAlta");
            tsmRecorridoListado.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmRecorridoListado");
            tsmRecorrido.Enabled = tsmRecorridoAlta.Enabled || tsmRecorridoListado.Enabled;

            //Menú Micro:
            tsmMicroAlta.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmMicroAlta");
            tsmMicroListado.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmMicroListado");
            tsmMicro.Enabled = tsmMicroAlta.Enabled || tsmMicroListado.Enabled;

            //Menú Viaje:
            tsmViajeAlta.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmViajeAlta");
            tsmViajeListado.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmViajeListado");
            tsmViaje.Enabled = tsmViajeAlta.Enabled || tsmViajeListado.Enabled;

            //Menú Cliente:
            tsmClienteListado.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmClienteListado");
            tsmClienteAlta.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmClienteAlta");
            
            tsmClientePasajeroFrecuenteConsultar.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmClientePasajeroFrecuenteConsultar");
            tsmClientePasajeroFrecuente.Enabled = tsmClientePasajeroFrecuenteConsultar.Enabled;
            tsmCliente.Enabled = tsmClienteListado.Enabled || tsmClienteAlta.Enabled || tsmClientePasajeroFrecuente.Enabled;

            //Menú Viaje:
            tsmViajeAlta.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmViajeAlta");
            tsmViajeListado.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmViajeListado");
            tsmViaje.Enabled = tsmViajeAlta.Enabled || tsmViajeListado.Enabled;

            //Menú Pasaje/Encomienda:
            tsmPasajeEncomiendaAlta.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmEncomiendaAlta");
            tsmPasajeEncomiendaCancelar.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmEncomiendaCancelar");
            tsmEncomienda.Enabled = tsmPasajeEncomiendaCancelar.Enabled || tsmPasajeEncomiendaAlta.Enabled;

            //Menú Estadísticas:
            tsmEstadisticasListados.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmEstadisticasT5DestMasVendidos");
            tsmEstadisticas.Enabled = tsmEstadisticasListados.Enabled;
            
            //Menú Premios:
            tsmPremiosAlta.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmPremiosAlta");
            tsmPremiosListado.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmPremiosListado");
            tsmPremios.Enabled = tsmPremiosAlta.Enabled || tsmPremiosListado.Enabled;
        }

        private void ActualizarStatusBar()
        {
            this.tssUsuarioValor.Text = Program.ContextoActual.UsuarioActual.Username;
            this.tssRolValor.Text = Program.ContextoActual.UsuarioActual.RolAsignado.Nombre;
            this.tssSesion.Text = Program.ContextoActual.ConSesionIniciada ? "(Sesión iniciada)" : "(Sesión no iniciada)";
        }

        private void cbPasajes_CheckedChanged(object sender, EventArgs e)
        {
            gbPasajeros.Enabled = (cbPasajes.Checked);
        }

        #region Listas
        private void ListarCiudadesDestino()
        {
            IList<Ciudad> ciudadesDestino = _ciudadManager.Listar();
            this.cbbCiudadDestino.DataSource = ciudadesDestino;
            this.cbbCiudadDestino.DisplayMember = "Nombre";
            this.cbbCiudadDestino.ValueMember = "Id";

        }

        private void ListarCiudadesOrigen()
        {
            IList<Ciudad> ciudadesOrigen = _ciudadManager.Listar();
            this.cbbCiudadOrigen.DataSource = ciudadesOrigen;
            this.cbbCiudadOrigen.DisplayMember = "Nombre";
            this.cbbCiudadOrigen.ValueMember = "Id";

        }

        #endregion

        private void lbEncomiendas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbEncomiendas_CheckedChanged(object sender, EventArgs e)
        {
            gbEncomiendas.Enabled = (cbEncomiendas.Checked);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void SetearCustomFormatDataTimePicker()
        {
            dtpFechaSalida.Format = DateTimePickerFormat.Custom;
            dtpFechaSalida.CustomFormat = "MMMM dd, yyyy - HH:mm:ss";
        }

        private void gbDetalles_Enter(object sender, EventArgs e)
        {

        }

        private void cbbMicro_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Micro = cbbMicro.SelectedValue as Micro;
            if (Micro != null)
            {

                txtButacasLibres.Text = Micro.ButacasDisponibles.ToString();
                txtKgsDisp.Text = Micro.KgsDisponibles.ToString();
                txtTipoServicio.Text = Micro.Servicio.ToString();
            }
        }

        private void txtCantPasajes_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtButacasLibres.Text))
            { 
                var cantDisp = Convert.ToInt32(txtButacasLibres.Text);
                var cantSeleccionada = Convert.ToInt32(txtCantPasajes.Text);
                if (cantSeleccionada > cantDisp)
                {
                    txtCantPasajes.Text = txtButacasLibres.Text;
                }
            }
        }

    }
}
