using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Abm_Pasaje_encomienda
{
    public partial class RegistrarCompra : Form
    {
        public RegistrarCompra()
        {
            InitializeComponent();
            dtpRegistrarCompraFechaNacimiento.Format = DateTimePickerFormat.Custom;
            dtpRegistrarCompraFechaNacimiento.CustomFormat = "MMMM dd, yyyy";
        }

        private void RegistrarCompra_Load(object sender, EventArgs e)
        {

        }

        private void dtpRegistrarCompraFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
