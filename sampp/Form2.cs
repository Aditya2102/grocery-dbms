using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sampp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Opacity = .1;
            timer.Start();

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.0)
                this.Opacity += .025;
            else
                timer.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            this.Hide();
            obj.Show();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(Products_UserControl.Instance))
            {
                panel1.Controls.Add(Products_UserControl.Instance);
                Products_UserControl.Instance.Dock = DockStyle.Fill;
                Products_UserControl.Instance.BringToFront();
            }
            else
            {
                Products_UserControl.Instance.BringToFront();

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(Seller_UserControl.Instance))
            {
                panel1.Controls.Add(Seller_UserControl.Instance);
                Seller_UserControl.Instance.Dock = DockStyle.Fill;
                Seller_UserControl.Instance.BringToFront();
            }
            else
            {
                Seller_UserControl.Instance.BringToFront();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(Customer_UserControl.Instance))
            {
                panel1.Controls.Add(Customer_UserControl.Instance);
                Customer_UserControl.Instance.Dock = DockStyle.Fill;
                Customer_UserControl.Instance.BringToFront();
            }
            else
            {
                Customer_UserControl.Instance.BringToFront();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(Transaction_UserControl.Instance))
            {
                panel1.Controls.Add(Transaction_UserControl.Instance);
                Transaction_UserControl.Instance.Dock = DockStyle.Fill;
                Transaction_UserControl.Instance.BringToFront();
            }
            else
            {
                Transaction_UserControl.Instance.BringToFront();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(A_UserControl1.Instance))
            {
                panel1.Controls.Add(A_UserControl1.Instance);
                A_UserControl1.Instance.Dock = DockStyle.Fill;
                A_UserControl1.Instance.BringToFront();
            }
            else
            {
                A_UserControl1.Instance.BringToFront();

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(b.Instance))
            {
                panel1.Controls.Add(b.Instance);
                b.Instance.Dock = DockStyle.Fill;
                b.Instance.BringToFront();
            }
            else
            {
                b.Instance.BringToFront();

            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(Department_UserControl.Instance))
            {
                panel1.Controls.Add(Department_UserControl.Instance);
                Department_UserControl.Instance.Dock = DockStyle.Fill;
                Department_UserControl.Instance.BringToFront();
            }
            else
            {
                Department_UserControl.Instance.BringToFront();

            }
        }
    }
}
