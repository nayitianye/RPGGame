using System.Drawing;

namespace AdventureGame 
{
    public class Animation
    {
        public static long RATE = 100;//静态变量RATE作为动画的基准速率，单位为毫秒

        public string bitmap_path; //动画的图像路径
        public Bitmap bitmap;  //动画的图像
        public int row = 1;    //bitmap 的行数和列数
        public int col = 1;
        public int max_frame = 1;//动画的帧数
        public int anm_rate; //以RATE为基准的播放速率。1.播放速率和Rate规定的最高速率一致，为N ,表示放慢了N倍播放

        //加载图像
        public void Load()
        {
            if (bitmap_path != null && bitmap_path != "")
            {
                bitmap = new Bitmap(bitmap_path);
                bitmap.SetResolution(96, 96);
            }
        }
        //卸载图像
        public void Unload()
        {
            if (bitmap != null)
            {
                bitmap = null;
            }
        }

        //获取图片
        public Bitmap Get_bitmap(int frame)
        {
            if (bitmap == null)
            {
                return null;
            }
            if (frame > max_frame)
            {
                return null;
            }
            //定义区域
            Rectangle rectangle = new Rectangle(
                        bitmap.Width / row * (frame % row),
                        bitmap.Height / col * (frame / row),
                        bitmap.Width / row,
                        bitmap.Height / col);

            return bitmap.Clone(rectangle, bitmap.PixelFormat);
        }

        //绘制图像
        public void Draw(Graphics graphics,int frame,int x,int y)
        {
            Bitmap bitmap = Get_bitmap(frame / anm_rate);
            if (bitmap == null)
            {
                return;
            }
            graphics.DrawImage(bitmap, x, y);
        }  
    }
}
