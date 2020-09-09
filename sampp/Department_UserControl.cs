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
    public partial class Department_UserControl : UserControl
    {
        private static Department_UserControl _instance;
        public static Department_UserControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Department_UserControl();
                return _instance;
            }
        }
        public Department_UserControl()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Adi\\source\\repos\\sampp\\sampp\\Database1.mdf;Integrated Security=True");


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void refresh()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("show_dept", con);
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
                this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Department_UserControl_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("add_dep", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", textBox1.Text);
            cmd.Parameters.AddWithValue("@b", textBox2.Text);
            cmd.Parameters.AddWithValue("@c", textBox3.Text);
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
            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dele_dep", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@a", textBox1.Text);
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
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update_dep", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", textBox1.Text);
            cmd.Parameters.AddWithValue("@b", textBox2.Text);
            cmd.Parameters.AddWithValue("@c", textBox3.Text);
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
            refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
