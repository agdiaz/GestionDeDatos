﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Manager;
using FrbaBus.Common.Entidades;
using FrbaBus.Common.Excepciones;
using FrbaBus.Common.Helpers;

namespace FrbaBus.Rol
{
    public partial class RolListado : Form
    {
        private RolUsuarioManager _manager;
        private FuncionalidadManager _funcionalidadesManager;

        public RolListado()
        {
            InitializeComponent();
            _manager = new RolUsuarioManager();
            _funcionalidadesManager = new FuncionalidadManager();
        }

        private void RolListado_Load(object sender, EventArgs e)
        {
            try
            {
                //Cargo la grilla de roles
                this.dgvRolListado.DataSource = _manager.Listar();
                this.dgvRolListado.Columns["IdRol"].Visible = false;
                this.dgvRolListado.Columns["Activado"].Visible = false;
                this.dgvRolListado.Columns["Funcionalidades"].Visible = false;

                //Cargo las funcionalidades
                CargarFuncionalidades();
            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error al intentar cargar el listado.\n Detalle del error: " + ex.Message);
            }
        }

        private void CargarFuncionalidades()
        {
            IList<Funcionalidad> funcionalidades = _funcionalidadesManager.Listar();
            funcionalidades.Insert(0, new Funcionalidad() { Nombre = string.Empty });
            this.cbbRolListadoFuncionalidades.DataSource = funcionalidades;
            this.cbbRolListadoFuncionalidades.DisplayMember = "Nombre";
            this.cbbRolListadoFuncionalidades.ValueMember = "Id";

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarRolesFiltrados();
        }

        private void CargarRolesFiltrados()
        {
            try
            {
                Funcionalidad funcionalidadElegida = null;
                if (this.cbbRolListadoFuncionalidades.SelectedItem != null)
                {
                    funcionalidadElegida = this.cbbRolListadoFuncionalidades.SelectedItem as Funcionalidad;
                }

                IList<RolUsuario> roles = _manager.ListarFiltrado(this.tbRolListadoRol.Text, funcionalidadElegida.Nombre);
                this.dgvRolListado.DataSource = roles;
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                RolUsuario rol = (RolUsuario)dgvRolListado.SelectedRows[0].DataBoundItem;
                using (RolModificar frm = new RolModificar(rol))
                {
                    frm.ShowDialog(this);
                }

                //Cargo la grilla de roles
                this.dgvRolListado.DataSource = _manager.Listar();
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

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                RolUsuario rol = (RolUsuario)dgvRolListado.SelectedRows[0].DataBoundItem;
                DialogResult confirm = MensajePorPantalla.MensajeInformativo(this, "¿Desea borrar el rol " + rol.Nombre + " ?", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    _manager.Baja(rol);
                    MensajePorPantalla.MensajeInformativo(this, "Se ha borrado el rol");
                    LimpiarDatos();
                    CargarRolesFiltrados();
                }
            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error al intentar borrar el registro.\n Detalle del error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
            CargarRolesFiltrados();
        }

        private void LimpiarDatos()
        {
            cbbRolListadoFuncionalidades.SelectedIndex = 0;
            tbRolListadoRol.Text = string.Empty;
        }

    }
}
