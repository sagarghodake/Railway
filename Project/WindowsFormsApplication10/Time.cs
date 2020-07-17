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
    public partial class Time : Form
    {
        public Time()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=D:\\WINDOWSFORMSAPPLICATION10\\WINDOWSFORMSAPPLICATION10\\DATABASE.MDF;Integrated Security=True;User Instance=True");
        SqlCommand cmd;
        string strsql;

        private void clear()
        {
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

                strsql = "insert into Time values(@TrainNo,@TForm,@TTo,@DTime)";

                cmd = new SqlCommand(strsql, con);
                cmd.Parameters.AddWithValue("@TrainNo", textBox1.Text);
                cmd.Parameters.AddWithValue("@TForm", textBox2.Text);
                cmd.Parameters.AddWithValue("@TTo", textBox3.Text);
                cmd.Parameters.AddWithValue("@DTime", textBox4.Text);
               
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

        private void Time_Load(object sender, EventArgs e)
        {

        }
    }
}
