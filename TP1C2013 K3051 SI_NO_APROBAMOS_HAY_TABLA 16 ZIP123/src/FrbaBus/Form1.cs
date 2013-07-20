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
using FrbaBus.Abm_Recorrido;
using FrbaBus.Abm_Viaje;
using FrbaBus.Common.Entidades;
using FrbaBus.Manager;
using FrbaBus.Abm_Recompensa;
using FrbaBus.Common.Helpers;
using FrbaBus.Compras;

namespace FrbaBus
{
    public partial class Form1 : Form
    {
        #region Managers
        private MicroManager _microManager;
        private UsuarioManager _managerUsuario;
        private CiudadManager _ciudadManager;
        private CompraManager _compraManager;
        #endregion
        
        #region Atributos para la compra
        
        IList<Pasaje> _pasajes;
        IList<Encomienda> _encomiendas;
        Viaje _viaje;
        Recorrido _recorrido;

        #endregion
        
        #region Constructor
        public Form1()
        {
            InitializeComponent();
            
            //Manager
            this._microManager = new MicroManager();
            this._managerUsuario = new UsuarioManager();
            this._ciudadManager = new CiudadManager();
            this._compraManager = new CompraManager();
            this._pasajes = new List<Pasaje>();
            this._encomiendas = new List<Encomienda>();
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
            LimpiarGrupoRecorrido(false);
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

            if (_viaje.Micro != null)
                MostrarOpcionesMicro();
        }

        // 3) Micro
        private void MostrarOpcionesMicro()
        {
            LimpiarGrupoMicros(true);

            try
            {
                _microManager.ObtenerDisponibilidades(_viaje.Micro, _viaje.Id);
            }
            catch (Exception)
            {
                ;
            }

            tbMicroButacasLibres.Text = _viaje.Micro.ButacasDisponibles.ToString();
            tbMicroKgDisponibles.Text = _viaje.Micro.KgsDisponibles.ToString();
            tbMicroMarca.Text = _viaje.Micro.Empresa.Descripcion;
            tbMicroPatente.Text = _viaje.Micro.Patente;
            tbMicroServicio.Text = _viaje.Micro.Servicio.TipoServicio;
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

        private void tsmComprarPasajes_Click(object sender, EventArgs e)
        {
            using (RecorridoListado frm = new RecorridoListado())
            {
                frm.ShowDialog(this);
                _recorrido = frm.RecorridoSeleccionado();
                MostrarOpcionesRecorrido();
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

        private void canjearPuntosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (RecompensaCanjearPuntos frm = new RecompensaCanjearPuntos())
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
            Pasaje p = ObtenerPasaje();
            _pasajes.Add(p);

            this.lbPasajeros.DataSource = _pasajes;

        }

        private Pasaje ObtenerPasaje()
        {
            Pasaje pasaje = null;
            using (PasajeAlta frm = new PasajeAlta(_viaje))
            {
                frm.ShowDialog(this);
                pasaje = frm.PasajeNuevo;
            }
        
            return pasaje;
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
            cargarArribaToolStripMenuItem.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("cargarArribaToolStripMenuItem");
            tsmViaje.Enabled = tsmViajeAlta.Enabled || tsmViajeListado.Enabled;

            //Menú Cliente:
            tsmClienteListado.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmClienteListado");
            tsmClienteAlta.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmClienteAlta");

            tsmClientePasajeroFrecuenteConsultar.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmClientePasajeroFrecuenteConsultar");
            tsmClientePasajeroFrecuenteConsultar.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("canjeDePuntosToolStripMenuItem");
            tsmClientePasajeroFrecuente.Enabled = tsmClientePasajeroFrecuenteConsultar.Enabled;
            tsmCliente.Enabled = tsmClienteListado.Enabled || tsmClienteAlta.Enabled || tsmClientePasajeroFrecuente.Enabled;

            //Menú Viaje:
            tsmViajeAlta.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmViajeAlta");
            tsmViajeListado.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmViajeListado");
            cargarArribaToolStripMenuItem.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("cargarArribaToolStripMenuItem");
                       
            tsmViaje.Enabled = tsmViajeAlta.Enabled || tsmViajeListado.Enabled;

            //Pasaje/Encomienda:
            tsmEncomienda.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmComprarPasajes");
            tsmPasajesListar.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmPasajesListar");
            tsmEncomiendasListar.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmEncomiendasListar");

            tsmCancelacionesListado.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmCancelacionesListado");
            tsmCancelacionesCompra.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmCancelacionesCompra");
            tsmCancelacionesPasaje.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmCancelacionesPasaje");
            tsmCancelacionesEncomienda.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmCancelacionesEncomienda");
            
            tsmPasajeEncomiendaCancelar.Enabled = tsmCancelacionesEncomienda.Enabled || tsmCancelacionesPasaje.Enabled || tsmCancelacionesListado.Enabled;
            tsmEncomienda.Enabled = tsmPasajesListar.Enabled || tsmEncomiendasListar.Enabled || tsmCancelacionesCompra.Enabled || tsmPasajeEncomiendaCancelar.Enabled;


            //Recompensas:
            tsmPremiosListado.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmPremiosListado");
            canjearPuntosToolStripMenuItem.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("canjearPuntosToolStripMenuItem");
            tsmPremios.Enabled = tsmPremiosListado.Enabled || canjearPuntosToolStripMenuItem.Enabled;

            //Menú Estadísticas:
            tsmEstadisticasListados.Enabled = Program.ContextoActual.UsuarioActual.RolAsignado.PermiteFuncionalidad("tsmEstadisticasListados");
            tsmEstadisticas.Enabled = tsmEstadisticasListados.Enabled;
            
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
            using (ViajeListado frm = new ViajeListado(_recorrido))
            {
                frm.ShowDialog(this);
                _viaje = frm.ViajeSeleccionado();
            }
            if (_viaje != null)
                MostrarOpcionesViaje();
        }
        private void btnCargarDetalles_Click(object sender, EventArgs e)
        {
            LimpiarGrupoDetalles(true);
        }

        private void tsmPremiosListado_Click(object sender, EventArgs e)
        {
            using (RecompensaListado frm = new RecompensaListado())
            {
                frm.ShowDialog(this);   
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            using (RecorridoListado frm = new RecorridoListado(true))
            {
                frm.ShowDialog(this);
                _recorrido = frm.RecorridoSeleccionado();
                MostrarOpcionesRecorrido();
            }
        }

        private void cargarArribaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ViajeCargarArribo frm = new ViajeCargarArribo())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnQuitarPasajero_Click(object sender, EventArgs e)
        {
            Pasaje p = this.lbPasajeros.SelectedItem as Pasaje;
            if (p != null)
            {
                this.lbPasajeros.Items.Remove(p);
            }
        }

        private void btnModificarPasajero_Click(object sender, EventArgs e)
        {
            Pasaje p = this.lbPasajeros.SelectedItem as Pasaje;
            if (p != null)
            {
                using (PasajeModificar frm = new PasajeModificar(p, _viaje))
                {
                    frm.ShowDialog(this);
                    p = frm.PasajeModificado;
                }
            }

        }

        private void cancelarCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Cancelaciones.CancelacionCompra frm = new Cancelaciones.CancelacionCompra ())
            {
                frm.ShowDialog(this);
            }
        }

