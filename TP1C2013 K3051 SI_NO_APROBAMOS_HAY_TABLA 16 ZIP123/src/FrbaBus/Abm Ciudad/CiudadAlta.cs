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
                CiudadManager cm = new CiudadManager();
                cm.Alta(this.tbCiudadAltaCiudad.Text);
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
