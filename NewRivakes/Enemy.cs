using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewRivakes
{
    public class Enemy
    {
        private int totalHp;
        private int Hp;
        private int attack;
        private int defense;
        private int level;
        private string name;

        public Enemy(int Hp,int attack,int defence,int level,string name)
        {
            this.Attack= attack;
            this.Defense = defence;
            this.TotalHp= Hp;
            this.Hp1 = Hp;
            this.Level= level;
            this.Name = name;
        }

        public int TotalHp { get => totalHp; set => totalHp = value; }
        public int Hp1 { get => Hp; set => Hp = value; }
        public int Attack { get => attack; set => attack = value; }
        public int Defense { get => defense; set => defense = value; }
        public int Level { get => level; set => level = value; }
        public string Name { get => name; set => name = value; }

        public string  Description(string name,string description)
        {
            return name + "凶狠的向你扑来," + description;
        }    
    }
}
