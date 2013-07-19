using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Manager;
using FrbaBus.Common.Helpers;
using FrbaBus.Common.Excepciones;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Abm_Ciudad
{
    public partial class CiudadListado : Form
    {
        private bool _esParaSeleccionar = false;
        private CiudadManager _manager;

        public CiudadListado()
        {
            InitializeComponent();
            _manager = new CiudadManager();
        }

        public CiudadListado(bool esParaSeleccionar)
        :this()
        {
            _esParaSeleccionar = esParaSeleccionar;
        }

        private void CargarCiudades()
        {
            try
            {
                IList<Ciudad> ciudades = _manager.Listar();
                this.dgvCiudadListado.DataSource = ciudades;
                this.dgvCiudadListado.Columns["Id"].Visible = false;
                this.dgvCiudadListado.Columns["Nombre"].Width = 300;
            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
                this.Close();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error al intentar cargar el listado.\n Detalle del error: " + ex.Message);
                this.Close();
            }
        }
        private void CiudadListado_Load(object sender, EventArgs e)
        {
            btnSeleccionar.Visible = _esParaSeleccionar;
            CargarCiudades();
        }
        private void btnCiudadListadoBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string ciudadElegida = this.tbCiudadListadoCiudad.Text;
                IList<Ciudad> dsCiudades = _manager.ObtenerListado(ciudadElegida);
                this.dgvCiudadListado.DataSource = dsCiudades;
            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error al realizar la búsqueda correspondiente.\n Detalle del error: " + ex.Message);
            }
        }
        private void btnCiudadListadoLimpiar_Click(object sender, EventArgs e)
        {
            tbCiudadListadoCiudad.Text = "";
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Ciudad ciudad = dgvCiudadListado.SelectedRows[0].DataBoundItem as Ciudad;
                
                using (CiudadModificar frm = new CiudadModificar(ciudad))
                {
                    frm.ShowDialog(this);
                }
                CargarCiudades();
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

            CargarCiudades();
        }
        private void btnCiudadListadoDarBaja_Click(object sender, EventArgs e)
        {
            try
            {
                Ciudad ciudad = dgvCiudadListado.SelectedRows[0].DataBoundItem as Ciudad;
                _manager.Baja(ciudad);
                CargarCiudades();
            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error al intentar cargar borrar el registro.\n Detalle del error: " + ex.Message);
            }
        }

        private void dgvCiudadListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_esParaSeleccionar)
                Seleccionar();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void Seleccionar()
        {
            if (this.dgvCiudadListado.SelectedRows.Count > 0)
            {
                DialogResult confirma = MensajePorPantalla.MensajeInformativo(this, "¿Desea seleccionar esta ciudad?", MessageBoxButtons.YesNo);

                if (confirma == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void CiudadListado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_esParaSeleccionar && e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult confirma = MensajePorPantalla.MensajeInformativo(this, "Debía seleccionar una ciudad.\n¿Desea salir de todas maneras?", MessageBoxButtons.YesNo);

                if (confirma == DialogResult.No)
                    e.Cancel = true;
            }
        }
    }
}
