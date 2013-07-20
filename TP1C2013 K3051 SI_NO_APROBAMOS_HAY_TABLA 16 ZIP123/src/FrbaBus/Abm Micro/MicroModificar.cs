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
    public partial class MicroModificar : Form
    {
        private MicroManager _manager;
        private EmpresaManager _empresaManager;
        private ServicioManager _servicioManager;
        private Micro _micro;

        public MicroModificar(Micro micro)
        {
            InitializeComponent();
            this._manager = new MicroManager();
            this._empresaManager = new EmpresaManager();
            this._servicioManager = new ServicioManager();
            _micro = micro;
        }

        private void cbbMicroModificarTipoEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnMicroModificarLimpiar_Click(object sender, EventArgs e)
        {
            this.cbbMicroModificarTipoEmpresa.SelectedIndex = 0;
            this.cbbMicroModificarTipoModelo.SelectedIndex = 0;
            this.cbbMicroModificarTipoServicio.SelectedIndex = 0;
            this.mtbMicroModificarKgsEncomiendas.Text = string.Empty;
        }

        private void MicroModificar_Load(object sender, EventArgs e)
        {
            this.cbbMicroModificarTipoModelo.SelectedIndex = 0;
            CargarEmpresas();
            CargarServicios();
            CargarMicro();
        }

        private void CargarMicro()
        {
            txtPatente.Text = _micro.Patente;
            mtbMicroModificarKgsEncomiendas.Text = _micro.KgsCapacidad.ToString();
            cbbMicroModificarTipoModelo.Text = _micro.Modelo;
            cbbMicroModificarTipoServicio.Text = _micro.Servicio.ToString();
            cbbMicroModificarTipoEmpresa.Text = _micro.Marca;
            dtpFechaAlta.Text = _micro.FechaAlta.ToString();


        }

        private void CargarEmpresas()
        {
            IList<Empresa> empresas = _empresaManager.Listar();

            this.cbbMicroModificarTipoEmpresa.DataSource = empresas;
            this.cbbMicroModificarTipoEmpresa.DisplayMember = "Descripcion";
            this.cbbMicroModificarTipoEmpresa.ValueMember = "Id";
        }
        private void CargarServicios()
        {
            IList<Servicio> servicios = _servicioManager.Listar();

            this.cbbMicroModificarTipoServicio.DataSource = servicios;
            this.cbbMicroModificarTipoServicio.DisplayMember = "TipoServicio";
            this.cbbMicroModificarTipoServicio.ValueMember = "Id";
        }

        private void btnMicroModificarGuardar_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatos())
            {
                try
                {
                    Servicio serv = this.cbbMicroModificarTipoServicio.SelectedItem as Servicio;
                    Empresa empresa = this.cbbMicroModificarTipoEmpresa.SelectedItem as Empresa;
                    string modelo = this.cbbMicroModificarTipoModelo.SelectedItem as string;

                    _micro.FechaAlta = dtpFechaAlta.Value;
                    _micro.NumeroDeMicro = 0;
                    _micro.Modelo = modelo;
                    _micro.Patente = this.txtPatente.Text;
                    _micro.KgsCapacidad = Convert.ToDecimal(this.mtbMicroModificarKgsEncomiendas.Text);
                    _micro.Servicio = serv;
                    _micro.Empresa = empresa;
                    _micro.BajaVidaUtil = cbBajaVidaUtil.Checked;

                    if (cbBajaVidaUtil.Checked)
                        _micro.FechaBajaVidaUtil = dtpFechaBajaUtil.Value;
                    else
                        _micro.FechaBajaVidaUtil = null;
                    _manager.Modificar(_micro);

                    MensajePorPantalla.MensajeInformativo(this, "Se ha modificado el micro con el id: " + _micro.Id.ToString());

                   // this.PreguntarCargarButacas(micro);

                    this.Close();
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
            }
        }

        private void PreguntarCargarButacas(Micro micro)
        {
            DialogResult confirma = MensajePorPantalla.MensajeInformativo(this, "¿Desea cargar las butacas ahora?", MessageBoxButtons.YesNo);

            if (confirma == DialogResult.Yes)
            {
                int cant = 999;

                if (!string.IsNullOrEmpty(tbCantButacas.Text))
                    cant = Convert.ToInt32(tbCantButacas.Text);

                using (MicroButacaAlta frm = new MicroButacaAlta(micro, cant))
                {
                    frm.ShowDialog(this);
                }
            }
        }

        private bool ValidarDatos()
        {
            return true;
        }

        private void cbBajaVidaUtil_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
