using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewRivakes
{
    public class Fight
    {
        Protagonist1 protagonist;
        Enemy enemy;
        
        
        public Fight(Protagonist1 protagonist,Enemy enemy)
        {
            this.protagonist = protagonist;
            this.enemy = enemy;
        }
        public Fight()
        {

        }
        //返回主角攻击敌人描述
        public string Attack_Enemy_Des(Enemy enemy, Protagonist1 protagonist)
        {
            enemy = Status_Change_Ene(enemy, protagonist);
            return enemy.Name + "遭受你的攻击,剩余血量" + enemy.Hp1+"\n";
        }

        //返回敌人的状态
        public Enemy Attack_Enemy_Staus(Enemy enemy, Protagonist1 protagonist)
        {
            return Status_Change_Ene(enemy,protagonist);
        }

        public string Enemy_Attack_Des(Enemy enemy, Protagonist1 protagonist)
        {
            int blood = enemy.Attack - protagonist.Defense >0? enemy.Attack - protagonist.Defense : 0;
            return "你遭受到了" + enemy.Name + "攻击,损失了血量" +(blood).ToString()+"\n"+"剩余血量:"+(protagonist.Hp-blood>0? protagonist.Hp - blood:0).ToString()+"\n";
        }
        public Protagonist1 Enemy_Attack_Sta(Enemy enemy,Protagonist1 protagonist)
        {
            return Status_Change_Pro(enemy,protagonist);
        }

        public Protagonist1 Status_Change_Pro(Enemy enemy, Protagonist1 protagonist)
        {
            int blood = enemy.Attack - protagonist.Defense > 0 ? enemy.Attack - protagonist.Defense : 0;
            protagonist.Hp = protagonist.Hp -blood;
            if (protagonist.Hp < 0)
            {
                protagonist.Hp = 0;
            }
            return protagonist;
        }

        public Enemy Status_Change_Ene(Enemy enemy, Protagonist1 protagonist)
        {
            int blood = protagonist.Attack- enemy.Defense > 0 ? protagonist.Attack - enemy.Defense : 0;
            enemy.Hp1 = enemy.Hp1 - blood;
            if (enemy.Hp1 < 0)
            {
                enemy.Hp1 = 0;
            }
            return enemy;
        }

        public int Get_empic(int Lv1, int Lv2)
        {
            int empiric;
            if (Lv1 > Lv2)
            {
                empiric = (int)(10 / (Lv1 - Lv2));
            }
            else
            {
                empiric = 4 * (Lv2 - Lv1);
            }
            return empiric;
        }
    }
}
