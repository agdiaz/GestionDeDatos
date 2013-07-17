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
        #region Managers
        private MicroManager _microManager;
        private UsuarioManager _managerUsuario;
        private CiudadManager _ciudadManager;
        #endregion
        
        #region Atributos para la compra
        
        IList<Pasaje> _pasajes;
        IList<Encomienda> _encomiendas;
        Viaje _viaje;
        Recorrido _recorrido;
        Micro _micro;

        #endregion
        
        #region Constructor
        public Form1()
        {
            InitializeComponent();
            
            //Manager
            this._microManager = new MicroManager();
            this._managerUsuario = new UsuarioManager();
            this._ciudadManager = new CiudadManager();

            this.RegistrarPermisos();
            SetearCustomFormatDataTimePicker();
        }

        #endregion
        
        #region Formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            this.IniciarFormulario();
        }

        private void IniciarFormulario()
        {
            InicializarDatosCompra();
            LimpiarGrupoRecorrido(true);
            LimpiarGrupoViaje(false);
            LimpiarGrupoMicros(false);
            LimpiarGrupoDetalles(false);
            LimpiarGrupoMedioPago(false);
            
        }

        private void LimpiarGrupoViaje(bool habilitado)
        {
            gbViaje.Enabled = habilitado;
        }

        private void LimpiarGrupoRecorrido(bool habilitar)
        {
            this.gbRecorrido.Enabled = habilitar;
        }

        private void LimpiarGrupoMedioPago(bool habilitar)
        {
            gbMedioDePago.Enabled = habilitar;
        }

        private void LimpiarGrupoDetalles(bool habilitar)
        {
            gbDetalles.Enabled = habilitar;
        }

        private void LimpiarGrupoMicros(bool habilitar)
        {
            gbMicro.Enabled = habilitar;
        }

        // 1) Recorrido
        private void MostrarOpcionesRecorrido()
        {
            LimpiarGrupoRecorrido(true);
            tbRecorridoCiudadDestino.Text = _recorrido.CiudadDestino.Nombre;
            tbRecorridoCiudadOrigen.Text = _recorrido.CiudadOrigen.Nombre;
            tbRecorridoServicio.Text = _recorrido.Servicio.TipoServicio;

        }
        // 2) Viaje
        private void MostrarOpcionesViaje()
        {
            LimpiarGrupoViaje(true);
            dtpViajeFechaArribo.Value = _viaje.FechaArribo;
            dtpViajeFechaSalida.Value = _viaje.FechaSalida;
        }

        // 3) Micro
        private void MostrarOpcionesMicro()
        {
            LimpiarGrupoMicros(true);
            tbMicroButacasLibres.Text = _micro.ButacasDisponibles.ToString();
            tbMicroKgDisponibles.Text = _micro.KgsDisponibles.ToString();
            tbMicroMarca.Text = _micro.Empresa.Descripcion;
            tbMicroPatente.Text = _micro.Patente;
            tbMicroServicio.Text = _micro.Servicio.TipoServicio;
        }
        
        private void btnBuscarMicros_Click(object sender, EventArgs e)
        {

        }

        private void CargarFecha()
        {
            var now = Helpers.FechaHelper.Ahora();
            this.tssFecha.Text = now.ToString("dd/MM/yyyy");
            this.tssHora.Text = now.ToString("HH:mm:ss");
            this.dtpViajeFechaSalida.Value = now;
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
        private void tsmMicroButacaAlta_Click(object sender, EventArgs e)
        {
            using (MicroButacaAlta frm = new MicroButacaAlta())
            {
                frm.ShowDialog(this);
            }
        }

        private void tsmMicroMarcaAlta_Click(object sender, EventArgs e)
        {
            using (MicroMarcaAlta frm = new MicroMarcaAlta())
            {
                frm.ShowDialog(this);
            }
        }

        private void tsmMicroServicioAlta_Click(object sender, EventArgs e)
        {
            using (MicroServicioAlta frm = new MicroServicioAlta())
            {
                frm.ShowDialog(this);
            }
        }


        #endregion

        #region Botones
        private void btnElegirMicro_Click(object sender, EventArgs e)
        {

        }

        
        private void btnAgregarPasajero_Click(object sender, EventArgs e)
        {
            new ClienteAlta().ShowDialog(this);
        }
        #endregion

        #region Listas
        #endregion

        #region Usuario y roles
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

            tsmMicroServicioListado.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmMicroServicioListado");
            tsmMicroServicioAlta.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmMicroServicioAlta");
            tsmMicroMarcaListado.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmMicroMarcaListado");
            tsmMicroMarcaAlta.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmMicroMarcaAlta");
            tsmMicroButacaAlta.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmMicroButacaAlta");

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

            //Menú Estadísticas:
            tsmEstadisticasListados.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmEstadisticasListado");
            tsmEstadisticas.Enabled = tsmEstadisticasListados.Enabled;
            
            //Menú Premios:
            tsmPremiosAlta.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmPremiosAlta");
            tsmPremiosListado.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmPremiosListado");
            tsmPremios.Enabled = tsmPremiosAlta.Enabled || tsmPremiosListado.Enabled;

            //Menú Ayuda Usuarios:
            tsmAyudaUsuarios.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmAyudaUsuarios");
            tsmAyudaUsuarios.Enabled = tsmAyudaUsuarios.Enabled;
        }

        private void ActualizarStatusBar()
        {
            this.tssUsuarioValor.Text = Program.ContextoActual.UsuarioActual.Username;
            this.tssRolValor.Text = Program.ContextoActual.UsuarioActual.RolAsignado.Nombre;
            this.tssSesion.Text = Program.ContextoActual.ConSesionIniciada ? "(Sesión iniciada)" : "(Sesión no iniciada)";
        }
        #endregion

        #region Compras

        private void InicializarDatosCompra()
        {
            _pasajes = new List<Pasaje>();
            _encomiendas = new List<Encomienda>();
            _viaje = new Viaje();
            _recorrido = new Recorrido();
            _micro = new Micro();
        }

        private void cbPasajes_CheckedChanged(object sender, EventArgs e)
        {
            gbPasajeros.Enabled = (cbPasajes.Checked);
        }
        
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
            dtpViajeFechaSalida.Format = DateTimePickerFormat.Custom;
            dtpViajeFechaSalida.CustomFormat = "MMMM dd, yyyy - HH:mm:ss";

            dtpViajeFechaArribo.Format = DateTimePickerFormat.Custom;
            dtpViajeFechaArribo.CustomFormat = "MMMM dd, yyyy - HH:mm:ss";
        }

        private void gbDetalles_Enter(object sender, EventArgs e)
        {

        }

        private void txtCantPasajes_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbMicroButacasLibres.Text))
            { 
                var cantDisp = Convert.ToInt32(tbMicroButacasLibres.Text);
                var cantSeleccionada = Convert.ToInt32(txtCantPasajes.Text);
                if (cantSeleccionada > cantDisp)
                {
                    txtCantPasajes.Text = tbMicroButacasLibres.Text;
                }
            }
        }

        private void gbPasajeros_Enter(object sender, EventArgs e)
        {

        }

        #endregion

        private void btnBuscarViaje_Click(object sender, EventArgs e)
        {
            MostrarOpcionesViaje();
        }
        private void btnCargarMicro_Click(object sender, EventArgs e)
        {
            MostrarOpcionesMicro();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCargarDetalles_Click(object sender, EventArgs e)
        {
            LimpiarGrupoDetalles(true);
        }

        

    }
}
