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

namespace FrbaBus.Abm_Recorrido
{
    public partial class RecorridoAlta : Form
    {
        private RecorridoManager _manager;
        private CiudadManager _ciudadManager;
        private ServicioManager _servicioManager;

        public RecorridoAlta()
        {
            InitializeComponent();
            this._manager = new RecorridoManager();
            this._ciudadManager = new CiudadManager();
            this._servicioManager = new ServicioManager();
        }

        private void RecorridoAlta_Load(object sender, EventArgs e)
        {
            CargarCiudades();
            CargarServicios();
        }

        private void btnRecorridoAltaLimpiar_Click(object sender, EventArgs e)
        {
            this.cbbRecorridoAltaTipoServicio.SelectedIndex = 0;
            this.cbCiudadDestino.SelectedIndex = 0;
            this.cbCiudadOrigen.SelectedIndex = 0;
            this.tbRecorridoAltaPrecioBasePorKgs.Text = string.Empty;
            this.tbRecorridoAltaPrecioBasePorPasaje.Text = string.Empty;
        }

        private void CargarCiudades()
        {
            IList<Ciudad> ciudadesOrigen = _ciudadManager.Listar();
            IList<Ciudad> ciudadesDestino = _ciudadManager.Listar();

            this.cbCiudadOrigen.DataSource = ciudadesOrigen;
            this.cbCiudadOrigen.DisplayMember = "Nombre";
            this.cbCiudadOrigen.ValueMember = "Id";

            this.cbCiudadDestino.DataSource = ciudadesDestino;
            this.cbCiudadDestino.DisplayMember = "Nombre";
            this.cbCiudadDestino.ValueMember = "Id";
        }

        private void CargarServicios()
        {
            IList<Servicio> servicios = _servicioManager.Listar();

            this.cbbRecorridoAltaTipoServicio.DataSource = servicios;
            this.cbbRecorridoAltaTipoServicio.DisplayMember = "TipoServicio";
            this.cbbRecorridoAltaTipoServicio.ValueMember = "Id";
        }

        private void btnRecorridoAltaGuardar_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatos())
            {
                try
                {
                    Recorrido rec = new Recorrido();

                    rec.CiudadDestino = this.cbCiudadDestino.SelectedItem as Ciudad;
                    rec.IdCiudadDestino = rec.CiudadDestino.Id;

                    rec.IdCiudadOrigen = rec.CiudadOrigen.Id;
                    rec.CiudadOrigen = this.cbCiudadOrigen.SelectedItem as Ciudad;
                    
                    rec.PrecioBaseKG = Convert.ToDecimal(this.tbRecorridoAltaPrecioBasePorKgs.Text);
                    rec.PrecioBasePasaje = Convert.ToDecimal(this.tbRecorridoAltaPrecioBasePorPasaje.Text);
                    
                    rec.Servicio = this.cbbRecorridoAltaTipoServicio.SelectedItem as Servicio;
                    rec.IdServicio = rec.Servicio.Id;

                    rec = this._manager.Alta(rec);

                    MensajePorPantalla.MensajeInformativo(this, "Se dio de alta el recorrido: " + rec.Informacion);

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
            if ((int)cbCiudadOrigen.SelectedValue < 1)
            {
                return false;
            }
            if ((int)cbCiudadDestino.SelectedValue < 1)
            {
                return false;
            }
            if ((int)cbbRecorridoAltaTipoServicio.SelectedValue < 1)
            {
                return false;
            }
            if (string.IsNullOrEmpty(tbRecorridoAltaPrecioBasePorKgs.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(tbRecorridoAltaPrecioBasePorPasaje.Text))
            {
                return false;
            }
            return true;
        }
    }
}
