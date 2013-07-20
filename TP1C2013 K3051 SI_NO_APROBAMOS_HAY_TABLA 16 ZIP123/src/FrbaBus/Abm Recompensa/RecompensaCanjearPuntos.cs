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
using FrbaBus.Abm_Clientes;

namespace FrbaBus.Abm_Recompensa
{
    public partial class RecompensaCanjearPuntos : Form
    {
        private RecompensaManager _manager;

        public RecompensaCanjearPuntos()
        {
            InitializeComponent();
            _manager = new RecompensaManager();
        }

        private void btnRecompensaCanjearPuntosBuscar_Click(object sender, EventArgs e)
        {
            Cliente cliente = null;
            using (ClienteListado frm = new ClienteListado())
            {
                frm.ShowDialog(this);
                cliente = frm.ClienteSeleccionado();

            }

            int puntosCliente;
            if (cliente != null)
            {
                this.tbRecompensaCanjearPuntosDni.Text = cliente.NroDni.ToString();
                puntosCliente = Convert.ToInt32(_manager.ObtenerPuntosCliente(cliente.NroDni));
                this.tbRecompensaCanjearPuntosPuntosAcumulados.Text = puntosCliente.ToString();

                this.dgvRecompensaCanjearPuntosRegistroPuntos.DataSource = _manager.ObtenerRegistroPuntosCliente(cliente.NroDni).Tables[0];

#region Ver premios disponibles para el cliente

                IList<Recompensa> recompensas = _manager.ListarFiltrado("", 0, puntosCliente, 0, 9999);
                this.dgvRecompensaCanjearPuntosPremiosDisponibles.DataSource = recompensas;

#endregion Ver premios disponibles para el cliente
            }
        }

        private void btnRecompensaCanjearPuntosCanjear_Click(object sender, EventArgs e)
        {

            try
            {


                decimal dniCliente = Convert.ToDecimal(tbRecompensaCanjearPuntosDni.Text);

                Recompensa recompensa = dgvRecompensaCanjearPuntosPremiosDisponibles.SelectedRows[0].DataBoundItem as Recompensa;

                int cantidadPedidad = Convert.ToInt32(tbRecompensaCanjearPuntosCantidadPedida.Text);

                _manager.CanjearPuntos(dniCliente, recompensa.IdRecompensa, cantidadPedidad);


                #region Actualizando datagridview's después de un canje

                tbRecompensaCanjearPuntosPuntosAcumulados.Text = _manager.ObtenerPuntosCliente(dniCliente);

                this.dgvRecompensaCanjearPuntosRegistroPuntos.DataSource = _manager.ObtenerRegistroPuntosCliente(dniCliente).Tables[0];

                int puntosAcumuladosActualizados = Convert.ToInt32(tbRecompensaCanjearPuntosPuntosAcumulados.Text);
                IList<Recompensa> recompensas = _manager.ListarFiltrado("", 0, puntosAcumuladosActualizados, 0, 9999);
                this.dgvRecompensaCanjearPuntosPremiosDisponibles.DataSource = recompensas;

                #endregion Actualizando datagridview's después de un canje

            } catch(Exception x){
                if (1 == 1) ;
            }

        }
    }
}