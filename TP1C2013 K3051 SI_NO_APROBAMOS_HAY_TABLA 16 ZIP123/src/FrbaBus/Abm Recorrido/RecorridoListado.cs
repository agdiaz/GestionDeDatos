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
using FrbaBus.Common.Excepciones;
using FrbaBus.Common.Helpers;

namespace FrbaBus.Abm_Recorrido
{
    public partial class RecorridoListado : Form
    {
        public RecorridoListado()
        {
            InitializeComponent();
        }

        private void btnRecorridoListadoBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var origenId = this.cbCiudadOrigen.SelectedIndex;
                var destinoId = this.cbCiudadDestino.SelectedIndex;
                var servicioId = this.cbbRecorridoListadoTipoServicio.SelectedIndex;

                DataSet ds = new MicroManager().ObtenerRegistrosRecorrido(origenId, destinoId, servicioId);
                this.dgvRecorridoListado.DataSource = ds;
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

        private void btnRecorridoListadoLimpiar_Click(object sender, EventArgs e)
        {
            this.cbbRecorridoListadoTipoServicio.SelectedIndex = 0;
            this.cbCiudadOrigen.SelectedIndex = 0;
            this.cbCiudadDestino.SelectedIndex = 0;
        }

        private void RecorridoListado_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCiudades();
                CargarServicios();
                this.dgvRecorridoListado.DataSource = new MicroManager().ObtenerRegistrosRecorrido().Tables[0];
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

        private void CargarCiudades()
        {
            IList<Ciudad> ciudadesOrigen = new CiudadManager().ObtenerListado();
            IList<Ciudad> ciudadesDestino = new CiudadManager().ObtenerListado();

            this.cbCiudadOrigen.DataSource = ciudadesOrigen;
            this.cbCiudadOrigen.DisplayMember = "Descripcion";
            this.cbCiudadOrigen.ValueMember = "Id";

            this.cbCiudadDestino.DataSource = ciudadesDestino;
            this.cbCiudadDestino.DisplayMember = "Descripcion";
            this.cbCiudadDestino.ValueMember = "Id";
        }
        private void CargarServicios()
        {
            IList<Servicio> servicios = new MicroManager().ObtenerServiciosDisponibles();

            this.cbbRecorridoListadoTipoServicio.DataSource = servicios;
            this.cbbRecorridoListadoTipoServicio.DisplayMember = "TipoServicio";
            this.cbbRecorridoListadoTipoServicio.ValueMember = "Id";
        }
    }
}
