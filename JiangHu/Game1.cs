using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewRivakes
{
    public partial class Game1 : Form
    {
        public string button;
        public Game1()
        {
            InitializeComponent();
        }

        private void Game1_Load(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(@"protagonist/ren1.jpg");
            bitmap.SetResolution(96, 96);
            pictureBox1.Image = bitmap;
            Bitmap bitmap1= new Bitmap(@"protagonist/wen1.jpg");
            bitmap.SetResolution(96, 96);
            pictureBox2.Image = bitmap1;
            button1.BackColor = Color.Blue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Bitmap bitmap = new Bitmap(@"protagonist/ren1.jpg");
            bitmap.SetResolution(96, 96);
            pictureBox1.Image = bitmap;
            Bitmap bitmap1 = new Bitmap(@"protagonist/wen1.jpg");
            bitmap.SetResolution(96, 96);
            pictureBox2.Image = bitmap1;
            button1.BackColor = Color.Blue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Bitmap bitmap = new Bitmap(@"protagonist/ren2.jpg");
            bitmap.SetResolution(96, 96);
            pictureBox1.Image = bitmap;
            Bitmap bitmap1 = new Bitmap(@"protagonist/wen1.jpg");
            bitmap.SetResolution(96, 96);
            pictureBox2.Image = bitmap1;
            button2.BackColor = Color.Blue;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Bitmap bitmap = new Bitmap(@"protagonist/ren3.jpg");
            bitmap.SetResolution(96, 96);
            pictureBox1.Image = bitmap;
            Bitmap bitmap1 = new Bitmap(@"protagonist/wen2.jpg");
            bitmap.SetResolution(96, 96);
            pictureBox2.Image = bitmap1;
            button3.BackColor = Color.Blue;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Bitmap bitmap = new Bitmap(@"protagonist/ren4.jpg");
            bitmap.SetResolution(96, 96);
            pictureBox1.Image = bitmap;
            Bitmap bitmap1 = new Bitmap(@"protagonist/wen2.jpg");
            bitmap.SetResolution(96, 96);
            pictureBox2.Image = bitmap1;
            button4.BackColor = Color.Blue;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Bitmap bitmap = new Bitmap(@"protagonist/ren5.jpg");
            bitmap.SetResolution(96, 96);
            pictureBox1.Image = bitmap;
            Bitmap bitmap1 = new Bitmap(@"protagonist/wen3.jpg");
            bitmap.SetResolution(96, 96);
            pictureBox2.Image = bitmap1;
            button5.BackColor = Color.Blue;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Bitmap bitmap = new Bitmap(@"protagonist/ren6.jpg");
            bitmap.SetResolution(96, 96);
            pictureBox1.Image = bitmap;
            Bitmap bitmap1 = new Bitmap(@"protagonist/wen3.jpg");
            bitmap.SetResolution(96, 96);
            pictureBox2.Image = bitmap1;
            button6.BackColor = Color.Blue;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Bitmap bitmap = new Bitmap(@"protagonist/ren7.jpg");
            bitmap.SetResolution(96, 96);
            pictureBox1.Image = bitmap;
            Bitmap bitmap1 = new Bitmap(@"protagonist/wen4.jpg");
            bitmap.SetResolution(96, 96);
            pictureBox2.Image = bitmap1;
            button7.BackColor = Color.Blue;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Bitmap bitmap = new Bitmap(@"protagonist/ren8.jpg");
            bitmap.SetResolution(96, 96);
            pictureBox1.Image = bitmap;
            Bitmap bitmap1 = new Bitmap(@"protagonist/wen4.jpg");
            bitmap.SetResolution(96, 96);
            pictureBox2.Image = bitmap1;
            button8.BackColor = Color.Blue;
        }
    }
}
