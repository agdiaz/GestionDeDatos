using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FrbaBus.Common;
using FrbaBus.Common.Entidades;

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
            ConfigurarUsuarioInicial();
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
            ContextoActual = new Contexto();
        }
    }
}
