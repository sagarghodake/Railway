using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;

namespace WindowsFormsApplication10
{
    public partial class Bookingcostform : Form
    {
        public Bookingcostform()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=D:\\WINDOWSFORMSAPPLICATION10\\WINDOWSFORMSAPPLICATION10\\DATABASE.MDF;Integrated Security=True;User Instance=True");
        SqlCommand cmd;
        string strsql;

        private void clear()
        {
            txtBid.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                strsql = "insert into Booking_cost values(@Bid,@Form1,@To1,@Departure_time,@Cost)";

                cmd = new SqlCommand(strsql, con);
                cmd.Parameters.AddWithValue("@Bid", txtBid.Text);
                cmd.Parameters.AddWithValue("@Form1", textBox1.Text);
                cmd.Parameters.AddWithValue("@To1",textBox2.Text);
                cmd.Parameters.AddWithValue("@Departure_time", textBox3.Text);
                cmd.Parameters.AddWithValue("@Cost", textBox4.Text);
             
                int no = cmd.ExecuteNonQuery();
                MessageBox.Show("Save Record successfully ", no.ToString());

                string s = "select * from Booking_cost";
                SqlDataAdapter sda = new SqlDataAdapter(s, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Booking_cost");
                DataTable dt = new DataTable();
                dt = ds.Tables["Booking_cost"];
                dataGridView1.DataSource = dt;

               con.Close();
               comb();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            clear();
           
       
        }

        private void comb()
        {
            string s = "select * from Time";
            SqlDataAdapter sda = new SqlDataAdapter(s, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Time");
            DataTable dt = new DataTable();
            dt = ds.Tables["Time"];
            comboBox1.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bookingcostform_Load(object sender, EventArgs e)
        {
            comb();
            string s = "select * from Booking_cost";
            SqlDataAdapter sda = new SqlDataAdapter(s, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Booking_cost");
            DataTable dt = new DataTable();
            dt = ds.Tables["Booking_cost"];
            dataGridView1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string s = "select * from Time where TrainNo=" + comboBox1.Text;
            //MessageBox.Show(comboBox1.Text);
            SqlDataAdapter sda = new SqlDataAdapter(s, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Time");
            DataTable dt = new DataTable();
            dt = ds.Tables["Time"];
            textBox1.Text = dt.Rows[0][1].ToString();
            textBox2.Text = dt.Rows[0][2].ToString();
            textBox3.Text = dt.Rows[0][3].ToString();
            
            con.Close();
        }
    }
}
