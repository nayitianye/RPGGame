using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterTroops
{
    public partial class Form1 : Form
    {
        private Player[] player = new Player[3];
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Player.Key_controller(player,e);
            Draw();
        }

   

        private void Draw()
        {
            Bitmap bitmap = new Bitmap(@"r1.png");
            bitmap.SetResolution(96, 96);
            //创建在PictureBox1上的图像graphics
            Graphics graphics = stage.CreateGraphics();
            //将图像画在内存上，并使graphics为pictureBox1上的图像
            BufferedGraphicsContext graphicsContext = BufferedGraphicsManager.Current;
            BufferedGraphics bufferedGraphics = graphicsContext.Allocate(graphics, this.DisplayRectangle);
            Graphics graphics1 = bufferedGraphics.Graphics;
            //自定义的绘图
            Player.Draw(player, graphics1);
            //显示图像并释放缓存
            bufferedGraphics.Render();
            bufferedGraphics.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player[0] = new Player();
            player[0].bitmap = new Bitmap(@"r1.png");
            player[0].bitmap.SetResolution(96, 96);
            player[0].is_active = 1;

            player[1] = new Player();
            player[1].bitmap = new Bitmap(@"r2.png");
            player[1].bitmap.SetResolution(96, 96);
            player[1].is_active =1;

            player[2] = new Player();
            player[2].bitmap = new Bitmap(@"r3.png");
            player[2].bitmap.SetResolution(96, 96);
            player[2].is_active = 1;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Player.Key_ctrl_up(player, e);
            Draw();
        }
    }
}
