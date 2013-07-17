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
    public partial class CiudadModificar : Form
    {
        private CiudadManager _manager;

        private Ciudad CiudadSeleccionada { get; set; }

        public CiudadModificar(Ciudad ciudad)
        {
            _manager = new CiudadManager(); 
            this.CiudadSeleccionada = ciudad;
            InitializeComponent();
        }

        private void btnCiudadModificarLimpiar_Click(object sender, EventArgs e)
        {
            this.tbCiudadModificarCiudad.Text = CiudadSeleccionada.Nombre;
        }

        private void btnCiudadModificarGuardar_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatos())
            {
                try
                {
                    CiudadSeleccionada.Nombre = this.tbCiudadModificarCiudad.Text;

                    _manager.Modificar(CiudadSeleccionada);

                    MensajePorPantalla.MensajeInformativo(this, "Se ha modificado la ciudad con el id: " + CiudadSeleccionada.Id.ToString());
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
            if (String.IsNullOrEmpty(this.tbCiudadModificarCiudad.Text))
            {
                MensajeDeError.MostrarError(lblCiudadModificarCiudad);
                return false;
            }
            return true;
        }

        private void CiudadModificar_Load(object sender, EventArgs e)
        {
            this.tbCiudadModificarCiudad.Text = CiudadSeleccionada.Nombre;
        }
    }
}
