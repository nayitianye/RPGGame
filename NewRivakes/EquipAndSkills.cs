using System;
using System.Windows.Forms;

namespace NewRivakes
{
    public partial class EquipAndSkills : Form
    {
        private Protagonist1 protagonist;
        private Equipment equipment;
        private int index;

        public EquipAndSkills()
        {
            InitializeComponent();
        }

        public EquipAndSkills(Protagonist1 protagonist)
        {
            this.protagonist = protagonist;
            InitializeComponent();
        }

        private void EquipAndSkills_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Equipment.equipment.Length; i++)
            {
                if (Equipment.equipment[i] == null)
                {
                    break;
                }
                listBox1.Items.Add(Equipment.equipment[i].Name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {
                for (int i = 0; i < Equipment.equipment.Length; i++)
                {
                    if (Equipment.equipment[i] == null)
                    {
                        break;
                    }
                    if (this.listBox1.SelectedItem.ToString() == Equipment.equipment[i].Name)
                    {
                        richTextBox1.Text = Equipment.equipment[i].ToString();
                        equipment = Equipment.equipment[i];
                        index = i;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (equipment == null)
            {
                richTextBox1.Text+="请先选择强化的装备\n";
                return;
            }
            if (protagonist.Equip_body == index ||protagonist.Equip_foot == index || protagonist.Equip_head == index || protagonist.Equip_weapon == index)
            {
                richTextBox1.Text += "请先将装备脱离\n";
                return;
            }
            equipment = equipment.Equip_Level(equipment, protagonist.Money);
            int money= (equipment.Level - 1) * 10;
            protagonist.Cost_money(money);
            if (money > protagonist.Money)
            {
                richTextBox1.Text = "";
                richTextBox1.Text += "金钱不够，请获取更多的金钱\n";
                return;
            }
            richTextBox1.Text = "";
            richTextBox1.Text += "强化后的装备效果：+\n"+equipment.ToString()+"\n";
            richTextBox1.Text += "花费了" + money + "金钱";
        }
    }
}
