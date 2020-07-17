using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication10
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }              

        private void reservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reservationform frm = new reservationform();
            frm.Show();
        }

        private void cancellationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cancellationform frm = new cancellationform();
            frm.Show();
        }

        private void bookingCostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bookingcostform frm = new Bookingcostform();
            frm.Show();
        }

       private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Aboutusform frm = new Aboutusform();
            frm.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reservationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptReport r = new rptReport();
            r.Customer();
            r.Show();
        }

        private void bookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptReport r = new rptReport();
            r.Booking();
            r.Show();
        }

        private void reservatioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reservationreportform frm = new reservationreportform();
            frm.Show();
        }

        private void timeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Time frm = new Time();
            frm.Show();
        }

        private void timeTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptReport frm = new rptReport();
            frm.Time();
            frm.Show();
        }

        private void typeMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Type frm = new Type();
            frm.Show();
        }

        private void typeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            rptReport frm = new rptReport();
            frm.Type_rpt();
            frm.Show();
        }
    }
}
