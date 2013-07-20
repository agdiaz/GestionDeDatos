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

        public EncomiendaListado()
        {
            _manager = new PasajeManager();
            InitializeComponent();
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

        private void btnEncomiendaListadoSeleccionarCliente_Click(object sender, EventArgs e)
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
    }
}
