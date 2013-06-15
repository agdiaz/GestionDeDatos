using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Manager;

namespace FrbaBus.Abm_Clientes
{
    public partial class ClienteListado : Form
    {
        public ClienteListado()
        {
            InitializeComponent();
        }

        private void ClienteListado_Load(object sender, EventArgs e)
        {
            ClienteManager manager = new ClienteManager();
            DataSet clientes = manager.Listar();
            this.dgvClienteListado.AutoGenerateColumns = false;
            this.dgvClienteListado.DataSource = clientes.Tables[0];

            var NameField = new DataColumn();

            NameField.ColumnName = "Name";
            //NameField. = "name";
            GridView1.Columns.Add(NameField);
        }
    }
}
