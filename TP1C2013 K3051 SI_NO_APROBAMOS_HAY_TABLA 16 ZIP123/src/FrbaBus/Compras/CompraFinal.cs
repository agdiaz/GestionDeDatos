using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Compras
{
    public partial class CompraFinal : Form
    {
        private Compra _compra;
        private IList<Pasaje> _pasajes;
        private IList<Encomienda> _encomiendas;

        private string _modo;

        public CompraFinal(Compra compra, string modo, IList<Pasaje> pasajes, IList<Encomienda> encomiendas)
        {
            this._compra = compra;
            this._modo = modo;
            this._pasajes = pasajes;
            this._encomiendas = encomiendas;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CompraFinal_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = _compra.IdCompra.ToString();
            this.textBox2.Text = _modo;

            foreach (Pasaje p in _pasajes)
            {
                this.listBox1.Items.Add(p.ToString());
            }

            foreach (Encomienda enc in _encomiendas)
            {
                this.listBox1.Items.Add(enc.ToString());
            }

        }
    }
}
