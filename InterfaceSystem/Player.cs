using System.Windows.Forms;
using System.Drawing;


namespace InterfaceSystem
{
    public class Player
    {
        //当前角色
        public static int current_player = 0;
        
        public int x = 0;   
        public int y = 0;     //人物的初始位置
        public int face = 1;  //人物的朝向
        public int animation_ctrl = 0;  //控制动画的帧
        public int anm_frame = 0;
        public long last_walk_time = 0;
        public long walk_interval = 80;
        public int speed =40;

        public int x_offset = -120;
        public int y_offset = -220;  //图片的偏移位置
        //图像
        public Bitmap bitmap;
        //角色是否激活
        public int is_active = 0;  
        //碰撞(角色)
        public int collision_ray = 80;
        public enum Status
        {
            WALK=1,
            PANEL=2,
            TASK=3,
            FIGHT=4,
        }
        public static Status status = Status.WALK;
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
        public static void Key_controller(Player[] players,Map[] maps,Npc[] npcs,KeyEventArgs e)
        {
            if (Player.status != Status.WALK)
            {
                return;
            }
            Player player = players[current_player];
            //切换角色
            if (e.KeyCode == Keys.Tab)
            {
                Key_change_player(players);
            }
             
            //行走
            if (e.KeyCode == Keys.W)
            {
                Walk(players,maps,Comm.Direction.UP);
            }else if(e.KeyCode == Keys.S)
            {
                Walk(players, maps, Comm.Direction.DOWN);
            }
            else if (e.KeyCode == Keys.A)
            {
                Walk(players, maps, Comm.Direction.LEFT);
            }
            else if (e.KeyCode == Keys.D)
            {
                Walk(players, maps, Comm.Direction.RIGHT);
            }
            //动画帧
            Npc_collision(players, maps, npcs, e);
        }
        /// <summary>
        /// 角色行走的函数
        /// </summary>
        /// <param name="players"></param>
        /// <param name="maps"></param>
        /// <param name="direction"></param>
        public static void Walk(Player[] players,Map[] maps,Comm.Direction direction)
        {
            Player player = players[current_player];
            //转向
            player.face = (int)direction;
            //间隔判定
            if (Comm.Time() - player.last_walk_time <= player.walk_interval)
            {
                return;
            }
            //行走
            //up
            if (direction == Comm.Direction.UP&&Map.Is_through(maps,player.x,player.y-player.speed))
            {
                player.y = player.y - player.speed;
            }
            //down
            if (direction == Comm.Direction.DOWN && Map.Is_through(maps, player.x, player.y + player.speed))
            {
                player.y = player.y + player.speed;
            }
            //right
            if (direction == Comm.Direction.LEFT && Map.Is_through(maps, player.x-player.speed, player.y ))
            {
                player.x = player.x - player.speed;
            }
            //left
            if (direction == Comm.Direction.RIGHT && Map.Is_through(maps, player.x+player.speed, player.y ))
            {
                player.x = player.x + player.speed;
            }
            //动画帧
            player.anm_frame = player.anm_frame + 1;
            if (player.anm_frame >= int.MaxValue)
            {
                player.anm_frame = 0;
            }
            //时间
            player.last_walk_time = Comm.Time();
        }

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

        public static Point Get_collision_point(Player[] players)
        {
            Player player = players[current_player];
            int collision_x = 0;
            int collision_y = 0;

            if (player.face == (int)Comm.Direction.UP)
            {
                collision_x = player.x;
                collision_y = player.y - player.collision_ray;
            }
            if (player.face == (int)Comm.Direction.DOWN)
            {
                collision_x = player.x;
                collision_y = player.y + player.collision_ray;
            }
            if (player.face == (int)Comm.Direction.LEFT)
            {
                collision_x = player.x - player.collision_ray;
                collision_y = player.y;
            }
            if (player.face == (int)Comm.Direction.RIGHT)
            {
                collision_x = player.x + player.collision_ray;
                collision_y = player.y;
            }
            return new Point(collision_x, collision_y);
        }
       /// <summary>
       /// Npc碰撞函数
       /// </summary>
       /// <param name="players"></param>
       /// <param name="maps"></param>
       /// <param name="npcs"></param>
       /// <param name="e"></param>
        public static void Npc_collision(Player[] players,Map[] maps,Npc[] npcs,KeyEventArgs e)
        {
            Player player = players[current_player];
            Point p1 = new Point(player.x, player.y);
            Point p2 = Get_collision_point(players);//碰撞射线的端点

            for(int i = 0; i < npcs.Length; i++)
            {
                if (npcs[i] == null)
                {
                    continue;
                }
                if (npcs[i].map != Map.current_map) //遍历NPC
                {
                    continue;
                }

                if (npcs[i].Is_line_collision(p1, p2))  //发生碰撞
                {
                    if (npcs[i].collosion_type == Npc.Collosion_type.ENTER)   //碰撞触发
                    {
                        Task.Story(i);      //发生事件
                        break;
                    }
                    else if (npcs[i].collosion_type== Npc.Collosion_type.KEY)  //按键触发
                    {
                        if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
                        {
                            Task.Story(i);  //发生事件
                            break;
                        }
                    }
                }
            }
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
        /// <summary>
        ///设置角色的位置
        /// </summary>
        /// <param name="players"></param>
        /// <param name="oldindex"></param>
        /// <param name="newindex"></param>
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
        public static int Get_pos_x(Player[] players)
        {
            return players[current_player].x;
        }
        public static int Get_pos_y(Player[] players)
        {
            return players[current_player].y;
        }
        public static int Get_pos_f(Player[] players)
        {
            return players[current_player].face;
        }
    }
}
