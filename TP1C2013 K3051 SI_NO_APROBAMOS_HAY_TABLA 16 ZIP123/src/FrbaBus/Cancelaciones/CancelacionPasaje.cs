using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Cancelaciones
{
    public partial class CancelacionPasaje : Form
    {
        public CancelacionPasaje()
        {
            InitializeComponent();
        }

        private void btnCancelacionPasajeBuscarCompra_Click(object sender, EventArgs e)
        {
            using (Compras.PasajeListado frm = new FrbaBus.Compras.PasajeListado())
            {
                frm.ShowDialog();
            }
        }
        
    }
}
