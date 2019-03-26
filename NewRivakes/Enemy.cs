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
            this.attack= attack;
            this.defense = defence;
            this.totalHp= Hp;
            this.Hp = Hp;
            this.level= level;
            this.name = name;
        }
        public string  Description(string name,string description)
        {
            return name + "凶狠的向你扑来," + description;
        }

        public int TotalHp { get; set; }
        public int Hp1 { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Level { get ; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
