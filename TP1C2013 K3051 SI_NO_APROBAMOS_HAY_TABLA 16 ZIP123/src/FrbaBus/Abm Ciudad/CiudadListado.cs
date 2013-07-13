using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Manager;
using FrbaBus.Common.Helpers;
using FrbaBus.Common.Excepciones;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Abm_Ciudad
{
    public partial class CiudadListado : Form
    {
        public CiudadListado()
        {
            InitializeComponent();

        }

        private void btnCiudadListadoBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string ciudadElegida = this.tbCiudadListadoCiudad.Text;
                IList<Ciudad> dsCiudades = new CiudadManager().ObtenerListado(ciudadElegida);
                this.dgvCiudadListado.DataSource = dsCiudades;
            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error al realizar la búsqueda correspondiente.\n Detalle del error: " + ex.Message);
            }
        }

        private void CiudadListado_Load(object sender, EventArgs e)
        {
            try
            {
                CiudadManager cm = new CiudadManager();
                DataSet ciudades = cm.Listar();
                this.dgvCiudadListado.DataSource = ciudades.Tables[0];
            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
                this.Close();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error al intentar cargar el listado.\n Detalle del error: " + ex.Message);
                this.Close();
            }
        }

        private void btnCiudadListadoLimpiar_Click(object sender, EventArgs e)
        {
            tbCiudadListadoCiudad.Text = "";
        }
    }
}
