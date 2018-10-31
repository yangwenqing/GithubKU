using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ordertest;

namespace MyForm
{
    public partial class Form1 : Form
    {
        public List<Order> orders = new List<Order>();
        public string KeyWord { set; get; }
        public Form1()
        {
            InitializeComponent();
            bindingSource1.DataSource = orders;
            queryInput.DataBindings.Add("Text", this, "KeyWord");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form1 = new Form();
          
            Button Mybutton1 = new Button();
            TextBox t1 = new TextBox();
            TextBox t2 = new TextBox();
            TextBox t3 = new TextBox();
            TextBox t4 = new TextBox();
            TextBox t5 = new TextBox();
            TextBox t6 = new TextBox();
            TextBox t7 = new TextBox();
            Label l1 = new Label();
            Label l2 = new Label();
            Label l3 = new Label();
            Label l4 = new Label();
            Label l5 = new Label();
            Label l6 = new Label();
            Label l7 = new Label();
            Mybutton1.Text = "确认添加";
            l1.Text = "请输入订单号";
            l1.Location = new Point(10, 10);
            t1.Location = new Point(l1.Left, l1.Height + l1.Top + 10);
            l2.Text = "请输入顾客名称";
            l2.Location = new Point(l1.Left, t1.Height + t1.Top + 10);
            t2.Location = new Point(l1.Left, l2.Height + l2.Top + 10);
            l3.Text = "请输入商品数量";
            l3.Location = new Point(l1.Left, t2.Height + t2.Top + 10);
            t3.Location = new Point(l1.Left, l3.Height + l3.Top + 10);
            l4.Text = "请输入商品名称";
            l4.Location = new Point(l1.Left, t3.Height + t3.Top + 10);
            t4.Location = new Point(l1.Left, l4.Height + l4.Top + 10);
            l5.Text = "请输入商品单价";
            l5.Location = new Point(l1.Left, t4.Height + t4.Top + 10);
            t5.Location = new Point(l1.Left, l5.Height + l5.Top + 10);
            l6.Text = "请输入商品序号";
            l6.Location = new Point(l1.Left, t5.Height + t5.Top + 10);
            t6.Location =new Point(l1.Left, l6.Height + l6.Top + 10);
            l7.Text = "请输入顾客序号";
            l7.Location = new Point(l1.Left, t6.Height + t6.Top + 10);
            t7.Location = new Point(l1.Left, l7.Height + l7.Top + 10);
            Mybutton1.Location = new Point(l1.Left, t7.Height + t7.Top + 10);
            form1.Text = "订单添加";

            form1.FormBorderStyle = FormBorderStyle.FixedDialog;
            form1.Size = new Size(500, 600);
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Controls.Add(l1);
            form1.Controls.Add(l2);
            form1.Controls.Add(l3);
            form1.Controls.Add(l4);
            form1.Controls.Add(l5);
            form1.Controls.Add(t1);
            form1.Controls.Add(t2);
            form1.Controls.Add(t3);
            form1.Controls.Add(t4);
            form1.Controls.Add(t5);
            form1.Controls.Add(t6);
            form1.Controls.Add(t7);
            form1.Controls.Add(l6);
            form1.Controls.Add(l7);
            form1.Controls.Add(Mybutton1);
            Mybutton1.DialogResult = DialogResult.OK;
            form1.AcceptButton = Mybutton1;
            form1.ShowDialog();


            string s1 = t1.Text;
            string s2 = t2.Text;
            string s3 = t3.Text;
            string s4 = t4.Text;
            string s5 = t5.Text;
            string s6 = t6.Text;
            string s7 = t7.Text;
            uint num1 = 0;
            double num2 = 0;

            num1 = UInt32.Parse(s6);
            num2 = Double.Parse(s5);
            ordertest.Goods good = new ordertest.Goods(num1, s4, num2);
            num1 = UInt32.Parse(s7);
            ordertest.Customer cu = new ordertest.Customer(num1, s2);
            num1 = UInt32.Parse(s3);
            ordertest.OrderDetail od = new ordertest.OrderDetail(1, good, num1);
            num1 = UInt32.Parse(s1);
            ordertest.Order or = new ordertest.Order(num1, cu);
            or.AddDetails(od);

            if (form1.DialogResult==DialogResult.OK)
            {
                orders.Add(or);
                form1.Dispose();
                bindingSource1.DataSource = null;
                bindingSource1.DataSource = orders;
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form2 = new Form();
            TextBox t1 = new TextBox();
            Button b1 = new Button();
            Label l1 = new Label();
            l1.Text = "请输入订单号";
            l1.Location = new Point(30, 40);
            t1.Location =new Point (l1.Left, l1.Height + l1.Top + 40);
            b1.Text = "确认删除";
            b1.Location = new Point(l1.Left, t1.Height + t1.Top + 40);
            form2.Controls.Add(l1);
            form2.Controls.Add(t1);
            form2.Controls.Add(b1);
            b1.DialogResult = DialogResult.OK;
            form2.AcceptButton = b1;
            form2.ShowDialog();
            uint num = 0;
            string s = t1.Text;
            num = UInt32.Parse(s);
            if(form2.DialogResult == DialogResult.OK)
            {
                int m = -1;
                for (int n = 0; n < orders.Count(); n++)
                {
                    if (orders[n].Id==num)
                    {
                        m = n;
                    }
                }
                if(m>=0)
                {
                    orders.Remove(orders[m]);
                }
                form2.Dispose();
                    bindingSource1.DataSource = null;
                    bindingSource1.DataSource = orders;
               
            }
        }

        private void queryInput_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = null;
            bindingSource1.DataSource =
              orders.Where(s => s.Customer.Name==KeyWord);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form3 = new Form();
            TextBox t1 = new TextBox();
            TextBox t2 = new TextBox();
            Button b1 = new Button();
            Label l1 = new Label();
            Label l2 = new Label();
           
            l1.Text = "请输入订单号";
            l1.Location = new Point(30, 20);
            t1.Location = new Point(l1.Left, l1.Height + l1.Top + 20);
            l2.Text = "修改后的姓名";
            l2.Location = new Point(l1.Left, t1.Height + t1.Top + 20);
            t2.Location = new Point(l1.Left, l2.Height + l2.Top + 20);
            b1.Text = "确认修改";
            b1.Location = new Point(l1.Left, t2.Height + t2.Top + 20);
            form3.Controls.Add(l1);
            form3.Controls.Add(t1);
            form3.Controls.Add(l2);
            form3.Controls.Add(t2);
            form3.Controls.Add(b1);
            b1.DialogResult = DialogResult.OK;
            form3.AcceptButton = b1;
            form3.ShowDialog();
            uint num = 0;
            string s = t1.Text;
            num = UInt32.Parse(s);
            int m = -1;
            for(int n =0;n<orders.Count();n++)
            {
                if (orders[n].Id==num)
                {
                    m = n;
                }
            }
            s = t2.Text;
            if (form3.DialogResult == DialogResult.OK)
            {
               if(m>=0)
                {
                    orders[m].Customer.Name = s;
                }
                form3.Dispose();
                bindingSource1.DataSource = null;
                bindingSource1.DataSource = orders;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = null;
            bindingSource1.DataSource = orders;
        }
    }
}
