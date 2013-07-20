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
using FrbaBus.Abm_Clientes;

namespace FrbaBus.Compras
{
    public partial class PasajeListado : Form
    {

        private PasajeManager _manager;
        public PasajeListado()
        {
            InitializeComponent();
            _manager = new PasajeManager();
        }

        public Pasaje PasajeSeleccionado()
        {
            Pasaje c = null;
            if (dgvPasajeListado.SelectedRows.Count > 0)
                c = dgvPasajeListado.SelectedRows[0].DataBoundItem as Pasaje;
            return c;
        }

        private void btnPasajeListadoBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdMicro = 0;
                if (!string.IsNullOrEmpty(tbPasajeListadoMicro.Text))
                {
                    IdMicro = Convert.ToInt32(tbPasajeListadoMicro.Text);
                }

                decimal DniCliente = 0;
                if (!string.IsNullOrEmpty(tbPasajeListadoCliente.Text))
                {
                    DniCliente = Convert.ToDecimal(tbPasajeListadoCliente.Text);
                }

                // DEBERIA SER POR NUMERO DE BUTACA
                int idButaca = 0;
                if (!string.IsNullOrEmpty(tbPasajeListadoButaca.Text))
                {
                    idButaca = Convert.ToInt32(tbPasajeListadoButaca.Text);
                }

                decimal precio = 0;
                if (!string.IsNullOrEmpty(tbPasajeListadoPrecio.Text))
                {
                    precio = Convert.ToDecimal(tbPasajeListadoPrecio.Text);
                }

                IList<Pasaje> pasajes = _manager.ListarFiltrado(IdMicro, DniCliente, idButaca, precio);

                dgvPasajeListado.DataSource = pasajes;

            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error al intentar dar el registro.\n Detalle del error: " + ex.Message);
            }

            /*
             // CAMPOS VISIBLES=> dni, pre_pasaje
            this.dgvPasajeListado.DataSource = pasajes;
            this.dgvPasajeListado.Columns["id_pasaje"].Visible = false;
            this.dgvPasajeListado.Columns["id_compra"].Visible = false;
            this.dgvPasajeListado.Columns["id_butaca"].Visible = false;
            this.dgvPasajeListado.Columns["id_cancelacion"].Visible = false;
            this.dgvPasajeListado.Columns["disponible"].Visible = false;
            this.dgvPasajeListado.Columns["cancel"].Visible = false;
            this.dgvPasajeListado.Columns["fecha_cancel"].Visible = false;
            this.dgvPasajeListado.Columns["motivo_cancel"].Visible = false;
            this.dgvPasajeListado.Columns["id_viaje"].Visible = false;
            */
        }

        private void btnPasajeListadoSeleccionarCliente_Click(object sender, EventArgs e)
        {
            Cliente cliente = null;
            using (ClienteListado frm = new ClienteListado(true))
            {
                frm.ShowDialog(this);
                cliente = frm.ClienteSeleccionado();
            }
            if (cliente != null)
            {
                tbPasajeListadoCliente.Text = cliente.NroDni.ToString();
            }
        }
    }
}
