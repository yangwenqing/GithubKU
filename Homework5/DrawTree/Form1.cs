using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            string s = textBox6.Text;
            int n = Int32.Parse(s);
            drawCayleyTree(n,200,450,100,-Math.PI / 2);
        }
        private Graphics graphics;
        private double th1
        {
            get
            {
                string s = textBox1.Text;
                double d = double.Parse(s);
                return d * Math.PI/180;
            }
        }
        private double th2
        {
            get
            {
                string s = textBox2.Text;
                double d = double.Parse(s);
                return d * Math.PI / 180;
            }
        }
        private double per1
        {
            get
            {
                string s = textBox3.Text;
                double d = double.Parse(s);
                return d ;
            }
        }
        private double per2
        {
            get
            {
                string s = textBox4.Text;
                double d = double.Parse(s);
                return d;
            }
        }
        private double k
        {
            get
            {
                string s = textBox5.Text;
                double d = double.Parse(s);
                return d;
            }
        }
        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n <= 0) return;
            double x1 = x0 + leng * k * Math.Cos(th);
            double y1 = y0 + leng * k * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }
        void drawLine(double x0,double y0,double x1,double y1)
        {
            graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
