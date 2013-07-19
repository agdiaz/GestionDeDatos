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
        Micro micro = null;
        Recorrido recorrido = null;

        private ViajeManager _manager;

        public ViajeModificar(Viaje viaje)
        {
            _manager = new ViajeManager();
            InitializeComponent();
            SetearCustomFormatDataTimePicker();
        }

        private void SetearCustomFormatDataTimePicker()
        {
            dtpViajeModificarFechaSalida.Format = DateTimePickerFormat.Custom;
            dtpViajeModificarFechaSalida.CustomFormat = "MMMM dd, yyyy - HH:mm:ss";
            dtpViajeModificarFechaLlegada.Format = DateTimePickerFormat.Custom;
            dtpViajeModificarFechaLlegada.CustomFormat = "MMMM dd, yyyy - HH:mm:ss";
            dtpViajeModificarFechaLlegadaEstimada.Format = DateTimePickerFormat.Custom;
            dtpViajeModificarFechaLlegadaEstimada.CustomFormat = "MMMM dd, yyyy - HH:mm:ss";
        }

        private void ViajeModificar_Load(object sender, EventArgs e)
        {

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
            new RecorridoListado().ShowDialog(this);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.dtpViajeModificarFechaLlegada.Value = FechaHelper.Ahora();
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
