using System.Drawing;
using System.Windows.Forms;

namespace InterfaceSystem
{
    public class Title
    {
        public static Panel title = new Panel();
        public static Panel confirm = new Panel();//确认面板
        //Panel对象类，作为标题画面的主界面
        public static string title_music = "2.mp3";

        public static Bitmap bg_1 = new Bitmap("T_bg1.png");
        public static Bitmap bg_2 = new Bitmap("T_bg2.png");
        public static Bitmap bg_3 = new Bitmap("T_bg3.png");
        public static Bitmap bg_font = new Bitmap("T_logo.png");

        public static long last_change_bg_time = 0;  //上一次切换的时间
        public static int bg_now = 2;   //当前显示的图片
        //标题画面的背景音乐
        //主界面初始化
        public static void Init()
        {
            //变量设置分辨率
            bg_1.SetResolution(96, 96);
            bg_2.SetResolution(96, 96);
            bg_3.SetResolution(96, 96);
            bg_font.SetResolution(96, 96);
            //开始游戏
            Button button_start= new Button();
            button_start.Set(325, 350, 0, 0, "T_start_1.png", "T_start_2.png", "T_start_2.png", 2, 1, -1, -1);
            button_start.click_event += new Button.Click_event(Newgame);
            //读取进度
            Button button_load = new Button();
            button_load.Set(325, 400, 0, 0, "T_load_1.png", "T_load_2.png", "T_load_2.png", 0, 2, -1, -1);
            button_load.click_event += new Button.Click_event(Loadgame);
            //退出游戏
            Button button_exit = new Button();
            button_exit.Set(325, 450, 0, 0, "T_exit_1.png", "T_exit_2.png", "T_exit_2.png", 1, 0, -1, -1);
            button_exit.click_event += new Button.Click_event(Exitgame);

            title.button = new Button[3];
            title.button[0] = button_start;
            title.button[1] = button_load;
            title.button[2] = button_exit;
            title.Set(0, 0, "T_bg1.png", 0, -1); //设置背景图
            title.draw_event += new Panel.Draw_event(Drawtitle);
            title.Init();

            //退出游戏询问框
            //确认
            Button btn_yes = new Button();
            btn_yes.Set(42, 60, 0, 0, "confirm_yes_1.png", "confirm_yes_2.png", "confirm_yes_2.png", -1, 1, -1, -1);
            btn_yes.click_event += new Button.Click_event(Confirm_yes);
            //取消
            Button btn_no = new Button();
            btn_no.Set(42, 100, 0, 0, "confirm_no_1.png", "confirm_no_2.png", "confirm_no_2.png", 0, -1, -1, -1);
            btn_no.click_event += new Button.Click_event(Confirm_no);

            confirm.button = new Button[2];
            confirm.button[0] = btn_yes;
            confirm.button[1] = btn_no;
            confirm.Set(283, 250, "confirm_bg.png", 0, -1);
            confirm.drawbg_event += new Panel.Drawbg_event(Drawconfirm);
            confirm.Init();
        }

        //用来显示title面板以及设置背景音乐
        public static void Show()
        {
            Form1.music_player.URL = title_music;
            title.Show();
        }

        public static void Newgame()
        {
            Map.Change_map(Form1.maps, Form1.players, Form1.npcs, 0, 800, 400, 1, Form1.music_player);
            title.Hide();
        }

        public static void Loadgame()
        {
            MessageBox.Show("Load Game");
        }

        public static void Exitgame()
        {
            confirm.Show();
        }

        //退出游戏
        public static void Confirm_yes()
        {
            Application.Exit();
        }
        //返回游戏首页，显示标题画面
        public static void Confirm_no()
        {
            title.Show();
        }

        //显示界面的背景随时间变化的事件委托
        public static void Drawtitle(Graphics graphics,int x_offset,int y_offset)
        {
            //绘制背景
            if (bg_now == 0)
            {
                graphics.DrawImage(bg_1, 0, 0);
            }else if (bg_now == 1)
            {
                graphics.DrawImage(bg_2, 0, 0);
            }else if (bg_now == 2)
            {
                graphics.DrawImage(bg_3, 0, 0);
            }
            if (Comm.Time() - last_change_bg_time > 5000)
            {
                bg_now = bg_now + 1;
                if (bg_now > 2)
                {
                    bg_now = 0;
                }
                last_change_bg_time = Comm.Time();
            }
        }
        public static void Drawconfirm(Graphics graphics, int x_offset, int y_offset)
        {
            title.Draw_me(graphics);
        }
    }
}
