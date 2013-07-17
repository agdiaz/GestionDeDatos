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

        private void ListarViajes()
        {
            this.dgvViajeListado.DataSource = _manager.Listar();
        }

        private void ListarRecorridos()
        {
            this.cbRecorrido.DataSource = _recorridoManager.Listar();
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
            this.cbMicro.DataSource = _microManager.Listar();
            this.cbMicro.DisplayMember = "Informacion";
            this.cbMicro.ValueMember = "Id";
        }

        private void btnViajeListadoBuscar_Click(object sender, EventArgs e)
        {
            try
            {

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
    }
}
