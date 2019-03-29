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
    public partial class Status : Form
    {
        //private Protagonist protagonist;
        private Protagonist1 protagonist;
        public int index=-1;
        private Equipment equipment;
        public Status()
        {
            InitializeComponent();   
        }

        public Status(Protagonist1 protagonist)
        {
            this.protagonist = protagonist;
            InitializeComponent();

        }

        //public Status(Protagonist protagonist)
        //{
        //    this.protagonist = protagonist;
        //    InitializeComponent();
        //}

        private void Status_Load(object sender, EventArgs e)
        {
            Image image = Image.FromFile(protagonist.Image_path);
            pictureBox1.Image = image;
            Init_Equipment();
            Get_Attaribute();
            for (int i = 0; i < Equipment.equipment.Length; i++)
            {
                if (Equipment.equipment[i] == null)
                {
                    break;
                }
                listBox1.Items.Add(Equipment.equipment[i].Name);    
            }
        }
 
        private void Get_Attaribute()
        {
            NameLabel.Text = protagonist.Name.ToString();
            RoleLabel.Text = protagonist.Role.ToString();
            LvLabel.Text = protagonist.Level.ToString();
            MpLabel.Text = protagonist.Hp.ToString();
            NpLabel.Text = protagonist.Mp.ToString();
            AttackLabel.Text = protagonist.Attack.ToString();
            DefenseLabel.Text = protagonist.Defense.ToString();
            EmpiricLabel.Text = protagonist.Empiric.ToString();
            MoneyLabel.Text = protagonist.Money.ToString();
            SpeedLabel.Text = protagonist.Speed.ToString();
        }
        private void Init_Equipment()
        {
            if (protagonist.Equip_head == -1)
            {
                Equip1.Text = "未装备";
            }
            else
            {
                Equip1.Text = Equipment.equipment[protagonist.Equip_head].Name;
            }
            if (protagonist.Equip_body == -1)
            {
                Equip2.Text = "未装备";
            }
            else
            {
                Equip2.Text = Equipment.equipment[protagonist.Equip_body].Name;
            }
            if (protagonist.Equip_foot == -1)
            {
                Equip3.Text = "未装备";
            }
            else
            {
                Equip3.Text = Equipment.equipment[protagonist.Equip_foot].Name;
            }
            if (protagonist.Equip_weapon== -1)
            {
                Equip4.Text = "未装备";
            }
            else
            {
                Equip4.Text = Equipment.equipment[protagonist.Equip_weapon].Name;
            }
        }

        private void Equip1_Click(object sender, EventArgs e)
        {
            if (protagonist.Equip_head == -1)
            {
                Equip1.Text = "未装备";
            }
            else
            {
                index = 0;
                richTextBox1.Text = "";
                richTextBox1.Text = Equipment.equipment[index].ToString();
            }  
        }

        private void Equip3_Click(object sender, EventArgs e)
        {
            if (protagonist.Equip_foot == -1)
            {
                Equip3.Text = "未装备";
            }
            else
            {
                index = 2;
                richTextBox1.Text = "";
                richTextBox1.Text = Equipment.equipment[index].ToString();
            }    
        }

        private void Equip2_Click(object sender, EventArgs e)
        {
            if (protagonist.Equip_body == -1)
            {
                Equip2.Text = "未装备";
            }
            else
            {
                index = 1;
                richTextBox1.Text = "";
                richTextBox1.Text = Equipment.equipment[index].ToString();
            }   
        }

        private void Equip4_Click(object sender, EventArgs e)
        {
            if (protagonist.Equip_weapon == -1)
            {
                Equip4.Text = "未装备";
            }
            else
            {
                index = 3;
                richTextBox1.Text = "";
                richTextBox1.Text = Equipment.equipment[index].ToString();
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (index == -1)
            {
                richTextBox1.Text += "请先选择装备\n";
                return;
            }
            if (protagonist.Equip_body != -1 || protagonist.Equip_foot != -1 || protagonist.Equip_head != -1 || protagonist.Equip_weapon != -1)
            {
                protagonist.UnEquip(Equipment.equipment[index], protagonist);
                richTextBox1.Text = "";
                richTextBox1.Text = "卸载了装备:" + Equipment.equipment[index].Name;
            }
            switch (Equipment.equipment[index].Type)
            {
                case 0:
                    Equip1.Text = "未装备";
                    break;
                case 1:
                    Equip2.Text = "未装备";
                    break;
                case 2:
                    Equip3.Text = "未装备";
                    break;
                case 3:
                    Equip4.Text = "未装备";
                    break;
            }
            //卸载装备后装备变为未选中状态
            index = -1;
            Get_Attaribute();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (index == -1)
            {
                richTextBox1.Text += "请先选择武器\n";
                return;
            }
            if (equipment == null)
            {
                return;
            }
           // index = equipment.Type;
            switch (equipment.Type)
            {
                case 0:
                    if (Equip1.Text != "未装备" && Equip1.Text != "")
                    {
                        protagonist.UnEquip(Equipment.equipment[equipment.Type], protagonist);
                        richTextBox1.Text = "";
                        richTextBox1.Text = "卸载了装备:" + Equipment.equipment[equipment.Type].Name+"\n";
                    }
                    protagonist.Equip(equipment, protagonist, index);
                    richTextBox1.Text += "装备了：" + equipment.Name + "\n";
                    Equip1.Text = equipment.Name;
                    break;
                case 1:
                    if (Equip2.Text != "未装备" && Equip2.Text != "")
                    {
                        protagonist.UnEquip(Equipment.equipment[equipment.Type], protagonist);
                        richTextBox1.Text = "";
                        richTextBox1.Text = "卸载了装备:" + Equipment.equipment[equipment.Type].Name + "\n"; 
                    }
                    protagonist.Equip(equipment, protagonist, index);
                    richTextBox1.Text += "装备了：" + equipment.Name + "\n";
                    Equip2.Text = equipment.Name;
                    break;
                case 2:
                    if (Equip3.Text != "未装备" && Equip3.Text != "")
                    {
                        protagonist.UnEquip(Equipment.equipment[equipment.Type], protagonist);
                        richTextBox1.Text = "";
                        richTextBox1.Text = "卸载了装备:" + Equipment.equipment[equipment.Type].Name + "\n";
                    }
                    protagonist.Equip(equipment, protagonist, index);
                    richTextBox1.Text += "装备了：" + equipment.Name + "\n";
                    Equip3.Text = equipment.Name;
                    break;
                case 3:
                    if (Equip4.Text != "未装备" && Equip4.Text != "")
                    {
                        protagonist.UnEquip(Equipment.equipment[equipment.Type], protagonist);
                        richTextBox1.Text = "";
                        richTextBox1.Text = "卸载了装备:" + Equipment.equipment[equipment.Type].Name + "\n";  
                    }
                    protagonist.Equip(equipment, protagonist, index);
                    richTextBox1.Text += "装备了：" + equipment.Name+"\n";
                    Equip4.Text = equipment.Name;
                    break;
            }
            Init_Equipment();
            Get_Attaribute();          
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
                    if(this.listBox1.SelectedItem.ToString()== Equipment.equipment[i].Name)
                    {
                        richTextBox1.Text = Equipment.equipment[i].ToString();
                        equipment = Equipment.equipment[i];
                        index = i;
                    }
                }
            }
        }
    }
}
