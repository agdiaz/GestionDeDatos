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
            
            
        }

        private void btnRecorridoListadoLimpiar_Click(object sender, EventArgs e)
        {
            this.cbbRecorridoListadoTipoServicio.SelectedIndex = 0;
            this.cbCiudadOrigen.SelectedIndex = 0;
            this.cbCiudadDestino.SelectedIndex = 0;
        }

        private void RecorridoListado_Load(object sender, EventArgs e)
        {
            CargarCiudades();
            CargarServicios();
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
