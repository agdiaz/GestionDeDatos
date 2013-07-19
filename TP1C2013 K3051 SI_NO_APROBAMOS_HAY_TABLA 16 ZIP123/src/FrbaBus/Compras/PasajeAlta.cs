using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Common.Entidades;
using FrbaBus.Abm_Clientes;
using FrbaBus.Common.Helpers;

namespace FrbaBus.Compras
{
    public partial class PasajeAlta : Form
    {
        public PasajeAlta()
        {
            InitializeComponent();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            Cliente c = ObtenerCliente();
        }
        private Cliente ObtenerCliente()
        {
            Cliente cliente = null;
            using (ClienteListado frm = new ClienteListado(true))
            {
                frm.ShowDialog(this);
                if (frm.ClienteSeleccionado() != null)
                    cliente = frm.ClienteSeleccionado();
            }

            if (cliente == null)
            {
                MensajePorPantalla.MensajeInformativo(this, "No ha seleccionado un cliente, se dará de alta uno nuevo");

                using (ClienteAlta frm = new ClienteAlta())
                {
                    frm.ShowDialog(this);

                    if (frm.ClienteNuevo() != null)
                    {
                        cliente = frm.ClienteNuevo();
                    }
                }
            }
            return cliente;
        }

        private void btnSeleccionarButaca_Click(object sender, EventArgs e)
        {

        }
    }
}
