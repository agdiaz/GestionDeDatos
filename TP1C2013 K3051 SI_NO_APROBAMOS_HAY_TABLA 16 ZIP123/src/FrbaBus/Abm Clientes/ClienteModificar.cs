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
using FrbaBus.Common.Helpers;

namespace FrbaBus.Abm_Clientes
{
    public partial class ClienteModificar : Form
    {
        private ClienteManager _manager;
        private Cliente _cliente;

        public ClienteModificar(Cliente c)
        {
            InitializeComponent();
            this._manager = new ClienteManager();
            this._cliente = c;
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

                _cliente.NroDni = Convert.ToInt64(this.mtbClienteDNI.Text);
                _cliente.Apellido = tbClienteApellido.Text;
                _cliente.Nombre = tbClienteNombre.Text;
                _cliente.Direccion = tbClienteDireccion.Text;
                _cliente.Telefono = mtbClienteTelefono.Text;
                _cliente.FechaNacimiento = dtpClienteFechaNac.Value;
                _cliente.EsDiscapacitado = cbClienteEsDiscapacitado.Checked;
                _cliente.Mail = tbClienteMail.Text;
                _cliente.Sexo = sexo;

                _manager.Modificar(_cliente);

                MensajePorPantalla.MensajeInformativo(this, "Se modifico el cliente con DNI: " + _cliente.NroDni.ToString());
                this.Close();
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

        private void ClienteModificar_Load(object sender, EventArgs e)
        {
            MostrarDatosCliente();
        }

        private void MostrarDatosCliente()
        {
            mtbClienteDNI.Text = _cliente.NroDni.ToString();
            mtbClienteDNI.ReadOnly = true;

            dtpClienteFechaNac.Value = _cliente.FechaNacimiento;
            tbClienteNombre.Text = _cliente.Nombre;
            tbClienteApellido.Text = _cliente.Apellido;

            switch (_cliente.Sexo)
            {
                case "M":
                    rbClienteHombre.Checked = false;
                    rbClienteMujer.Checked = true;
                    break;
                case "H":
                    rbClienteHombre.Checked = true;
                    rbClienteMujer.Checked = false;
                    break;
                case "-":
                default:
                    rbClienteHombre.Checked = false;
                    rbClienteMujer.Checked = false;
                    break;
            }

            cbClienteEsDiscapacitado.Checked = _cliente.EsDiscapacitado;
            tbClienteDireccion.Text = _cliente.Direccion;
            mtbClienteTelefono.Text = _cliente.Telefono;
            tbClienteMail.Text = _cliente.Mail;
        }
    }
}
