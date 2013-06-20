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
            string mensaje = ex.Message;
            mensaje += "\nConsulta realizada: " + ex.Consulta;
            mensaje += "\nParametros usados: ";
            foreach (var item in ex.ParametrosUsados)
            {
                mensaje += "\n\tNombre: " + item.Key;
                mensaje += "\tValor: " + item.Value.ToString();
            }

            mensaje += "Mensaje interno del error:\n" + ex.InnerException.Message;

            return MessageBox.Show(formulario, mensaje, "FrbaBus - Problemas con la Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
