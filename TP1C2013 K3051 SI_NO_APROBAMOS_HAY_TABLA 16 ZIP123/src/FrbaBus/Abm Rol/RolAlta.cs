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
using FrbaBus.Common.Helpers;
using FrbaBus.Common.Excepciones;

namespace FrbaBus.Rol
{
    public partial class RolAlta : Form
    {
        private RolUsuarioManager _manager;
        private FuncionalidadManager _funcionalidadManager;

        public RolAlta()
        {
            InitializeComponent();
            _manager = new RolUsuarioManager();
            _funcionalidadManager = new FuncionalidadManager();
        }

        private void btnRolAltaLimpiar_Click(object sender, EventArgs e)
        {
            this.tbRolAltaNuevoRol.Text = string.Empty;
            for (int i = 0; i < this.clbFuncionalidades.Items.Count; i++)
            {
                clbFuncionalidades.SetItemChecked(i, false);
            }
        }

        private void RolAlta_Load(object sender, EventArgs e)
        {
            IList<Funcionalidad> funcs = _funcionalidadManager.Listar();
            clbFuncionalidades.DataSource = funcs;
            clbFuncionalidades.DisplayMember = "Nombre";
            clbFuncionalidades.ValueMember = "Id";
        }

        private void btnRolAltaGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                RolUsuario rol = new RolUsuario(this.tbRolAltaNuevoRol.Text);
                rol = _manager.Alta(rol);

                foreach (var funcObj in this.clbFuncionalidades.CheckedItems)
                {
                    Funcionalidad f = (Funcionalidad)funcObj;
                    _funcionalidadManager.AsociarRolFuncionalidad(rol, f);
                }

                MensajePorPantalla.MensajeInformativo(this, "Se dio de alta el rol con el id: " + rol.IdRol.ToString());
                this.Close();
            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
                this.Close();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error al intentar dar el registro.\n Detalle del error: " + ex.Message);
                this.Close();
            }
        }
    }
}
