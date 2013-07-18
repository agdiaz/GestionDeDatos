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
using FrbaBus.Common.Entidades;

namespace FrbaBus.Abm_Clientes
{
    public partial class ClienteListado : Form
    {
        private ClienteManager _manager;

        public ClienteListado()
        {
            InitializeComponent();
            _manager = new ClienteManager();
        }

        public Cliente ClienteSeleccionado()
        {
            Cliente c = null;
            if (dgvClienteListado.SelectedRows.Count > 0)
                c = dgvClienteListado.SelectedRows[0].DataBoundItem as Cliente;
            return c;
        }

        private void ClienteListado_Load(object sender, EventArgs e)
        {
            try
            {
                LimpiarControles();
                CargarListaClientes();
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

        private void CargarListaClientes()
        {
            this.dgvClienteListado.DataSource = _manager.Listar();
            this.dgvClienteListado.Columns["Sexo"].Visible = false;
            this.dgvClienteListado.Columns["SexoValor"].HeaderText = "Sexo";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = this.txtDni.Text;
                string nombre = this.txtNombre.Text;
                string apellido = this.txtApellido.Text;
                string discapacitado = string.Empty;
                
                if (this.rbDiscNo.Checked)
                    discapacitado = "N";
                if (this.rbDiscSi.Checked)
                    discapacitado = "S";

                string sexo = string.Empty;
                if (this.cbFemenino.Checked)
                    sexo = "M";
                if (cbMasculino.Checked)
                    sexo = "H";

                this.dgvClienteListado.DataSource = _manager.ListarFiltrado(dni, nombre, apellido, discapacitado, sexo);
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
            LimpiarControles();
        }

        private void LimpiarControles()
        {
            this.txtApellido.Text = string.Empty;
            this.txtDni.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.rbDiscNA.Checked = true;
            this.cbFemenino.Checked = false;
            this.cbMasculino.Checked = false;
        }

        private void btnDarBaja_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    Cliente cliente = dgvClienteListado.SelectedRows[0].DataBoundItem as Cliente;
                    new ClienteManager().Baja(cliente);
                    MensajePorPantalla.MensajeInformativo(this,"El cliente se ha dado de baja correctamente");
                    CargarListaClientes();
                }
                catch (AccesoBDException ex)
                {
                    MensajePorPantalla.MensajeExceptionBD(this, ex);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MensajePorPantalla.MensajeError(this, "Error al intentar borrar el registro.\n Detalle del error: " + ex.Message);
                    this.Close();
                }

                CargarListaClientes();

            }

        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = dgvClienteListado.SelectedRows[0].DataBoundItem as Cliente;

                using (ClienteModificar frm = new ClienteModificar(cliente))
                {
                    frm.ShowDialog(this);
                }
                CargarListaClientes();
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

            CargarListaClientes();
        }
    }
}
