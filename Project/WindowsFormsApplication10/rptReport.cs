using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace WindowsFormsApplication10
{
    public partial class rptReport : Form
    {
        public rptReport()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=D:\\WINDOWSFORMSAPPLICATION10\\WINDOWSFORMSAPPLICATION10\\DATABASE.MDF;Integrated Security=True;User Instance=True");
        SqlCommand cmd;
        string strsql;

        private void rptReport_Load(object sender, EventArgs e)
        {

        }

        public void Customer()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Reservation", con);
            Database1DataSet ds = new Database1DataSet();
            sda.Fill(ds, "Reservation");
            CrystalReport1 rpt = new CrystalReport1();
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            con.Close();
        }
        public void Booking()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Booking_cost", con);
            Database1DataSet ds = new Database1DataSet();
            sda.Fill(ds, "Booking_cost");
            Booking rpt = new Booking();
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            con.Close();
        }
        public void Time()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Time", con);
            Database1DataSet ds = new Database1DataSet();
            sda.Fill(ds, "Time");
            Time_rpt rpt = new Time_rpt();
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            con.Close();           
        }
        public void Type_rpt()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Type", con);
            Database1DataSet ds = new Database1DataSet();
            sda.Fill(ds, "Type");
            Type_rpt rpt = new Type_rpt();
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;            
            con.Close();
        }
    }
}
