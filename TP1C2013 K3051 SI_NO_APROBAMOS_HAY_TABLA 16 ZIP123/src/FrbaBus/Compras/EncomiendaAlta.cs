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
using FrbaBus.Abm_Clientes;

namespace FrbaBus.Compras
{
    public partial class EncomiendaAlta : Form
    {

        private PasajeManager _manager;
        private Viaje _viaje;
        public Encomienda EncomiendaNuevo { get; set; }

        public EncomiendaAlta(Viaje v)
        {
            _manager = new PasajeManager();
            _viaje = v;
            InitializeComponent();
        }

        private void btnEncomiendaAltaGuardar_Click(object sender, EventArgs e)
        {
            Encomienda encomienda = new Encomienda();

            encomienda.NroDni = Convert.ToInt32(tbEncomiendaAltaDniCliente.Text);
            encomienda.IdViaje = Convert.ToInt32(tbEncomiendaAltaViaje.Text);
            encomienda.Peso = Convert.ToDecimal(tbEncomiendaAltaPesoKg.Text);
//            encomienda.PrecioEncomienda = Convert.ToDecimal(tbPrecio.text);

            MensajePorPantalla.MensajeInformativo(this, "Se dio de alta la solicitud de encomienda");
            EncomiendaNuevo = encomienda;

            this.Close();

        }

        private void btnEncomiendaAltaDniCliente_Click(object sender, EventArgs e)
        {
            Cliente cliente = null;
            using (ClienteListado frm = new ClienteListado(true))
            {
                frm.ShowDialog(this);
                cliente = frm.ClienteSeleccionado();
            }
            tbEncomiendaAltaDniCliente.Text = cliente.NroDni.ToString();
        }
    }
}
