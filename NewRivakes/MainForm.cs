using System;
using System.Drawing;
using System.Windows.Forms;

namespace NewRivakes
{
    public partial class MainForm : Form
    {
        private Player player;
        private Protagonist1 protagonist;
        private Equipment[] equipment;

        public MainForm()
        {
            InitializeComponent();
        }


        public MainForm(Player player)
        {
            this.player = player;
        }

        public MainForm(Protagonist1 protagonist)
        {
            this.protagonist = protagonist;
            InitializeComponent();
        }

        public MainForm(Protagonist1 protagonist, Equipment[] equipment) : this(protagonist)
        {
            this.equipment = equipment;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Status status = new Status(protagonist);
            status.FormBorderStyle = FormBorderStyle.None;
            status.TopLevel = false;
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(status);
            status.Visible = true;
            status.Show();
        } 

        private void StateBtn_Click(object sender, EventArgs e)
        {
            Status status = new Status(protagonist);
            status.FormBorderStyle = FormBorderStyle.None;
            status.TopLevel = false;
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(status);
            status.Visible = true;
            status.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           IsMdiContainer = true;
        }

        private void RivakesBtn_Click(object sender, EventArgs e)
        {
            Rivakes rivakes = new Rivakes(protagonist);
            rivakes.FormBorderStyle = FormBorderStyle.None;
            rivakes.TopLevel = false;
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(rivakes);
            rivakes.Visible = true;
            rivakes.Show();
        }

        private void PacksackBtn_Click(object sender, EventArgs e)
        {
            EquipAndSkills equipAndSkills = new EquipAndSkills(protagonist);
            equipAndSkills.FormBorderStyle = FormBorderStyle.None;
            equipAndSkills.TopLevel = false;
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(equipAndSkills);
            equipAndSkills.Visible = true;
            equipAndSkills.Show();
        }
    }
}
