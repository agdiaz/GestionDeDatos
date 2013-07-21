using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Abm_Micro;
using FrbaBus.Abm_Recorrido;
using FrbaBus.Helpers;
using FrbaBus.Common.Entidades;
using FrbaBus.Manager;
using FrbaBus.Common.Helpers;
using FrbaBus.Common.Excepciones;

namespace FrbaBus.Abm_Viaje
{
    public partial class ViajeAlta : Form
    {
        Micro micro = null;
        Recorrido recorrido = null;

        private ViajeManager _manager;

        public ViajeAlta()
        {
            _manager = new ViajeManager();
            InitializeComponent();
            SetearCustomFormatDataTimePicker();
        }

        private void SetearCustomFormatDataTimePicker()
        {
            dtpViajeAltaFechaSalida.Format = DateTimePickerFormat.Custom;
            dtpViajeAltaFechaSalida.CustomFormat = "MMMM dd, yyyy - HH:mm:ss";
            dtpViajeAltaFechaLlegadaEstimada.Format = DateTimePickerFormat.Custom;
            dtpViajeAltaFechaLlegadaEstimada.CustomFormat = "MMMM dd, yyyy - HH:mm:ss";
        }

        private void ViajeAlta_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnViajeAltaBuscarMicro_Click(object sender, EventArgs e)
        {
            {
                using (MicroListado frm = new MicroListado(true))
                {
                    frm.ShowDialog(this);
                    micro = frm.MicroSeleccionado();
                }

                if (micro != null)
                {
                    txtMicro.Text = micro.Informacion;
                }
            }
        }

        private void btnViajeAltaBuscarRecorrido_Click(object sender, EventArgs e)
        {
            {
                using (RecorridoListado frm = new RecorridoListado(true))
                {
                    frm.ShowDialog(this);
                    recorrido = frm.RecorridoSeleccionado();
                }

                if (recorrido != null)
                {
                    txtRecorrido.Text = recorrido.Informacion;
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.dtpViajeAltaFechaLlegadaEstimada.Value = FechaHelper.Ahora();
            this.dtpViajeAltaFechaSalida.Value = FechaHelper.Ahora();
            this.txtMicro.Text = string.Empty;
            this.txtRecorrido.Text = string.Empty;
        }

        private void btnViajeAltaGuardar_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatos())
            {
                try
                {
                    Viaje viaje = new Viaje();

                    viaje.FechaSalida = this.dtpViajeAltaFechaSalida.Value;
                    viaje.FechaArriboEstimada = this.dtpViajeAltaFechaLlegadaEstimada.Value;
                    
                    viaje.Micro = micro;
                    viaje.IdMicro = micro.Id;
                    viaje.Recorrido = recorrido;
                    viaje.IdRecorrido = recorrido.Id;

                   viaje = this._manager.Alta(viaje);

                    MensajePorPantalla.MensajeInformativo(this, "Se dio de alta el viaje con el id: " + viaje.Id.ToString());

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
            if (dtpViajeAltaFechaSalida.Value < Helpers.FechaHelper.Ahora())
            {
                MensajePorPantalla.MensajeError(this, "Complete la fecha de salida");
                return false;
            }
     
            if (dtpViajeAltaFechaLlegadaEstimada.Value < Helpers.FechaHelper.Ahora())
            {
                MensajePorPantalla.MensajeError(this, "Complete la fecha de llegada estimada");
                return false;
            }
            if (dtpViajeAltaFechaLlegadaEstimada.Value <= dtpViajeAltaFechaSalida.Value)
            {
                MensajePorPantalla.MensajeError(this, "La llegada no puede ser antes que la salida");
                return false;
            }
            if (micro==null)
            {
                MensajePorPantalla.MensajeError(this, "Elija un micro");
                return false;
            }
            if (recorrido==null)
            {
                MensajePorPantalla.MensajeError(this, "Elija un recorrido");
                return false;
            }
            return true;
        }
    }
}
