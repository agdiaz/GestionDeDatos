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
    public partial class CancelacionCompra : Form
    {
        private CancelacionManager _manager; 
        private Compra compra;

        public CancelacionCompra()
        {
            _manager = new CancelacionManager();
            compra = null;
            InitializeComponent();
        }

        private void btnBuscarCompraCancel_Click(object sender, EventArgs e)
        {
            
            using (Compras.ComprasListado frm = new FrbaBus.Compras.ComprasListado())
            {
                frm.ShowDialog();
                compra = frm.CompraSeleccionada();
            }
            MostrarCompra();
        }

        private void MostrarCompra()
        {
            if (compra != null)
            {
                this.tbCompra.Text = compra.IdCompra.ToString();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                _manager.CancelarCompra(compra, tbMotivo.Text);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
