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
using FrbaBus.Common.Helpers;
using FrbaBus.Common.Excepciones;

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
            this.tbMicroListadoNumeroMicro.Text = string.Empty;
            this.tbMicroListadoPatente.Text = string.Empty;
            this.cbbMicroListadoTipoEmpresa.SelectedIndex = 0;
            this.cbbMicroListadoTipoModelo.SelectedIndex = 0;
            this.cbbMicroListadoTipoServicio.SelectedIndex = 0;
        }

        private void MicroListado_Load(object sender, EventArgs e)
        {
            try
            {
                CargarServicios();
                CargarEmpresas();
                this.dgvMicroListado.DataSource = new MicroManager().ObtenerRegistrosMicro().Tables[0];
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

        private void btnMicroListadoBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string kgsEncomiendas = this.tbMicroListadoKgsEncomiendas.Text;
                string numeroPatente = this.tbMicroListadoNumeroMicro.Text;
                string numeroMicro = this.tbMicroListadoNumeroMicro.Text;
                string tipoEmpresa = this.cbbMicroListadoTipoEmpresa.Text;
                string tipoModelo = this.cbbMicroListadoTipoModelo.Text;
                string tipoServicio = this.cbbMicroListadoTipoServicio.Text;

                DataSet dsMicros = new MicroManager().ObtenerRegistrosMicro(kgsEncomiendas, numeroPatente, numeroMicro, tipoEmpresa, tipoModelo, tipoServicio);
                this.dgvMicroListado.DataSource = dsMicros.Tables[0];
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
    }
}
