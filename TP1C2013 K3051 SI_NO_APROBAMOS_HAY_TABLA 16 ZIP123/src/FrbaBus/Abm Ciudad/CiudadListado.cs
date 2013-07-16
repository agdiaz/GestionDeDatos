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

        private void CargarCiudades()
        {
            try
            {
                CiudadManager cm = new CiudadManager();
                IList<Ciudad> ciudades = cm.Listar();
                this.dgvCiudadListado.DataSource = ciudades;
                this.dgvCiudadListado.Columns["Id"].Visible = false;
                this.dgvCiudadListado.Columns["Nombre"].Width = 300;
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
        private void CiudadListado_Load(object sender, EventArgs e)
        {
            CargarCiudades();
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
        private void btnCiudadListadoLimpiar_Click(object sender, EventArgs e)
        {
            tbCiudadListadoCiudad.Text = "";
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Ciudad ciudad = dgvCiudadListado.SelectedRows[0].DataBoundItem as Ciudad;
                
                using (CiudadModificar frm = new CiudadModificar(ciudad))
                {
                    frm.ShowDialog(this);
                }
                CargarCiudades();
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

            CargarCiudades();
        }
        private void btnCiudadListadoDarBaja_Click(object sender, EventArgs e)
        {
            try
            {
                Ciudad ciudad = dgvCiudadListado.SelectedRows[0].DataBoundItem as Ciudad;
                new CiudadManager().Baja(ciudad);
                CargarCiudades();
            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
                this.Close();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error al intentar cargar borrar el registro.\n Detalle del error: " + ex.Message);
                this.Close();
            }

            CargarCiudades();

        }

        private void dgvCiudadListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
