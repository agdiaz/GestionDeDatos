using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Manager;
using FrbaBus.Helpers;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Abm_Ciudad
{
    public partial class CiudadAlta : Form
    {
        public CiudadAlta()
        {
            InitializeComponent();
        }

        private void btnCiudadAltaLimpiar_Click(object sender, EventArgs e)
        {
            this.tbCiudadAltaCiudad.Text = "";
        }

        private void btnCiudadAltaGuardar_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatos())
            {
                Ciudad c = new Ciudad()
                {
                    Nombre = this.tbCiudadAltaCiudad.Text
                };
                
                new CiudadManager().Alta(c);

                this.Close();
            }
        }

        private bool ValidarDatos()
        {
            if (String.IsNullOrEmpty(this.tbCiudadAltaCiudad.Text))
            {
                MensajeDeError.MostrarError(lblCiudadAltaCiudad);
                return false;
            }
            return true;
        }
    }
}
