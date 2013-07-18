using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Manager;

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
    }
}
