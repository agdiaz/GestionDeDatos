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
using FrbaBus.Common.Excepciones;

namespace FrbaBus.Compras
{
    public partial class EncomiendaAlta : Form
    {

        private PasajeManager _manager;
        private Viaje _viaje;
        private Cliente cliente = null;
        public Encomienda EncomiendaNuevo { get; set; }

        public EncomiendaAlta(Viaje v)
        {
            _manager = new PasajeManager();
            _viaje = v;
            InitializeComponent();
        }

        private void btnEncomiendaAltaGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Encomienda encomienda = new Encomienda();

                encomienda.NroDni = cliente.NroDni;
                encomienda.IdViaje = _viaje.Id;
                encomienda.Peso = Convert.ToDecimal(tbEncomiendaAltaPesoKg.Text);

                MensajePorPantalla.MensajeInformativo(this, "Se dio de alta la solicitud de encomienda");
                EncomiendaNuevo = encomienda;

                this.Close();
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void btnEncomiendaAltaDniCliente_Click(object sender, EventArgs e)
        {
            try
            {
                using (ClienteListado frm = new ClienteListado(true))
                {
                    frm.ShowDialog(this);
                    cliente = frm.ClienteSeleccionado();
                }
                if (cliente != null)
                    tbEncomiendaAltaDniCliente.Text = cliente.NroDni.ToString();
            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error al intentar modificar el registro.\n Detalle del error: " + ex.Message);
            }
        }

        private void EncomiendaAlta_Load(object sender, EventArgs e)
        {
            this.tbEncomiendaAltaMicro.Text = _viaje.Micro.Informacion;
            tbEncomiendaAltaViaje.Text = _viaje.Informacion;

        }
    }
}
