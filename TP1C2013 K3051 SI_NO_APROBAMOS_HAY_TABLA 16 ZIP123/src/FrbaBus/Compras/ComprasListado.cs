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

namespace FrbaBus.Compras
{
    public partial class ComprasListado : Form
    {
        private CompraManager _manager;

        public ComprasListado()
        {
            InitializeComponent();
            _manager = new CompraManager();
        }

        public Compra CompraSeleccionada()
        {
            Compra c = null;
            if (dgvCompras.SelectedRows.Count > 0)
                c = dgvCompras.SelectedRows[0].DataBoundItem as Compra;
            return c;
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal nroDni = 0;
                if(!string.IsNullOrEmpty(txtDni.Text))
                    nroDni = Convert.ToDecimal(txtDni.Text);

                int idCompra = 0;
                if (!string.IsNullOrEmpty(txtIDCompra.Text))
                    idCompra = Convert.ToInt32(txtIDCompra.Text);

                DateTime? a = null;
                if (checkBox1.Checked)
                    a = dtpFechaCompra.Value;

                IList<Compra> compras = _manager.ListarFiltrado(nroDni, idCompra, a);
                this.dgvCompras.DataSource = compras;
                
                dgvCompras.Columns["IdUsuario"].Visible = false;
                dgvCompras.Columns["IdCancelacion"].Visible = false;
                //dgvCompras.Columns["Puntajes"].Visible = false;
            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error al realizar la búsqueda correspondiente.\n Detalle del error: " + ex.Message);
            }
        }

        private void ComprasListado_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
