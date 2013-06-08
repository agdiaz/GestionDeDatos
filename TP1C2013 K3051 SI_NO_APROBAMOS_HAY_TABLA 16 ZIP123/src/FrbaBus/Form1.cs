using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Abm_Micro;
using FrbaBus.Rol;
using FrbaBus.Abm_Ciudad;

namespace FrbaBus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tsmRolListado_Click(object sender, EventArgs e)
        {
            new RolListado().ShowDialog(this);
        }

        private void tsmMicros_Click(object sender, EventArgs e)
        {

        }

        private void tsmMicroListado_Click(object sender, EventArgs e)
        {
            new MicroListado().ShowDialog(this);
        }

        private void tsmPasajero_Click(object sender, EventArgs e)
        {

        }

        private void top5ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsmMicroAlta_Click(object sender, EventArgs e)
        {
            new MicroAlta().ShowDialog(this);
        }

        private void tsmRolAlta_Click(object sender, EventArgs e)
        {
            new RolAlta().ShowDialog(this);
        }

        private void tsmCiudadListado_Click(object sender, EventArgs e)
        {
            new CiudadListado().ShowDialog(this);
        }

        private void tsmCiudadAlta_Click(object sender, EventArgs e)
        {
            new CiudadAlta().ShowDialog(this);
        }
    }
}
