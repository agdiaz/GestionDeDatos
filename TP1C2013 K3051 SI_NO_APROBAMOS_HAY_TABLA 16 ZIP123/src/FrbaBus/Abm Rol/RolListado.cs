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
            //Cargo la grilla de roles
            DataSet dsRoles = _manager.ObtenerRegistrosRolUsuario();
            this.dgvRolListado.DataSource = dsRoles.Tables[0];

            //Cargo las funcionalidades
            IList<Funcionalidad> funcionalidades = _manager.ListarFuncionalidad();
            this.cbbRolListadoFuncionalidades.Items.AddRange(funcionalidades.Select(f => f.Nombre).ToArray());
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            DataSet dsRoles = _manager.ObtenerRegistrosRolUsuario(this.tbRolListadoRol.Text, this.cbbRolListadoFuncionalidades.SelectedItem.ToString());
            this.dgvRolListado.DataSource = dsRoles.Tables[0];
        }


    }
}
