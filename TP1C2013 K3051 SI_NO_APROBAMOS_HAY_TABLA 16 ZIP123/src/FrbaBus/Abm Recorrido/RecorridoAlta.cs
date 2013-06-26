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
    public partial class RecorridoAlta : Form
    {
        public RecorridoAlta()
        {
            InitializeComponent();
        }

        private void btnRecorridoAltaLimpiar_Click(object sender, EventArgs e)
        {
            this.cbbRecorridoAltaTipoServicio.SelectedIndex = 0;
            this.cbCiudadDestino.SelectedIndex = 0;
            this.cbCiudadOrigen.SelectedIndex = 0;
            this.tbRecorridoAltaPrecioBasePorKgs.Text = string.Empty;
            this.tbRecorridoAltaPrecioBasePorPasaje.Text = string.Empty;
        }

        private void RecorridoAlta_Load(object sender, EventArgs e)
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

            this.cbbRecorridoAltaTipoServicio.DataSource = servicios;
            this.cbbRecorridoAltaTipoServicio.DisplayMember = "TipoServicio";
            this.cbbRecorridoAltaTipoServicio.ValueMember = "Id";
        }
    }
}
