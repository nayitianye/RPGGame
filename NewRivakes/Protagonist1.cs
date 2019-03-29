using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewRivakes
{
    public abstract class Protagonist1
    {
        WeaponBehavior weaponBehavior ;
        private string name;
        //姓名   用户角色名称
        private int level;
        //等级   角色的登记
        private string sex;
        //角色的性别
        private int empiric;
        //经验值 角色当前的经验值
        private int hp;
        //生命值血量
        private int max_Hp;
        //最大的生命值
        private int mp;
        //内力、蓝
        private int max_Mp;
        //最大的内力 蓝
        private int power;
        //力量  
        private int speed;
        //速度、敏捷
        private int furtune;
        //幸运、掉落物品的几率
        private int attack;
        //攻击力   
        private int defense;
        //防御力
        private int role;
        //表示角色的类型
        private string image_path;
        //图像地址
        private int money;
        //金钱
        private int equip_head=-1;
        private int equip_body = -1;
        private int equip_foot = -1;
        private int equip_weapon = -1;
        public  string Name { get => name; set => name = value; }
        public  int Level { get => level; set => level = value; }
        public string Sex { get => sex; set => sex = value; }
        public int Empiric { get => empiric; set => empiric = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Max_Hp { get => max_Hp; set => max_Hp = value; }
        public int Mp { get => mp; set => mp = value; }
        public int Max_Mp { get => max_Mp; set => max_Mp = value; }
        public int Power { get => power; set => power = value; }
        public int Speed { get => speed; set => speed = value; }
        public int Furtune { get => furtune; set => furtune = value; }
        public int Attack { get => attack; set => attack = value; }
        public int Defense { get => defense; set => defense = value; }
        public int Role { get => role; set => role = value; }
        public string Image_path { get => image_path; set => image_path = value; }
        public int Money { get => money; set => money = value; }
        public int Equip_head { get => equip_head; set => equip_head = value; }
        public int Equip_body { get => equip_body; set => equip_body = value; }
        public int Equip_foot { get => equip_foot; set => equip_foot = value; }
        public int Equip_weapon { get => equip_weapon; set => equip_weapon = value; }

        public void Init(string name,string sex)
        {
            this.Name = name;
            this.Level = 1;
            this.Sex = sex;
            this.Empiric = 0;
            this.Hp = 100;
            this.Max_Hp = 100;
            this.Mp =100;
            this.Max_Mp = 100;
            this.Money = 1000;
        }
        public void Cost_money(int money)
        {
            if (this.Money < money)
            {
                return;
            }
            this.Money -= money;
        }
        public void Equip(Equipment equipment,Protagonist1 protagonist, int index)
        {
           
            if (equipment.Type == 0&&protagonist.Equip_head==-1)
            {
                protagonist.Defense += equipment.Defense;
                protagonist.Attack += equipment.Attack;
                protagonist.Speed += equipment.Speed;
                protagonist.Equip_head = index;
            }
            else if (equipment.Type == 1 && protagonist.Equip_body == -1)
            {
                protagonist.Defense += equipment.Defense;
                protagonist.Attack += equipment.Attack;
                protagonist.Speed += equipment.Speed;
                protagonist.Equip_body = index;
            }
            else if (equipment.Type == 2&&protagonist.Equip_foot == -1)
            {
                protagonist.Defense += equipment.Defense;
                protagonist.Attack += equipment.Attack;
                protagonist.Speed += equipment.Speed;
                protagonist.Equip_foot = index;
            }
            else if (equipment.Type == 3 && protagonist.Equip_weapon == -1)
            {
                protagonist.Defense += equipment.Defense;
                protagonist.Attack += equipment.Attack;
                protagonist.Speed += equipment.Speed;
                protagonist.Equip_weapon = index;
            }
        }
        public void UnEquip(Equipment equipment, Protagonist1 protagonist)
        {
            
            if (equipment.Type == 0&&protagonist.Equip_head!=-1)
            {
                protagonist.Defense -= equipment.Defense;
                protagonist.Attack -= equipment.Attack;
                protagonist.Speed -= equipment.Speed;
                protagonist.Equip_head = -1;
            }
            else if (equipment.Type == 1&&protagonist.Equip_body!=-1)
            {
                protagonist.Defense -= equipment.Defense;
                protagonist.Attack -= equipment.Attack;
                protagonist.Speed -= equipment.Speed;
                protagonist.Equip_body = -1;
            }else if (equipment.Type == 2&&protagonist.Equip_foot!=-1)
            {
                protagonist.Defense -= equipment.Defense;
                protagonist.Attack -= equipment.Attack;
                protagonist.Speed -= equipment.Speed;
                protagonist.Equip_foot = -1;
            }else if (equipment.Type == 3&&protagonist.Equip_weapon!=-1)
            {
                protagonist.Defense -= equipment.Defense;
                protagonist.Attack -= equipment.Attack;
                protagonist.Speed -= equipment.Speed;
                protagonist.Equip_weapon = -1;
            }
        }
        //public int Get_empic(int Lv1,int Lv2)
        //{
        //    int empiric;
        //    if (Lv1 > Lv2)
        //    {
        //        empiric = (int)(10 / (Lv1 - Lv2));
        //    }
        //    else
        //    {
        //        empiric = 4 * (Lv2 - Lv1);
        //    }
        //    return empiric;
        //}
        public abstract void Set_Attributre();
        public abstract void LevelUp(int level, int empic);
        ////返回攻击描述
        //public string Attack_Enemy_Des(Enemy enemy, Protagonist1 protagonist)
        //{
        //    enemy.Hp1 = enemy.Hp1 - protagonist.Attack + enemy.Defense;
        //    return enemy.Name + "遭受你的攻击,剩余血量" + enemy.Hp1;
        //}

        ////返回敌人的状态
        //public Enemy Attack_Enemy_Staus(Enemy enemy, Protagonist1 protagonist)
        //{
        //    enemy.Hp1 = enemy.Hp1 - protagonist.Attack + enemy.Defense;
        //    return enemy;
        //}
    }
    public class ProtagonistYan : Protagonist1
    {

        public override void Set_Attributre()
        {
            this.Attack = 10;
            this.Defense = 10;
            this.Furtune = 5;
            this.Speed = 5;
            this.Power = 5;
            this.Image_path = "protagonist/ren1x.jpg";
            this.Role = 1;
        }
        public override void LevelUp(int level, int empic)
        {
            this.Level += 1;
            this.Empiric -= Level * 10;
            this.Attack +=2;
            this.Defense +=2;
            this.Furtune +=1;
            this.Speed +=1;
            this.Power +=1;
        }
    }
    public class ProtagonistYin : Protagonist1
    {
        public override void Set_Attributre()
        {
            this.Attack = 12;
            this.Defense = 8;
            this.Furtune = 3;
            this.Speed = 8;
            this.Power = 4;
            this.Image_path = "protagonist/ren2x.jpg";
            this.Role = 2;
        }
        public override void LevelUp(int level, int empic)
        {
            this.Level += 1;
            this.Empiric -= Level * 10;
            this.Attack += 3;
            this.Defense += 1;
            this.Furtune += 1;
            this.Speed += 1;
            this.Power += 1;
        }
    }
    public class ProtagonistMo : Protagonist1
    {
        public override void Set_Attributre()
        {
            this.Attack = 8;
            this.Defense = 12;
            this.Speed = 4;
            this.Power = 8;
            this.Furtune = 3;
            this.Image_path = "protagonist/ren3x.jpg";
            this.Role = 3;
        }
        public override void LevelUp(int level, int empic)
        {
            this.Level += 1;
            this.Empiric -= Level * 10;
            this.Attack += 1;
            this.Defense += 3;
            this.Furtune += 1;
            this.Speed += 1;
            this.Power += 1;
        }
    }
}
