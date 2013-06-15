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

namespace FrbaBus.Abm_Viaje
{
    public partial class ViajeAlta : Form
    {
        public ViajeAlta()
        {
            InitializeComponent();
            SetearCustomFormatDataTimePicker();
        }

        private void SetearCustomFormatDataTimePicker()
        {
            dtpViajeAltaFechaSalida.Format = DateTimePickerFormat.Custom;
            dtpViajeAltaFechaSalida.CustomFormat = "MMMM dd, yyyy - HH:mm:ss";
            dtpViajeAltaFechaLlegada.Format = DateTimePickerFormat.Custom;
            dtpViajeAltaFechaLlegada.CustomFormat = "MMMM dd, yyyy - HH:mm:ss";
            dtpViajeAltaFechaLlegadaEstimada.Format = DateTimePickerFormat.Custom;
            dtpViajeAltaFechaLlegadaEstimada.CustomFormat = "MMMM dd, yyyy - HH:mm:ss";
        }

        private void ViajeAlta_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnViajeAltaBuscarMicro_Click(object sender, EventArgs e)
        {
            new MicroListado().ShowDialog(this);
        }

        private void btnViajeAltaBuscarRecorrido_Click(object sender, EventArgs e)
        {
            new RecorridoListado().ShowDialog(this);
        }
    }
}
