using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Abm_Micro
{
    public partial class MicroAlta : Form
    {
        public MicroAlta()
        {
            InitializeComponent();

            cbbMicroAltaTipoEmpresa.Items.Add("Chevallier");
            cbbMicroAltaTipoEmpresa.Items.Add("Flecha Bus");
        }

        private void cbbMicroAltaTipoEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
