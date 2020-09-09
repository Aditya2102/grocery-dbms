using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace sampp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label4.Hide();
            label8.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Adi\\source\\repos\\sampp\\sampp\\Database1.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        private String getp()
        {
            
            con.Open();
            String temp="";
            String syntax = "SELECT * FROM Login where Property ='" + textBox1.Text + "'";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            while(dr.Read())
                temp = (dr.GetString(1));
            con.Close();
            return temp;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            String p=getp(),pass;
            pass = textBox2.Text;
            if (p == " " || pass == "")
            { label8.Hide();label4.Show(); }
            else if (pass.Equals(p))
            {
                label8.Hide();
                label4.Hide();
                // MessageBox.Show("Login Success");
                Form2 obj = new Form2();
                this.Hide();
                obj.Show();
            }
            else
            {
                label8.Hide();
                label4.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("addlog", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", textBox4.Text);
            cmd.Parameters.AddWithValue("@b", textBox3.Text);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("       <<< INVALID SQL OPERATION! >>>\n" + ex);
            }
            con.Close();
            textBox4.Text = textBox3.Text = "";
            label8.Show();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
