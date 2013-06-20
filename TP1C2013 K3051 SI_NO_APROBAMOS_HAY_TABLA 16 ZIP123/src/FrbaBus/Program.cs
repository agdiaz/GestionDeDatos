using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FrbaBus.Common;
using FrbaBus.Common.Entidades;
using FrbaBus.Manager;
using FrbaBus.Common.Helpers;
using System.IO;

namespace FrbaBus
{
    static class Program
    {
        public static Contexto ContextoActual{ get; set; }
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            try
            {
                ConfigurarUsuarioInicial();
            }
            catch (Exception ex)
            {
                var path = Path.Combine(Application.StartupPath, "fatal_error_" + DateTime.Now.ToString("yyyyMMddhhmmss"));
                
                MessageBox.Show("El programa se cerrará.\nRevise el siguiente path para ver el problema: " + path, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                StreamWriter f = File.CreateText(path);

                f.WriteLine("Error fatal al intentar iniciar la aplicación. Revise la siguiente excepción");
                f.WriteLine(ex.Message);
                f.WriteLine(ex.StackTrace);

                f.Close();

                return;
            }

            LanzarPantallaPrincipal();
        }

        private static void LanzarPantallaPrincipal()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void ConfigurarUsuarioInicial()
        {
            UsuarioManager uManager = new UsuarioManager();
            
            ContextoActual = new Contexto().Limpiar();
            //ContextoActual.RegistrarUsuario(uManager.ObtenerUsuarioGenerico());
        }
    }
}
