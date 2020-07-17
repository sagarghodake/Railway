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

        private void timeTableMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timetableform frm = new timetableform();
            frm.Show();
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

        private void reservationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reservationreportform frm = new reservationreportform();
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
    }
}
