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
    public partial class ViajeListado : Form
    {
        public ViajeListado()
        {
            InitializeComponent();
            dtpViajeListadoFechaSalida.Format = DateTimePickerFormat.Custom;
            dtpViajeListadoFechaSalida.CustomFormat = "MMMM dd, yyyy - HH:mm:ss";
            dtpViajeListadoFechaLlegada.Format = DateTimePickerFormat.Custom;
            dtpViajeListadoFechaLlegada.CustomFormat = "MMMM dd, yyyy - HH:mm:ss";
            dtpViajeListadoFechaLlegadaEstimada.Format = DateTimePickerFormat.Custom;
            dtpViajeListadoFechaLlegadaEstimada.CustomFormat = "MMMM dd, yyyy - HH:mm:ss";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
