using System.Drawing;
using System.Windows.Forms;

namespace NewAdventureGame
{
    //定义面板
    public class Panel
    {
        //全部Panel状态
        public static Panel panel = null;      //静态Penel类型，表明当前激活的是哪个界面，panel=null表示没有界面激活
        private static Player.Status last_player_status = Player.Status.WALK;

        //表示面板的坐标
        public int x;
        public int y;

        //表示面版的背景图和坐标
        public string bitmap_path;
        public Bitmap bitmap;

        //buttonl类数组 指明面板中的所有button
        public Button[] button;
        public int default_button = 0; //默认按钮
        public int cancel_button = -1; 
        public int current_button = 0;

        //用来设置Panel
        public void Set(int x0, int y0, string path,int default_button0, int cancel_button0)
        {
            x = x0;
            y = y0;
            bitmap_path = path;
            default_button = default_button0;
            cancel_button = cancel_button0;
        }

        //载入   设置面板的初始化
        public void Init()
        {
            //背景图
            if (bitmap_path != null && bitmap_path != "")
            {
                bitmap = new Bitmap(bitmap_path);
                bitmap.SetResolution(96, 96);
            }
            //按钮
            if (button != null)
            {
                for (int i = 0; i < button.Length; i++)
                {
                    if (button[i] == null)
                        continue;

                    button[i].Load();
                }
            }
        }
        //面板的显示
        public void Show()
        {
            panel = this;
            current_button = default_button;
            Set_button_status(Button.Status.SELECT);
            if (Player.status != Player.Status.PANEL)
            {
                last_player_status = Player.status;
            }    
            Player.status = Player.Status.PANEL;
        }

        //面板的隐藏
        public void Hide()
        {
            panel = null;
            Player.status = last_player_status;
        }

        //设置button的状态
        public void Set_button_status(Button.Status status)
        {
            if (button != null)
            {
                for (int i = 0; i < button.Length; i++)
                {
                    if (button[i] == null)
                        continue;

                    button[i].status = Button.Status.NOMAL;
                }
                if (button[current_button] != null)
                {
                    button[current_button].status = status;
                }    
            }
        }

        // 绘图  委托的实例
        public delegate void Draw_event(Graphics g, int x_offset, int y_offset);
        public event Draw_event draw_event;
        public delegate void Drawbg_event(Graphics g, int x_offset, int y_offset);
        public event Drawbg_event drawbg_event;

        public static void Draw(Graphics g)
        {
            if (panel != null)
                panel.Draw_me(g);
        }
        //绘图的回调
        public void Draw_me(Graphics g)
        {
            //背景调用D 
            if (drawbg_event != null)
                drawbg_event(g, this.x, this.y);
            //背景图
            if (bitmap != null)
                g.DrawImage(bitmap, x, y);
            //外部调用
            if (draw_event != null)
                draw_event(g, this.x, this.y);
            //按钮
            if (button != null)
            {
                for (int i = 0; i < button.Length; i++)
                {
                    if (button[i] == null)
                    {
                        continue;
                    }
                    button[i].Draw(g, x, y);
                }
            }
        }
     
        //     操控
        public static void Key_ctrl(KeyEventArgs e)
        {
            if (panel != null)
               
                panel.Key_ctrl_me(e);
        }
        public void Key_ctrl_me(KeyEventArgs e)
        {
            if (button == null)
            {
                return;
            }    
            Button btn = button[current_button];
            if (btn == null)
            {
                return;
            }
               
            //方向
            int newindex = -1;
            if (e.KeyCode == Keys.W)
            {
                newindex = btn.key_controller.up;
            }
            else if (e.KeyCode == Keys.S)
            {
                newindex = btn.key_controller.down;
            }
            else if (e.KeyCode == Keys.A)
            {
                newindex = btn.key_controller.left;
            }
            else if (e.KeyCode == Keys.D)
            {
                newindex = btn.key_controller.right;
            }
            //判断目标按钮是否有效
            if (newindex >= 0 && newindex < button.Length
                && button[newindex] != null)
            {
                current_button = newindex;
                Set_button_status(Button.Status.SELECT);
            }
            //按下确定键
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
            {
                //调用按钮的click方法
                Set_button_status(Button.Status.PRESS);
                btn.Click();
            }
            //按下取消键
            else if (e.KeyCode == Keys.Escape)
            {
                //调用按钮的click方法
                if (cancel_button >= 0 && cancel_button < button.Length)
                {
                    button[cancel_button].Click();
                }       
            }
        }
        //鼠标的移动事件的处理
        public static void Mouse_move(MouseEventArgs e)
        {
            if(panel!= null)
            {
                panel.Mouse_move_me(e);
            }
        }
        public void Mouse_move_me(MouseEventArgs e)
        {
            if (button != null)
            {
                for(int i = 0; i < button.Length; i++)
                {
                    if (button[i] == null)
                    {
                        continue;
                    }
                    if (button[i].Is_collision(e.X - x, e.Y - y))
                    {
                        current_button = i;
                        Set_button_status(Button.Status.SELECT);
                        break;
                    }
                }
            }
        }
        public static void Mouse_click(MouseEventArgs e)
        {
            if (panel != null)
            {
                panel.Mouse_click_me(e);
            }
        }
        public void Mouse_click_me(MouseEventArgs e)
        {
            //只响应鼠标左键
            if(e.Button!=MouseButtons.Left){
                return;
            }
            //遍历按钮
            if (button != null)
            {
                for (int i = 0; i < button.Length; i++)
                {
                    if (button[i] == null)
                    {
                        continue;
                    }

                    if (button[i].Is_collision(e.X - x, e.Y - y))  //是否发生碰撞
                    {
                        current_button = i;
                        Set_button_status(Button.Status.PRESS);   //按钮按下
                        button[i].Click();   //调用click事件
                        break;
                    }
                }
            }
        }
    }
    //Button 类  用来绘制按钮
    public class Button
    {
        //位置
        public int x = 0;   
        public int y = 0;
        //按钮的位置（相对于面板的位置上）
        public int w = 0;
        public int h = 0;
        //按钮的宽和高

