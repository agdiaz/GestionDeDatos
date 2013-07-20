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

namespace FrbaBus.Cancelaciones
{
    public partial class CancelacionEncomienda : Form
    {
        private CancelacionManager _manager;
        public CancelacionEncomienda()
        {
            InitializeComponent();
        }

        private void btnCancelacionEncomiendaBuscarCompra_Click(object sender, EventArgs e)
        {
            Encomienda encomienda = null;
            using (Compras.EncomiendaListado frm = new FrbaBus.Compras.EncomiendaListado())
            {
                frm.ShowDialog();                
            }
        }
    }
}
