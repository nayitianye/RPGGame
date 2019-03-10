using System.Drawing;

namespace NpcCharacter
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
        public static void change_map(Map[] maps,Player[] players,int newindex,int x,int y,int face,WMPLib.WindowsMediaPlayer mediaPlayer)
        {
            mediaPlayer.URL = maps[current_map].music_path;
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
            //当前的map
            current_map = newindex;
            //位置设置
            Player.Set_position(players, x, y, face);
        }

        public static void Draw(Map[] maps, Player[] players, Graphics graphics, Rectangle rectangle)
        {
            Map map = maps[current_map];
            //绘图位置x
            int map_sx = 0;//地图屏幕坐标
            int player_x = Player.get_pos_x(players);//角色坐标
            int map_w = map.bitmap.Width;
            if (player_x <= rectangle.Width / 2)
            {
                map_sx = 0;
            }
            else if (player_x > map_w - rectangle.Width / 2)
            {
                map_sx = rectangle.Width - map_w;
            }
            else
            {
                map_sx = rectangle.Width / 2 - player_x;
            }
            //绘图位置y
            int map_sy = 0;//地图屏幕坐标
            int player_y = Player.get_pos_y(players);//角色坐标
            int map_h = map.bitmap.Height;
            if (player_y<= rectangle.Width / 2)
            {
                map_sy = 0;
            }
            else if (player_y > map_h- rectangle.Height / 2)
            {
                map_sy = rectangle.Height - map_h;
            }
            else
            {
                map_sy = rectangle.Height / 2 - player_y;
            }
            //绘图
            if (map.back != null)
            {
                graphics.DrawImage(map.back, 0, 0);
            }
            graphics.DrawImage(map.bitmap, map_sx, map_sy);
            Player.Draw(players, graphics, map_sx, map_sy);
            graphics.DrawImage(map.shade, map_sx, map_sy);
           
        }

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
}
