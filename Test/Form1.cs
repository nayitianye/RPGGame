using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test test2 = new Test();
            test2.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(test2);
            test2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Test test2 = new Test();
            test2.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(test2);
            test2.Show();
        }
    }
}
