using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace foldername
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var appd = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Directory.CreateDirectory(appd + "/foldersname/tempfiles/in/");
            using (StreamWriter writer = new StreamWriter(appd + "/foldersname/tempfiles/in/file.bat"))
            {

                foreach (string i in Directory.GetDirectories(folderBrowserDialog1.SelectedPath))
                {
                    var ti = i.Replace(folderBrowserDialog1.SelectedPath, "");
                    var ri = ti.Split(']')[1];
                    Console.WriteLine(ri);
                    if (ri == "string")
                    {

                        writer.WriteLine(System.IO.File.ReadAllText(i + "/string.txt"));

                    }
                    else
                    {
                        writer.WriteLine(ri);
                    }
                }
                writer.WriteLine("cmd /k");
            }
            System.Diagnostics.Process.Start(appd + "/foldersname/tempfiles/in/file.bat");

        }
    }
}
