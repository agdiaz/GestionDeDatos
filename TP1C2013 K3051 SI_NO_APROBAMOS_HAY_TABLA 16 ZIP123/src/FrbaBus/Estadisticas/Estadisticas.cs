using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Helpers;
using FrbaBus.Common.Entidades.Estadisticas;
using FrbaBus.Manager;

namespace FrbaBus.Estadisticas
{
    public partial class Estadisticas : Form
    {
        private EstadisticasManager _manager;

        public Estadisticas()
        {
            InitializeComponent();
            this._manager = new EstadisticasManager();
        }

        private void EstadisticasClientesConMasPuntos_Load(object sender, EventArgs e)
        {
            var s = FechaHelper.ListarSemestres();
            this.comboBox1.DataSource = s;
            this.comboBox1.DisplayMember = "Periodo";
            this.comboBox1.ValueMember = "Periodo";

            this.cbListado.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            IList<IListadoEstadistico> registros = new List<IListadoEstadistico>();
            
            Semestre s = this.comboBox1.SelectedItem as Semestre;

            switch (this.cbListado.SelectedIndex)
            {
                case 0:
                    registros = this._manager.DestinosMasVendidos(s);
                    break;
                case 1:
                    registros = this._manager.DestinosConMasMicrosVacios(s);
                    break;
                case 2:
                    registros = this._manager.ClientesConMasPuntos(s);
                    break;
                case 3:
                    registros = this._manager.DestinosMasCancelados(s);
                    break;
                case 4:
                    registros = this._manager.MicrosConMasDiasFueraDeServicio(s);
                    break;
                default:
                    break;
            }

            this.dgvEstadistica.DataSource = registros;

        }
    }
}
