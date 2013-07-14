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
    public partial class CiudadModificar : Form
    {
        private Ciudad CiudadSeleccionada { get; set; }

        public CiudadModificar(Ciudad ciudad)
        {
            this.CiudadSeleccionada = ciudad;
            InitializeComponent();
        }

        private void btnCiudadModificarLimpiar_Click(object sender, EventArgs e)
        {
            this.tbCiudadModificarCiudad.Text = CiudadSeleccionada.Descripcion;
        }

        private void btnCiudadModificarGuardar_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatos())
            {
                CiudadSeleccionada.Descripcion = this.tbCiudadModificarCiudad.Text;

                CiudadManager cm = new CiudadManager();
                cm.Modificar(CiudadSeleccionada);
                this.Close();
            }
        }

        private bool ValidarDatos()
        {
            if (String.IsNullOrEmpty(this.tbCiudadModificarCiudad.Text))
            {
                MensajeDeError.MostrarError(lblCiudadModificarCiudad);
                return false;
            }
            return true;
        }

        private void CiudadModificar_Load(object sender, EventArgs e)
        {
            this.tbCiudadModificarCiudad.Text = CiudadSeleccionada.Descripcion;
        }
    }
}
