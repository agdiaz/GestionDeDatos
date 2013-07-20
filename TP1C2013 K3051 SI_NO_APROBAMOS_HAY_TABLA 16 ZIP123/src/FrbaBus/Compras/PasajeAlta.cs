using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Common.Entidades;
using FrbaBus.Abm_Clientes;
using FrbaBus.Common.Helpers;
using FrbaBus.Manager;
using FrbaBus.Abm_Micro;
using FrbaBus.Common.Excepciones;

namespace FrbaBus.Compras
{
    public partial class PasajeAlta : Form
    {
        private Viaje _viaje;
        private Cliente _cliente;
        private Butaca _butaca;

        public Pasaje PasajeNuevo { get; set; }
        
        private PasajeManager _manager;

        public PasajeAlta(Viaje v)
        {
            _manager = new PasajeManager();
            _viaje = v;
            InitializeComponent();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            this._cliente = ObtenerCliente();
            if (_cliente != null)
            {
                tbCliente.Text = _cliente.ToString();
            }
            if (_butaca != null && _cliente != null)
            {
                MostrarPrecio();
            }
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

        private void btnSeleccionarButaca_Click(object sender, EventArgs e)
        {
            this._butaca = ObtenerButaca();
            if (_butaca != null)
            {
                tbButaca.Text = _butaca.Informacion;
            }
            if (_butaca != null && _cliente != null)
            {
                MostrarPrecio();
            }
        }

        private void MostrarPrecio()
        {
            this.tbPrecio.Text = "0";
            try
            {
                decimal precio = this._manager.BuscarPrecio(_viaje.Recorrido, _cliente.NroDni);
                this.tbPrecio.Text = precio.ToString();
            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error.\n Detalle del error: " + ex.Message);
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

        private void PasajeAlta_Load(object sender, EventArgs e)
        {
            this.tbMicro.Text = _viaje.Micro.Informacion;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatos())
            {
                try
                {
                    Pasaje p = new Pasaje();
                    p.Butaca = _butaca;
                    p.IdViaje = _viaje.Id;
                    p.NroDni = _cliente.NroDni;
                    p.PrecioPasaje = Convert.ToDecimal(tbPrecio.Text);

                    MensajePorPantalla.MensajeInformativo(this, "Se dio de alta la solicitud de pasaje");
                    PasajeNuevo = p;

                    this.Close();
                }
                catch (AccesoBDException ex)
                {
                    MensajePorPantalla.MensajeExceptionBD(this, ex);
                }
                catch (Exception ex)
                {
                    MensajePorPantalla.MensajeError(this, "Error al intentar dar el registro.\n Detalle del error: " + ex.Message);
                }
            }

        }

        private bool ValidarDatos()
        {
            return true;
        }
    }
}
