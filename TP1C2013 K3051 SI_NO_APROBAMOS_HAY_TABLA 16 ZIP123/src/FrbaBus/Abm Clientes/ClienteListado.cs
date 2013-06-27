using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Manager;
using FrbaBus.Common.Excepciones;
using FrbaBus.Common.Helpers;

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
            try
            {
                ClienteManager manager = new ClienteManager();
                DataSet clientes = manager.Listar();
                this.dgvClienteListado.DataSource = clientes.Tables[0];
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = this.txtDni.Text;
                string nombre = this.txtNombre.Text;
                string apellido = this.txtApellido.Text;
                string discapacitado = this.cbDiscapacitado.Checked ? "S" : "N";
                string sexo = string.Empty;
                if (this.cbFemenino.Checked && !cbMasculino.Checked)
                    sexo = "Fem";
                if (!this.cbFemenino.Checked && cbMasculino.Checked)
                    sexo = "Masc";

                DataSet dsClientes = new ClienteManager().ObtenerRegistrosCliente(dni, nombre, apellido, discapacitado, sexo);
                this.dgvClienteListado.DataSource = dsClientes.Tables[0];
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtApellido.Text = string.Empty;
            this.txtDni.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.cbDiscapacitado.Checked = false;
            this.cbFemenino.Checked = false;
            this.cbMasculino.Checked = false;
        }
    }
}
