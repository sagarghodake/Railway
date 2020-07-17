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
    public partial class reservationreportform : Form
    {
        public reservationreportform()
       
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=D:\\WINDOWSFORMSAPPLICATION10\\WINDOWSFORMSAPPLICATION10\\DATABASE.MDF;Integrated Security=True;User Instance=True");
        SqlCommand cmd;
        SqlDataReader dr;
        string strsql;

        private void reservationreportform_Load(object sender, EventArgs e)
        {
            string s = "select * from Reservation";
            SqlDataAdapter sda = new SqlDataAdapter(s, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Reservation");
            DataTable dt = new DataTable();
            dt = ds.Tables["Reservation"];
            dataGridView1.DataSource = dt;
            
        }

     
    }
}
