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

namespace FrbaBus.Abm_Micro
{
    public partial class MicroAlta : Form
    {
        public MicroAlta()
        {
            InitializeComponent();
        }

        private void cbbMicroAltaTipoEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnMicroAltaLimpiar_Click(object sender, EventArgs e)
        {
            this.cbbMicroAltaTipoEmpresa.SelectedIndex = 0;
            this.cbbMicroAltaTipoModelo.SelectedIndex = 0;
            this.cbbMicroAltaTipoServicio.SelectedIndex = 0;
            this.mtbMicroAltaCantidadButacas.Text = string.Empty;
            this.mtbMicroAltaKgsEncomiendas.Text = string.Empty;
        }

        private void MicroAlta_Load(object sender, EventArgs e)
        {
            CargarEmpresas();
            CargarServicios();
        }

        private void CargarEmpresas()
        {
            IList<Empresa> empresas = new MicroManager().ObtenerEmpresasDisponibles();

            this.cbbMicroAltaTipoEmpresa.DataSource = empresas;
            this.cbbMicroAltaTipoEmpresa.DisplayMember = "Descripcion";
            this.cbbMicroAltaTipoEmpresa.ValueMember = "Id";
        }
        private void CargarServicios()
        {
            IList<Servicio> servicios = new MicroManager().ObtenerServiciosDisponibles();

            this.cbbMicroAltaTipoServicio.DataSource = servicios;
            this.cbbMicroAltaTipoServicio.DisplayMember = "TipoServicio";
            this.cbbMicroAltaTipoServicio.ValueMember = "Id";
        }
    }
}
