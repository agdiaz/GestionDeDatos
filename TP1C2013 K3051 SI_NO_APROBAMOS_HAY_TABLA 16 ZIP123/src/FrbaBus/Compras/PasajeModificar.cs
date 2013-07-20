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

namespace FrbaBus.Compras
{
    public partial class PasajeModificar : Form
    {
        private Pasaje _pasaje;
        private Viaje _viaje;
        private Butaca _butaca;
        private Cliente _cliente;
        public Pasaje PasajeModificado { get { return _pasaje; } }

        public PasajeModificar(Pasaje p, Viaje v)
        {
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

        }
        private void btnSeleccionarButaca_Click(object sender, EventArgs e)
        {

        }
        private Butaca ObtenerButaca()
        {
            Butaca b = null;
            using (MicroButacaListado frm = new MicroButacaListado(_viaje.Micro))
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

    }
}
