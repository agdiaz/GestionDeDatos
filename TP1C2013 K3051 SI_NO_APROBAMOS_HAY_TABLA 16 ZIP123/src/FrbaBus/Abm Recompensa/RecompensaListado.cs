﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Manager;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Abm_Recompensa
{
    public partial class RecompensaListado : Form
    {
        private RecompensaManager _manager;

        public RecompensaListado()
        {
            InitializeComponent();
            _manager = new RecompensaManager();
        }

        private void RecompensaListado_Load(object sender, EventArgs e)
        {
            LimpiarDatos();
        }

        private void LimpiarDatos()
        {
            tbDescripcion.Text = string.Empty;
            tbPuntosDesde.Text = string.Empty;
            tbPuntosHasta.Text= string.Empty;
            tbStockDesde.Text= string.Empty;
            tbStockHasta.Text = string.Empty;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string descripcion = tbDescripcion.Text;
            int puntosDesde = Convert.ToInt32(tbPuntosDesde.Text);
            int puntosHasta = Convert.ToInt32(tbPuntosHasta.Text);
            int stockDesde = Convert.ToInt32 (tbStockDesde.Text);
            int stockHasta = Convert.ToInt32 (tbStockHasta.Text);

            IList<Recompensa> recompensas = _manager.ListarFiltrado(descripcion, puntosDesde, puntosHasta, stockDesde, stockHasta);
            dgvRecomensas.DataSource = recompensas;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }
    }
}
