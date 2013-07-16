﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Common.Entidades;
using FrbaBus.Manager;
using FrbaBus.Common.Excepciones;
using FrbaBus.Common.Helpers;

namespace FrbaBus.Abm_Recorrido
{
    public partial class RecorridoListado : Form
    {
        private RecorridoManager _manager;
        private ServicioManager _servicioManager;
        private CiudadManager _ciudadManager;


        public RecorridoListado()
        {
            InitializeComponent();
            _manager = new RecorridoManager();
            _servicioManager = new ServicioManager();
            _ciudadManager = new CiudadManager();
        }

        private void btnRecorridoListadoBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Ciudad origen = this.cbCiudadOrigen.SelectedItem as Ciudad;
                Ciudad destino = this.cbCiudadDestino.SelectedItem as Ciudad;
                Servicio servicio = this.cbbRecorridoListadoTipoServicio.SelectedItem as Servicio;

                this.dgvRecorridoListado.DataSource = _manager.ListarFiltrado(origen, destino, servicio);
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

        private void btnRecorridoListadoLimpiar_Click(object sender, EventArgs e)
        {
            this.cbbRecorridoListadoTipoServicio.SelectedIndex = 0;
            this.cbCiudadOrigen.SelectedIndex = 0;
            this.cbCiudadDestino.SelectedIndex = 0;
        }

        private void RecorridoListado_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCiudades();
                CargarServicios();
                CargarRecorridos();                
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

        private void CargarRecorridos()
        {
            var recorridos = _manager.Listar().OrderBy(r => r.CiudadOrigen.Nombre).ThenBy(r => r.CiudadDestino.Nombre).ThenBy(r => r.Servicio.TipoServicio).ToList();
            this.dgvRecorridoListado.DataSource = recorridos;
            this.dgvRecorridoListado.Columns["Id"].Visible = false;
            this.dgvRecorridoListado.Columns["IdCiudadDestino"].Visible = false;
            this.dgvRecorridoListado.Columns["IdCiudadOrigen"].Visible = false;
            this.dgvRecorridoListado.Columns["IdServicio"].Visible = false;
        }
        private void CargarCiudades()
        {
            IList<Ciudad> ciudadesOrigen = _ciudadManager.Listar();
            ciudadesOrigen.Insert(0, new Ciudad(){Nombre = string.Empty });

            IList<Ciudad> ciudadesDestino = _ciudadManager.Listar();
            ciudadesDestino.Insert(0, new Ciudad() { Nombre = string.Empty });

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
            servicios.Insert(0, new Servicio() { TipoServicio = string.Empty });

            this.cbbRecorridoListadoTipoServicio.DataSource = servicios;
            this.cbbRecorridoListadoTipoServicio.DisplayMember = "TipoServicio";
            this.cbbRecorridoListadoTipoServicio.ValueMember = "Id";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Recorrido recorrido = dgvRecorridoListado.SelectedRows[0].DataBoundItem as Recorrido;

            using (RecorridoModificar frm = new RecorridoModificar(recorrido))
            {
                frm.ShowDialog(this);
            }
            CargarRecorridos();
            
        }

        private void btnRecorridoListadoDarBaja_Click(object sender, EventArgs e)
        {
            try
            {
                Recorrido rec = (Recorrido)dgvRecorridoListado.SelectedRows[0].DataBoundItem;
                _manager.Baja(rec);

                //Cargo la grilla de roles
                CargarRecorridos();

            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
                this.Close();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error al intentar borrar el registro.\n Detalle del error: " + ex.Message);
                this.Close();
            }
            
        }
    }
}
