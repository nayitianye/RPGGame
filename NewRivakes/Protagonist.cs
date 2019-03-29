namespace NewRivakes
{
    public  class Protagonist
    {
        private string name ;
        //姓名   用户角色名称
        private int lv;
        //等级   角色的登记
        private string sex;
        //角色的性别
        private int empiric;
        //经验值 角色当前的经验值
        private int Hp;
        //生命值血量
        private int max_Hp;
        //最大的生命值
        private int mp;
        //内力、蓝
        private int max_mp;
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
        private int yan_attack;
        //阳攻击力
        private int yin_attack;
        //阴攻击力
        private int mo_attack;
        //魔攻击力
        private int yan_defense;
        //阳防御力
        private int yin_defense;
        //阴防御力
        private int mo_defense;
        //魔防御力
        private int role;
        //表示角色的类型
        private string image_path;
        //技能数组
        public int[] skills = { -1, -1, -1, -1 };

        public string Name { get => name; set => name = value; }
        public int Lv { get => lv; set => lv = value; }
        public int Empiric { get => empiric; set => empiric = value; }
 
        public int Mp { get => mp; set => mp = value; }
        public int Max_mp { get => max_mp; set => max_mp = value; }
        public int Power { get => power; set => power = value; }
        public int Speed { get => speed; set => speed = value; }
        public int Furtune { get => furtune; set => furtune = value; }
        public int Attack { get => attack; set => attack = value; }
        public int Defense { get => defense; set => defense = value; }
        public int Yan_attack { get => yan_attack; set => yan_attack = value; }
        public int Yin_attack { get => yin_attack; set => yin_attack = value; }
        public int Mo_attack { get => mo_attack; set => mo_attack = value; }
        public int Yan_defense { get => yan_defense; set => yan_defense = value; }
        public int Yin_defense { get => yin_defense; set => yin_defense = value; }
        public int Mo_defense { get => mo_defense; set => mo_defense = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Image_path { get => image_path; set => image_path = value; }
        public int Role { get => role; set => role = value; }
        public int Hp1 { get => Hp; set => Hp = value; }
        public int Max_Hp { get => max_Hp; set => max_Hp = value; }

        private string Description(string name,int mp,int np)
        {
            return name + "当前的血量为：" + mp + "内力为：" + np;
        }

        //返回攻击描述
        public string Attack_Enemy_Des(Enemy enemy,Protagonist protagonist)
        {
            enemy.Hp1 = enemy.Hp1 - protagonist.Attack + enemy.Defense;
            return enemy.Name + "遭受你的攻击,剩余血量" + enemy.Hp1;
        }

        //返回敌人的状态
        public Enemy Attack_Enemy_Staus(Enemy enemy,Protagonist protagonist)
        {
            enemy.Hp1 = enemy.Hp1 - protagonist.Attack + enemy.Defense;
            return enemy;
        }


    }
}
