using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Common.Entidades;
using FrbaBus.Manager;
using FrbaBus.Common.Helpers;
using FrbaBus.Common.Excepciones;

namespace FrbaBus.Cancelaciones
{
    public partial class CancelacionPasaje : Form
    {
        private Pasaje pasaje;
        private CancelacionManager _manager;

        public CancelacionPasaje()
        {
            _manager = new CancelacionManager();
            pasaje = null;
            InitializeComponent();
        }

        private void btnCancelacionPasajeBuscarCompra_Click(object sender, EventArgs e)
          {
            using (Compras.PasajeListado frm = new FrbaBus.Compras.PasajeListado(true))
            {
                frm.ShowDialog();
                pasaje = frm.PasajeSeleccionado();
            }
            MostrarPasaje();
        }

        private void MostrarPasaje()
        {
            if (pasaje != null)
            {
                this.tbCancelacionPasaje.Text = pasaje.Id.ToString();
            }
        }

        private void btnCancelacionPasajeCancelarPasaje_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                try
                {
                    _manager.CancelarPasaje(pasaje, tbMotivoCancelPasaje.Text);

                    MensajePorPantalla.MensajeInformativo(this, "Se cancelo el pasaje con el id: " + pasaje.IdCompra);
                    this.Close();
                }
                catch (AccesoBDException ex)
                {
                    MensajePorPantalla.MensajeExceptionBD(this, ex);

                }
                catch (Exception ex)
                {
                    MensajePorPantalla.MensajeError(this, "Error al intentar modificar el registro.\n Detalle del error: " + ex.Message);

                }
            }
        }

        private bool ValidarDatos()
        {
            if (pasaje == null)
            {
                MensajePorPantalla.MensajeError(this, "Debe seleccionar un pasaje");
                return false;
            }
            if (tbMotivoCancelPasaje.Text == "")
            {
                MensajePorPantalla.MensajeError(this, "Debe ingresar un motivo");
                return false;
            }
            return true;
        }

    }
}
