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
    public partial class MicroAlta : Form
    {
        private MicroManager _manager;
        private EmpresaManager _empresaManager;
        private ServicioManager _servicioManager;

        public MicroAlta()
        {
            InitializeComponent();
            this._manager = new MicroManager();
            this._empresaManager = new EmpresaManager();
            this._servicioManager = new ServicioManager();
        }

        private void cbbMicroAltaTipoEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnMicroAltaLimpiar_Click(object sender, EventArgs e)
        {
            this.cbbMicroAltaTipoEmpresa.SelectedIndex = 0;
            this.cbbMicroAltaTipoModelo.SelectedIndex = 0;
            this.cbbMicroAltaTipoServicio.SelectedIndex = 0;
            this.mtbMicroAltaKgsEncomiendas.Text = string.Empty;
        }

        private void MicroAlta_Load(object sender, EventArgs e)
        {
            this.cbbMicroAltaTipoModelo.SelectedIndex = 0;
            CargarEmpresas();
            CargarServicios();
        }

        private void CargarEmpresas()
        {
            IList<Empresa> empresas = _empresaManager.Listar();

            this.cbbMicroAltaTipoEmpresa.DataSource = empresas;
            this.cbbMicroAltaTipoEmpresa.DisplayMember = "Descripcion";
            this.cbbMicroAltaTipoEmpresa.ValueMember = "Id";
        }
        private void CargarServicios()
        {
            IList<Servicio> servicios = _servicioManager.Listar();

            this.cbbMicroAltaTipoServicio.DataSource = servicios;
            this.cbbMicroAltaTipoServicio.DisplayMember = "TipoServicio";
            this.cbbMicroAltaTipoServicio.ValueMember = "Id";
        }

        private void btnMicroAltaGuardar_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatos())
            {
                try
                {
                    Servicio serv = this.cbbMicroAltaTipoServicio.SelectedItem as Servicio;
                    Empresa empresa = this.cbbMicroAltaTipoEmpresa.SelectedItem as Empresa;
                    string modelo = this.cbbMicroAltaTipoModelo.SelectedItem as string;

                    Micro micro = new Micro()
                    {
                        FechaAlta = dtpFechaAlta.Value,
                        NumeroDeMicro = 0,
                        Modelo = modelo,
                        Patente = this.txtPatente.Text,
                        KgsCapacidad = Convert.ToDecimal(this.mtbMicroAltaKgsEncomiendas.Text),
                        Servicio = serv,
                        FechaBajaVidaUtil = null,
                        Empresa = empresa
                    };

                    if (_manager.CheckearPatanteUnica(micro))
                    {
                        _manager.Alta(micro);

                        MensajePorPantalla.MensajeInformativo(this, "Se dio de alta el micro con el id: " + micro.Id.ToString());

                        this.PreguntarCargarButacas(micro);

                        this.Close();
                    }
                    else
                    {
                        MensajePorPantalla.MensajeError(this, "Ya existe un micro con la patente: " + micro.Patente);
                    }
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
    }
}
