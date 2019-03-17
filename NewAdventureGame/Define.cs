using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAdventureGame
{
    public class Define
    {
        //系统各种属性的预定义
        public static void define(Player[] players,Npc[] npcs,Map[] maps,Weapon[] weapons)
        {
            //player define
            players[0] = new Player();
            players[0].bitmap = new Bitmap(@"r1.png");
            players[0].bitmap.SetResolution(96, 96);
            players[0].is_active = 1;
            players[0].status_bitmap = new Bitmap(@"item/face1.png");
            players[0].status_bitmap.SetResolution(96, 96);

            players[1] = new Player();
            players[1].bitmap = new Bitmap(@"r2.png");
            players[1].bitmap.SetResolution(96, 96);
            players[1].is_active = 1;
            players[1].status_bitmap = new Bitmap(@"item/face2.png");
            players[1].status_bitmap.SetResolution(96, 96);

            players[2] = new Player();
            players[2].bitmap = new Bitmap(@"r3.png");
            players[2].bitmap.SetResolution(96, 96);
            players[2].is_active = 1;
            players[2].status_bitmap = new Bitmap(@"item/face3.png");
            players[2].status_bitmap.SetResolution(96, 96);

            //map define
            maps[0] = new Map();
            maps[0].bitmap_path = "map1.png";
            maps[0].shade_path = "map1_shade.png";
            maps[0].block_path = "map1_block.png";
            maps[0].back_path = "map1_back.png";
            maps[0].music_path = "1.mp3";
            maps[1] = new Map();
            maps[1].bitmap_path = "map2.png";
            maps[1].shade_path = "map2_shade.png";
            maps[1].block_path = "map2_block.png";
            maps[1].music_path = "2.mp3";

            //npc define
            npcs[0] = new Npc();
            npcs[0].map = 0;
            npcs[0].x = 600;
            npcs[0].y = 780;
            npcs[0].y_offset = -50;
            npcs[0].mc_offsetx = 0;
            npcs[0].mc_offsety = 0;
            npcs[0].mc_widht = 90;
            npcs[0].mc_height = 50;
            npcs[0].bitmap_path = "npc_shoe.png";
            npcs[0].collosion_type = Npc.Collosion_type.KEY;

            npcs[1] = new Npc();
            npcs[1].map = 0;
            npcs[1].x = 800;
            npcs[1].y = 280;
            npcs[1].bitmap_path = "npc2.png";
            npcs[1].collosion_type = Npc.Collosion_type.KEY;

            npcs[2] = new Npc();
            npcs[2].map = 0;
            npcs[2].x = 20;
            npcs[2].y = 600;
            npcs[2].region_x = 40;
            npcs[2].region_y = 400;
            npcs[2].collosion_type = Npc.Collosion_type.ENTER;

            npcs[3] = new Npc();
            npcs[3].map = 1;
            npcs[3].x = 980;
            npcs[3].y = 600;
            npcs[3].region_x = 40;
            npcs[3].region_y = 400;
            npcs[3].collosion_type = Npc.Collosion_type.ENTER;

            npcs[4] = new Npc();
            npcs[4].map = 1;
            npcs[4].x = 700;
            npcs[4].y = 350;
            npcs[4].bitmap_path = "npc3.png";
            npcs[4].collosion_type = Npc.Collosion_type.KEY;
            Animation npc4anm1 = new Animation();
            npc4anm1.bitmap_path = "Anm1.png";
            npc4anm1.row = 2;
            npc4anm1.col = 2;
            npc4anm1.max_frame = 3;
            npc4anm1.anm_rate = 4;
            npcs[4].animations = new Animation[1];
            npcs[4].animations[0] = npc4anm1;

            npcs[5] = new Npc();
            npcs[5].map = 1;
            npcs[5].x = 400;
            npcs[5].y = 350;
            npcs[5].bitmap_path = "npc4.png";
            npcs[5].collosion_type = Npc.Collosion_type.KEY;
            npcs[5].npc_type = Npc.Npc_type.CHARACTER;
            npcs[5].idle_walk_direction = Comm.Direction.LEFT;
            npcs[5].idle_walk_time = 20;

            npcs[6] = new Npc();
            npcs[6].map = 0;
            npcs[6].x = 600;
            npcs[6].y = 280;
            npcs[6].bitmap_path = "npc2.png";
            npcs[6].collosion_type = Npc.Collosion_type.KEY;

            
            weapons[0] = new Weapon();
            weapons[0].Set("短剑", "一把钢质短剑", "item/item3.png", 1,
                1, 10, 0, 0, 5);
            weapons[0].use_event += new Weapon.Use_event(Weapon.Equip);

            weapons[1] = new Weapon();
            weapons[1].Set("斧头", "传说这是一把能够劈开阴\n气的斧头，但无人亲眼见\n过它的威力", "item/item4.png", 1,
                1, 3, 0, 0, 50);
            weapons[1].use_event += new Weapon.Use_event(Weapon.Equip);

            weapons[2] = new Weapon();
            weapons[2].Set("钢盾", "刚质盾牌，没有矛可以穿\n破它", "item/item5.png", 1,
               2, 0, 20, 5, 0);
            weapons[2].use_event += new Weapon.Use_event(Weapon.Equip);

            Weapon.Add_item(0, 3);
            Weapon.Add_item(1, 3);
            Weapon.Add_item(2, 2);
            //item
            //Item.item = new Item[6];
            //Item.item[0] = new Item();
            //Item.item[0].Set("红药水", "恢复少量hp", "item/item1.png", 1,
            //    30, 0, 0, 0, 0);
            //Item.item[0].cost = 30;

            //Item.item[0].use_event += new Item.Use_event(Item.Add_hp);

            //Item.item[1] = new Item();
            //Item.item[1].Set("蓝药水", "恢复少量mp", "item/item2.png", 1,
            //    30, 0, 0, 0, 0);
            //Item.item[1].use_event += new Item.Use_event(Item.Add_mp);

            //Item.item[2] = new Item();
            //Item.item[2].Set("短剑", "一把钢质短剑", "item/item3.png", 1,
            //    1, 10, 0, 0, 5);
            //Item.item[2].use_event += new Item.Use_event(Item.Equip);

            //Item.item[3] = new Item();
            //Item.item[3].Set("斧头", "传说这是一把能够劈开阴\n气的斧头，但无人亲眼见\n过它的威力", "item/item4.png", 1,
            //    1, 3, 0, 0, 50);
            //Item.item[3].use_event += new Item.Use_event(Item.Equip);

            //Item.item[4] = new Item();
            //Item.item[4].Set("钢盾", "刚质盾牌，没有矛可以穿\n破它", "item/item5.png", 1,
            //    2, 0, 20, 5, 0);
            //Item.item[4].use_event += new Item.Use_event(Item.Equip);

            //Item.item[5] = new Item();
            //Item.item[5].Set("罗培羽书", "一本游记，记录世间\n奇事，可打开阅览", "item/item6.png", 0,
            //    30, 0, 0, 0, 0);
            //Item.item[5].use_event += new Item.Use_event(Item.Ipybook);

            //Item.Add_item(0, 3);
            //Item.Add_item(1, 3);
            //Item.Add_item(2, 2);
            //Item.Add_item(3, 1);
            //Item.Add_item(4, 1);
            //Item.Add_item(5, 1);

            //skill
            Skill.skill = new Skill[2];
            Skill.skill[0] = new Skill();
            Skill.skill[0].Set("治疗术", "恢复少量hp\nmp:20", "item/skill2.png", 20,
                20, 0, 0, 0, 0);
            Skill.skill[0].use_event += new Skill.Use_event(Skill.Add_hp);

            Skill.skill[1] = new Skill();
            Skill.skill[1].Set("黑洞漩涡", "攻击型技能，将敌人\n吸入漩涡\nmp:20", "item/skill1.png", 20,
                0, 0, 0, 0, 0);
            Skill.skill[1].use_event += new Skill.Use_event(Skill.Add_hp);

            Skill.Learn_skill(0, 0, 1);
            Skill.Learn_skill(0, 1, 1);
            Skill.Learn_skill(1, 0, 1);
        }
    }
}
