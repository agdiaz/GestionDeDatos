﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Common.Excepciones;
using FrbaBus.Common.Helpers;
using FrbaBus.Common.Entidades;
using FrbaBus.Manager;
using FrbaBus.Helpers;

namespace FrbaBus.Abm_Viaje
{
    public partial class ViajeListado : Form
    {
        private ViajeManager _manager;
        private MicroManager _microManager;
        private RecorridoManager _recorridoManager;
        private bool _esParaSeleccionar; 

        private Recorrido _recorrido;

        public ViajeListado()
            : this(false)
        {
        }
        public ViajeListado(bool esParaSeleccionar)
        {
            InitializeComponent();
            _esParaSeleccionar = esParaSeleccionar;
            _manager = new ViajeManager();
            _microManager = new MicroManager();
            _recorridoManager = new RecorridoManager();

            dtpViajeListadoFechaSalida.Format = DateTimePickerFormat.Custom;
            dtpViajeListadoFechaSalida.CustomFormat = "MMMM dd, yyyy - HH:mm:ss";
            dtpViajeListadoFechaLlegada.Format = DateTimePickerFormat.Custom;
            dtpViajeListadoFechaLlegada.CustomFormat = "MMMM dd, yyyy - HH:mm:ss";
            dtpViajeListadoFechaLlegadaEstimada.Format = DateTimePickerFormat.Custom;
            dtpViajeListadoFechaLlegadaEstimada.CustomFormat = "MMMM dd, yyyy - HH:mm:ss";
        }
        public ViajeListado(Recorrido rec)
            : this(rec, false)
        {

        }

        public ViajeListado(Recorrido rec, bool esParaSeleccionar)
            :   this(esParaSeleccionar)
        {
            _recorrido = rec;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ViajeListado_Load(object sender, EventArgs e)
        {
            try
            {
                btnSeleccionarViaje.Visible = !_esParaSeleccionar;
                btnViajeListadoDarBaja.Visible = !_esParaSeleccionar;
                btnModificar.Visible = !_esParaSeleccionar;
                CargarFechas();
                ListarMicros();
                ListarRecorridos();
                //ListarViajes();
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

        private void CargarFechas()
        {
            this.dtpViajeListadoFechaSalida.Value = FechaHelper.Ahora();
            this.dtpViajeListadoFechaLlegadaEstimada.Value = FechaHelper.Ahora();
        }

        private void ListarViajes()
        {
            try
            {
                DateTime? fecha_salida = null;
                if (cbFechaSalida.Checked)
                    fecha_salida = this.dtpViajeListadoFechaSalida.Value;

                DateTime? fecha_llegada = null;
                if (cbFechaLlegada.Checked)
                    fecha_llegada = this.dtpViajeListadoFechaLlegada.Value;

                DateTime? fecha_llegada_estimada = null;
                if (cbFechaEstimada.Checked)
                    fecha_llegada_estimada = this.dtpViajeListadoFechaLlegadaEstimada.Value;

                Micro micro = cbMicro.SelectedItem as Micro;
                Recorrido recorrido = cbRecorrido.SelectedItem as Recorrido;

                var viajes = _manager.ListarFiltrado(fecha_llegada, fecha_salida, fecha_llegada_estimada, recorrido, micro);

                this.dgvViajeListado.DataSource = viajes;
                this.dgvViajeListado.Columns["Id"].Visible = false;
                this.dgvViajeListado.Columns["IdRecorrido"].Visible = false;
                this.dgvViajeListado.Columns["IdMicro"].Visible = false;
                this.dgvViajeListado.Columns["Pasajes"].Visible = false;
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

        private void ListarRecorridos()
        {
            IList<Recorrido> recorridos;
            if (this._recorrido != null)
            {
                recorridos = new List<Recorrido>();
                recorridos.Add(_recorrido);
                this.cbRecorrido.SelectedItem = _recorrido;
                this.cbRecorrido.Enabled = false;
            }
            else
            {
                recorridos = _recorridoManager.Listar().OrderBy(r => r.Informacion).ToList();
                recorridos.Insert(0, new Recorrido());
            }
            this.cbRecorrido.DataSource = recorridos;
            this.cbRecorrido.DisplayMember = "Informacion";
            this.cbRecorrido.ValueMember = "Id";
            
        }

        private void ListarMicros()
        {
            var micros = _microManager.Listar().OrderBy(m => m.Informacion).ToList();
            micros.Insert(0, new Micro() { });
            this.cbMicro.DataSource = micros;
            this.cbMicro.DisplayMember = "Informacion";
            this.cbMicro.ValueMember = "Id";
           
        }

        private void btnViajeListadoBuscar_Click(object sender, EventArgs e)
        {
            ListarViajes();

        }

        public Viaje ViajeSeleccionado()
        {
            Viaje v = null;
            if (dgvViajeListado.SelectedRows.Count > 0)
                v = dgvViajeListado.SelectedRows[0].DataBoundItem as Viaje;

            return v;
        }

        private void btnViajeListadoLimpiar_Click(object sender, EventArgs e)
        {
            cbFechaEstimada.Checked = false;
            cbFechaLlegada.Checked = false;
            cbFechaSalida.Checked = false;
            dtpViajeListadoFechaLlegada.Value = Helpers.FechaHelper.Ahora();
            dtpViajeListadoFechaLlegadaEstimada.Value = Helpers.FechaHelper.Ahora();
            dtpViajeListadoFechaSalida.Value = Helpers.FechaHelper.Ahora();
            cbMicro.SelectedIndex = 0;
            cbRecorrido.SelectedIndex = 0;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Viaje viaje = dgvViajeListado.SelectedRows[0].DataBoundItem as Viaje;

                using (ViajeModificar frm = new ViajeModificar(viaje))
                {
                    frm.ShowDialog(this);
                }
                ListarViajes();
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

            ListarViajes();
        }

        private void btnViajeListadoDarBaja_Click(object sender, EventArgs e)
        {
            try
            {
                Viaje viaje = (Viaje)dgvViajeListado.SelectedRows[0].DataBoundItem;
                _manager.Baja(viaje);

                //Cargo la grilla de roles
                ListarViajes();

            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
                this.Close();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error al intentar borrar el registro.\n Detalle del error: " + ex.Message);
                this.Close();
            }
            
        }

        private void btnSeleccionarViaje_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void Seleccionar()
        {
            if (this.dgvViajeListado.SelectedRows.Count > 0)
            {
                DialogResult confirma = MensajePorPantalla.MensajeInformativo(this, "¿Desea seleccionar este viaje?", MessageBoxButtons.YesNo);

                if (confirma == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void ViajeListado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_esParaSeleccionar && e.CloseReason == CloseReason.UserClosing)
            {
                if (dgvViajeListado.SelectedRows.Count == 0)
                {
                    DialogResult confirma = MensajePorPantalla.MensajeInformativo(this, "Debía seleccionar un viaje.\n¿Desea salir de todas maneras?", MessageBoxButtons.YesNo);

                    if (confirma == DialogResult.No)
                        e.Cancel = true;
                }
            }

        }
        
        
    }
}