        //图片的途径，表示三种状态
        public string b_nomal_path;    //鼠标没有放到按钮上的状态
        public string b_select_path;   //鼠标放到按钮上但没有点击的状态
        public string b_press_path;    //按钮被鼠标点击的状态

        private Bitmap bitmap_nomal;
        private Bitmap bitmap_select;
        private Bitmap bitmap_press;

        //状态  定义按钮的三种状态，并定义变量表明按钮的当前状态
        public enum Status 
        {
            NOMAL=1,
            SELECT=2,
            PRESS=3,
        }
        public Status status = Status.NOMAL;

        //键盘控制跳转
        public class Key_controller
        {
            public int up = -1;
            public int down = -1;
            public int right = -1;
            public int left = -1;
        }
        //设置按钮的跳转方式
        public Key_controller key_controller = new Key_controller();

        /// <summary>
        ///给Button初始化设置
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="w0"></param>
        /// <param name="h0"></param>
        /// <param name="nomal_path"></param>
        /// <param name="select_path"></param>
        /// <param name="press_path"></param>
        /// <param name="key_up"></param>
        /// <param name="key_down"></param>
        /// <param name="key_left"></param>
        /// <param name="key_right"></param>
        public void Set(int x0, int y0, int w0, int h0,string nomal_path, string select_path, string press_path,int key_up, int key_down, int key_left, int key_right)
        {
            x = x0;
            y = y0;
            b_nomal_path = nomal_path;
            b_select_path = select_path;
            b_press_path = press_path;
            w = w0;
            h = h0;
            key_controller.up = key_up;
            key_controller.down = key_down;
            key_controller.left = key_left;
            key_controller.right = key_right;
        }

        //button的加载
        public void Load()
        {
            //加载
            //普通状态
            if (b_nomal_path != null && b_nomal_path != "")
            {
                bitmap_nomal = new Bitmap(b_nomal_path);
                bitmap_nomal.SetResolution(96, 96);
                //宽和高
                if (w <= 0)
                    w = bitmap_nomal.Width;
                if (h <= 0)
                    h = bitmap_nomal.Height;
            }
            //选择状态
            if (b_select_path != null && b_select_path != "")
            {
                bitmap_select = new Bitmap(b_select_path);
                bitmap_select.SetResolution(96, 96);
            }
            //点击状态
            if (b_press_path != null && b_press_path != "")
            {
                bitmap_press = new Bitmap(b_press_path);
                bitmap_press.SetResolution(96, 96);
            }
        }
        //button绘图方法
        public void Draw(Graphics g, int x_offset, int y_offset)
        {
            //普通状态
            if (status == Status.NOMAL && bitmap_nomal != null)
            {
                g.DrawImage(bitmap_nomal, x_offset + x, y_offset + y);
            }  
            //选择状态
            if (status == Status.SELECT && bitmap_select != null)
            {
                g.DrawImage(bitmap_select, x_offset + x, y_offset + y);
            } 
            //点击状态
            if (status == Status.PRESS && bitmap_press != null)
            {
                g.DrawImage(bitmap_press, x_offset + x, y_offset + y);
            }     
        }
        
        //点击事件事件  委托类型
        public delegate void Click_event();  //定义类型
        public event Click_event click_event; //定义变量
        public void Click()  //调用
        {  
            if (click_event != null)
            {
                click_event();
            }      
        }
        //判断鼠标点击点是否在面板区域以内
        public bool Is_collision(int collision_x,int collision_y)
        {
            Rectangle rectangle = new Rectangle(x, y, w, h);
            return rectangle.Contains(collision_x, collision_y);
        }
    }
}
