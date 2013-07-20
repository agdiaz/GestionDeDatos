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

namespace FrbaBus.Abm_Micro
{
    public partial class MicroDecision : Form
    {
        private MicroManager _manager;
        private Micro _micro;

        public MicroDecision(Micro micro)
        {
            InitializeComponent();
            _manager = new MicroManager();
            _micro = micro;
        }

        private void MicroDecision_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            try
            {
                _manager.CancelarTodosLosViajes(_micro);
                MensajePorPantalla.MensajeInformativo(this, "Se cancelaron todos los viajes");
                this.Close();
            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error al intentar cargar borrar el registro.\n Detalle del error: " + ex.Message);
            }
        }

        private void btnReasignar_Click(object sender, EventArgs e)
        {
            try
            {
                int resultado = _manager.ReAsignarMicros(_micro);
                while (resultado < 1)
                {
                    MensajePorPantalla.MensajeError(this, "No se pudo encontrar un micro candidato para reasignar los viajes. De de alta uno nuevo");
                    using (MicroAlta frm = new MicroAlta())
                    {
                        frm.ShowDialog(this);
                    }
                    resultado = _manager.ReAsignarMicros(_micro);
                }
                MensajePorPantalla.MensajeInformativo(this, "Se reasignaron todos los viajes al micro con id: " + resultado);
                this.Close();
            }
            catch (AccesoBDException ex)
            {
                MensajePorPantalla.MensajeExceptionBD(this, ex);
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, "Error al intentar cargar borrar el registro.\n Detalle del error: " + ex.Message);
            }
        }


    }
}
