﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Generar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] txtFiles;
            txtFiles = Directory.GetFiles(textBox1.Text, "*.sql").OrderBy(t=> t.ToString()).ToArray();
            using (StreamWriter writer = new StreamWriter(textBox1.Text + @"\ZZ_PROCEDURES.sql", false))
            {
                for (int i = 0; i < txtFiles.Length; i++)
                {
                    using (StreamReader reader = File.OpenText(txtFiles[i]))
                    {
                        
                        writer.WriteLine("PRINT 'Inicio de sp: " + txtFiles[i] + "'");
                        writer.WriteLine("GO ");
                        writer.WriteLine(reader.ReadToEnd());
                        writer.WriteLine("");
                        writer.WriteLine("PRINT 'Fin de sp: " + txtFiles[i]+ "'");
                        writer.WriteLine("");
                    }
                }
            }
            MessageBox.Show("Se procesaron " + txtFiles.Length + "archivos correctamente");
        }
    }
}
