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
using FrbaBus.Common.Excepciones;
using FrbaBus.Common.Helpers;

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
            try
            {
                string descripcion = tbDescripcion.Text;

                int puntosDesde = 0;
                if (!string.IsNullOrEmpty(this.tbPuntosDesde.Text))
                {
                    puntosDesde = Convert.ToInt32(tbPuntosDesde.ToString());
                }
                int puntosHasta = 9999;
                if (!string.IsNullOrEmpty(tbPuntosHasta.Text))
                {
                    puntosHasta = Convert.ToInt32(tbPuntosHasta.Text);
                }

                int stockDesde = 0;
                if (!string.IsNullOrEmpty(tbStockDesde.Text))
                {
                    stockDesde = Convert.ToInt32(tbStockDesde.Text);
                }
                int stockHasta = 9999;
                if (!string.IsNullOrEmpty(tbStockHasta.Text))
                {
                    stockHasta = Convert.ToInt32(tbStockHasta.Text);
                }
                
                IList<Recompensa> recompensas = _manager.ListarFiltrado(descripcion, puntosDesde, puntosHasta, stockDesde, stockHasta);
                dgvRecomensas.DataSource = recompensas;
                dgvRecomensas.Columns["IdRecompensa"].Visible = false;
            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error al intentar borrar el registro.\n Detalle del error: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }
    }
}
