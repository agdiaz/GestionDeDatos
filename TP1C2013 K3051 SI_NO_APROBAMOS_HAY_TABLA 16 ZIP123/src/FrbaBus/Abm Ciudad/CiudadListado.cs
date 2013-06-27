using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Manager;

namespace FrbaBus.Abm_Ciudad
{
    public partial class CiudadListado : Form
    {
        public CiudadListado()
        {
            InitializeComponent();

        }

        private void btnCiudadListadoBuscar_Click(object sender, EventArgs e)
        {
            string ciudadElegida = this.tbCiudadListadoCiudad.Text ;;
            DataSet dsCiudades = new CiudadManager().ObtenerRegistrosCiudades(ciudadElegida);
            this.dgvCiudadListado.DataSource = dsCiudades.Tables[0];
        }

        private void CiudadListado_Load(object sender, EventArgs e)
        {
            CiudadManager cm = new CiudadManager();
            DataSet ciudades = cm.Listar();
            this.dgvCiudadListado.DataSource = ciudades.Tables[0];
        }

        private void btnCiudadListadoLimpiar_Click(object sender, EventArgs e)
        {
            tbCiudadListadoCiudad.Text = "";
        }
    }
}
