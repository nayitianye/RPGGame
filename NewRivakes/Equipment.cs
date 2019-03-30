using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewRivakes
{
    public abstract class Equipment
    {
        public static Equipment[] equipment;
        private int level;
        private int type;
        //装备的类型
        private int attack;
        //装备的攻击力
        private int defense;
        //装备的防御力
        private int speed;
        //装备的加成速度
        private string name;
        //装备的名称
        public int Type { get => type; set => type = value; }
        public int Attack { get => attack; set => attack = value; }
        public int Defense { get => defense; set => defense = value; }
        public int Speed { get => speed; set => speed = value; }
        public string Name { get => name; set => name = value; }
        public int Level { get => level; set => level = value; }

        public override string ToString()
        {
            return "名称：" + Name + "\n攻击加成：+" + Attack + "\n防御力加成：+" + Defense + "\n速度加成：+" + Speed+"\n";
        }

        public Equipment Equip_Level(Equipment equipment,int money)
        {
            int level = equipment.Level;
            if (money > level * 10 && money>0)
            {
                money -= level * 10;
                equipment.Level++;
                equipment.Speed++;
                equipment.Attack++;
                equipment.defense++;
            }
            return equipment;
        }
        public abstract void Init();

        public abstract void GetInit(int level, int attack, int defense, int speed, string name);


    }
    public class HeadEquip : Equipment
    {
        public override void Init()
        {
            this.Level = 0;
            this.Type = 0;
            this.Attack = 1;
            this.Defense = 1;
            this.Speed = 1;
            this.Name = "破旧的头盔";
        }
        public override void GetInit(int level, int attack, int defense, int speed, string name)
        {
            this.Type = 0;
            this.Level = level;
            this.Attack = attack;
            this.Defense = defense;
            this.Speed = speed;
            this.Name = name;
        }
    }

    public class BodyEquip : Equipment
    {
        public override void Init()
        {
            this.Type = 1;
            this.Level = 0;
            this.Attack = 0;
            this.Defense = 3;
            this.Speed = -1;
            this.Name = "破旧的盔甲";
        }
        public override void GetInit(int level, int attack, int defense, int speed, string name)
        {
            this.Type = 1;
            this.Level = level;
            this.Attack = attack;
            this.Defense = defense;
            this.Speed = speed;
            this.Name = name;
        }
    }

    public class FootEquip : Equipment
    {
        public override void Init()
        {
            this.Type = 2;
            this.Level = 0;
            this.Attack = 0;
            this.Defense = 1;
            this.Speed = 2;
            this.Name = "破旧的布鞋";
        }
        public override void GetInit(int level, int attack, int defense, int speed, string name)
        {
            this.Type = 2;
            this.Level = level;
            this.Attack = attack;
            this.Defense = defense;
            this.Speed = speed;
            this.Name = name;
        }
    }

    public class WeaponEquip : Equipment
    {
        public override void Init()
        {
            this.Type = 3;
            this.Level = 0;
            this.Attack = 3;
            this.Defense = 0;
            this.Speed = 0;
            this.Name = "破旧的铁剑";
        }
        public override void GetInit(int level, int attack, int defense, int speed, string name)
        {
            this.Type = 3;
            this.Level = level;
            this.Attack = attack;
            this.Defense = defense;
            this.Speed = speed;
            this.Name = name;
        }
    }

}
