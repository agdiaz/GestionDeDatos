﻿using System;
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
        private bool _esParaSeleccionar = false;
        private MicroManager _manager;
        private ServicioManager _servicioManager;
        private RecorridoManager _recorridoManager;
        private EmpresaManager _empresaManager;
        private Viaje _viaje;

        public MicroListado()
        {
            this._manager = new MicroManager();
            this._recorridoManager = new RecorridoManager();
            this._servicioManager = new ServicioManager();
            this._empresaManager = new EmpresaManager();
    
            InitializeComponent();
        }
        public MicroListado(bool esParaSeleccionar)
        :this()
        {
            _esParaSeleccionar = esParaSeleccionar;
        }
        public MicroListado(Viaje viaje)
        : this(false)
        {
            _viaje = viaje;
        }
        public MicroListado(Viaje viaje, bool esParaSeleccionar)
            : this(viaje)
        {
            _esParaSeleccionar = esParaSeleccionar;
        }

        public Micro MicroSeleccionado()
        {
            Micro seleccionado = null;

            seleccionado = dgvMicroListado.SelectedRows[0].DataBoundItem as Micro;

            return seleccionado;
        }

        private void btnMicroListadoLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Filtrar();
        }

        private void Limpiar()
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
            btnSeleccionar.Visible = _esParaSeleccionar;
            btnMicroListadoDarBaja.Visible = !_esParaSeleccionar;
            btnMicroListadoModificar.Visible = !_esParaSeleccionar;

            try
            {
                CargarServicios();
                CargarEmpresas();
                CargarModelo();
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

        private void CargarModelo()
        {
            this.cbbMicroListadoTipoModelo.SelectedIndex = 0;
        }
        private void CargarMicros()
        {
            if (_viaje == null)
                this.dgvMicroListado.DataSource = _manager.Listar();
            else
            {
                IList<Micro> microUnico = new List<Micro>();
                microUnico.Add(_viaje.Micro);
                this.dgvMicroListado.DataSource = microUnico;
            }
            this.dgvMicroListado.Columns["Id"].Visible = false;
            this.dgvMicroListado.Columns["NumeroDeMicro"].Visible = false;
            this.dgvMicroListado.Columns["IdEmpresa"].Visible = false;
            this.dgvMicroListado.Columns["IdServicio"].Visible = false;
            this.dgvMicroListado.Columns["Empresa"].Visible = false;
            this.dgvMicroListado.Columns["ButacasDisponibles"].Visible = false;
            this.dgvMicroListado.Columns["ButacasTotal"].Visible = false;
            this.dgvMicroListado.Columns["ButacasVendidas"].Visible = false;
            this.dgvMicroListado.Columns["KgsDisponibles"].Visible = false;
            this.dgvMicroListado.Columns["KgsVendidos"].Visible = false;
            this.dgvMicroListado.Columns["Butacas"].Visible = false;
            this.dgvMicroListado.Columns["informacion"].Visible = false;
        }
        private void CargarEmpresas()
        {
            IList<Empresa> empresas = _empresaManager.Listar();
            empresas.Insert(0,new Empresa());
            this.cbbMicroListadoTipoEmpresa.DataSource = empresas;
            this.cbbMicroListadoTipoEmpresa.DisplayMember = "Descripcion";
            this.cbbMicroListadoTipoEmpresa.ValueMember = "Id";
        }
        private void CargarServicios()
        {
            IList<Servicio> servicios = _servicioManager.Listar();
            servicios.Insert(0, new Servicio());

            this.cbbMicroListadoTipoServicio.DataSource = servicios;
            this.cbbMicroListadoTipoServicio.DisplayMember = "TipoServicio";
            this.cbbMicroListadoTipoServicio.ValueMember = "Id";
        }

        private void btnMicroListadoBuscar_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void Filtrar()
        {
            try
            {
                decimal kgsEncomiendas = 0;
                if (!string.IsNullOrEmpty(this.tbMicroListadoKgsEncomiendas.Text))
                    kgsEncomiendas = Convert.ToDecimal(this.tbMicroListadoKgsEncomiendas.Text);

                int numeroMicro = 0;
                if (!string.IsNullOrEmpty(this.tbMicroListadoNumeroMicro.Text))
                    Convert.ToInt32(this.tbMicroListadoNumeroMicro.Text);

                string numeroPatente = this.tbMicroListadoPatente.Text;

                string tipoEmpresa = null;
                if (cbbMicroListadoTipoEmpresa.SelectedIndex > 0)
                    tipoEmpresa = this.cbbMicroListadoTipoEmpresa.Text;

                string tipoModelo = null;
                if (cbbMicroListadoTipoModelo.SelectedIndex > 0)
                    tipoModelo = this.cbbMicroListadoTipoModelo.Text;

                string tipoServicio = null;
                if (cbbMicroListadoTipoServicio.SelectedIndex > 0)
                    tipoServicio = this.cbbMicroListadoTipoServicio.Text;

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
            try
            {
                Micro micro = dgvMicroListado.SelectedRows[0].DataBoundItem as Micro;

                using (MicroModificar frm = new MicroModificar(micro))
                {
                    frm.ShowDialog(this);
                }
                Limpiar();
                Filtrar();
            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error al intentar modificar el registro.\n Detalle del error: " + ex.Message);
            }   
        }

        private void btnMicroListadoDarBaja_Click(object sender, EventArgs e)
        {
            try
            {
                Micro micro = dgvMicroListado.SelectedRows[0].DataBoundItem as Micro;

                using (MicroDecision frm = new MicroDecision(micro))
                {
                    frm.ShowDialog(this);
                }
                Limpiar();
                Filtrar();

            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error al intentar cargar borrar el registro.\n Detalle del error: " + ex.Message);
            }
        }

        private void dgvMicroListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_esParaSeleccionar)
                Seleccionar();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void Seleccionar()
        {
            if (this.dgvMicroListado.SelectedRows.Count > 0)
            {
                DialogResult confirma = MensajePorPantalla.MensajeInformativo(this, "¿Desea seleccionar este micro?", MessageBoxButtons.YesNo);

                if (confirma == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void MicroListado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_esParaSeleccionar && e.CloseReason == CloseReason.UserClosing)
            {
                if (dgvMicroListado.SelectedRows.Count == 0)
                {
                DialogResult confirma = MensajePorPantalla.MensajeInformativo(this, "Debía seleccionar un micro.\n¿Desea salir de todas maneras?", MessageBoxButtons.YesNo);

                if (confirma == DialogResult.No)
                    e.Cancel = true;
                }
            }
        }
    }
}
