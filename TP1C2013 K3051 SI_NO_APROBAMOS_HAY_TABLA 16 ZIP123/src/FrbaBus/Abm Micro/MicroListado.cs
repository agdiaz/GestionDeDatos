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
    public partial class MicroListado : Form
    {
        public MicroListado()
        {
            InitializeComponent();
        }

        private void btnMicroListadoLimpiar_Click(object sender, EventArgs e)
        {
            this.tbMicroListadoKgsEncomiendas.Text = string.Empty;
            this.tbMicroListadoNumeroPatente.Text = string.Empty;
            this.tbMicroListadoPatente.Text = string.Empty;
            this.cbbMicroListadoTipoEmpresa.SelectedIndex = 0;
            this.cbbMicroListadoTipoModelo.SelectedIndex = 0;
            this.cbbMicroListadoTipoServicio.SelectedIndex = 0;
        }

        private void MicroListado_Load(object sender, EventArgs e)
        {
            CargarServicios();
            CargarEmpresas();
        }
        private void CargarEmpresas()
        {
            IList<Empresa> empresas = new MicroManager().ObtenerEmpresasDisponibles();

            this.cbbMicroListadoTipoEmpresa.DataSource = empresas;
            this.cbbMicroListadoTipoEmpresa.DisplayMember = "Descripcion";
            this.cbbMicroListadoTipoEmpresa.ValueMember = "Id";
        }
        private void CargarServicios()
        {
            IList<Servicio> servicios = new MicroManager().ObtenerServiciosDisponibles();

            this.cbbMicroListadoTipoServicio.DataSource = servicios;
            this.cbbMicroListadoTipoServicio.DisplayMember = "TipoServicio";
            this.cbbMicroListadoTipoServicio.ValueMember = "Id";
        }
    }
}
