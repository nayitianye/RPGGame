using System;
using System.Windows.Forms;

namespace NewRivakes
{
    public partial class Rivakes : Form
    {
        public Enemy enemy;
        public Fight fight = new Fight();
        private Protagonist1 protagonist;

        public Rivakes()
        {
            InitializeComponent();
        }

        public Rivakes(Protagonist1 protagonist)
        {
            this.protagonist = protagonist;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button9.Enabled = true;
            richTextBox1.Text = "";
            enemy = new Enemy(20, 3, 3, 1, "流氓甲");
            richTextBox1.Text += enemy.Description(enemy.Name, "请注意它耍阴招")+"\n";   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button9.Enabled = true;
            richTextBox1.Text = "";
            enemy = new Enemy(40, 6, 6, 3, "蟊贼甲");
            richTextBox1.Text += enemy.Description(enemy.Name, "请注意它耍阴招") + "\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button9.Enabled = true;
            richTextBox1.Text = "";
            enemy = new Enemy(60, 9, 9,5, "恶霸甲");
            richTextBox1.Text += enemy.Description(enemy.Name, "请注意它耍阴招") + "\n";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button9.Enabled = true;
            richTextBox1.Text = "";
            enemy = new Enemy(120, 18, 18, 10, "飞贼甲");
            richTextBox1.Text += enemy.Description(enemy.Name, "请注意它耍阴招") + "\n";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            button9.Enabled = true;
            richTextBox1.Text = "";
            enemy = new Enemy(240, 24, 24,15 , "采花大盗");
            richTextBox1.Text += enemy.Description(enemy.Name, "你们轻功了得，当心对面跑了") + "\n";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button9.Enabled = true;
            richTextBox1.Text = "";
            enemy = new Enemy(480, 48, 48, 20, "武林盟主");
            richTextBox1.Text += enemy.Description(enemy.Name, "对面是一代武林宗师，内力雄厚") + "\n";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button9.Enabled = true;
            richTextBox1.Text = "";
            enemy = new Enemy(1000, 100, 100, 30, "中神童");
            richTextBox1.Text += enemy.Description(enemy.Name, "江湖上少有对手，虽然你也很强，但小心驶得万年船") + "\n";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += fight.Attack_Enemy_Des(enemy, protagonist) + "\n";
            enemy = fight.Attack_Enemy_Staus(enemy, protagonist);
            richTextBox1.Text += fight.Enemy_Attack_Des(enemy, protagonist) + "\n";
            protagonist = fight.Enemy_Attack_Sta(enemy, protagonist);
            if (enemy.Hp1 <= 0 || protagonist.Hp <= 0)
            {
                if (enemy.Hp1 <= 0)
                {
                    richTextBox1.Text += "你战胜了懦弱的恶人，这只是江湖中的一面,请继续闯荡";
                    protagonist.Empiric += fight.Get_empic(protagonist.Level, enemy.Level);
                    while (protagonist.Empiric > protagonist.Level * 10)
                    {
                        protagonist.LevelUp(protagonist.Level, protagonist.Empiric);
                    }
                }
                else if (protagonist.Hp <= 0)
                {
                    richTextBox1.Text += "小伙子江湖之旅很是险恶，需要多加练习再来闯荡！！！";
                }
                button9.Enabled = false;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text += protagonist.Current_status();
            protagonist.SetSkills(new ConcreteImplementA());
            protagonist.Operation();
            if (protagonist.Mp > protagonist.CostMp())
            {
                protagonist.Mp -= protagonist.CostMp();
                if (protagonist.Hp + Skills.skills[0].HP > protagonist.Max_Hp)
                {
                    protagonist.Hp = protagonist.Max_Hp;
                }
                protagonist.Hp += Skills.skills[0].HP;               
            }
            else
            {
                richTextBox1.Text += "内力不够，技能无法使用";
                richTextBox1.Text += protagonist.Use_Skill();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text += protagonist.Current_status();
            protagonist.SetSkills(new ConcreteImplementB());
            protagonist.Operation();
            if (protagonist.Mp > protagonist.CostMp())
            {
                protagonist.Mp -= protagonist.CostMp();
                protagonist.Defense += Skills.skills[1].Defense;
                richTextBox1.Text += protagonist.Use_Skill();
            }
            else
            {
                richTextBox1.Text += "内力不够，技能无法使用";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text += protagonist.Current_status();
            protagonist.SetSkills(new ConcreteImplementC());
            protagonist.Operation();
            if (protagonist.Mp > protagonist.CostMp())
            {
                protagonist.Mp -= protagonist.CostMp();
                enemy.Hp1 -= Skills.skills[2].Damage;
                richTextBox1.Text += protagonist.Use_Skill();
            }
            else
            {
                richTextBox1.Text += "内力不够，技能无法使用";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text += protagonist.Current_status();
            protagonist.SetSkills(new ConcreteImplementD());
            protagonist.Operation();
            if (protagonist.Mp > protagonist.CostMp())
            {
                protagonist.Mp -= protagonist.CostMp();
                if (protagonist.Mp + Skills.skills[3].MP>protagonist.Max_Mp)
                {
                    protagonist.Mp = protagonist.Max_Mp;
                }
                else
                {
                    protagonist.Mp += Skills.skills[3].MP;
                }
                richTextBox1.Text += protagonist.Use_Skill();
            }
            else
            {
                richTextBox1.Text += "内力不够，技能无法使用";
            }
           
        }

        private void button14_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text+=protagonist.Current_status();
        }
    }
}
