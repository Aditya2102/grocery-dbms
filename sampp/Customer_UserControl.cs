using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sampp
{
    public partial class Customer_UserControl : UserControl
    {
        private static Customer_UserControl _instance;
        public static Customer_UserControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Customer_UserControl();
                return _instance;
            }
        }
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Adi\\source\\repos\\sampp\\sampp\\Database1.mdf;Integrated Security=True");

        public Customer_UserControl()
        {
            InitializeComponent();
        }

        private void Customer_UserControl_Load(object sender, EventArgs e)
        {
            refresh();fill();
        }
        public void refresh()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("trig_disp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
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
                dataGridView1.DataSource = ds.Tables[0];
                this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("custo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", textBox1.Text);
            cmd.Parameters.AddWithValue("@b", textBox2.Text);
            cmd.Parameters.AddWithValue("@c", textBox3.Text);
            cmd.Parameters.AddWithValue("@d", textBox6.Text);
            cmd.Parameters.AddWithValue("@e", textBox4.Text);
            cmd.Parameters.AddWithValue("@f", textBox5.Text);
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


            cmd = new SqlCommand("trans", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", textBox1.Text);
            cmd.Parameters.AddWithValue("@b", textBox4.Text);

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
           // MessageBox.Show("ADDED Customer "+textBox2.Text+"("+textBox4.Text+")");
            refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            fill();
        }
        public void fill()
        {
            String str = "Select * from Products";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr;
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                comboBox1.Items.Clear();
                while (dr.Read())
                    comboBox1.Items.Add(dr.GetString(1));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String str = "Select * from Products where P_name='" + comboBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr;
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                    textBox4.Text = dr.GetInt32(0).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }
    }
}
