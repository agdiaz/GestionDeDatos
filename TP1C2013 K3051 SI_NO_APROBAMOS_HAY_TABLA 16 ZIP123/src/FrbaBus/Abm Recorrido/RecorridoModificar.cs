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
    public partial class RecorridoModificar : Form
    {
        private RecorridoManager _manager;
        private CiudadManager _ciudadManager;
        private ServicioManager _servicioManager;
        private Recorrido _recorrido;

        public RecorridoModificar(Recorrido recorrido)
        {
            InitializeComponent();
            this._manager = new RecorridoManager();
            this._ciudadManager = new CiudadManager();
            this._servicioManager = new ServicioManager();
            this._recorrido = recorrido;
        }

        private void btnRecorridoModificarLimpiar_Click(object sender, EventArgs e)
        {
            this.cbbRecorridoModificarTipoServicio.SelectedIndex = 0;
            this.cbCiudadDestino.SelectedIndex = 0;
            this.cbCiudadOrigen.SelectedIndex = 0;
            this.tbRecorridoModificarPrecioBasePorKgs.Text = string.Empty;
            this.tbRecorridoModificarPrecioBasePorPasaje.Text = string.Empty;
        }

        private void RecorridoModificar_Load(object sender, EventArgs e)
        {
            CargarCiudades();
            CargarServicios();

            CargarRecorrido();
        }

        private void CargarRecorrido()
        {
            this.cbbRecorridoModificarTipoServicio.SelectedItem = _recorrido.Servicio;
            this.cbCiudadDestino.SelectedItem = _recorrido.CiudadDestino;
            this.cbCiudadOrigen.SelectedItem = _recorrido.CiudadOrigen;
            this.tbRecorridoModificarPrecioBasePorKgs.Text = _recorrido.PrecioBaseKG.ToString();
            this.tbRecorridoModificarPrecioBasePorPasaje.Text = _recorrido.PrecioBasePasaje.ToString();

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

            this.cbbRecorridoModificarTipoServicio.DataSource = servicios;
            this.cbbRecorridoModificarTipoServicio.DisplayMember = "TipoServicio";
            this.cbbRecorridoModificarTipoServicio.ValueMember = "Id";
        }

        private void btnRecorridoModificarGuardar_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatos())
            {
                try
                {
                    _recorrido.CiudadDestino = this.cbCiudadDestino.SelectedItem as Ciudad;
                    _recorrido.CiudadOrigen = this.cbCiudadOrigen.SelectedItem as Ciudad;
                    _recorrido.IdCiudadDestino = _recorrido.CiudadDestino.Id;
                    _recorrido.IdCiudadOrigen = _recorrido.CiudadOrigen.Id;
                    _recorrido.PrecioBaseKG = Convert.ToDecimal(this.tbRecorridoModificarPrecioBasePorKgs.Text);
                    _recorrido.PrecioBasePasaje = Convert.ToDecimal(this.tbRecorridoModificarPrecioBasePorPasaje.Text);
                    _recorrido.Servicio = this.cbbRecorridoModificarTipoServicio.SelectedItem as Servicio;
                    _recorrido.IdServicio = _recorrido.Servicio.Id;

                    this._manager.Modificar(_recorrido);
                    MensajePorPantalla.MensajeInformativo(this, "Se dio de alta el recorrido con el id: " + _recorrido.Id.ToString());

                    this.Close();
                }
                catch (AccesoBDException ex)
                {
                    MensajePorPantalla.MensajeExceptionBD(this, ex);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MensajePorPantalla.MensajeError(this, "Error al intentar modificar el registro.\n Detalle del error: " + ex.Message);
                    this.Close();
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
            if ((int)cbbRecorridoModificarTipoServicio.SelectedValue < 1)
            {
                return false;
            }
            if (string.IsNullOrEmpty(tbRecorridoModificarPrecioBasePorKgs.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(tbRecorridoModificarPrecioBasePorPasaje.Text))
            {
                return false;
            }
            return true;
        }
    }
}
