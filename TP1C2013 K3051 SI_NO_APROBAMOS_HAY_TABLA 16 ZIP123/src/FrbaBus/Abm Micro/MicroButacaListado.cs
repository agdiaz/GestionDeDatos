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

namespace FrbaBus.Abm_Micro
{
    public partial class MicroButacaListado : Form
    {
        private Micro _micro;
        private ButacaManager _manager;

        public MicroButacaListado()
        {
            _manager = new ButacaManager();
            InitializeComponent();
        }

        public MicroButacaListado(Micro m)
        :this()
        {
            _micro = m;
        }
        private void MicroButacaListado_Load(object sender, EventArgs e)
        {
            MostrarDatosMicro();
            CargarListaTipoButaca();
            CargarButacas();
        }

        private void CargarButacas()
        {
            
        }

        private void CargarListaTipoButaca()
        {
            IList<string> tipos = new List<string>();
            tipos.Add(TipoButaca.Pasillo);
            tipos.Add(TipoButaca.Ventanilla);

            cbTipoButaca.DataSource = tipos;
        }
        private void MostrarDatosMicro()
        {
            if (_micro != null)
            {
                tbMicro.Text = _micro.Informacion;
            }
        }

        
    }
}
