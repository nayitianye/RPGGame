using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterTroops
{
    public class Player
    {
        //当前角色
        public static int current_player = 0;
        public int is_active=0;  //角色是否激活
        public int x = 0;   
        public int y = 0;     //人物的初始位置
        public int face = 1;  //人物的朝向
        public int animation_ctrl = 0;  //控制动画的帧
        public Bitmap bitmap;  //图像

        public int anm_frame = 0;
        public long last_walk_time = 0;
        public long walk_interval = 100;
        public int speed = 20;
        public Player()
        {
            bitmap = new Bitmap(@"r1.png");
            bitmap.SetResolution(96, 96);
        }
        public static void Key_controller(Player[] players,KeyEventArgs e)
        {
            Player player = players[current_player];
            //切换角色
            if (e.KeyCode == Keys.Tab)
            {
                Key_change_player(players);
            }
            //切换方向
            if (e.KeyCode == Keys.W&&player.face!=4)
            {
                //player.y = player.y - 5;
                //Console.WriteLine("x="+x+"y="+y);
                player.face = 4;
            }
            if (e.KeyCode == Keys.S && player.face != 1)
            {
                //player.y = player.y + 5;
                player.face = 1;
            }
            if (e.KeyCode == Keys.A && player.face != 2)
            {
                //player.x = player.x - 5;
                player.face = 2;
            }
            if (e.KeyCode == Keys.D && player.face != 3)
            {
                //player.x = player.x + 5;
                player.face = 3;
            }
            if (Comm.Time() - player.last_walk_time <= player.walk_interval)
            {
                return;
            }
            //移动处理
            if (e.KeyCode == Keys.W)
            {
                player.y = player.y - player.speed;
            }else if(e.KeyCode == Keys.S)
            {
                player.y = player.y + player.speed;
            }
            else if (e.KeyCode == Keys.A)
            {
                player.x = player.x - player.speed;
            }
            else if (e.KeyCode == Keys.D)
            {
                player.x = player.x + player.speed;
            }
            //动画帧
            player.anm_frame = player.anm_frame + 1;
            if (player.anm_frame >= int.MaxValue)
            {
                player.anm_frame = 0;
            }
            player.last_walk_time = Comm.Time();
        }
        public static void Draw(Player[] players,Graphics graphics1)
        {
            Player player = players[current_player];
            Rectangle rectangle = new Rectangle(player.bitmap.Width / 4 * (player.anm_frame % 4), player.bitmap.Height / 4 * (player.face - 1), player.bitmap.Width / 4, player.bitmap.Height / 4);  //自定义区间
            Bitmap bitmap0 = player.bitmap.Clone(rectangle, player.bitmap.PixelFormat);//复制小图
            graphics1.DrawImage(bitmap0, player.x, player.y);
        }

        /// <summary>
        /// 切换角色
        /// </summary>
        /// <param name="players"></param>
        public static void Key_change_player(Player[] players)
        {
            for (int i = current_player + 1; i < players.Length; i++)
            {
                if (players[i].is_active == 1)
                {
                    Set_player(players, current_player, i);
                    return;
                }
            }
            for (int i=0; i < current_player; i++)
            {
                if (players[i].is_active == 1)
                {
                    Set_player(players, current_player, i);
                    return;
                }
            }
        }

        public static void  Set_player(Player[] players,int oldindex,int newindex)
        {
            current_player = newindex;
            players[newindex].x = players[oldindex].x;
            players[newindex].y = players[oldindex].y;
            players[newindex].face = players[oldindex].face;
        }

        public static void Key_ctrl_up(Player[] players,KeyEventArgs e)
        {
            Player player = players[current_player];
            //动画帧
            player.anm_frame = 0;
            player.last_walk_time = 0;
        }
    }
}
