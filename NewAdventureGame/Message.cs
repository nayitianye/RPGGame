using System.Drawing;

namespace NewAdventureGame
{
    public class Message
    {
        public static Panel message = new Panel();   //语言交流面板
        public static Panel messagetip = new Panel();//游戏提示面板
        public static Bitmap face;
        public enum Face
        {
            LEFT = 1,
            RIGHT = 2,
        }
        public static Face face_pos = Face.LEFT;
        public static string name = "";
        public static string content = "";

        public static void Init()
        {
            Button button_ok = new Button();
            button_ok.Set(-1000, -1000, 2000, 2000, "", "", "", -1, -1, -1, -1);
            button_ok.click_event += new Button.Click_event(Button_ok_event);
            message.button = new Button[1];
            message.button[0] = button_ok;
            message.Set(0, 415, "msg.png", 0, -1);
            message.draw_event += new Panel.Draw_event(msgdraw);
            message.Init();

            Button button_ok_tip = new Button();
            button_ok_tip.Set(-1000, -1000, 2000, 2000, "", "", "", -1, -1, -1, -1);
            button_ok_tip.click_event += new Button.Click_event(Button_tip_ok_event);
            messagetip.button = new Button[1];
            messagetip.button[0] = button_ok_tip;
            messagetip.Set(251, 200, "msgtip.png", 0, -1);
            messagetip.draw_event += new Panel.Draw_event(msgdrawtip);
            messagetip.Init();
        }
        public static void Button_ok_event()
        {
            message.Hide();
        }
        public static void Button_tip_ok_event()
        {
            messagetip.Hide();
        }
        public static void Show(string name0, string content0, string face_path, Face face_pos0)
        {
            //content
            name = name0;
            content = content0;
            //face
            if (face_path != null && face_path != "")
            {
                face = new Bitmap(face_path);
                face.SetResolution(96, 96);
            }
            else
            {
                face = null;
            }
            face_pos = face_pos0;
            message.Show();
        }

        public static void msgdraw(Graphics graphics, int x_offset, int y_offset)
        {
            //立绘
            if (face != null)
            {
                if (face_pos == Face.LEFT)
                {
                    graphics.DrawImage(face, 0, 245);
                }
                else if (face_pos == Face.RIGHT)
                {
                    graphics.DrawImage(face, 486, 245);
                }
            }
            //名字
            Font name_font = new Font("黑体", 14);
            Brush name_brush = Brushes.Peru;
            StringFormat name_sf = new StringFormat();
            if (face_pos == Face.LEFT)
            {
                graphics.DrawString(name, name_font, name_brush, x_offset + 240, y_offset + 25, name_sf);
            }
            else
            {
                graphics.DrawString(name, name_font, name_brush, x_offset + 240, y_offset + 25, name_sf);
            }
            //内容
            Font content_font = new Font("黑体", 12);
            Brush content_brush = Brushes.WhiteSmoke;
            StringFormat content_sf = new StringFormat();
            string show_content = Linefeed(content, 25);
            if (face_pos == Face.LEFT)
            {
                graphics.DrawString(show_content, content_font, content_brush, x_offset + 260, y_offset + 55, content_sf);
            }
            else
            {
                graphics.DrawString(show_content, content_font, content_brush, x_offset + 170, y_offset + 55, content_sf);
            }
        }

        //显示文字
        public static void msgdrawtip(Graphics graphics,int x_offset,int y_offset)
        {
            //画文字
            Font content_font = new Font("黑体", 12);
            Brush content_brush = new SolidBrush(Color.WhiteSmoke);
            StringFormat content_sf = new StringFormat();
            content_sf.Alignment = StringAlignment.Center;
            graphics.DrawString(content, content_font, content_brush, new Rectangle(x_offset, y_offset + 12, 291, 42), content_sf);
        }

        //显示面板
        public static void Showtip(string content0)
        {
            content= content0;
            messagetip.Show();
        }
        //自动换行
        public static string Linefeed(string str, int num)
        {
            if (str == null)
            {
                return null;
            }
            string ret = "";
            int start_pos = 0;
            while (start_pos < str.Length)
            {
                if (start_pos + num > str.Length)
                {
                    num = str.Length - start_pos;
                }
                ret = ret + str.Substring(start_pos, num) + "\n";
                start_pos = start_pos + num;
            }
            return ret;
        }
    }
}
