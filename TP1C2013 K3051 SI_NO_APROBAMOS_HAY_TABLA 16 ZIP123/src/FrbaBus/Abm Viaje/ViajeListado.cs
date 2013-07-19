using System;
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

        private Recorrido _recorrido;

        public ViajeListado()
        {
            InitializeComponent();

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
            :   this()
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
                CargarFechas();
                ListarMicros();
                ListarRecorridos();
                ListarViajes();
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
            Micro micro = cbMicro.SelectedItem as Micro;
            Recorrido rec = cbRecorrido.SelectedItem as Recorrido;

            this.dgvViajeListado.DataSource = _manager.ListarFiltrado(dtpViajeListadoFechaLlegada.Value, dtpViajeListadoFechaSalida.Value, dtpViajeListadoFechaLlegadaEstimada.Value, rec, micro);
            this.dgvViajeListado.Columns["Id"].Visible = false;
            this.dgvViajeListado.Columns["IdRecorrido"].Visible = false;
            this.dgvViajeListado.Columns["IdMicro"].Visible = false;
        }

        private void ListarRecorridos()
        {
            var recorridos = _recorridoManager.Listar();
            recorridos.Insert(0, new Recorrido());
            this.cbRecorrido.DataSource = recorridos;
            this.cbRecorrido.DisplayMember = "Informacion";
            this.cbRecorrido.ValueMember = "Id";

            if (this._recorrido != null)
            {
                this.cbRecorrido.SelectedItem = _recorrido;
                this.cbRecorrido.Enabled = false;
            }
        }

        private void ListarMicros()
        {
            var micros = _microManager.Listar();
            micros.Insert(0, new Micro());
            this.cbMicro.DataSource = micros;
            this.cbMicro.DisplayMember = "Informacion";
            this.cbMicro.ValueMember = "Id";
           
        }

        private void btnViajeListadoBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime? fecha_salida = null;
                if (cbFechaSalida.Checked)
                    fecha_salida = this.dtpViajeListadoFechaSalida.Value;

                DateTime? fecha_llegada = null;
                if(cbFechaLlegada.Checked)
                    fecha_llegada = this.dtpViajeListadoFechaLlegada.Value;

                DateTime? fecha_llegada_estimada = null;
                if(cbFechaEstimada.Checked)
                fecha_llegada_estimada = this.dtpViajeListadoFechaLlegadaEstimada.Value;
                
                Micro micro = cbMicro.SelectedItem as Micro;
                Recorrido recorrido = cbRecorrido.SelectedItem as Recorrido;

                var viajes = _manager.ListarFiltrado(fecha_llegada, fecha_salida, fecha_llegada_estimada, recorrido, micro);

                this.dgvViajeListado.DataSource = viajes;
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
        
        
    }
}
