using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            roundedPanel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
        private void exiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           System.Windows.Forms.Application.Exit();
        }
        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chose();
        }
        private void oneImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.SelectionMode = SelectionMode.None;
            listBox1.SelectionMode = SelectionMode.One;
        }
        private void multiyImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.SelectionMode = SelectionMode.None;
            listBox1.SelectionMode = SelectionMode.MultiSimple;
        }
        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            roundedPanel1.Controls.Clear();
            counter = 0;
            timer1.Interval = 100;
            timer1.Start();
        }

        private void chose()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"E:\";
            openFileDialog1.Title = "Files";
            openFileDialog1.Multiselect = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            openFileDialog1.FilterIndex = 2;
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    listBox1.Items.Add(file);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counter == listBox1.Items.Count)
            {
                roundedPanel1.Controls.Clear();
                counter = 0;
                timer1.Stop();
                return;
            }
            var path = listBox1.Items[counter++].ToString();
            imag.Image = Image.FromFile(path);
            imag.SizeMode = PictureBoxSizeMode.StretchImage;
            roundedPanel1.Controls.Add(imag);
            imag.Dock = DockStyle.Fill;
        }
        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            roundedPanel1.Controls.Clear();
            PictureBox im = new PictureBox();
            if (listBox1.SelectionMode == SelectionMode.One)
            {
                string path = listBox1.GetItemText(listBox1.SelectedItem);
                im.Image = Image.FromFile(path);
                im.SizeMode = PictureBoxSizeMode.StretchImage;
                roundedPanel1.Controls.Add(im);
                im.Dock = DockStyle.Fill;
            }
            else
            {
                int x = 18, y = 20;
                foreach (var path in listBox1.SelectedItems)
                {
                    im = new PictureBox();
                    im.Image = Image.FromFile(path.ToString());
                    im.Location = new Point(x, y);
                    im.Size = new Size(140, 100);
                    im.SizeMode = PictureBoxSizeMode.StretchImage;
                    roundedPanel1.Controls.Add(im);
                    x += 155;
                    if (x + 300 >= 881)
                    {
                        x = 18;
                        y += 120;
                    }
                }
            }
        }
        PictureBox imag = new PictureBox();
        int counter = 0;
    }
}