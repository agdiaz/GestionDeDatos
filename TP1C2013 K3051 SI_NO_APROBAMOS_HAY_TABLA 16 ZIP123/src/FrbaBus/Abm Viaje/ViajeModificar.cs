using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Abm_Micro;
using FrbaBus.Abm_Recorrido;
using FrbaBus.Helpers;
using FrbaBus.Common.Entidades;
using FrbaBus.Manager;

namespace FrbaBus.Abm_Viaje
{
    public partial class ViajeModificar : Form
    {
        Viaje viaje = null;
        Micro micro = null;
        Recorrido recorrido = null;

        private ViajeManager _manager;

        public ViajeModificar(Viaje v)
        {
            viaje = v;
            _manager = new ViajeManager();
            InitializeComponent();
            SetearCustomFormatDataTimePicker();
        }

        private void SetearCustomFormatDataTimePicker()
        {
            dtpViajeModificarFechaSalida.Format = DateTimePickerFormat.Custom;
            dtpViajeModificarFechaSalida.CustomFormat = "MMMM dd, yyyy - HH:mm:ss";
            dtpViajeModificarFechaLlegadaEstimada.Format = DateTimePickerFormat.Custom;
            dtpViajeModificarFechaLlegadaEstimada.CustomFormat = "MMMM dd, yyyy - HH:mm:ss";
        }

        private void ViajeModificar_Load(object sender, EventArgs e)
        {
            cargarDatosDelViaje();
        }

        private void cargarDatosDelViaje()
        {
            this.dtpViajeModificarFechaSalida.Value = viaje.FechaSalida;
            this.dtpViajeModificarFechaLlegadaEstimada.Value = viaje.FechaArriboEstimada;
            this.txtMicro.Text = viaje.Micro.Informacion;
            this.txtRecorrido.Text = viaje.Recorrido.Informacion;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnViajeModificarBuscarMicro_Click(object sender, EventArgs e)
        {
            
            using (MicroListado frm = new MicroListado())
            {
                frm.ShowDialog(this);
                micro = frm.MicroSeleccionado();
            }
            
            if (micro != null)
            {
                txtMicro.Text = micro.Informacion;
            }
        }

        private void btnViajeModificarBuscarRecorrido_Click(object sender, EventArgs e)
        {
            {
                using (RecorridoListado frm = new RecorridoListado())
                {
                    frm.ShowDialog(this);
                    recorrido = frm.RecorridoSeleccionado();
                }

                if (recorrido != null)
                {
                    txtRecorrido.Text = recorrido.Informacion;
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.dtpViajeModificarFechaLlegadaEstimada.Value = FechaHelper.Ahora();
            this.dtpViajeModificarFechaSalida.Value = FechaHelper.Ahora();
            this.txtMicro.Text = string.Empty;
            this.txtRecorrido.Text = string.Empty;
        }

        private void btnViajeModificarGuardar_Click(object sender, EventArgs e)
        {
            //this._manager.Alta(recorrido);
        }
    }
}
