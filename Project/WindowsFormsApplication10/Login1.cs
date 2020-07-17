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
    public partial class Login1 : Form
    {
        public Login1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = "Admin";
            string b = "admin";
            if (a == txtusername.Text && b == txtpassword.Text)
            {
                MessageBox.Show("Wel-come to the Project");
                this.Hide();
                mainform frm = new mainform();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Unauthorized User. Try again.....");
            }
       
        }

       
       
    }
}
