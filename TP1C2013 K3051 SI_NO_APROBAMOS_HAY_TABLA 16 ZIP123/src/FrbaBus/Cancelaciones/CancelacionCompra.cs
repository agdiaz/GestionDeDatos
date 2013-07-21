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
using FrbaBus.Common.Excepciones;

namespace FrbaBus.Cancelaciones
{
    public partial class CancelacionCompra : Form
    {
        private CancelacionManager _manager;
        private CompraManager _compraManager;

        private Compra compra;

        public CancelacionCompra()
        {
            _manager = new CancelacionManager();
            _compraManager = new CompraManager();
            compra = null;
            InitializeComponent();
        }

        private void btnBuscarCompraCancel_Click(object sender, EventArgs e)
        {
            
            //using (Compras.ComprasListado frm = new FrbaBus.Compras.ComprasListado())
            //{
            //    frm.ShowDialog();
            //    compra = frm.CompraSeleccionada();
            //}
            try
            {
                using (Compras.ComprasListado frm = new FrbaBus.Compras.ComprasListado())
                {
                    frm.ShowDialog(this);
                    compra = frm.CompraSeleccionada();
                }
            }
            catch (Exception)
            {
                compra = null;
            }

            MostrarCompra();
        }

        private void MostrarCompra()
        {
            if (compra != null)
            {
                this.tbCompra.Text = compra.IdCompra.ToString();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                try
                {
                    _manager.CancelarCompra(compra, tbMotivo.Text);

                    MensajePorPantalla.MensajeInformativo(this, "Se cancelo la compra con el id: " + compra.IdCompra);
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

        private bool ValidarDatos()
        {
            if (compra == null)
            {
                MensajePorPantalla.MensajeError(this, "Debe seleccionar una compra");
                return false;
            }
            if (tbMotivo.Text == "")
            {
                MensajePorPantalla.MensajeError(this, "Debe ingresar el motivo");
                return false;
            }
            return true;

        }
    }
}
