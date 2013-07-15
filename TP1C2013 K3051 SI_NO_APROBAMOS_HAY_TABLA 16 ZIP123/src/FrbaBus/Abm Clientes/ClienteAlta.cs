using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Manager;
using FrbaBus.Helpers;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Abm_Clientes
{
    public partial class ClienteAlta : Form
    {
        private ClienteManager _manager;

        public ClienteAlta()
        {
            InitializeComponent();
            this._manager = new ClienteManager();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.mtbClienteDNI.Text = "";
            this.tbClienteNombre.Text = "";
            this.tbClienteApellido.Text = "";
            this.tbClienteMail.Text = "";
            this.tbClienteDireccion.Text = "";
            this.mtbClienteTelefono.Text = "";
            this.dtpClienteFechaNac.Value = FechaHelper.Ahora();
            this.cbClienteEsDiscapacitado.Checked = false;
            this.rbClienteHombre.Checked = false;
            this.rbClienteMujer.Checked = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatos())
            {
                string sexo = "";
                if (rbClienteHombre.Checked)
                {
                    sexo = "H";
                }
                else if (rbClienteMujer.Checked)
                {
                    sexo = "M";
                }
                
                Cliente cliente = new Cliente()
                {
                    NroDni = Convert.ToInt64(this.mtbClienteDNI.Text),
                    Apellido = tbClienteApellido.Text,
                    Nombre = tbClienteNombre.Text,
                    Direccion = tbClienteDireccion.Text,
                    Telefono = mtbClienteTelefono.Text,
                    FechaNacimiento = dtpClienteFechaNac.Value,
                    EsDiscapacitado = cbClienteEsDiscapacitado.Checked,
                    Mail = tbClienteMail.Text,
                    Sexo = sexo
                };

                _manager.Alta(cliente);

                MessageBox.Show(this, "Cliente dado de alta", "El cliente fue dado de alta correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(this.mtbClienteDNI.Text))
            {
                MessageBox.Show("Controle el dni");
                return false;
            }
            if (string.IsNullOrEmpty(this.tbClienteNombre.Text))
            {
                MessageBox.Show("Controle el nombre");
                return false;
            }
            if (string.IsNullOrEmpty(this.tbClienteApellido.Text))
            {
                MessageBox.Show("Controle el apellido");
                return false;
            }
            if (string.IsNullOrEmpty(this.tbClienteDireccion.Text))
            {
                MessageBox.Show("Controle la dirección");
                return false;
            }
            if (string.IsNullOrEmpty(this.mtbClienteTelefono.Text))
            {
                MessageBox.Show("Controle el teléfono");
                return false;
            }
            if (string.IsNullOrEmpty(this.tbClienteMail.Text))
            {
                MessageBox.Show("Controle el mail");
                return false;
            }
            return true;
        }
    }
}
