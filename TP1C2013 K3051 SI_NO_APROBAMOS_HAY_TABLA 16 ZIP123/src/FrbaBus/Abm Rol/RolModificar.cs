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

namespace FrbaBus.Rol
{
    public partial class RolModificar : Form
    {
        private RolUsuarioManager _manager;
        private FuncionalidadManager _funcionalidadManager;

        private RolUsuario Rol { get; set; }

        public RolModificar(RolUsuario rol)
        {
            this.Rol = rol;

            _manager = new RolUsuarioManager();
            _funcionalidadManager = new FuncionalidadManager();
            
            InitializeComponent();
        }

        private void btnRolModificarLimpiar_Click(object sender, EventArgs e)
        {
            this.tbRolModificarNuevoRol.Text = Rol.Nombre;
            for (int i = 0; i < this.clbFuncionalidades.Items.Count; i++)
            {
                clbFuncionalidades.SetItemChecked(i, false);
            }
            this.CargarFuncionalidadesDelRol();
        }

        private void RolModificar_Load(object sender, EventArgs e)
        {
            this.tbRolModificarNuevoRol.Text = Rol.Nombre;
            this.cbHabilitado.Checked = Rol.Inhabilitado;

            IList<Funcionalidad> funcs = _funcionalidadManager.Listar();
            clbFuncionalidades.DataSource = funcs;
            clbFuncionalidades.DisplayMember = "Nombre";
            clbFuncionalidades.ValueMember = "Id";

            this.CargarFuncionalidadesDelRol();
        }

        private void CargarFuncionalidadesDelRol()
        {
            foreach (Funcionalidad func in Rol.Funcionalidades)
            {
                for (int i = 0; i < clbFuncionalidades.Items.Count; i++)
                {
                    Funcionalidad item = (Funcionalidad)clbFuncionalidades.Items[i];
                    if (func.Nombre.Equals(item.Nombre)) 
                    {
                        clbFuncionalidades.SetItemChecked(i, true);
                        break;
                    }
                }
            }
        }

        private void btnRolModificarGuardar_Click(object sender, EventArgs e)
        {
            
            _manager.BajaRolFuncionalidades(Rol);
            
            foreach (var funcObj in this.clbFuncionalidades.CheckedItems)
            {
                Funcionalidad f = (Funcionalidad)funcObj;
                _funcionalidadManager.AsociarRolFuncionalidad(Rol, f);
            }
            
            _manager.Modificar(Rol);

            this.Close();
        }
    }
}
