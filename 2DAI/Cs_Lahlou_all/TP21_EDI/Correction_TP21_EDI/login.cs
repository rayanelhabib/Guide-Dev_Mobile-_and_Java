using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Correction_TP21_EDI
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        public bool authentification()
        {
            bool x = false;
            if(txtBx_Username.Text !="" && txtBx_Password.Text !="")
            {
                if(txtBx_Username.Text == Donnees.username && txtBx_Password.Text == Donnees.password)
                {

                    x = true;
                }
            }
            return x;
        }

        private void btn_LLogin_Click(object sender, EventArgs e)
        {
            if (authentification())
            {
                MessageBox.Show("authentification=true");
                this.Hide();
                Profile p = new Profile();
                p.Show();
            }
            else
            {
                MessageBox.Show("Username ou Password incorrecte ! ");
            }
        }

        private void lkLbl_Register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Register r = new Register();
            r.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.MinimizeBox = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
