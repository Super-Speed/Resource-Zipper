using System;
using System.IO;
using Ionic.Zip;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Model_Resource_Zipper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string rich = richTextBox1.Text;
            string zipfile = textBox1.Text + ".zip";
            FolderBrowserDialog fold = new FolderBrowserDialog();
            fold.ShowDialog();

            using (var zip = new Ionic.Zip.ZipFile())
            {
                if (richTextBox1.TextLength > 0)
                {
                    richTextBox1.SaveFile(fold.SelectedPath + @"\Readme.txt", RichTextBoxStreamType.PlainText);
                }

                zip.AddDirectory(fold.SelectedPath,textBox1.Text);
                
                zip.Save(zipfile);

                MessageBox.Show("Done!");
                File.Copy(zipfile, @"Ready-for-Upload\" + zipfile, true);
                File.Delete(zipfile);
            }
        }
    }
}
