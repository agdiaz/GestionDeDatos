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
using FrbaBus.Common.Excepciones;
using FrbaBus.Common.Helpers;

namespace FrbaBus.Compras
{
    public partial class EncomiendaModificar : Form
    {
        private Encomienda _encomienda;
        private Cliente _cliente;

        public EncomiendaModificar(Encomienda enc)
        {
            _encomienda = enc;
            InitializeComponent();
        }

        private void btnEncomiendaAltaDniCliente_Click(object sender, EventArgs e)
        {
            try
            {
                using (ClienteListado frm = new ClienteListado(true))
                {
                    frm.ShowDialog(this);
                    _cliente = frm.ClienteSeleccionado();
                }
                if (_cliente != null)
                    tbEncomiendaModificarDniCliente.Text = _cliente.NroDni.ToString();
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

        private void btnEncomiendaModificarGuardar_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatos())
            {
                try
                {
                    if (_cliente != null)
                        _encomienda.NroDni = _cliente.NroDni;

                    _encomienda.Peso = Convert.ToDecimal(tbEncomiendaModificarPesoKg.Text);

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
            if (tbEncomiendaModificarPesoKg.Text == "")
            {
                MensajePorPantalla.MensajeError(this, "Debe ingresar un peso");
                return false;
            }
            return true;
        }

        private void EncomiendaModificar_Load(object sender, EventArgs e)
        {
            tbEncomiendaModificarDniCliente.Text = _encomienda.NroDni.ToString();
            tbEncomiendaModificarPesoKg.Text = _encomienda.Peso.ToString();
            tbEncomiendaModificarViaje.Text = _encomienda.IdViaje.ToString();
        }
    }
}
