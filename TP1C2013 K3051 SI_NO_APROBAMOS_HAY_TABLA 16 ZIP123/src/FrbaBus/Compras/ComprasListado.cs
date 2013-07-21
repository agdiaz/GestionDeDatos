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
                IList<Compra> compras = _manager.Listar();
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
    }
}
