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
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            lbl_Name.Text = Donnees.name;
            lbl_Username.Text = Donnees.username;
            lbl_Password.Text = Donnees.password;
            lbl_Phone.Text = Donnees.phone;
            lbl_Email.Text = Donnees.email;
            lbl_Gender.Text = Donnees.gender;
        }

        private void lkLbl_Deconnexion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Donnees.name = "";
            Donnees.username = "";
            Donnees.password = "";
            Donnees.phone = "";
            Donnees.email = "";
            Donnees.gender = "";
            this.Hide();
            login l2 = new login();
            l2.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

            this.MinimizeBox = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
