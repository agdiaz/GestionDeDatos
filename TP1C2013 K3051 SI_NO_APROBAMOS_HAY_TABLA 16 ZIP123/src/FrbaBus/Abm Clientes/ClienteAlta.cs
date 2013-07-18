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
using FrbaBus.Common.Excepciones;

namespace FrbaBus.Abm_Clientes
{
    public partial class ClienteAlta : Form
    {
        private ClienteManager _manager;
        private Cliente _cliente;

        public ClienteAlta()
        {
            InitializeComponent();
            this._manager = new ClienteManager();
        }
        
        public Cliente ClienteNuevo()
        {
            return _cliente;
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
                try
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

                    _cliente = new Cliente()
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

                    _cliente = _manager.Alta(_cliente);

                    MensajePorPantalla.MensajeInformativo(this, "Se dio de alta el cliente con DNI: " + _cliente.NroDni.ToString());
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
