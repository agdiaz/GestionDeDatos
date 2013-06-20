using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Common.Excepciones;

namespace FrbaBus.Common.Helpers
{
    public static class MensajePorPantalla
    {
        public static DialogResult MensajeInformativo( IWin32Window formulario, string mensaje)
        {
            return MessageBox.Show(formulario, mensaje, "FrbaBus - Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult MensajeError(IWin32Window formulario, string mensaje)
        {
            return MessageBox.Show(formulario, mensaje, "FrbaBus - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult MensajeExceptionBD(IWin32Window formulario, AccesoBDException ex)
        {
            return MessageBox.Show(formulario, ex.Message, "FrbaBus - Problemas con la Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
