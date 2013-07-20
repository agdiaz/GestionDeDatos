using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Manager;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Compras
{
    public partial class ComprasListado : Form
    {
        private CompraManager _manager;

        public ComprasListado()
        {
            InitializeComponent();
            _manager = new CompraManager();
        }

        private void ComprasListado_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            IList<Compra> compras = _manager.Listar();
            this.dgvCompras.DataSource = compras;
        }
    }
}