        private void cancelarPasajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Cancelaciones.CancelacionPasaje frm = new Cancelaciones.CancelacionPasaje())
            {
                frm.ShowDialog(this);
            }
        }

        private void cancelarEncomiendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Cancelaciones.CancelacionEncomienda frm = new Cancelaciones.CancelacionEncomienda())
            {
                frm.ShowDialog(this);
            }
        }

        private void tsmPasajesListar_Click(object sender, EventArgs e)
        {
            using (Compras.PasajeListado frm = new PasajeListado())
            {
                frm.ShowDialog(this);
            }
        }

        private void tsmEncomiendasListar_Click(object sender, EventArgs e)
        {
            using (Compras.EncomiendaListado frm = new EncomiendaListado())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            //Valido si puedo comprar:
            ClienteManager _clienteManager = new ClienteManager();

            var clientes = _pasajes.Select(p => _clienteManager.Obtener(p.NroDni)).ToList();
            int cantDiscapacitados = clientes.Count(p => p.EsDiscapacitado);

            if (cantDiscapacitados > 2)
            {
                MensajePorPantalla.MensajeError(this, "Solo puede haber un pasajero discapacitado por compra");
                return;
            }

            if (cantDiscapacitados == 1)
            {
                var pasajesAQuitarMonto = new List<Pasaje>();
                
                var discapacitado = clientes.Where(c => c.EsDiscapacitado).FirstOrDefault();
                pasajesAQuitarMonto.Add(_pasajes.First(p => p.NroDni == discapacitado.NroDni));

                if (_pasajes.Count > 1)
                {
                    pasajesAQuitarMonto.Add(_pasajes.FirstOrDefault(p => p.NroDni != discapacitado.NroDni));
                }

                foreach (Pasaje p in pasajesAQuitarMonto)
                {
                    p.PrecioPasaje = 0;
                }
            }

            // Primero tengo que generar la compra;
            Compra compra = new Compra();
            compra.FechaCompra = Helpers.FechaHelper.Ahora();
            compra.IdUsuario = Program.ContextoActual.UsuarioActual.IdUsuario;
            
            try
            {    
                // Impacto la compra contra la base de datos
                _compraManager.Alta(compra);
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
                compra = null;
            }

            if (compra != null)
            {
                try
                {
                    //Impacto los pasajes a la compra en la base de datos
                    int retornoPasajes = AltaPasajesDeCompra(compra);

                    //Impacto las encomiendas a la compra en la base de datos
                    int retornoEncomiendas = AltaEncomiendasDeCompra(compra);

                    MensajePorPantalla.MensajeInformativo(this, "Se ha dado de alta la compra con id: " + compra.IdCompra);
                }
                catch (Exception ex)
                {
                    //Cancelar la compra
                    MensajePorPantalla.MensajeError(this, ex.Message);
                }
            }
            
        }

        private int AltaEncomiendasDeCompra(Compra compra)
        {
            foreach (Encomienda encomienda in _encomiendas)
            {
                _compraManager.CompraEncomienda(compra, encomienda);
            }
            return _encomiendas.Count;
        }

        private int AltaPasajesDeCompra(Compra compra)
        {
            foreach (Pasaje pasaje in _pasajes)
            {
                _compraManager.CompraPasaje(compra, pasaje);
            }
            return _pasajes.Count();
        }

        private void btnHabilitarConfirmarCompra_Click(object sender, EventArgs e)
        {
            this.LimpiarGrupoMedioPago(true);
        }

        private void tsmPasajeEncomiendaListadoCompras_Click(object sender, EventArgs e)
        {
            using (Compras.ComprasListado frm = new ComprasListado())
            {
                frm.ShowDialog();
            }
        }

        private void tsmCancelacionesListado_Click(object sender, EventArgs e)
        {
            using (Cancelaciones.CancelacionesListado frm = new FrbaBus.Cancelaciones.CancelacionesListado())
            {
                frm.ShowDialog();
            }
        }
    }
}
