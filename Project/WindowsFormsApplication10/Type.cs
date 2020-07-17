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
    public partial class Type : Form
    {
        public Type()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=D:\\WINDOWSFORMSAPPLICATION10\\WINDOWSFORMSAPPLICATION10\\DATABASE.MDF;Integrated Security=True;User Instance=True");
        SqlCommand cmd;
        string strsql;

        private void Type_Load(object sender, EventArgs e)
        {
            comb();
            string s = "select * from Type";
            SqlDataAdapter sda = new SqlDataAdapter(s, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Type");
            DataTable dt = new DataTable();
            dt = ds.Tables["Type"];
            dataGridView1.DataSource = dt;
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
           //dataGridView1.DataSource = dt;
        }
        private void clear()
        {
            CodeTextBox.Text="";
            textBox2.Text="";
            textBox3.Text="";
            TypeNameTextBox.Text = "";
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                strsql = "insert into Type values(@TrainNo,@FForm,@TTo,@Type)";

                cmd = new SqlCommand(strsql, con);
                cmd.Parameters.AddWithValue("@TrainNo", CodeTextBox.Text);
                cmd.Parameters.AddWithValue("@FForm", textBox2.Text);
                cmd.Parameters.AddWithValue("@TTo", textBox3.Text);
                cmd.Parameters.AddWithValue("@Type", TypeNameTextBox.Text);

                int no = cmd.ExecuteNonQuery();
                MessageBox.Show("Save Record successfully ", no.ToString());

                con.Close();

                string s = "select * from Type";
                SqlDataAdapter sda = new SqlDataAdapter(s, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Type");
                DataTable dt = new DataTable();
                dt = ds.Tables["Type"];
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            clear();
            
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
            CodeTextBox.Text = dt.Rows[0][0].ToString();
            textBox2.Text = dt.Rows[0][1].ToString();
            textBox3.Text = dt.Rows[0][2].ToString();
            con.Close();
        }
    }
}
