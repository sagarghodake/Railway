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
    public partial class reservationform : Form
    {
        public reservationform()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=D:\\WINDOWSFORMSAPPLICATION10\\WINDOWSFORMSAPPLICATION10\\DATABASE.MDF;Integrated Security=True;User Instance=True");
        SqlCommand cmd;
        SqlDataReader dr;
        string strsql;

        private void clear()
        {
            txtpassenger.Text = "";
            txtname.Text = "";
            txtmobile.Text = "";
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            //comboBox2.Text = "";
            
        }
    
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                strsql = "insert into Reservation values(@Passenger_id,@Name,@Mobile_no,@Date,@From1,@To1,@cost)";

                cmd = new SqlCommand(strsql, con);
                cmd.Parameters.AddWithValue("@Passenger_id", txtpassenger.Text);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Mobile_no", txtmobile.Text);
                cmd.Parameters.AddWithValue("@Date", date.Value.ToString("MM-dd-yyyy"));
                cmd.Parameters.AddWithValue("@From1", textBox1.Text);
                cmd.Parameters.AddWithValue("@To1", textBox2.Text);
                cmd.Parameters.AddWithValue("@cost", txtamount.Text);

                int no = cmd.ExecuteNonQuery();
                MessageBox.Show("Save Record successfully ", no.ToString());

               
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            clear();
           
       
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comb()
        {
            string s = "select * from Booking_cost";
            SqlDataAdapter sda = new SqlDataAdapter(s, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Booking_cost");
            DataTable dt = new DataTable();
            dt = ds.Tables["Booking_cost"];
            comboBox1.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());
            }
            //dataGridView1.DataSource = dt;
        }

        private void reservationform_Load(object sender, EventArgs e)
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
            string s = "select * from Booking_cost where Bid=" + comboBox1.Text;
            //MessageBox.Show(comboBox1.Text);
            SqlDataAdapter sda = new SqlDataAdapter(s, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Booking_cost");
            DataTable dt = new DataTable();
            dt = ds.Tables["Booking_cost"];
            textBox1.Text = dt.Rows[0][1].ToString();
            textBox2.Text = dt.Rows[0][2].ToString();
            txtamount.Text = dt.Rows[0][4].ToString();

            con.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        ctrl.Text = " ";
                    }
                }
                strsql = "select count(Passenger_id) from Reservation";
                cmd = new SqlCommand(strsql, con);
                int no = Convert.ToInt32(cmd.ExecuteScalar());
                if (no == 0)
                    no = 1;
                else
                {

                    strsql = "select max(Passenger_id) from Reservation";
                    cmd = new SqlCommand(strsql, con);
                    no = Convert.ToInt32(cmd.ExecuteScalar());
                    no = no + 1;

                }
                txtpassenger.ReadOnly = true;
                txtpassenger.Text = no.ToString();
                txtpassenger.Focus();
                //btnNew.Enabled = false;
                //BtnSave.Enabled = true;
                //BtnDelete.Enabled = false;
                //Update.Enabled = false;

            }
            catch (Exception ex)
            {
            }
            con.Close();
               
        }
    }
}
