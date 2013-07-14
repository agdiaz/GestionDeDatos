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
            Semestre s = this.comboBox1.SelectedItem as Semestre;

            switch (this.cbListado.SelectedIndex)
            {
                case 0:
                    {
                        IList<DestinoMasVendido> registros = this._manager.DestinosMasVendidos(s);
                        this.dgvEstadistica.DataSource = registros;
                        break;
                    }
                case 1:
                    {
                        IList<DestinoConMasMicrosVacios> registros = this._manager.DestinosConMasMicrosVacios(s);
                        this.dgvEstadistica.DataSource = registros;
                        break;
                    }
                case 2:
                    {
                        IList<ClienteConMasPuntos> registros = this._manager.ClientesConMasPuntos(s);
                        this.dgvEstadistica.DataSource = registros;
                        break;
                    }
                case 3:
                    {
                        IList<DestinoMasCancelado> registros = this._manager.DestinosMasCancelados(s);
                        this.dgvEstadistica.DataSource = registros;
                        break;
                    }
                case 4:
                    {
                        IList<MicroConMasDiasFueraDeServicio> registros = this._manager.MicrosConMasDiasFueraDeServicio(s);
                        this.dgvEstadistica.DataSource = registros;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
