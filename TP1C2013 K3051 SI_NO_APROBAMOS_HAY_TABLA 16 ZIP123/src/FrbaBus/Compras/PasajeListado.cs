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
        private bool _esSeleccionar;
        private PasajeManager _manager;
        public PasajeListado(bool es)
        {
            _esSeleccionar = es;
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
                this.dgvPasajeListado.Columns["Disponible"].Visible = false;
                this.dgvPasajeListado.Columns["IdCancelacion"].Visible = false;
                this.dgvPasajeListado.Columns["Cancelacion"].Visible = false;
                this.dgvPasajeListado.Columns["Butaca"].Visible = false;

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

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            this.Seleccionar();
        }
        private void Seleccionar()
        {
            if (this.dgvPasajeListado.SelectedRows.Count > 0)
            {
                DialogResult confirma = MensajePorPantalla.MensajeInformativo(this, "¿Desea seleccionar este pasaje?", MessageBoxButtons.YesNo);

                if (confirma == DialogResult.Yes)
                {
                    this.Close();
                }
            }

        }

        private void PasajeListado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_esSeleccionar && e.CloseReason == CloseReason.UserClosing)
            {
                if (dgvPasajeListado.SelectedRows.Count == 0)
                {
                    DialogResult confirma = MensajePorPantalla.MensajeInformativo(this, "Debía seleccionar un pasaje.\n¿Desea salir de todas maneras?", MessageBoxButtons.YesNo);

                    if (confirma == DialogResult.No)
                        e.Cancel = true;
                }
            }

        }

        private void dgvPasajeListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPasajeListado.SelectedRows.Count > 0)
            {
                Seleccionar();
            }
        }
    }
}
