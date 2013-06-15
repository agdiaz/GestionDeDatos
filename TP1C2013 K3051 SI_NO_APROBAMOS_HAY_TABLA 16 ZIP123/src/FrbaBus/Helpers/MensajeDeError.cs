using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Helpers
{
    public static class MensajeDeError
    {
        public static void MostrarError(Control c)
        {
            MessageBox.Show("validación errónea " + c.Text, "Error" , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
