using System;
using System.Drawing;
using System.Windows.Forms;

namespace FightSystem
{
    public partial class Form1 : Form
    {
        public static WMPLib.WindowsMediaPlayer music_player = new WMPLib.WindowsMediaPlayer();
        public static Player[] players = new Player[3];
        public static Map[] maps = new Map[2];
        public static Npc[] npcs = new Npc[7];

        public Bitmap mc_nomal;  //普通状态的光标
        public Bitmap mc_event;  //事件状态下的光标
        public int mc_mod = 0;//0-nomal 1-event
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
           
            if (Fight.fighting == 0)
                Map.Draw(maps, players, npcs, graphics1, new Rectangle(0, 0, stage.Width, stage.Height));
            else
                Fight.Draw(graphics1);
            //显示图像并释放缓存
            if (Panel.panel != null)
            {
                Panel.Draw(graphics1);
            }
            Draw_mouse(graphics1);
            bufferedGraphics.Render();
            bufferedGraphics.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //光标
            mc_nomal = new Bitmap(@"mc_1.png");
            mc_nomal.SetResolution(96, 96);
            mc_event = new Bitmap(@"mc_2.png");
            mc_event.SetResolution(96, 96);
            Define.define(players, npcs, maps);
            Map.Change_map(maps, players, npcs, 1, 800, 400, 1, music_player);
            Message.Init();
            Title.Init();
            Title.Show();
            Shop.Init();
            //Fight.Init();
            Fight.Start(new int[] { 0, 0, -1 }, "fight/f_scene.png", 1, 0, 1, 1, 100);
            StatusMenu.Init();
        }

        public void Draw_mouse(Graphics graphics)
        {
            Point showpoint = stage.PointToClient(Cursor.Position);
            if (mc_mod == 0)
            {
                graphics.DrawImage(mc_nomal, showpoint.X, showpoint.Y);
            }
            else
            {
                graphics.DrawImage(mc_event, showpoint.X, showpoint.Y);
            }
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
            Player.Time_logic(players, maps);
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

        private void stage_MouseClick(object sender, MouseEventArgs e)
        {
            Npc.Mouse_click(maps, players, npcs, new Rectangle(0, 0, stage.Width, stage.Height), e);
            Player.Mouse_click(maps, players, new Rectangle(0, 0, stage.Width, stage.Height), e);
            if (Panel.panel != null)
            {
                Panel.Mouse_click(e);
            }
        }

        private void stage_MouseMove(object sender, MouseEventArgs e)
        {
            if (Panel.panel != null)
            {
                Panel.Mouse_move(e);
            }
            mc_mod = Npc.Check_mouse_collision(maps, players, npcs, new Rectangle(0, 0, stage.Width, stage.Height), e);
        }

        private void stage_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Hide();
        }

        private void stage_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Show();
        }
    }
}
