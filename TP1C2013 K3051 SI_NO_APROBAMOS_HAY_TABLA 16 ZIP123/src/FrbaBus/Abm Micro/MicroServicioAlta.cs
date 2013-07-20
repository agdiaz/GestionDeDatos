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
using FrbaBus.Helpers;
using FrbaBus.Common.Excepciones;

namespace FrbaBus.Abm_Micro
{
    public partial class MicroServicioAlta : Form
    {
        public MicroServicioAlta()
        {
            InitializeComponent();
        }

        private void btnMicroServicioAltaGuardar_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatos())
            {
                try
                {
                    Servicio c = new Servicio()
                            {
                                TipoServicio = this.tbMicroServicioAltaTipoServicio.Text,
                                Adicional = Convert.ToDecimal(this.tbAdicional.Text)
                            };

                    c = new ServicioManager().Alta(c);

                    MensajePorPantalla.MensajeInformativo(this, "Se dio de alta el servicio con el id: " + c.Id.ToString());

                    this.Close();
                }
                catch (AccesoBDException ex)
                {
                    MensajePorPantalla.MensajeExceptionBD(this, ex);
                }
                catch (Exception ex)
                {
                    MensajePorPantalla.MensajeError(this, "Error al intentar crear el registro.\n Detalle del error: " + ex.Message);
                    this.Close();
                }
            }
        }
        
        private bool ValidarDatos()
        {
            if (String.IsNullOrEmpty(this.tbMicroServicioAltaTipoServicio.Text))
            {
                MensajeDeError.MostrarError(lblMicroServicioAltaTipoServicio);
                return false;
            }
            return true;
        }

        private void btnMicroServicioAltaLimpiar_Click(object sender, EventArgs e)
        {

        }
    }
}
