using System.Drawing;
using System.Windows.Forms;

namespace FightSystem
{
    public class Npc
    {
        //NPCD的类型，NOMAL正常的，CHARACTER移动的
        public enum Npc_type
        {
            NOMAL = 0,
            CHARACTER = 1,
        }
        public Npc_type npc_type = Npc_type.NOMAL;
       
        //位置
        public int map = -1;             //地图id
        public int x = 0;                //坐标
        public int y = 0;
        public int x_offset = -120;      //绘图偏移
        public int y_offset = -220;
        
        //显示
        public string bitmap_path = "";  //图片路径
        public Bitmap bitmap;            //图像
        public bool visable = true;             //是否可见
        
        //碰撞区域 （Npc）
        public int region_x = 60;
        public int region_y = 60;
        public enum Collosion_type
        {
            KEY = 1,
            ENTER = 2,
        }
        public Collosion_type collosion_type = Collosion_type.KEY;
        
        //动画相关变量
        public Animation[] animations;   //动画类型的数组，她代表这个NPC所能使用的所有动画
        public int anm_frame = 0;  //当前的播放的帧
        public int current_anm = -1;//当前使用的动画，它对应于anm数组的下标。-1表示没有在播放动画
        public long last_anm_time = 0;//上一帧播放的时间，用于调控播放速率
       
        //人物类（可动的NPC的定义）
        public Comm.Direction face=Comm.Direction.DOWN;   //方向
        public int walk_frame = 0;//行走的帧
        public long last_walk_time = 0;//最后一次行走的时间
        public long walk_interval = 80;//行走的时间间隔
        public int speed = 20;//速度
        public Comm.Direction idle_walk_direction = Comm.Direction.DOWN;//行走方向，分为上下和左右两种徘徊方式
        public int idle_walk_time = 0;//往每个方向行走的帧数，也是控制往每个方向行走的距离
        public int idle_walk_time_new = 0;//当前行走的时间

        //鼠标碰撞区域  NPC的点击事件
        //碰撞区域的中心
        public int mc_offsetx = 0;
        public int mc_offsety = -30;
        //碰撞区域的高和宽
        public int mc_widht = 100;
        public int mc_height=150;
        //表明在什么区域内点击NPC才能生效
        public static int mc_distance_x = 300;
        public static int mc_distance_y = 200;

