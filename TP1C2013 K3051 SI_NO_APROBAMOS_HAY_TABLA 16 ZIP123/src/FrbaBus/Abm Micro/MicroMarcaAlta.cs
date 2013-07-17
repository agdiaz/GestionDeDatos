using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Common.Entidades;
using FrbaBus.Manager;
using FrbaBus.Common.Helpers;
using FrbaBus.Helpers;

namespace FrbaBus.Abm_Micro
{
    public partial class MicroMarcaAlta : Form
    {
        public MicroMarcaAlta()
        {
            InitializeComponent();
        }

        private void btnMicroMarcaAltaGuardar_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatos())
            {
                Empresa c = new Empresa()
                {
                    Descripcion = this.tbMicroMarcaAltaMarca.Text
                };

                new EmpresaManager().Alta(c);

                MensajePorPantalla.MensajeInformativo(this, "Se dio de alta la empresa/marca con el id: " + c.Id.ToString());

                this.Close();
            }
        }

        private bool ValidarDatos()
        {
            if (String.IsNullOrEmpty(this.tbMicroMarcaAltaMarca.Text))
            {
                MensajeDeError.MostrarError(lblMicroMarcaAltaMarca);
                return false;
            }
            return true;
        }
    }
}
