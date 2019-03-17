using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSystem
{
    public class Skill
    {
        //Skill数组
        public static Skill[] skill;

        public int mp = 10;
        public string name = "";
        public string description = "";
        public Bitmap bitmap;

        public int value1 = 0;
        public int value2 = 0;
        public int value3 = 0;
        public int value4 = 0;
        public int value5 = 0;
      
        //战斗中使用
        public int canfuse = 0;
        public int fvalue1 = 0;
        public int fvalue2 = 0;
        public Animation fanm;
        public bool Check_fuse(int mp)
        {
            if (canfuse != 1)
                return false;

            if (mp < this.mp)
                return false;

            return true;
        }
        public void Fset(Animation fanm, int fvalue1, int fvalue2)
        {
            this.fanm = fanm;
            this.fvalue1 = fvalue1;
            this.fvalue2 = fvalue2;
            this.canfuse = 1;
            if (fanm != null)
                fanm.Load();
        }
        public void Set(string name, string description, string bitmap_path, int mp,
             int value1, int value2, int value3, int value4, int value5)
        {
            this.name = name;
            this.description = description;

            if (bitmap_path != null && bitmap_path != "")
            {
                bitmap = new Bitmap(bitmap_path);
                bitmap.SetResolution(96, 96);
            }
            this.mp = mp;
            this.value1 = value1;
            this.value2 = value2;
            this.value3 = value3;
            this.value4 = value4;
            this.value5 = value5;
        }


        //使用  定义委托类型
        public delegate void Use_event(Skill skill);
        public event Use_event use_event;
        public void Use()
        {
            if (Form1.players[Player.select_player].mp < mp)  //mp判断
                return;

            Form1.players[Player.select_player].mp -= mp;   //减去mp
            if (use_event != null)
                use_event(this);   //使用技能
        } 

        //----------------------------------------------------------------
        //     学习技能
        //----------------------------------------------------------------
        //type 0-解除 1-习得  
        public static void Learn_skill(int player_index, int index, int type)
        {
            if (skill == null) return;
            if (index < 0) return;
            if (index >= skill.Length) return;
            if (skill[index] == null) return;
            if (type == 0)//解除技能
            {
                for (int i = 0; i < Form1.players[player_index].skill.Length; i++)
                {
                    if (Form1.players[player_index].skill[i] == index)
                    {
                        Form1.players[player_index].skill[i] = -1;   //设置成空位
                    }       
                }
            }
            else//学习技能
            {
                for (int i = 0; i < Form1.players[player_index].skill.Length; i++)
                {
                    if (Form1.players[player_index].skill[i] == index)//已经学会该技能
                    {
                        return;
                    }      
                }

                for (int i = 0; i < Form1.players[player_index].skill.Length; i++)
                {
                    if (Form1.players[player_index].skill[i] == -1)//找到空位
                    {
                        Form1.players[player_index].skill[i] = index;//添加技能
                        return;
                    }
                }
            }

        }


        //----------------------------------------------------------------
        //     通用回调函数
        //----------------------------------------------------------------
        //添加hp，使用value1
        public static void Add_hp(Skill skill)
        {
            Player player = Form1.players[Player.select_player];
            player.hp += skill.value1;
            if (player.hp > player.max_hp)
                player.hp = player.max_hp;
            if (player.hp < 0)
                player.hp = 0;
        }
    }
}
