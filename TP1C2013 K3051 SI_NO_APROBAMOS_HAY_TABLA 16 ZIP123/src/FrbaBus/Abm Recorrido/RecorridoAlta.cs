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
        private RecorridoManager _manager;
        private CiudadManager _ciudadManager;
        private ServicioManager _servicioManager;

        public RecorridoAlta()
        {
            InitializeComponent();
            this._manager = new RecorridoManager();
            this._ciudadManager = new CiudadManager();
            this._servicioManager = new ServicioManager();
        }

        private void RecorridoAlta_Load(object sender, EventArgs e)
        {
            CargarCiudades();
            CargarServicios();
        }

        private void btnRecorridoAltaLimpiar_Click(object sender, EventArgs e)
        {
            this.cbbRecorridoAltaTipoServicio.SelectedIndex = 0;
            this.cbCiudadDestino.SelectedIndex = 0;
            this.cbCiudadOrigen.SelectedIndex = 0;
            this.tbRecorridoAltaPrecioBasePorKgs.Text = string.Empty;
            this.tbRecorridoAltaPrecioBasePorPasaje.Text = string.Empty;
        }

        private void CargarCiudades()
        {
            IList<Ciudad> ciudadesOrigen = _ciudadManager.Listar();
            IList<Ciudad> ciudadesDestino = _ciudadManager.Listar();

            this.cbCiudadOrigen.DataSource = ciudadesOrigen;
            this.cbCiudadOrigen.DisplayMember = "Nombre";
            this.cbCiudadOrigen.ValueMember = "Id";

            this.cbCiudadDestino.DataSource = ciudadesDestino;
            this.cbCiudadDestino.DisplayMember = "Nombre";
            this.cbCiudadDestino.ValueMember = "Id";
        }

        private void CargarServicios()
        {
            IList<Servicio> servicios = _servicioManager.Listar();

            this.cbbRecorridoAltaTipoServicio.DataSource = servicios;
            this.cbbRecorridoAltaTipoServicio.DisplayMember = "TipoServicio";
            this.cbbRecorridoAltaTipoServicio.ValueMember = "Id";
        }

        private void btnRecorridoAltaGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
