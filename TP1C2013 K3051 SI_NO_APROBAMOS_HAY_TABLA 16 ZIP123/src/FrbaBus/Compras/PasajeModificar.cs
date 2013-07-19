using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Compras
{
    public partial class PasajeModificar : Form
    {
        private Pasaje _pasaje;
        private Viaje _viaje;

        public PasajeModificar(Pasaje p, Viaje v)
        {
            _viaje = v;
            _pasaje = p;
            InitializeComponent();
        }
    }
}
