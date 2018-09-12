using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            s = textBox1.Text;
            int a = Int32.Parse(s);
            s = textBox2.Text;
            int b = Int32.Parse(s);
            int Answer = a * b;
            label1.Text = "所求两数之积为：" + Answer;
        }
    }
}
