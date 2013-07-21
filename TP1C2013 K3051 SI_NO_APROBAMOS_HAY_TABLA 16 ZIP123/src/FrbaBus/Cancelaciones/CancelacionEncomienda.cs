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
using FrbaBus.Common.Helpers;
using FrbaBus.Common.Excepciones;

namespace FrbaBus.Cancelaciones
{
    public partial class CancelacionEncomienda : Form
    {
        private CancelacionManager _manager;
        private Encomienda encomienda;
        public CancelacionEncomienda()
        {
            _manager = new CancelacionManager();
            encomienda = null;
            InitializeComponent();
        }

        private void btnCancelacionEncomiendaBuscarCompra_Click(object sender, EventArgs e)
        {
            using (Compras.EncomiendaListado frm = new FrbaBus.Compras.EncomiendaListado(true))
            {
                frm.ShowDialog();
                encomienda = frm.EncomiendaSeleccionado();
            }
            MostrarEncomienda();
        }

        private void MostrarEncomienda()
        {
            if (encomienda != null)
            {
                this.tbCancelacionEncomienda.Text = encomienda.IdEncomienda.ToString();
            }
        }

        private void btnCancelacionEncomiendaCancelarEncomienda_Click(object sender, EventArgs e)
        {
            try
            {
                _manager.CancelarEncomienda(encomienda, tbMotivoCancelEncomienda.Text);

                MensajePorPantalla.MensajeInformativo(this, "Se cancelo la encomienda con el id: " + encomienda.IdEncomienda);
                this.Close();
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
    }
}