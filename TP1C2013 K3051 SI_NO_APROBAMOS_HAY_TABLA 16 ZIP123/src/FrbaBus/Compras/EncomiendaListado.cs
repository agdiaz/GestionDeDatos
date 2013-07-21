using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Common.Excepciones;
using FrbaBus.Common.Helpers;
using FrbaBus.Common.Entidades;
using FrbaBus.Manager;
using FrbaBus.Abm_Clientes;

namespace FrbaBus.Compras
{
    public partial class EncomiendaListado : Form
    {
        private PasajeManager _manager;
        private bool _esParaSeleccionar;

        public EncomiendaListado()
        :this(false)
        {

        }
        public EncomiendaListado(bool esP)
        {
            _manager = new PasajeManager();
            _esParaSeleccionar = esP;
            InitializeComponent();
        }

        public Encomienda EncomiendaSeleccionado()
        {
            Encomienda c = null;
            if (dgvEncomiendaListado.SelectedRows.Count > 0)
                c = dgvEncomiendaListado.SelectedRows[0].DataBoundItem as Encomienda;
            return c;
        }

        private void btnEncomiendaListadoBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdViaje = 0;
                if (!string.IsNullOrEmpty(tbEncomiendaListadoViaje.Text))
                {
                    IdViaje = Convert.ToInt32(tbEncomiendaListadoViaje.Text);
                }

                decimal DniCliente = 0;
                if (!string.IsNullOrEmpty(tbEncomiendaListadoDniCliente.Text))
                {
                    DniCliente = Convert.ToDecimal(tbEncomiendaListadoDniCliente.Text);
                }

                // DEBERIA SER POR NUMERO DE BUTACA
                int idEncomienda = 0;
                if (!string.IsNullOrEmpty(tbEncomiendaListadoEncomienda.Text))
                {
                    idEncomienda = Convert.ToInt32(tbEncomiendaListadoEncomienda.Text);
                }
                
                int idCompra = 0;
                if (!string.IsNullOrEmpty(tbEncomiendaListadoCompra.Text))
                {
                    idCompra = Convert.ToInt32(tbEncomiendaListadoCompra.Text);
                }
                
                decimal peso = 0;
                if (!string.IsNullOrEmpty(tbEncomiendaListadoPesoKg.Text))
                {
                    peso = Convert.ToDecimal(tbEncomiendaListadoPesoKg.Text);
                }

                IList<Encomienda> encomiendas = _manager.ListarFiltradoEncomiendas(DniCliente, idEncomienda, IdViaje, idCompra, peso);

                dgvEncomiendaListado.DataSource = encomiendas;
                dgvEncomiendaListado.Columns["idCancelacion"].Visible = false;

            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error al intentar dar el registro.\n Detalle del error: " + ex.Message);
            }
        }

        private void btnEncomiendaListadoBuscarCliente_Click(object sender, EventArgs e)
        {
            Cliente cliente = null;
            using (ClienteListado frm = new ClienteListado(true))
            {
                frm.ShowDialog(this);
                cliente = frm.ClienteSeleccionado();
            }
            if (cliente != null)
            {
                tbEncomiendaListadoDniCliente.Text = cliente.NroDni.ToString();
            }
        }

        private void btnEncomiendaListadoSeleccionarEncomienda_Click(object sender, EventArgs e)
        {
            Cliente cliente = null;
            using (ClienteListado frm = new ClienteListado(true))
            {
                frm.ShowDialog(this);
                cliente = frm.ClienteSeleccionado();
            }
            if (cliente != null)
            {
                tbEncomiendaListadoDniCliente.Text = cliente.NroDni.ToString();
            }
        }

        private void EncomiendaListado_Load(object sender, EventArgs e)
        {
            btnEncomiendaListadoBuscar.Visible = _esParaSeleccionar;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

        }

        private void EncomiendaListado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_esParaSeleccionar && e.CloseReason == CloseReason.UserClosing)
            {
                if (dgvEncomiendaListado.SelectedRows.Count == 0)
                {
                    DialogResult confirma = MensajePorPantalla.MensajeInformativo(this, "Debía seleccionar una encomienda.\n¿Desea salir de todas maneras?", MessageBoxButtons.YesNo);

                    if (confirma == DialogResult.No)
                        e.Cancel = true;
                }
            }
        }

        private void Seleccionar()
        {
            if (this.dgvEncomiendaListado.SelectedRows.Count > 0)
            {
                DialogResult confirma = MensajePorPantalla.MensajeInformativo(this, "¿Desea seleccionar esta encomienda?", MessageBoxButtons.YesNo);

                if (confirma == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void dgvEncomiendaListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEncomiendaListado.SelectedRows.Count > 0)
            {
                Seleccionar();
            }
        }
    }
}
