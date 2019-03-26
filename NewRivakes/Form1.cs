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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game game= new Game();
            //game.Show();
            //Game1 game = new Game1();
            game.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Confirm confirm= new Confirm();
            confirm.Show();
        }


    }
}
