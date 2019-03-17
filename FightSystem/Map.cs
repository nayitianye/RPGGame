using System.Drawing;

namespace FightSystem
{
    public class Map
    {
        public static int current_map = 0;

        public string bitmap_path;  //图片路径
        public Bitmap bitmap;
        public string shade_path;   //遮挡层图片路径
        public Bitmap shade;
        public string block_path;   //不可通行的地图
        public Bitmap block;
        public string back_path;    //背景图
        public Bitmap back;
     
        public string music_path;   //音乐路径
        public Map()
        {
            bitmap_path = "map1_b.gif";
        }

        public  static void Draw(Map[] maps,Graphics g)
        {
            Map map = maps[current_map];
            g.DrawImage(map.bitmap, 0, 0);
            
        }
        /// <summary>
        /// 地图的修改
        /// </summary>
        /// <param name="maps"></param>
        /// <param name="players"></param>
        /// <param name="newindex"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="face"></param>
        public static void Change_map(Map[] maps,Player[] players,Npc[] npcs,int newindex,int x,int y,int face,WMPLib.WindowsMediaPlayer mediaPlayer)
        {
            //卸载旧地图资源
            if (maps[current_map].bitmap != null)
            {
                maps[current_map].bitmap = null;
            }
            if (maps[current_map].shade != null)
            {
                maps[current_map].shade = null;
            }
            if (maps[current_map].block != null)
            {
                maps[current_map].block= null;
            }
            if (maps[current_map].back != null)
            {
                maps[current_map].back = null;
            }
            //加载新地图资源
            if (maps[newindex].bitmap_path != null && maps[newindex].bitmap_path != "")
            {
                maps[newindex].bitmap = new Bitmap(maps[newindex].bitmap_path);
                maps[newindex].bitmap.SetResolution(96, 96);
            }
            if (maps[newindex].shade_path != null && maps[newindex].shade_path != "")
            {
                maps[newindex].shade = new Bitmap(maps[newindex].shade_path);
                maps[newindex].shade.SetResolution(96, 96);
            }
            if (maps[newindex].block_path != null && maps[newindex].block_path != "")
            {
                maps[newindex].block = new Bitmap(maps[newindex].block_path);
                maps[newindex].block.SetResolution(96, 96);
            }
            if (maps[newindex].back_path != null && maps[newindex].back_path!= "")
            {
                maps[newindex].back = new Bitmap(maps[newindex].back_path);
                maps[newindex].back.SetResolution(96, 96);
            }

            //加载NPC资源
            for(int i = 0; i < npcs.Length; i++)
            {
                if (npcs[i] == null)
                {
                    continue;
                }
                if (npcs[i].map == current_map)
                {
                    npcs[i].Unload();
                }
                if (npcs[i].map == newindex)
                {
                    npcs[i].Load();
                }
            }

            //当前的map
            current_map = newindex;
            //位置设置
            Player.Set_position(players, x, y, face);
            //音乐
            mediaPlayer.URL = maps[current_map].music_path;
        }
        /// <summary>
        /// 地图的绘制
        /// </summary>
        /// <param name="maps"></param>
        /// <param name="players"></param>
        /// <param name="npcs"></param>
        /// <param name="graphics"></param>
        /// <param name="rectangle"></param>
        public static void Draw(Map[] maps, Player[] players,Npc[] npcs, Graphics graphics, Rectangle rectangle)
        {
            Map map = maps[current_map];
            //绘图位置x
            int map_sx = Get_map_sx(maps, players, rectangle);
            //绘图位置y
            int map_sy = Get_map_sy(maps, players, rectangle);
            //绘图
            if (map.back != null)
            {
                graphics.DrawImage(map.back, 0, 0);
            }
            if (map.bitmap != null)
            {
                graphics.DrawImage(map.bitmap, map_sx, map_sy);
            }
            Player.Draw_flag(graphics, map_sx, map_sy);
            //绘制NPC和用户
            Draw_player_npc(maps, players, npcs, graphics, map_sx, map_sy);

            if (map.shade != null)
            {
                graphics.DrawImage(map.shade, map_sx, map_sy);
            }
        }
        /// <summary>
        /// 处理主角和Npc的层次并绘制他们
        /// </summary>
        /// <param name="maps"></param>
        /// <param name="players"></param>
        /// <param name="npcs"></param>
        /// <param name="graphics"></param>
        /// <param name="map_sx"></param>
        /// <param name="map_sy"></param>
        public static void Draw_player_npc(Map[] maps,Player[] players,Npc[] npcs,Graphics graphics,int map_sx,int map_sy)
        {
            //绘制主角和NPC
            Layer_sort[] layer_sorts = new Layer_sort[npcs.Length + 1];
            for (int i = 0; i < npcs.Length; i++)
            {
                if (npcs[i] != null)
                {
                    layer_sorts[i].y = npcs[i].y;
                    layer_sorts[i].index = i;
                    layer_sorts[i].type = 1;
                }
                else
                {
                    layer_sorts[i].y = int.MaxValue;
                    layer_sorts[i].index = i;
                    layer_sorts[i].type = 1;
                }
            }

            layer_sorts[npcs.Length].y = Player.Get_pos_y(players);
            layer_sorts[npcs.Length].index = 0;
            layer_sorts[npcs.Length].type = 0;

            System.Array.Sort(layer_sorts, new Layer_sort_comparer());
            for(int i = 0; i < layer_sorts.Length; i++)
            {
                //画主角
                if(layer_sorts[i].type==0)
                {
                    Player.Draw(players, graphics, map_sx, map_sy);
                }
                //画NPC
                else if (layer_sorts[i].type==1)
                {
                    int index = layer_sorts[i].index;
                    if (npcs[index] == null)
                    {
                        continue;
                    }
                    if (npcs[index].map != current_map)
                    {
                        continue;
                    }
                    npcs[index].Draw(graphics, map_sx, map_sy);
                }
            }
        }
        /// <summary>
        /// 绘图位置y
        /// </summary>
        /// <param name="players"></param>
        /// <param name="rectangle"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        public static int Get_map_sy(Map[] maps,Player[] players, Rectangle rectangle )
        {
            Map map = maps[current_map];
            if (map.bitmap == null)
            {
                return 0;
            }
            int map_sy = 0;//地图屏幕坐标
            int player_y = Player.Get_pos_y(players);//角色坐标
            int map_height = map.bitmap.Height;
            if (player_y <= rectangle.Width / 2)
            {
                map_sy = 0;
            }
            else if (player_y > map_height - rectangle.Height / 2)
            {
                map_sy = rectangle.Height - map_height;
            }
            else
            {
                map_sy = rectangle.Height / 2 - player_y;
            }
            return map_sy;
        }
        /// <summary>
        /// 绘图位置X
        /// </summary>
        /// <param name="maps"></param>
        /// <param name="players"></param>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public static int Get_map_sx(Map[] maps,Player[] players,Rectangle rectangle)
        {
            Map map = maps[current_map];
            if (map.bitmap == null)
            {
                return 0;
            }
            int map_sx = 0;    //地图屏幕坐标
            int player_x = Player.Get_pos_x(players);//角色坐标
            int map_width = map.bitmap.Width;
            if (player_x <= rectangle.Width / 2)
            {
                map_sx = 0;
            }
            else if (player_x > map_width - rectangle.Width / 2)
            {
                map_sx = rectangle.Width - map_width;
            }
            else
            {
                map_sx = rectangle.Width / 2 - player_x;
            }
            return map_sx;
        }
        /// <summary>
        /// 判断人物是否能够正常通过
        /// </summary>
        /// <param name="maps"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool Is_through(Map[] maps,int x,int y)
        {
            Map map = maps[current_map];

            //判断是否在图片范围内
            if (x < 0)
            {
                return false;
            }else if (x >= map.block.Width)
            {
                return false;
            }else if (y < 0)
            {
                return false;
            }else if (y >= map.block.Height)
            {
                return false;
            }

            //判断是否为黑色  黑色不可通行，白色可以通行
            if (map.block.GetPixel(x, y).B == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    /// <summary>
    /// 层次排序
    /// </summary>
    public struct Layer_sort
    {
        public int y;   //y表示纵坐标
        public int index;  //index表示NPC的Id
        //0-主角  1-NPC
        public int type;
    }
    /// <summary>
    /// 继承系统的排序类，对人物和场景的排序
    /// </summary>
    public class Layer_sort_comparer : System.Collections.IComparer
    {
        public int Compare(object s1, object s2)
        {
            //返回True s1在s2的前面
            return ((Layer_sort)s1).y - ((Layer_sort)s2).y;
        }
    }
}
