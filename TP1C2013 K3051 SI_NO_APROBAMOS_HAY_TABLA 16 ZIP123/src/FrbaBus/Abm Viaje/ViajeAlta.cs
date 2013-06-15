using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Abm_Viaje
{
    public partial class ViajeAlta : Form
    {
        public ViajeAlta()
        {
            InitializeComponent();
            SetearCustomFormat();
        }

        private void SetearCustomFormat()
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
    }
}
