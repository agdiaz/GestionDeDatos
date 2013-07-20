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
using FrbaBus.Common.Helpers;
using FrbaBus.Common.Excepciones;

namespace FrbaBus.Abm_Ciudad
{
    public partial class CiudadAlta : Form
    {
        private CiudadManager _manager;
        public CiudadAlta()
        {
            this._manager = new CiudadManager();
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
                try
                {
                    Ciudad c = new Ciudad();
                    c.Nombre = this.tbCiudadAltaCiudad.Text;

                    _manager.Alta(c);

                    MensajePorPantalla.MensajeInformativo(this, "Se dio de alta la ciudad con el id: " + c.Id.ToString());

                    this.Close();
                }
                catch (AccesoBDException ex)
                {
                    MensajePorPantalla.MensajeExceptionBD(this, ex);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MensajePorPantalla.MensajeError(this, "Error al intentar dar el registro.\n Detalle del error: " + ex.Message);
                    this.Close();
                }
            }
        }

        private bool ValidarDatos()
        {
            if (String.IsNullOrEmpty(this.tbCiudadAltaCiudad.Text))
            {
                MensajePorPantalla.MensajeError(this, "Debe ingresar un nombre");
                return false;
            }
            return true;
        }
    }
}