        //加载动画
        public void Load()
        {
            //加载地图
            if (bitmap_path != "")
            {
                bitmap = new Bitmap(bitmap_path);
                bitmap.SetResolution(96, 96);
            }
            //加载动画
            if (animations != null)
            {
                for(int i = 0; i < animations.Length; i++)
                {
                    animations[i].Load();
                }
            }
            //鼠标碰撞区域
            if (bitmap != null)//有图片
            {
                if (npc_type == Npc.Npc_type.NOMAL)  //默认类型NPC
                {
                    if (mc_widht == 0)
                    {
                        mc_widht = bitmap.Width;
                    }
                    if (mc_height == 0)
                    {
                        mc_height = bitmap.Height;
                    }
                }else if(npc_type==Npc.Npc_type.CHARACTER){//人物类型
                    if (mc_widht == 0)
                    {
                        mc_widht = bitmap.Width/4;
                    }
                    if (mc_height == 0)
                    {
                        mc_height = bitmap.Height/4;
                    }
                }
                else//没有图片
                {
                    if (mc_widht == 0)
                    {
                        mc_widht = region_x;
                    }
                    if (mc_height == 0)
                    {
                        mc_height = region_y;
                    }
                }
            }
        }
        //卸载动画
        public void Unload()
        {
            //卸载地图
            if (bitmap != null)
            {
                bitmap = null;
            }
            //卸载动画
            if (animations != null)
            {
                for (int i = 0; i < animations.Length; i++)
                {
                    animations[i].Unload();
                }
            }
        }
        /// <summary>
        /// 绘图
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="map_sx"></param>
        /// <param name="map_sy"></param>
        public void Draw(Graphics graphics,int map_sx,int map_sy)
        {
            if (visable != true)
            {
                return;
            }
            //绘制角色
            if (current_anm < 0)
            {
                if (npc_type==Npc_type.NOMAL)
                {
                    if (bitmap != null)
                    {
                        graphics.DrawImage(bitmap, map_sx + x + x_offset, map_sy + y + y_offset);
                    }
                    else if (npc_type == Npc_type.CHARACTER)
                    {
                        Draw_character(graphics, map_sx, map_sy);
                    }
                }
            }
            //绘制动画
            else
            {
                Draw_animation(graphics, map_sx, map_sy);
            }    
        }  
        //碰撞（用来判断用户控制角色与NPC是否碰撞）
        public bool Is_collision(int collision_x,int collision_y)
        {
            Rectangle rectangle = new Rectangle(x - region_x / 2, y - region_y / 2, region_x, region_y);
            return rectangle.Contains(new Point(collision_x, collision_y));
        }
        //线碰撞
        public bool Is_line_collision(Point p1,Point p2)
        {
            //判断点是否碰撞
            if (Is_collision(p2.X, p2.Y))
            {
                return true;
            }
            int px, py;
            px = p1.X + (p2.X - p1.X) / 2;
            py = p1.Y + (p2.Y - p1.Y) / 2;
            if (Is_collision(px, py))
            {
                return true;
            }
            px = p2.X - (p2.X - p1.X) / 4;
            py = p2.Y - (p2.Y - p1.Y) / 4;
            if (Is_collision(px, py))
            {
                return true;
            }
            return false;
        }
        //判断鼠标是否在碰撞区域以内
        public bool Is_mouse_collision(int collision_x,int collision_y)
        {
            //有图
            if (bitmap != null)
            {
                if (npc_type == Npc.Npc_type.NOMAL)
                {
                    int center_x = x + x_offset + bitmap.Width / 2;
                    int center_y = y + y_offset + bitmap.Height / 2;
                    Rectangle rectangle = new Rectangle(center_x-mc_widht/2, center_y-mc_height/2, mc_widht, mc_height);
                    return rectangle.Contains(new Point(collision_x, collision_y));
                }
                else
                {
                    int center_x = x + x_offset + bitmap.Width /4/ 2;
                    int center_y = y + y_offset + bitmap.Height /4/ 2;
                    Rectangle rectangle = new Rectangle(center_x - mc_widht / 2, center_y - mc_height / 2, mc_widht, mc_height);
                    return rectangle.Contains(new Point(collision_x, collision_y));
                }
            }
            else
            {
                Rectangle rectangle = new Rectangle(x - mc_widht / 2, y - mc_height / 2, mc_widht, mc_height);
                return rectangle.Contains(new Point(collision_x, collision_y));
            }
        }
        //距离检测
        public bool Check_mc_distance(Npc npc,int player_x,int player_y)
        {
            Rectangle rectangle = new Rectangle(npc.x - mc_distance_x / 2, npc.y - mc_distance_y, mc_distance_x, mc_distance_y);
            return rectangle.Contains(new Point(player_x, player_y));
        }
        //鼠标操作
        public static void Mouse_click(Map[] maps,Player[] players,Npc[] npcs,Rectangle stage,MouseEventArgs e)
        {
            if (Player.status != Player.Status.WALK)
            {
                return;
            }
            if (npcs == null)
            {
                return;
            }
            for(int i = 0; i < npcs.Length; i++)
            {
                if (npcs[i] == null)
                {
                    continue;
                }
                if (npcs[i].map != Map.current_map)
                {
                    continue;
                }
                int collision_x = e.X - Map.Get_map_sx(maps, players, stage);
                int collision_y = e.Y - Map.Get_map_sy(maps, players, stage);
                if (!npcs[i].Is_mouse_collision(collision_x, collision_y))
                {
                    continue;
                }
                //距离
                if (!npcs[i].Check_mc_distance(npcs[i], Player.Get_pos_x(players), Player.Get_pos_y(players)))
                {
                    Player.Stop_walk(players);
                    Message.Showtip("请走近些点");
                    Task.Block();
                    continue;
                }
                Player.Stop_walk(players);
                Task.Story(i);
            }
        }
        //绘制动画
        public void Draw_animation(Graphics graphics, int map_sx, int map_sy)
        {
            //判断动画有效性
            if (animations == null||current_anm>animations.Length||animations[current_anm]==null||animations[current_anm].bitmap_path==null)
            {
                current_anm = -1;
                anm_frame = 0;
                last_anm_time = 0;
                return;
            }
            //绘图

            animations[current_anm].Draw(graphics, anm_frame, map_sx + x + x_offset, y + map_sy + y_offset);

            //处理下一帧
            if (Comm.Time() - last_anm_time >= Animation.RATE)
            {
                anm_frame = anm_frame + 1;
                last_anm_time = Comm.Time();
                if (anm_frame / animations[current_anm].anm_rate >= animations[current_anm].max_frame)
                {
                    current_anm = -1;
                    anm_frame = 0;
                    last_anm_time = 0;
                }
            }
        }
        //NPC画角色
        public void Draw_character(Graphics graphics,int map_sx,int map_sy)
        {
            Rectangle rectangle = new Rectangle(
                            bitmap.Width / 4 * (walk_frame % 4),
                            bitmap.Height / 4 * ((int)face - 1),
                            bitmap.Width / 4,
                            bitmap.Height / 4);
            Bitmap bitmap0 = bitmap.Clone(rectangle, bitmap.PixelFormat);
            graphics.DrawImage(bitmap0, map_sx + x + x_offset, map_sy + y + y_offset);
        }
        /// <summary>
        /// NPC 的定义是否可以自由行走
        /// </summary>
        /// <param name="maps"></param>
        /// <param name="direction"></param>
        /// <param name="isblock"></param>
        public void Walk(Map[] maps,Comm.Direction direction,bool isblock)
        {
            //转向
            face = direction;
            //间隔判定
            if (Comm.Time() - last_walk_time <= walk_interval)
            {
                return;
            }
            //up
            if (direction == Comm.Direction.UP&&(!isblock||Map.Is_through(maps,x,y-speed)))
            {
                y = y - speed;
            }
            //down
            if (direction == Comm.Direction.DOWN && (!isblock || Map.Is_through(maps, x, y + speed)))
            {
                y = y + speed;
            }
            //right
            if (direction == Comm.Direction.DOWN && (!isblock || Map.Is_through(maps, x-speed, y)))
            {
                x = x - speed;
            }
            //left
            if (direction == Comm.Direction.DOWN && (!isblock || Map.Is_through(maps, x + speed, y)))
            {
                x = x + speed;
            }
            //动画帧
            walk_frame = walk_frame + 1;
            if (walk_frame >= int.MaxValue)
            {
                walk_frame = 0;
            }
            //时间
            last_walk_time = Comm.Time();
        }
        public void Time_logic(Map[] maps)
        {
            if (npc_type == Npc_type.CHARACTER && idle_walk_time != 0)
            {

                Comm.Direction direction;
                if (idle_walk_time_new >= 0)
                    direction = idle_walk_direction;
                else
                    direction = Comm.Opposite_direction(idle_walk_direction);

                Walk(maps, direction, true);

                if (idle_walk_time_new >= 0)
                {
                    idle_walk_time_new = idle_walk_time_new + 1;
                    if (idle_walk_time_new > idle_walk_time)
                        idle_walk_time_new = -1;
                }
                else if (idle_walk_time_new < 0)
                {
                    idle_walk_time_new = idle_walk_time_new - 1;
                    if (idle_walk_time_new < -idle_walk_time)
                        idle_walk_time_new = 1;
                }
            }
        }
        /// <summary>
        /// 检测碰撞  0-没有 1-有
        /// </summary>
        /// <param name="maps"></param>
        /// <param name="players"></param>
        /// <param name="npcs"></param>
        /// <param name="stage"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static int Check_mouse_collision(Map[] maps,Player[] players,Npc[] npcs,Rectangle stage,MouseEventArgs e)
        {
            if (Player.status != Player.Status.WALK)//状态判断
            {
                return 0;
            }
            if (npcs == null)
            {
                return 0;
            }
            for(int i = 0; i < npcs.Length; i++)   //遍历NPC
            {
                if (npcs[i] == null)
                {
                    continue;
                }
                if (npcs[i].map != Map.current_map)
                {
                    continue;
                }
                //获取碰撞坐标
                int collision_x = e.X - Map.Get_map_sx(maps, players, stage);
                int collision_y = e.Y - Map.Get_map_sy(maps, players, stage);
                //判断是否发生碰撞
                if (npcs[i].Is_mouse_collision(collision_x, collision_y))
                {
                    //碰撞到当前地图的某一NPC
                    return 1;
                }
            }
            //没有碰到任何npc
            return 0;
        }
        public void Stop_walk()
        {
            walk_frame = 0;
            last_walk_time = 0;
        }
        //事件
        public void Play_aniation(int index)
        {
            current_anm = index;
            anm_frame = 0;
        }
    }
}
