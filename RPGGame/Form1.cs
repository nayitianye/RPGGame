using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGGame
{
    public partial class Form1 : Form
    {
        private int x = 50, y = 50;  //人物的初始位置
        private int face = 1;  //人物的朝向
        private int animation_ctrl = 0;  //控制动画的帧
        public Form1()
        {
            InitializeComponent();
        }
 
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                y = y -5;
                //Console.WriteLine("x="+x+"y="+y);
                face = 4;
            }
            if (e.KeyCode == Keys.S)
            {
                y = y +5;
                face = 1;
            }
            if (e.KeyCode == Keys.A)
            {
                x = x - 5;
                face = 2;
            }
            if (e.KeyCode == Keys.D)
            {
                x = x + 5;
                face = 3;
            }
            Draw();
        }
        private void Draw()
        {
            Bitmap bitmap = new Bitmap(@"r1.png");
            bitmap.SetResolution(96, 96);
            //创建在PictureBox1上的图像graphics
            Graphics graphics = pictureBox1.CreateGraphics();
            //将图像画在内存上，并使graphics为pictureBox1上的图像
            BufferedGraphicsContext graphicsContext = BufferedGraphicsManager.Current;
            BufferedGraphics bufferedGraphics = graphicsContext.Allocate(graphics, this.DisplayRectangle);
            Graphics graphics1 = bufferedGraphics.Graphics;
            //自定义的绘图
            animation_ctrl += 1;
            Rectangle rectangle = new Rectangle(bitmap.Width/4*(animation_ctrl%4), bitmap.Height / 4 * (face - 1), bitmap.Width / 4, bitmap.Height / 4);  //自定义区间
            Bitmap bitmap0 = bitmap.Clone(rectangle, bitmap.PixelFormat);//复制小图
            graphics1.DrawImage(bitmap0, x, y);
            //显示图像并释放缓存
            bufferedGraphics.Render();
            bufferedGraphics.Dispose();
        }
    }
}
