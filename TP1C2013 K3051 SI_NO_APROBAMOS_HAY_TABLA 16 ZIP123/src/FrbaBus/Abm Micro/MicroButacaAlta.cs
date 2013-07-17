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

namespace FrbaBus.Abm_Micro
{
    public partial class MicroButacaAlta : Form
    {
        private MicroManager _microManager;
        private ButacaManager _butacaManager;
        private Micro MicroSeleccionado { get; set; }
        private IList<Butaca> Butacas { get; set; }
        private bool _desdeAltaMicro;

        public MicroButacaAlta()
        {
            _desdeAltaMicro = false;
            _microManager = new MicroManager();
            _butacaManager = new ButacaManager();
            Butacas = new List<Butaca>();
        }
        public MicroButacaAlta(Micro micro)
        {
            _desdeAltaMicro = true;
            _microManager = new MicroManager();
            _butacaManager = new ButacaManager();
            MicroSeleccionado = micro;
            Butacas = new List<Butaca>();
        }

        private void MicroButacaAlta_Load(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;

            if (_desdeAltaMicro)
                CargarDatosMicro();
            else
                ObtenerMicro();
            
            CargarListaTipo();
            CargarButacas();
        }

        private void ObtenerMicro()
        {
            this.btnBuscarMicro.Visible = true;
        }

        private void CargarButacas()
        {
            lbButacas.DataSource = null;
            lbButacas.DataSource = Butacas;
            lbButacas.DisplayMember = "Informacion";
            lbButacas.ValueMember = "Id";

            tbCantidadButacas.Text = Butacas.Count.ToString();
        }

        private void CargarListaTipo()
        {
            IList<string> tipos = new List<string>();
            tipos.Add(TipoButaca.Pasillo);
            tipos.Add(TipoButaca.Ventanilla);

            cbTipoButaca.DataSource = tipos;
        }

        private void CargarDatosMicro()
        {
            tbMarca.Text = MicroSeleccionado.Empresa.Descripcion;
            tbPatente.Text = MicroSeleccionado.Patente;
            tbServicio.Text = MicroSeleccionado.Servicio.TipoServicio;
            groupBox2.Enabled = true;
            this.btnBuscarMicro.Visible = false;
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            
            LimpiarNuevaButaca(true);
        }

        private void LimpiarNuevaButaca(bool mostrar)
        {
            gbNuevaButaca.Enabled = mostrar;
            tbNroButaca.Text = string.Empty;
            tbPiso.Text = string.Empty;
            cbTipoButaca.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Butaca nueva = new Butaca();
            nueva.IdMicro = MicroSeleccionado.Id;
            nueva.NroButaca = Convert.ToDecimal(tbNroButaca.Text);
            nueva.Piso = Convert.ToDecimal(tbPiso.Text);

            Butacas.Add(nueva);
            CargarButacas();
            LimpiarNuevaButaca(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarNuevaButaca(true);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            Butaca quitada = lbButacas.SelectedItem as Butaca;

            if (quitada != null)
            {
                Butacas.Remove(quitada);
                CargarButacas();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            foreach (Butaca butaca in Butacas)
            {
                _butacaManager.Alta(butaca);
            }
        }

        private void btnBuscarMicro_Click(object sender, EventArgs e)
        {
            using (MicroListado frm = new MicroListado())
            {
                frm.ShowDialog(this);
                if (frm.MicroSeleccionado() != null)
                {
                    this.MicroSeleccionado = frm.MicroSeleccionado();
                    CargarDatosMicro();
                }
            }
        }
        
    }
}
