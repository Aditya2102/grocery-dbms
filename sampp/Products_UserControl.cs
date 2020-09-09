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

    public partial class Products_UserControl : UserControl
    {
        private static Products_UserControl _instance;
        public static Products_UserControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Products_UserControl();
                return _instance;
            }
        }
        public Products_UserControl()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Adi\\source\\repos\\sampp\\sampp\\Database1.mdf;Integrated Security=True");


        public void fill()
        {
            comboBox1.Text = "";
            textBox3.Text = "";

            String str = "Select * from Department";

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
        public void fill1()
        {
            comboBox2.Text = "";
            textBox7.Text = "";
            String str1 = "Select * from Seller";
            SqlCommand cmd1 = new SqlCommand(str1, con);
            SqlDataReader dr;
            con.Open();
            try
            {
                dr = cmd1.ExecuteReader();
                comboBox2.Items.Clear();
                while (dr.Read())
                    comboBox2.Items.Add(dr.GetString(1));

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       private void Products_UserControl_Load(object sender, EventArgs e)
        {
            refresh();
            fill(); fill1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";


        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sear", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@a", textBox1.Text);

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
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        public void refresh()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("showee", con);
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
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("prod", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", textBox1.Text);
            cmd.Parameters.AddWithValue("@b", textBox2.Text);
            cmd.Parameters.AddWithValue("@c", textBox3.Text);
            cmd.Parameters.AddWithValue("@d", textBox4.Text);
            cmd.Parameters.AddWithValue("@e", textBox5.Text);
            cmd.Parameters.AddWithValue("@f", textBox7.Text);

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
                SqlCommand cmd = new SqlCommand("dele", con);
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("updat", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", textBox1.Text);
            cmd.Parameters.AddWithValue("@b", textBox2.Text);
            cmd.Parameters.AddWithValue("@c", textBox5.Text);
            cmd.Parameters.AddWithValue("@d", textBox4.Text);
            cmd.Parameters.AddWithValue("@e", textBox3.Text);
            cmd.Parameters.AddWithValue("@f", textBox7.Text);

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

        private void button5_Click(object sender, EventArgs e)
        {
            refresh(); fill(); fill1();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String str = "Select * from Department where D_name='" + comboBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr;
            con.Open();
            try
            {

                dr = cmd.ExecuteReader();
                while (dr.Read())
                    textBox3.Text = dr.GetInt32(0).ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String str = "Select * from Seller where S_name='" + comboBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr;
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                    textBox7.Text = dr.GetInt32(0).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
