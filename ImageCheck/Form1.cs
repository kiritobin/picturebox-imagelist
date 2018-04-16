using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ImageCheck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int index;
        private void button1_Click(object sender, EventArgs e)
        {
            index--;
            if (index<0)
            {
                MessageBox.Show("去往最后一张图片");
                index = imageList1.Images.Count - 1;
            }
            this.pictureBox1.Image = this.imageList1.Images[index];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            index++;
            if (index>imageList1.Images.Count-1)
            {
                MessageBox.Show("回到第一张图片");
                index = 0;
            }
            this.pictureBox1.Image = this.imageList1.Images[index];
        }

        private void LoadImage()
        {
            string rootPath = Application.StartupPath;
            string filePath = rootPath + @"\image";
            DirectoryInfo rootDir = new DirectoryInfo(filePath);
            FileInfo[] file = rootDir.GetFiles();
            for (int i=0;i<=file.Length-1;i++)
            {
                Image img = Image.FromFile(file[i].FullName);
                this.imageList1.Images.Add(img);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadImage();
            this.pictureBox1.Image = this.imageList1.Images[index];
        }
    }
}
