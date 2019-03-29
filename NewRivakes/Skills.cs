using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewRivakes
{
    public abstract class Skills
    {
        public static Skills[] skills;
        private string name;
        private int mP;
        private int hP;
        private int damage;
        private int defense;
        private int type;   //表示技能的类型：用于自身还是用于自己

        public string Name { get => name; set => name = value; }
        public int MP { get => mP; set => mP = value; }
        public int HP { get => hP; set => hP = value; }
        public int Damage { get => damage; set => damage = value; }
        public int Defense { get => defense; set => defense = value; }
        public int Type { get => type; set => type = value; }

        public void Set(string name, int mp, int hp, int damage, int defense, int type)
        {
            this.Name = name;
            this.MP = mp;
            this.HP = hp;
            this.Damage = damage;
            this.Defense = defense;
            this.Type = type;
        }

        public abstract void Init();
        public abstract void Operation();

        public abstract int CostMP();
    }
    public class ConcreteImplementA : Skills
    {
        public override void Operation()
        {
            Console.WriteLine("使用了A技能");
        }

        public override void Init()
        {
            this.Name = "技能A";
            this.HP = 10;
            this.MP = 0;
            this.Damage = 0;
            this.Defense = 0;
            this.Type = 0;
        }
        public override int CostMP()
        {
            return 5;
        }
    }
    public class ConcreteImplementB: Skills
    {
        public override void Operation()
        {
            Console.WriteLine("使用了B技能");
        }
        public override void Init()
        {
            this.Name = "技能B";
            this.HP = 0;
            this.MP = 0;
            this.Damage = 0;
            this.Defense = 2;
            this.Type = 0;
        }
        public override int CostMP()
        {
            return 10;
        }
    }
    public class ConcreteImplementC : Skills
    {
        public override void Operation()
        {
            Console.WriteLine("使用了C技能");
        }
        public override void Init()
        {
            this.Name = "技能C";
            this.HP = 0;
            this.MP = 0;
            this.Damage = 20;
            this.Defense = 0;
            this.Type = 1;
        }
        public override int CostMP()
        {
            return 15;
        }

    }
    public class ConcreteImplementD : Skills
    {
        public override void Operation()
        {
            Console.WriteLine("使用了D技能");
        }
        public override void Init()
        {
            this.Name = "技能D";
            this.HP = 0;
            this.MP = 100;
            this.Damage = 0;
            this.Defense = 0;
            this.Type = 0;
        }
        public override int CostMP()
        {
            return 40;
        }
    }

}
