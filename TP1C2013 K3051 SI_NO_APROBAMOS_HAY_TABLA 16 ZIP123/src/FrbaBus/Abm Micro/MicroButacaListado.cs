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
using FrbaBus.Common.Helpers;

namespace FrbaBus.Abm_Micro
{
    public partial class MicroButacaListado : Form
    {
        private Butaca _butacaSeleccionada;
        private bool _esParaSeleccionar = false;
        private Micro _micro;
        private ButacaManager _manager;

        public MicroButacaListado()
        {
            _manager = new ButacaManager();
            InitializeComponent();
        }

        public MicroButacaListado(bool esParaSeleccionar)
            : this()
        {
            this._esParaSeleccionar = esParaSeleccionar;
        }

        public MicroButacaListado(Micro m, bool esParaSeleccionar)
        :this(esParaSeleccionar)
        {
            _micro = m;
        }

        public MicroButacaListado(Micro m)
        :this(m, false)
        {
        }

        private void MicroButacaListado_Load(object sender, EventArgs e)
        {
            btnSeleccionar.Visible = _esParaSeleccionar;
            
            MostrarDatosMicro();
            CargarListaTipoButaca();
            CargarButacas();
        }        

        private void CargarButacas()
        {
            
        }

        private void CargarListaTipoButaca()
        {
            IList<string> tipos = new List<string>();
            tipos.Add(TipoButaca.Pasillo);
            tipos.Add(TipoButaca.Ventanilla);

            cbTipoButaca.DataSource = tipos;
        }
        private void MostrarDatosMicro()
        {
            if (_micro != null)
            {
                tbMicro.Text = _micro.Informacion;
            }
        }

        private void dgvLibres_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_esParaSeleccionar)
                Seleccionar();
        }

        private void Seleccionar()
        {
            if (this.dgvLibres.SelectedRows.Count > 0)
            {
                DialogResult confirma = MensajePorPantalla.MensajeInformativo(this, "¿Desea seleccionar esta butaca?", MessageBoxButtons.YesNo);

                if (confirma == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        public Butaca ButacaSeleccionada()
        {
            Butaca b = null;
            if (dgvLibres.SelectedRows.Count > 0)
                b = dgvLibres.SelectedRows[0].DataBoundItem as Butaca;
            return b;
        }
    }
}
