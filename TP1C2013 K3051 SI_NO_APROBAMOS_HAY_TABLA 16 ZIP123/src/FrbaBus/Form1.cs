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
        public Form1()
        {
            InitializeComponent();
            this.RegistrarPermisos();
            SetearCustomFormatDataTimePicker();
        }

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
            tsmEstadisticasT5ClientesMasPuntos.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmEstadisticasT5ClientesMasPuntos");
            tsmEstadisticasT5DestMasCancelados.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmEstadisticasT5DestMasCancelados");
            tsmEstadisticasT5DestMasMicrosVacios.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmEstadisticasT5DestMasMicrosVacios");
            tsmEstadisticasT5DestMasVendidos.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmEstadisticasT5DestMasVendidos");
            tsmEstadisticasT5MicrosMasDiasFueraDeServicio.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmEstadisticasT5MicrosMasDiasFueraDeServicio");
            tsmEstadisticas.Enabled = tsmEstadisticasT5ClientesMasPuntos.Enabled || tsmEstadisticasT5DestMasCancelados.Enabled || tsmEstadisticasT5DestMasMicrosVacios.Enabled || tsmEstadisticasT5DestMasVendidos.Enabled || tsmEstadisticasT5MicrosMasDiasFueraDeServicio.Enabled;
            
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
                Program.ContextoActual.Limpiar().RegistrarUsuario(new UsuarioManager().ObtenerUsuarioGenerico(), true);
                this.RegistrarPermisos();
            }
        }

        private void tsmArchivo_DropDownOpened(object sender, EventArgs e)
        {
            tsmSesionCerrar.Enabled = Program.ContextoActual.ConSesionIniciada;
        }

        private void tsmEstadisticasT5DestMasVendidos_Click(object sender, EventArgs e)
        {
            new Estadisticas.EstadisticasDestinosMasVendidos().ShowDialog(this);
        }

        private void tsmEstadisticasT5DestMasMicrosVacios_Click(object sender, EventArgs e)
        {
            new Estadisticas.EstadisticasDestinosConMasMicrosVacios().ShowDialog(this);
        }

        private void tsmEstadisticasT5ClientesMasPuntos_Click(object sender, EventArgs e)
        {
            new Estadisticas.EstadisticasClientesConMasPuntos().ShowDialog(this);
        }

        private void tsmEstadisticasT5DestMasCancelados_Click(object sender, EventArgs e)
        {
            new Estadisticas.EstadisticasDestinosMasCancelados().ShowDialog(this);
        }

        private void tsmEstadisticasT5MicrosMasDiasFueraDeServicio_Click(object sender, EventArgs e)
        {
            new Estadisticas.EstadisticasMicrosConMasDiasFueraDeServicio().ShowDialog(this);
        }

        private void cbPasajes_CheckedChanged(object sender, EventArgs e)
        {
            gbPasajeros.Enabled = (cbPasajes.Checked);
        }

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

            IList<Micro> microsDisponibles = new MicroManager().ObtenerMicrosDisponibles(origen, destino, this.dtpFechaSalida.Value);

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

        private void Form1_Load(object sender, EventArgs e)
        {
            var now = Helpers.FechaHelper.Ahora();
            this.tssFecha.Text = now.ToString("dd/MM/yyyy");
            this.tssHora.Text = now.ToString("HH:mm:ss");
            this.dtpFechaSalida.Value = now;

            gbPasajeros.Enabled = (cbPasajes.Checked);
            gbEncomiendas.Enabled = (cbPasajes.Checked);

            IList<Ciudad> ciudadesOrigen = new CiudadManager().ObtenerListado();
            IList<Ciudad> ciudadesDestino = new CiudadManager().ObtenerListado();

            this.cbbCiudadOrigen.DataSource = ciudadesOrigen;
            this.cbbCiudadOrigen.DisplayMember = "Descripcion";
            this.cbbCiudadOrigen.ValueMember = "Id";

            this.cbbCiudadDestino.DataSource = ciudadesDestino;
            this.cbbCiudadDestino.DisplayMember = "Descripcion";
            this.cbbCiudadDestino.ValueMember = "Id";

        }

        private void lbEncomiendas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbEncomiendas_CheckedChanged(object sender, EventArgs e)
        {
            gbEncomiendas.Enabled = (cbEncomiendas.Checked);
        }

        private void btnAgregarPasajero_Click(object sender, EventArgs e)
        {
            new ClienteAlta().ShowDialog(this);
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
