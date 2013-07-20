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
using FrbaBus.Common.Excepciones;

namespace FrbaBus.Abm_Micro
{
    public partial class MicroButacaListado : Form
    {
        #region Propiedades
        private ButacaManager _manager;
        private bool _esParaSeleccionar = false;
        private Viaje _viaje;
        #endregion

        #region Constructores
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

        public MicroButacaListado(Viaje m, bool esParaSeleccionar)
        :this(esParaSeleccionar)
        {
            _viaje = m;
        }

        public MicroButacaListado(Viaje m)
        :this(m, false)
        {
        }
        #endregion

        public Butaca ButacaSeleccionada()
        {
            Butaca b = null;
            if (dgvLibres.SelectedRows.Count > 0)
                b = dgvLibres.SelectedRows[0].DataBoundItem as Butaca;
            return b;
        }

        private void MicroButacaListado_Load(object sender, EventArgs e)
        {
            btnSeleccionar.Visible = _esParaSeleccionar;
            
            MostrarDatosMicro();
            CargarListaTipoButaca();
            CargarButacas();
        }
        
        #region MostrarDatos
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
            if (_viaje.Micro != null)
            {
                tbMicro.Text = _viaje.Micro.Informacion;
                btnBuscarMicro.Enabled = false;
            }
        }
        #endregion

        private void btnBuscarMicro_Click(object sender, EventArgs e)
        {
            Micro m = null;

            try
            {
                using (MicroListado frm = new MicroListado())
                {
                    frm.ShowDialog();
                    m = frm.MicroSeleccionado();
                }

                if (m != null)
                {
                    this._viaje.Micro = m;
                    MostrarDatosMicro();
                }
            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error.\n Detalle del error: " + ex.Message);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                IList<Butaca> libres = _manager.ListarLibres(_viaje);
                IList<Butaca> ocupadas = _manager.ListarOcupadas(_viaje);

                this.dgvLibres.DataSource = libres;
                this.dgvOcupadas.DataSource = ocupadas;
            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error.\n Detalle del error: " + ex.Message);
            }
            

        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.tbMicro.Text = string.Empty;
            this.tbNroButaca.Text = string.Empty;
            this.tbPiso.Text = string.Empty;
            this.cbTipoButaca.SelectedIndex = 0;

            if (!_esParaSeleccionar)
                _viaje = null;

        }
        
        #region Seleccion
        private void dgvLibres_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_esParaSeleccionar)
                Seleccionar();
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
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
        #endregion
    }
}
