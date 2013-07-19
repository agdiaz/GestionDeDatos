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
    public partial class ViajeModificar : Form
    {
        Viaje viaje = null;

        private ViajeManager _manager;

        public ViajeModificar(Viaje v)
        {
            viaje = v;
            _manager = new ViajeManager();
            InitializeComponent();
            SetearCustomFormatDataTimePicker();
        }

        private void SetearCustomFormatDataTimePicker()
        {
            dtpViajeModificarFechaSalida.Format = DateTimePickerFormat.Custom;
            dtpViajeModificarFechaSalida.CustomFormat = "MMMM dd, yyyy - HH:mm:ss";
            dtpViajeModificarFechaLlegadaEstimada.Format = DateTimePickerFormat.Custom;
            dtpViajeModificarFechaLlegadaEstimada.CustomFormat = "MMMM dd, yyyy - HH:mm:ss";
        }

        private void ViajeModificar_Load(object sender, EventArgs e)
        {
            cargarDatosDelViaje();
        }

        private void cargarDatosDelViaje()
        {
            this.dtpViajeModificarFechaSalida.Value = viaje.FechaSalida;
            this.dtpViajeModificarFechaLlegadaEstimada.Value = viaje.FechaArriboEstimada;
            this.txtMicro.Text = viaje.Micro.Informacion;
            this.txtRecorrido.Text = viaje.Recorrido.Informacion;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnViajeModificarBuscarMicro_Click(object sender, EventArgs e)
        {
            
            using (MicroListado frm = new MicroListado(true))
            {
                frm.ShowDialog(this);
                viaje.Micro = frm.MicroSeleccionado();
            }
            
            if (viaje.Micro != null)
            {
                txtMicro.Text = viaje.Micro.Informacion;
            }
        }

        private void btnViajeModificarBuscarRecorrido_Click(object sender, EventArgs e)
        {
            {
                using (RecorridoListado frm = new RecorridoListado(true))
                {
                    frm.ShowDialog(this);
                    viaje.Recorrido = frm.RecorridoSeleccionado();
                }

                if (viaje.Recorrido != null)
                {
                    txtRecorrido.Text = viaje.Recorrido.Informacion;
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.dtpViajeModificarFechaLlegadaEstimada.Value = FechaHelper.Ahora();
            this.dtpViajeModificarFechaSalida.Value = FechaHelper.Ahora();
            this.txtMicro.Text = string.Empty;
            this.txtRecorrido.Text = string.Empty;
        }

        private void btnViajeModificarGuardar_Click(object sender, EventArgs e)
        {
            {
            if (this.ValidarDatos())
            {
                try
                {
                    viaje.FechaSalida = this.dtpViajeModificarFechaSalida.Value;
                    viaje.FechaArriboEstimada = this.dtpViajeModificarFechaLlegadaEstimada.Value;
                    
                    viaje.Micro = viaje.Micro;
                    viaje.IdMicro = viaje.Micro.Id;
                    viaje.Recorrido = viaje.Recorrido;
                    viaje.IdRecorrido = viaje.Recorrido.Id;

                   this._manager.Modificar(viaje);

                 
                    MensajePorPantalla.MensajeInformativo(this, "Se modifico el viaje con el id: " + viaje.Id.ToString());

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

        private bool ValidarDatos()
        {
            if (dtpViajeModificarFechaSalida.Value < Helpers.FechaHelper.Ahora())
            {
                MensajePorPantalla.MensajeError(this, "Complete la fecha de salida");
                return false;
            }
     
            if (dtpViajeModificarFechaLlegadaEstimada.Value < Helpers.FechaHelper.Ahora())
            {
                MensajePorPantalla.MensajeError(this, "Complete la fecha de llegada estimada");
                return false;
            }
            if (viaje.Micro==null)
            {
                MensajePorPantalla.MensajeError(this, "Elija un micro");
                return false;
            }
            if (viaje.Recorrido==null)
            {
                MensajePorPantalla.MensajeError(this, "Elija un recorrido");
                return false;
            }
            return true;
        }
    }
}

