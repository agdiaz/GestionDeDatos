using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Abm_Pasaje_encomienda;

namespace FrbaBus.Abm_encomienda
{
    public partial class Comprar : Form
    {
        public Comprar()
        {
            InitializeComponent();
            dtpPasajeEncomiendaComprar.Format = DateTimePickerFormat.Custom;
            dtpPasajeEncomiendaComprar.CustomFormat = "MMMM dd, yyyy";
        }

        private void btnPasajeEncomiendaComprar_Click(object sender, EventArgs e)
        {
            new RegistrarCompra().ShowDialog(this);
        }
    }
}
