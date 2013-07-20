using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Common.Entidades;
using FrbaBus.Manager;

namespace FrbaBus.Cancelaciones
{
    public partial class CancelacionPasaje : Form
    {
        private Pasaje pasaje;
        private CancelacionManager _manager; 
        
        public CancelacionPasaje()
        {
            pasaje = null;
            InitializeComponent();
        }

        private void btnCancelacionPasajeBuscarCompra_Click(object sender, EventArgs e)
        {
            using (Compras.PasajeListado frm = new FrbaBus.Compras.PasajeListado())
            {
                frm.ShowDialog();
            }
        }

        private void btnCancelacionPasajeCancelarPasaje_Click(object sender, EventArgs e)
        {
            using (Compras.PasajeListado frm = new FrbaBus.Compras.PasajeListado())
            {
                frm.ShowDialog();
                pasaje = frm.PasajeSeleccionado();
            }
            MostrarPasaje();
        }

        private void MostrarPasaje()
        {
                if (pasaje != null)
                {
                    this.tbCancelacionPasaje.Text = pasaje.Id.ToString();
                }
            
        }
        
    }
}
