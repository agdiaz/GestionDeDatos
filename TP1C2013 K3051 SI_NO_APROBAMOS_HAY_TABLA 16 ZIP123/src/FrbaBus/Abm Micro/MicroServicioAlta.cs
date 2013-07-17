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
                Servicio c = new Servicio()
                {
                    TipoServicio = this.tbMicroServicioAltaTipoServicio.Text
                };

                new ServicioManager().Alta(c);

                MensajePorPantalla.MensajeInformativo(this, "Se dio de alta el servicio con el id: " + c.Id.ToString());

                this.Close();
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
    }
}
