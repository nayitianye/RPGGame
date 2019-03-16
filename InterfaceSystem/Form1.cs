using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfaceSystem
{
    public partial class Form1 : Form
    {
        public static WMPLib.WindowsMediaPlayer music_player = new WMPLib.WindowsMediaPlayer();
        public static Player[] players = new Player[3];
        public static Map[] maps = new Map[2];
        public static Npc[] npcs = new Npc[6];
        public Form1()
        {
            InitializeComponent();
        }

        private void Draw()
        {

            //创建在PictureBox1上的图像graphics
            Graphics graphics = stage.CreateGraphics();
            //将图像画在内存上，并使graphics为pictureBox1上的图像
            BufferedGraphicsContext graphicsContext = BufferedGraphicsManager.Current;
            BufferedGraphics bufferedGraphics = graphicsContext.Allocate(graphics, this.DisplayRectangle);
            Graphics graphics1 = bufferedGraphics.Graphics;
            //自定义的绘图
            Map.Draw(maps, players, npcs, graphics1, new Rectangle(0, 0, stage.Width, stage.Height));
            //显示图像并释放缓存
            if (Panel.panel != null)
            {
                Panel.Draw(graphics1);
            }
            bufferedGraphics.Render();
            bufferedGraphics.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //player define
            players[0] = new Player();
            players[0].bitmap = new Bitmap(@"r1.png");
            players[0].bitmap.SetResolution(96, 96);
            players[0].is_active = 1;

            players[1] = new Player();
            players[1].bitmap = new Bitmap(@"r2.png");
            players[1].bitmap.SetResolution(96, 96);
            players[1].is_active = 1;

            players[2] = new Player();
            players[2].bitmap = new Bitmap(@"r3.png");
            players[2].bitmap.SetResolution(96, 96);
            players[2].is_active = 1;

            //map define
            maps[0] = new Map();
            maps[0].bitmap_path = "map1.png";
            maps[0].shade_path = "map1_shade.png";
            maps[0].block_path = "map1_block.png";
            maps[0].back_path = "map1_back.png";
            maps[0].music_path = "1.mp3";
            maps[1] = new Map();
            maps[1].bitmap_path = "map2.png";
            maps[1].shade_path = "map2_shade.png";
            maps[1].block_path = "map2_block.png";
            maps[1].music_path = "2.mp3";

            //npc define
            npcs[0] = new Npc();
            npcs[0].map = 0;
            npcs[0].x = 800;
            npcs[0].y = 300;
            npcs[0].bitmap_path = "npc1.png";

            npcs[1] = new Npc();
            npcs[1].map = 0;
            npcs[1].x = 700;
            npcs[1].y = 350;
            npcs[1].bitmap_path = "npc2.png";

            npcs[2] = new Npc();
            npcs[2].map = 0;
            npcs[2].x = 20;
            npcs[2].y = 600;
            npcs[2].region_x = 40;
            npcs[2].region_y = 400;
            npcs[2].collosion_type = Npc.Collosion_type.ENTER;

            npcs[3] = new Npc();
            npcs[3].map = 1;
            npcs[3].x = 980;
            npcs[3].y = 600;
            npcs[3].region_x = 40;
            npcs[3].region_y = 400;
            npcs[3].collosion_type = Npc.Collosion_type.ENTER;

            npcs[4] = new Npc();
            npcs[4].map = 1;
            npcs[4].x = 700;
            npcs[4].y = 350;
            npcs[4].bitmap_path = "npc3.png";
            npcs[4].collosion_type = Npc.Collosion_type.KEY;
            Animation npc4anm1 = new Animation();
            npc4anm1.bitmap_path = "Anm1.png";
            npc4anm1.row = 2;
            npc4anm1.col = 2;
            npc4anm1.max_frame = 3;
            npc4anm1.anm_rate = 4;
            npcs[4].animations = new Animation[1];
            npcs[4].animations[0] = npc4anm1;

            npcs[5] = new Npc();
            npcs[5].map = 1;
            npcs[5].x = 400;
            npcs[5].y = 350;
            npcs[5].bitmap_path = "npc4.png";
            npcs[5].collosion_type = Npc.Collosion_type.KEY;
            npcs[5].npc_type = Npc.Npc_type.CHARACTER;
            npcs[5].idle_walk_direction = Comm.Direction.LEFT;
            npcs[5].idle_walk_time = 20;

            Map.Change_map(maps, players, npcs, 1, 800, 400, 1, music_player);
            Message.Init();
            Title.Init();
            Title.Show();
           
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Player.Key_controller(players, maps, npcs, e);
            if (Panel.panel != null)
            {
                Panel.Key_ctrl(e);
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Player.Key_ctrl_up(players, e);
        }

        //测谁按键
        public void Tryevent()
        {
            MessageBox.Show("成功");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < npcs.Length; i++)  //遍历当前场景的NPC
            {
                if (npcs[i] == null)
                {
                    continue;
                }
                if (npcs[i].map != Map.current_map)
                {
                    continue;
                }
                npcs[i].Time_logic(maps);
            }
            Draw();
        }

    }
}
