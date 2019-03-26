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
        private Protagonist protagonist;

        public Status()
        {
            InitializeComponent();   
        }

        public Status(Protagonist protagonist)
        {
            this.protagonist = protagonist;
            InitializeComponent();
        }

        private void Status_Load(object sender, EventArgs e)
        {
            Image image = Image.FromFile(protagonist.Image_path);
            pictureBox1.Image = image;
            Get_Attaribute();
        }
        private void Get_Attaribute()
        {
            NameLabel.Text = protagonist.Name.ToString();
            RoleLabel.Text = protagonist.Role.ToString();
            LvLabel.Text = protagonist.Empiric.ToString();
            MpLabel.Text = protagonist.Mp.ToString();
            NpLabel.Text = protagonist.Np.ToString();
            AttackLabel.Text = protagonist.Attack.ToString();
            AttackLabel1.Text = protagonist.Yan_attack.ToString();
            AttackLabel2.Text = protagonist.Yin_attack.ToString();
            AttackLabel3.Text = protagonist.Mo_attack.ToString();
            DefenseLabel.Text = protagonist.Defense.ToString();
            DefenseLabel1.Text = protagonist.Yan_defense.ToString();
            DefenseLabel2.Text = protagonist.Yin_defense.ToString();
            DefenseLabel3.Text = protagonist.Mo_defense.ToString();
        }
    }
}
