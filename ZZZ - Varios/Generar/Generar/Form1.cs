using System;
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
            txtFiles = Directory.GetFiles(textBox1.Text, "*.sql");
            using (StreamWriter writer = new StreamWriter(textBox1.Text + @"\demo_puto.sql"))
            {
                for (int i = 0; i < txtFiles.Length; i++)
                {
                    using (StreamReader reader = File.OpenText(txtFiles[i]))
                    {
                        writer.WriteLine("GO ");
                        writer.Write(reader.ReadToEnd());
                        writer.WriteLine("GO ");
                    }
                }
            }
            MessageBox.Show("LISTO GATIENZO");
        }
    }
}
