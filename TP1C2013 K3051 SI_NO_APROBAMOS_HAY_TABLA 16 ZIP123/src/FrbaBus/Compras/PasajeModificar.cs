using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Common.Entidades;
using FrbaBus.Common.Helpers;
using FrbaBus.Common.Excepciones;
using FrbaBus.Abm_Clientes;
using FrbaBus.Abm_Micro;
using FrbaBus.Manager;

namespace FrbaBus.Compras
{
    public partial class PasajeModificar : Form
    {
        private PasajeManager _manager;

        private Pasaje _pasaje;
        private Viaje _viaje;
        private Butaca _butaca;
        private Cliente _cliente;
        public Pasaje PasajeModificado { get { return _pasaje; } }

        public PasajeModificar(Pasaje p, Viaje v)
        {
            _manager = new PasajeManager();

            _viaje = v;
            _pasaje = p;
            _butaca = null;
            _cliente = null;

            InitializeComponent();
        }

        private void PasajeModificar_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            tbButaca.Text = _pasaje.Butaca.Informacion;
            tbCliente.Text = _pasaje.NroDni.ToString();
            tbMicro.Text = _viaje.Micro.Informacion;
            tbPrecio.Text = _pasaje.PrecioPasaje.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatos())
            {
                try
                {
                    _pasaje.Butaca = _butaca;
                    _pasaje.IdViaje = _viaje.Id;
                    _pasaje.NroDni = _cliente.NroDni;
                    _pasaje.PrecioPasaje = Convert.ToDecimal(tbPrecio.Text);

                    MensajePorPantalla.MensajeInformativo(this, "Se modificó la solicitud de pasaje");

                    this.Close();
                }
                catch (AccesoBDException ex)
                {
                    MensajePorPantalla.MensajeExceptionBD(this, ex);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MensajePorPantalla.MensajeError(this, "Error al intentar modificar el registro.\n Detalle del error: " + ex.Message);
                    this.Close();
                }
            }
        }

        private bool ValidarDatos()
        {
            return true;
        }
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            this._cliente = ObtenerCliente();
            if (_butaca != null && _cliente != null)
            {
                MostrarPrecio();
            }
        }
        private void btnSeleccionarButaca_Click(object sender, EventArgs e)
        {
            this._butaca = ObtenerButaca();
            if (_butaca != null && _cliente != null)
            {
                MostrarPrecio();
            }
        }
        private Butaca ObtenerButaca()
        {
            Butaca b = null;
            using (MicroButacaListado frm = new MicroButacaListado(_viaje))
            {
                frm.ShowDialog();
                b = frm.ButacaSeleccionada();
            }
            return b;
        }
        private Cliente ObtenerCliente()
        {
            Cliente cliente = null;
            using (ClienteListado frm = new ClienteListado(true))
            {
                frm.ShowDialog(this);
                if (frm.ClienteSeleccionado() != null)
                    cliente = frm.ClienteSeleccionado();
            }

            if (cliente == null)
            {
                MensajePorPantalla.MensajeInformativo(this, "No ha seleccionado un cliente, se dará de alta uno nuevo");

                using (ClienteAlta frm = new ClienteAlta())
                {
                    frm.ShowDialog(this);

                    if (frm.ClienteNuevo() != null)
                    {
                        cliente = frm.ClienteNuevo();
                    }
                }
            }
            return cliente;
        }
        private void MostrarPrecio()
        {
            decimal precio = this._manager.BuscarPrecio(_viaje.Recorrido, _cliente.NroDni);
            this.tbPrecio.Text = precio.ToString();
        }

    }
}
