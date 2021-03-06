﻿using System.Windows.Forms;
using System.Drawing;


namespace GameMap
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

        public int x_offset = -120;
        public int y_offset = -120;  //图片的偏移位置
        public Player()
        {
            bitmap = new Bitmap(@"r1.png");
            bitmap.SetResolution(96, 96);
        }
        /// <summary>
        /// 角色移动的方法
        /// </summary>
        /// <param name="players"></param>
        /// <param name="e"></param>
        public static void Key_controller(Player[] players,Map[] maps,KeyEventArgs e)
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
            if (e.KeyCode == Keys.W&& Map.Is_through(maps, player.x, player.y - player.speed))
            {
                player.y = player.y - player.speed;
            }else if(e.KeyCode == Keys.S && Map.Is_through(maps, player.x, player.y +player.speed))
            {
                player.y = player.y + player.speed;
            }
            else if (e.KeyCode == Keys.A && Map.Is_through(maps, player.x-player.speed, player.y))
            {
                player.x = player.x - player.speed;
            }
            else if (e.KeyCode == Keys.D && Map.Is_through(maps, player.x + player.speed, player.y))
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
        /*public static void Draw(Player[] players,Graphics graphics1)
        {
            Player player = players[current_player];
            Rectangle rectangle = new Rectangle(player.bitmap.Width / 4 * (player.anm_frame % 4), player.bitmap.Height / 4 * (player.face - 1), player.bitmap.Width / 4, player.bitmap.Height / 4);  //自定义区间
            Bitmap bitmap0 = player.bitmap.Clone(rectangle, player.bitmap.PixelFormat);//复制小图
            graphics1.DrawImage(bitmap0, player.x, player.y);
        }*/

        public static void Draw(Player[] players, Graphics graphics1,int map_sx,int map_sy)
        {
            Player player = players[current_player];
            Rectangle rectangle = new Rectangle(
                                player.bitmap.Width / 4 * (player.anm_frame % 4),
                                player.bitmap.Height / 4 * (player.face - 1),
                                player.bitmap.Width / 4, 
                                player.bitmap.Height / 4);  //自定义区间
            Bitmap bitmap0 = player.bitmap.Clone(rectangle, player.bitmap.PixelFormat);//复制小图
            graphics1.DrawImage(bitmap0, map_sx+player.x+player.x_offset, map_sy+player.y+player.y_offset);
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

        /// <summary>
        /// 设置玩家的位置
        /// </summary>
        /// <param name="players"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="face"></param>
        public static void Set_position(Player[] players,int x,int y,int face)
        {
            players[current_player].x = x;
            players[current_player].y = y;
            players[current_player].face = face;
        }

        /// <summary>
        /// 得到人物的位置信息
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        public static int get_pos_x(Player[] players)
        {
            return players[current_player].x;
        }
        public static int get_pos_y(Player[] players)
        {
            return players[current_player].y;
        }
        public static int get_pos_f(Player[] players)
        {
            return players[current_player].face;
        }
    }
}
