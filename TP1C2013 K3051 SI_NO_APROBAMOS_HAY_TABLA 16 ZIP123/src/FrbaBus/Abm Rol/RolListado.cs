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
using FrbaBus.Common.Excepciones;
using FrbaBus.Common.Helpers;

namespace FrbaBus.Rol
{
    public partial class RolListado : Form
    {
        private UsuarioManager _manager;

        public RolListado()
        {
            InitializeComponent();
            _manager = new UsuarioManager();
        }

        private void RolListado_Load(object sender, EventArgs e)
        {
            try
            {
                //Cargo la grilla de roles
                DataSet dsRoles = _manager.ObtenerRegistrosRolUsuario();
                this.dgvRolListado.DataSource = dsRoles.Tables[0];

                //Cargo las funcionalidades
                IList<Funcionalidad> funcionalidades = _manager.ListarFuncionalidad();
                this.cbbRolListadoFuncionalidades.Items.AddRange(funcionalidades.Select(f => f.Nombre).ToArray());
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                string funcionalidadElegida = string.Empty;
                if (this.cbbRolListadoFuncionalidades.SelectedItem != null)
                    funcionalidadElegida = this.cbbRolListadoFuncionalidades.SelectedItem.ToString();
                DataSet dsRoles = _manager.ObtenerRegistrosRolUsuario(this.tbRolListadoRol.Text, funcionalidadElegida);
                this.dgvRolListado.DataSource = dsRoles.Tables[0];
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


    }
}
