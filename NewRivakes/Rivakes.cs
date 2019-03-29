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
            enemy = new Enemy(40, 6, 6, 2, "蟊贼甲");
            richTextBox1.Text += enemy.Description(enemy.Name, "请注意它耍阴招") + "\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button9.Enabled = true;
            richTextBox1.Text = "";
            enemy = new Enemy(60, 9, 9, 3, "恶霸甲");
            richTextBox1.Text += enemy.Description(enemy.Name, "请注意它耍阴招") + "\n";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button9.Enabled = true;
            richTextBox1.Text = "";
            enemy = new Enemy(120, 18, 18, 4, "飞贼甲");
            richTextBox1.Text += enemy.Description(enemy.Name, "请注意它耍阴招") + "\n";
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
    }
}
