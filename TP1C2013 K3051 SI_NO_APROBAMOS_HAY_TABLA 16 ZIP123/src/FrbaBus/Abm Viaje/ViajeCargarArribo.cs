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
using FrbaBus.Common.Entidades;
using FrbaBus.Manager;
using FrbaBus.Common.Helpers;
using FrbaBus.Common.Excepciones;

namespace FrbaBus.Abm_Viaje
{
    public partial class ViajeCargarArribo : Form
    {
        private Viaje _viaje;
        private ViajeManager _manager;

        public ViajeCargarArribo()
        {
            InitializeComponent();
            _viaje = null;
            _manager = new ViajeManager();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                _viaje.FechaArribo = dtpFechaArriboReal.Value;
                _manager.GenerarArribo(_viaje);
                MensajePorPantalla.MensajeInformativo(this, "Se registro el arribo real del viaje");
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

        private void CargarDatosViaje()
        {
            tbCiudadDestino.Text = _viaje.Recorrido.CiudadDestino.Nombre;
            tbCiudadOrigen.Text = _viaje.Recorrido.CiudadOrigen.Nombre;
            tbMicro.Text = _viaje.Micro.Informacion;

            dtpFechaSalida.Value = _viaje.FechaSalida;
            dtpFechaArriboEstimada.Value = _viaje.FechaArriboEstimada;

            
        }

        private void ViajeCargarArribo_Load(object sender, EventArgs e)
        {
            dtpFechaArriboEstimada.Format = DateTimePickerFormat.Custom;
            dtpFechaArriboEstimada.CustomFormat = "dd/MM/yyyy hh:mm:ss";

            dtpFechaArriboReal.Format = DateTimePickerFormat.Custom;
            dtpFechaArriboReal.CustomFormat = "dd/MM/yyyy hh:mm:ss";

            dtpFechaSalida.Format = DateTimePickerFormat.Custom;
            dtpFechaSalida.CustomFormat = "dd/MM/yyyy hh:mm:ss";  
        }

        private void btnMicro_Click(object sender, EventArgs e)
        {
            using (ViajeListado frm = new ViajeListado())
            {
                frm.ShowDialog(this);
                _viaje = frm.ViajeSeleccionado();
            }

            if (_viaje != null)
            {
                if (_viaje.FechaArribo != null && _viaje.FechaArribo > DateTime.MinValue.AddMilliseconds(1))
                {
                    CargarDatosViaje();
                }
                else
                {
                    MensajePorPantalla.MensajeError(this, "El viaje ya tiene cargado una fecha de arribo");
                    _viaje = null;
                }

            }
        }

    }
}
