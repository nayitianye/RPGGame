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
    public partial class Rivakes : Form
    {
        public Enemy enemy;
        public Rivakes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            enemy = new Enemy(20, 3, 3, 1, "张三");
            richTextBox1.Text += enemy.Description(enemy.Name, "请注意它耍阴招")+"\n";   
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
        }
    }
}
