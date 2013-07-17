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
        private MicroManager _manager;
        private ServicioManager _servicioManager;
        private RecorridoManager _recorridoManager;
        private EmpresaManager _empresaManager;

        public MicroListado()
        {
            this._manager = new MicroManager();
            this._recorridoManager = new RecorridoManager();
            this._servicioManager = new ServicioManager();
            this._empresaManager = new EmpresaManager();
    
            InitializeComponent();
        }

        public Micro MicroSeleccionado()
        {
            Micro seleccionado = null;

            seleccionado = dgvMicroListado.SelectedRows[0].DataBoundItem as Micro;

            return seleccionado;
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

                CargarMicros();
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

        private void CargarMicros()
        {
            this.dgvMicroListado.DataSource = _manager.Listar();
            this.dgvMicroListado.Columns["Id"].Visible = false;
            this.dgvMicroListado.Columns["NumeroDeMicro"].Visible = false;
            this.dgvMicroListado.Columns["IdEmpresa"].Visible = false;
            this.dgvMicroListado.Columns["IdServicio"].Visible = false;
            this.dgvMicroListado.Columns["Empresa"].Visible = false;
        }
        private void CargarEmpresas()
        {
            IList<Empresa> empresas = _empresaManager.Listar();

            this.cbbMicroListadoTipoEmpresa.DataSource = empresas;
            this.cbbMicroListadoTipoEmpresa.DisplayMember = "Descripcion";
            this.cbbMicroListadoTipoEmpresa.ValueMember = "Id";
        }
        private void CargarServicios()
        {
            IList<Servicio> servicios = _servicioManager.Listar();

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

                this.dgvMicroListado.DataSource = _manager.ListarFiltrado(kgsEncomiendas, numeroPatente, numeroMicro, tipoEmpresa, tipoModelo, tipoServicio);
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

        private void btnMicroListadoModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnMicroListadoDarBaja_Click(object sender, EventArgs e)
        {
            try
            {
                Micro micro = dgvMicroListado.SelectedRows[0].DataBoundItem as Micro;
                _manager.Baja(micro);
                CargarMicros();
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
        }
    }
}
