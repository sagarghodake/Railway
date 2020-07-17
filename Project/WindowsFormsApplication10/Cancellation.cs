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
    public partial class cancellationform : Form
    {
        public cancellationform()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=D:\\WINDOWSFORMSAPPLICATION10\\WINDOWSFORMSAPPLICATION10\\DATABASE.MDF;Integrated Security=True;User Instance=True");
        SqlCommand cmd;
        string strsql;

      
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            if (comboBox1.SelectedIndex >= 0)
            {
                string s = "select * from Reservation where Passenger_id=" + comboBox1.Text;
                //MessageBox.Show(comboBox1.Text);
                SqlDataAdapter sda = new SqlDataAdapter(s, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Reservation");
                DataTable dt = new DataTable();
                dt = ds.Tables["Reservation"];
                textBox1.Text = dt.Rows[0][0].ToString();
                textBox2.Text = dt.Rows[0][2].ToString();
                textBox3.Text = dt.Rows[0][3].ToString();
            }
            con.Close();
        }

        private void comb()
        {
            string s = "select * from Reservation";
            SqlDataAdapter sda = new SqlDataAdapter(s, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Reservation");
            DataTable dt = new DataTable();
            dt = ds.Tables["Reservation"];
            comboBox1.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());
            }
            //dataGridView1.DataSource = dt;
        }

        private void cancellationform_Load(object sender, EventArgs e)
        {
            comb();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void c()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                strsql = "delete from Reservation where Passenger_id=" + textBox1.Text;
                cmd = new SqlCommand(strsql, con);
                int j = cmd.ExecuteNonQuery();

                MessageBox.Show("Record is deleted" + j.ToString());


               // clear();
                comb();
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                con.Close();
            }
            c();
        }
    }
}
