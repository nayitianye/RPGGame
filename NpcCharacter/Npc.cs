using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpcCharacter
{
    public class Npc
    {
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

        //动画相关变量
        public Animation[] animations;   //动画类型的数组，她代表这个NPC所能使用的所有动画
        public int anm_frame = 0;  //当前的播放的帧
        public int current_anm = -1;//当前使用的动画，它对应于anm数组的下标。-1表示没有在播放动画
        public long last_anm_time = 0;//上一帧播放的时间，用于调控播放速率
        public enum Collosion_type
        {
            KEY=1,
            ENTER=2,
        }
        public Collosion_type collosion_Type = Collosion_type.KEY;
        
        //加载动画
        public void Load()
        {
            if (bitmap_path != "")
            {
                bitmap = new Bitmap(bitmap_path);
                bitmap.SetResolution(96, 96);
            }
            if (animations != null)
            {
                for(int i = 0; i < animations.Length; i++)
                {
                    animations[i].Load();
                }
            }
        }
        //卸载动画
        public void Unload()
        {
            if (bitmap != null)
            {
                bitmap = null;
            }
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
                if (bitmap != null)
                {
                    graphics.DrawImage(bitmap, map_sx + x + x_offset, map_sy + y + y_offset);
                }
            }
            //绘制动画
            else
            {
                Draw_animation(graphics, map_sx, map_sy);
            }
            
        }  
        
        //碰撞
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

        //事件
        public void Play_aniation(int index)
        {
            current_anm = index;
            anm_frame = 0;
        }
    }
}
