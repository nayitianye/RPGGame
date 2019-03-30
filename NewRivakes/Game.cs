using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewRivakes
{
    public partial class Game : Form
    {

        int type = 4;
        string strsex;
        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("22 岁，其父天道真君原是天神敎的主要首领，但经历天神灭劫事件当中，" +
                "对天神敎所倡导的教义持怀疑态度，多次秘密通知、协助剑皇等人粉碎天神教阴谋，后被降世神君发现，" +
                "追杀至龙口关，联同剑皇等对抗降世神君，最终与傲天客舍身成仁击败降世神君，其母在护其逃亡其中被天神教众杀害，" +
                "年幼的他被剑皇的总护法凌峰所救，从此在道火村修炼武功成长为正派的后继人才。他与任天有深厚的交情，" +
                "自从任天被陷害沦落为逃亡者之后，为了给任天洗清冤屈而努力揭开所有事件的真相。 ");
           type = 1;
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("23 岁，他的全部亲人都在天神灭劫事件中，被当作祭品祭拜了三道行神。" +
                "当时他的母亲趁着天道侠客一家逃离天神敎的混乱局面，冒着生命危险把风云霸子从天神敎的魔爪中救出。" +
                "后来成为孤儿沦落天涯时，被刀帝的门人官叶所收留，培养成为了很受期望的杀手。" +
                "但由于天神祭品事件来的后遗症，潜在心中的魔性经常发作而倍受折磨。" +
                "为了摆脱自己被诅咒了的命运，决心与天神敎展开孤立的战斗。");
            type = 2;
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("22 岁，他的祖上是以前辅佐武神的英雄门第，但由于传家家谱被误传是天印，而遭到了灭门之灾。" +
                "天生意志坚强躲在母亲怀中目睹亲人被杀也未露声息，终于保住了性命。" +
                "后被魔尊门人血流天刹获救，教导其武功，时刻不忘记灭门大仇，" +
                "逐抛弃了人性选择成为魔人的孤独道路，成为魔尊血盟的新培武士之中最强的夜叉。");
            type = 3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请取一个响亮的称呼！");
                return;
            }
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("请选择性别！");
                return;
            }
            Equipment.equipment = new Equipment[20];
            Equipment.equipment[0] = new HeadEquip();
            Equipment.equipment[0].Init();
            Equipment.equipment[1] = new BodyEquip();
            Equipment.equipment[1].Init();
            Equipment.equipment[2] = new FootEquip();
            Equipment.equipment[2].Init();
            Equipment.equipment[3] = new WeaponEquip();
            Equipment.equipment[3].Init();
            Equipment.equipment[4] = new WeaponEquip();
            Equipment.equipment[4].GetInit(10,5, 0, 1, "普通的铁剑");
            Equipment.equipment[5] = new HeadEquip();
            Equipment.equipment[5].GetInit(10, 0, 2, -1, "普通的头盔");
            Equipment.equipment[6] = new FootEquip();
            Equipment.equipment[6].GetInit(10, 1, 0, 3, "普通的皮鞋");
            Equipment.equipment[7] = new FootEquip();
            Equipment.equipment[7].GetInit(10, 0, 3, -3, "普通的锁子甲");
            Skills.skills = new Skills[4];
            Skills.skills[0] = new ConcreteImplementA();
            Skills.skills[0].Init();
            Skills.skills[1] = new ConcreteImplementB();
            Skills.skills[1].Init();
            Skills.skills[2] = new ConcreteImplementC();
            Skills.skills[2].Init();
            Skills.skills[3] = new ConcreteImplementD();
            Skills.skills[3].Init();
            Protagonist1 protagonist = null ;
            if (type != 4)
            {
                protagonist = ProtagoinstFactory.CreateProtagoinst(type);
            }
            protagonist.Init(textBox1.Text.ToString(), strsex);
            protagonist.Set_Attributre();
            protagonist.Equip(Equipment.equipment[0],protagonist,0);
            protagonist.Equip(Equipment.equipment[1], protagonist,1);
            protagonist.Equip(Equipment.equipment[2], protagonist,2);
            protagonist.Equip(Equipment.equipment[3], protagonist,3);
            protagonist.Init(textBox1.Text.ToString(),strsex);
            Hide();
            MainForm mainForm = new MainForm(protagonist);
            mainForm.Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            strsex = "女";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            strsex = "男";
        }


    }
}
