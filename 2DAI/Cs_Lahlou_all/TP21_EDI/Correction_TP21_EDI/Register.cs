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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        public bool formValide()
        {
            bool a = false;
            if(txtBx_Name.Text != "" && txtBx_Phone.Text != "" && txtBx_Email.Text != "" && txtBx_Username.Text != "" && txtBx_Password.Text != "" && cmbBx_Gender.Text != "")
            {
                a = true;
                MessageBox.Show("formvalide=true");
            }
            return a;
        }

        public bool register()
        {
            bool a = false;
            if(formValide())
            {
                Donnees.username = txtBx_Username.Text;
                Donnees.password = txtBx_Password.Text;
                Donnees.name = txtBx_Name.Text;
                Donnees.email = txtBx_Email.Text;
                Donnees.phone = txtBx_Phone.Text;
                Donnees.gender = cmbBx_Gender.Text;
                a = true;

            }
            return a;
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            if (register())
            {

                MessageBox.Show("register=true");
                this.Hide();
                login l = new login();
                l.Show();
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs");
            }
        }

        private void lkLbl_Login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Register r2 = new Register();
            r2.Show();
        }

        private void label14_Click(object sender, EventArgs e)
        {

            this.MinimizeBox = true;
        }

        private void label15_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
