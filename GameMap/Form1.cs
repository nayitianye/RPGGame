using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameMap
{
    public partial class Form1 : Form
    {
        Player[] player = new Player[3];
        Map[] maps = new Map[2];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Player.Key_controller(player,maps, e);
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
            Map.Draw(maps,player,graphics1,new Rectangle(0,0,stage.Width,stage.Height));
            //显示图像并释放缓存
            bufferedGraphics.Render();
            bufferedGraphics.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //player define
            player[0] = new Player();
            player[0].bitmap = new Bitmap(@"r1.png");
            player[0].bitmap.SetResolution(96, 96);
            player[0].is_active = 1;

            player[1] = new Player();
            player[1].bitmap = new Bitmap(@"r2.png");
            player[1].bitmap.SetResolution(96, 96);
            player[1].is_active = 1;

            player[2] = new Player();
            player[2].bitmap = new Bitmap(@"r3.png");
            player[2].bitmap.SetResolution(96, 96);
            player[2].is_active = 1;

            //map define
            maps[0] = new Map();
            maps[0].bitmap_path = "map1.png";
            maps[0].shade_path = "map1_shade.png";
            maps[0].block_path = "map1_block.png";

            maps[1] = new Map();
            maps[1].bitmap_path = "map2.png";
            maps[1].shade_path = "map2_shade.png";
            maps[1].block_path = "map2_block.png";

            Map.change_map(maps, player, 0, 30, 500, 1);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Player.Key_ctrl_up(player, e);
            Draw();
        }


    }
}
