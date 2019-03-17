using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSystem
{
    public class StatusMenu
    {
        public static Panel status = new Panel();

        public static int menu = 0;//0-物品 1-技能
        public static Bitmap bitmap_menu_item;//物品
        public static Bitmap bitmap_menu_eqip;//装备

        public static int page = 1;
        public static int selnow = 1;
        public static Bitmap bitmap_sel;
        //----------------------------------------------------------------
        //     载入/显示
        //----------------------------------------------------------------
        public static void Init()
        {


            bitmap_menu_item = new Bitmap(@"item/sbt2_1.png");
            bitmap_menu_item.SetResolution(96, 96);
            bitmap_menu_eqip = new Bitmap(@"item/sbt2_2.png");
            bitmap_menu_eqip.SetResolution(96, 96);
            bitmap_sel = new Bitmap(@"item/sbt7_2.png");
            bitmap_sel.SetResolution(96, 96);

            Button equip_att = new Button();
            equip_att.Set(41, 55, 0, 0,
                "item/sbt9_1.png", "item/sbt9_2.png", "item/sbt9_2.png",
                -1, -1, -1, -1);
            equip_att.click_event += new Button.Click_event(Click_equip_att);

            Button equip_def = new Button();
            equip_def.Set(41, 135, 0, 0,
                "item/sbt9_1.png", "item/sbt9_2.png", "item/sbt9_2.png",
                -1, -1, -1, -1);
            equip_def.click_event += new Button.Click_event(Click_equip_def);

            Button next_player = new Button();
            next_player.Set(305, 296, 0, 0,
                "item/sbt1_1.png", "item/sbt1_2.png", "item/sbt1_2.png",
                -1, -1, -1, -1);
            next_player.click_event += new Button.Click_event(Click_next_player);

            Button item_menu = new Button();
            item_menu.Set(634, 66, 0, 0,
                "item/sbt10.png", "item/sbt10.png", "item/sbt10.png",
                -1, -1, -1, -1);
            item_menu.click_event += new Button.Click_event(Click_item_menu);

            Button skill_menu = new Button();
            skill_menu.Set(634, 173, 0, 0,
                "item/sbt10.png", "item/sbt10.png", "item/sbt10.png",
                -1, -1, -1, -1);
            skill_menu.click_event += new Button.Click_event(Click_skill_menu);

            Button previous_page = new Button();
            previous_page.Set(372, 326, 0, 0,
                "item/sbt3_1.png", "item/sbt3_2.png", "item/sbt3_2.png",
                -1, -1, -1, -1);
            previous_page.click_event += new Button.Click_event(Click_previous_page);

            Button next_page = new Button();
            next_page.Set(523, 326, 0, 0,
                "item/sbt5_1.png", "item/sbt5_2.png", "item/sbt5_2.png",
                -1, -1, -1, -1);
            next_page.click_event += new Button.Click_event(Click_next_page);

            Button use = new Button();
            use.Set(447, 326, 0, 0,
                "item/sbt4_1.png", "item/sbt4_2.png", "item/sbt4_2.png",
                -1, -1, -1, -1);
            use.click_event += new Button.Click_event(Click_use);

            Button close = new Button();
            close.Set(627, 16, 0, 0,
                "item/sbt6_1.png", "item/sbt6_2.png", "item/sbt6_2.png",
                -1, -1, -1, -1);
            close.click_event += new Button.Click_event(Click_close);

            Button sel1 = new Button();
            sel1.Set(350, 38, 0, 0,
                "item/sbt7_1.png", "item/sbt7_2.png", "item/sbt7_2.png",
                -1, -1, -1, -1);
            sel1.click_event += new Button.Click_event(Click_sel1);

            Button sel2 = new Button();
            sel2.Set(350, 133, 0, 0,
                "item/sbt7_1.png", "item/sbt7_2.png", "item/sbt7_2.png",
                -1, -1, -1, -1);
            sel2.click_event += new Button.Click_event(Click_sel2);

            Button sel3 = new Button();
            sel3.Set(350, 228, 0, 0,
                "item/sbt7_1.png", "item/sbt7_2.png", "item/sbt7_2.png",
                -1, -1, -1, -1);
            sel3.click_event += new Button.Click_event(Click_sel3);


            Button under = new Button();
            under.Set(-100, -100, 1000, 1000,
                "item/sbt6_1.png", "item/sbt6_2.png", "item/sbt6_2.png",
                -1, -1, -1, -1);

            status.button = new Button[13];
            status.button[0] = equip_att;
            status.button[1] = equip_def;
            status.button[2] = next_player;
            status.button[3] = item_menu;
            status.button[4] = skill_menu;
            status.button[5] = previous_page;
            status.button[6] = next_page;
            status.button[7] = use;
            status.button[8] = close;
            status.button[9] = sel1;
            status.button[10] = sel2;
            status.button[11] = sel3;
            status.button[12] = under;
            status.Set(58, 71, "item/status_bg.png", 2, 8);
            status.draw_event += new Panel.Draw_event(Draw);
            status.Init();
        }


        public static void Show()
        {
            menu = 0;
            page = 1;
            status.Show();
        }


        //----------------------------------------------------------------
        //     按钮回调
        //----------------------------------------------------------------
        //武器
        public static void Click_equip_att()
        {
            Item.Unequip(1);
        }
        //防具
        public static void Click_equip_def()
        {
            Item.Unequip(2);
        }
        //查找下一个角色
        public static void Click_next_player()
        {
            Player.select_player = Player.select_player + 1;
            for (int i = Player.select_player; i < Form1.players.Length; i++)
            {
                if (Form1.players[i].is_active == 1)
                {
                    Player.select_player = i;
                    return;
                }
            }

            for (int i = 0; i < Player.select_player; i++)
            {
                if (Form1.players[i].is_active == 1)
                {
                    Player.select_player = i;
                    return;
                }
            }

        }
        //物品
        public static void Click_item_menu()
        {
            page = 1;
            selnow = 1;
            menu = 0;
        }
        //技能
        public static void Click_skill_menu()
        {
            page = 1;
            selnow = 1;
            menu = 1;
        }
        //上一页
        public static void Click_previous_page()
        {
            page--;
            if (page < 1) page = 1;
        }
        //下一页
        public static void Click_next_page()
        {
            page++;
        }
        //使用按钮
        public static void Click_use()
        {
            if (menu == 0)
            {
                int index = -1;
                for (int i = 0, count = 0; i < Item.item.Length; i++)
                {
                    if (Item.item[i].num <= 0)
                        continue;
                    count++;

                    if (count <= (page - 1) * 3 + selnow - 1)
                        continue;

                    index = i;
                    break;
                }
                if (index >= 0)
                {
                    Item.item[index].Use();
                }
            }
            else
            {
                int index = -1;
                int[] pskill = Form1.players[Player.select_player].skill;
                for (int i = 0, count = 0; i < pskill.Length; i++)
                {
                    if (pskill[i] < 0)
                        continue;
                    count++;

                    if (count <= (page - 1) * 3 + selnow - 1)
                        continue;

                    index = i;
                    break;
                }
                if (index >= 0)
                {
                    Skill.skill[pskill[index]].Use();
                }
            }
        }
        //关闭按钮
        public static void Click_close()
        {
            status.Hide();
        }
        public static void Click_sel1()
        {
            selnow = 1;
        }
        public static void Click_sel2()
        {
            selnow = 2;
        }
        public static void Click_sel3()
        {
            selnow = 3;
        }
        //----------------------------------------------------------------
        //     绘图回调
        //----------------------------------------------------------------
        public static void Draw(Graphics graphics, int x_offset, int y_offset)
        {
            //画角色状态
            Player player = Form1.players[Player.select_player];
            graphics.DrawImage(player.status_bitmap, x_offset, y_offset);
            //状态数字
            Font font = new Font("黑体", 10);
            Brush brush = Brushes.Black;
            graphics.DrawString(player.hp.ToString(), font, brush,
                 x_offset + 90, y_offset + 346, new StringFormat());
            graphics.DrawString(player.attack.ToString(), font, brush,
                 x_offset + 90, y_offset + 366, new StringFormat());
            graphics.DrawString(player.fspeed.ToString(), font, brush,
                 x_offset + 90, y_offset + 386, new StringFormat());
            graphics.DrawString(player.mp.ToString(), font, brush,
                 x_offset + 225, y_offset + 346, new StringFormat());
            graphics.DrawString(player.defense.ToString(), font, brush,
                 x_offset + 225, y_offset + 366, new StringFormat());
            graphics.DrawString(player.fortune.ToString(), font, brush,
                 x_offset + 225, y_offset + 386, new StringFormat());
            //装备加成
            Font font_eq = new Font("黑体", 10);
            Brush brush_eq = Brushes.Red;
            int value1 = 0;
            int value2 = 0;
            int value3 = 0;
            int value4 = 0;

            if (player.equip_att >= 0)
            {
                value1 = Item.item[player.equip_att].value2;
                value2 = Item.item[player.equip_att].value3;
                value3 = Item.item[player.equip_att].value4;
                value4 = Item.item[player.equip_att].value5;
            }
            if (player.equip_def >= 0)
            {
                value1 += Item.item[player.equip_def].value2;
                value2 += Item.item[player.equip_def].value3;
                value3 += Item.item[player.equip_def].value4;
                value4 += Item.item[player.equip_def].value5;
            }
            if (value1 != 0)
                graphics.DrawString("+" + value1.ToString(), font_eq, brush_eq,
                 x_offset + 110, y_offset + 366, new StringFormat());
            if (value2 != 0)
                graphics.DrawString("+" + value2.ToString(), font_eq, brush_eq,
                 x_offset + 255, y_offset + 366, new StringFormat());
            if (value3 != 0)
                graphics.DrawString("+" + value3.ToString(), font_eq, brush_eq,
                 x_offset + 110, y_offset + 386, new StringFormat());
            if (value4 != 0)
                graphics.DrawString("+" + value4.ToString(), font_eq, brush_eq,
                 x_offset + 255, y_offset + 386, new StringFormat());

            //装备图标
            if (player.equip_att >= 0 && Item.item[player.equip_att].bitmap != null)
                graphics.DrawImage(Item.item[player.equip_att].bitmap, x_offset + 41, y_offset + 55);
            if (player.equip_def >= 0 && Item.item[player.equip_def].bitmap != null)
                graphics.DrawImage(Item.item[player.equip_def].bitmap, x_offset + 41, y_offset + 136);
            //金钱
            Font font_m = new Font("黑体", 16);
            Brush brush_m = Brushes.DarkOrange;
            graphics.DrawString(Player.money.ToString(), font_m, brush_m,
                 x_offset + 461, y_offset + 374, new StringFormat());
            //物品或装备选框  
            if (menu == 0)
                graphics.DrawImage(bitmap_menu_item, x_offset + 629, y_offset + 51);
            else 
                graphics.DrawImage(bitmap_menu_eqip, x_offset + 629, y_offset + 51);
            //显示物品
            if (menu == 0)
            {
                for (int i = 0, count = 0, showcount = 0;i < Item.item.Length && showcount < 3; i++)
                {
                    if (Item.item[i].num <= 0)
                    {
                        continue;
                    }       
                    count++;
                    if (count <= (page - 1) * 3)
                    {
                        continue;
                    }
                    if (Item.item[i].bitmap != null)
                        graphics.DrawImage(Item.item[i].bitmap, x_offset + 360, y_offset + 48 + showcount * 96);
                    Font font_n = new Font("黑体", 12);
                    Brush brush_n = Brushes.GreenYellow;
                    graphics.DrawString(Item.item[i].name + " X" + Item.item[i].num.ToString(), font_n, brush_n,
                        x_offset + 440, y_offset + 48 + showcount * 96, new StringFormat());
                    Font font_d = new Font("黑体", 10);
                    Brush brush_d = Brushes.LawnGreen;
                    graphics.DrawString(Item.item[i].description, font_d, brush_d,
                        x_offset + 440, y_offset + 75 + showcount * 96, new StringFormat());
                    showcount++;
                }
            }
            //显示技能
            else if (menu == 1)
            {
                int[] pskill = Form1.players[Player.select_player].skill;
                for (int i = 0, count = 0, showcount = 0;
                    i < pskill.Length && showcount < 3; i++)
                {
                    if (pskill[i] < 0)
                        continue;
                    count++;

                    if (count <= (page - 1) * 3)
                        continue;

                    if (Skill.skill[pskill[i]].bitmap != null)
                        graphics.DrawImage(Skill.skill[pskill[i]].bitmap, x_offset + 360, y_offset + 48 + showcount * 96);
                    Font font_n = new Font("黑体", 12);
                    Brush brush_n = Brushes.GreenYellow;
                    graphics.DrawString(Skill.skill[pskill[i]].name, font_n, brush_n,
                        x_offset + 440, y_offset + 48 + showcount * 96, new StringFormat());
                    Font font_d = new Font("黑体", 10);
                    Brush brush_d = Brushes.LawnGreen;
                    graphics.DrawString(Skill.skill[pskill[i]].description, font_d, brush_d,
                        x_offset + 440, y_offset + 75 + showcount * 96, new StringFormat());
                    showcount++;
                }
            }
            //显示选择框
            graphics.DrawImage(bitmap_sel, x_offset + 350, y_offset + 38 + (selnow - 1) * 95);
        }
    }
}
