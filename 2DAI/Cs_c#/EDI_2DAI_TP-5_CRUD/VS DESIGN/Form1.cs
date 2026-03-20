using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ED_2DAI_TP_5_Correction
{
    public partial class Form1 : Form
    {
        DAO dao;
        // Ajoutez ce champ à la classe Form1 pour corriger l'erreur CS0103
        private TextBox txtBx_Description;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string cnx = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=BDD_BOOK";
                dao = new DAO(cnx);
                MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void btn_Inserer_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = $"INSERT INTO livre(titre, auteur, description, prix) VALUES ('{txtBx_Titre.Text}', '{txtBx_Auteur.Text}', '{txtBx_Description.Text}', {txtBx_Prix.Text})";
                dao.inserer(sql);
                MessageBox.Show("Insertion Reussie ");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void btn_Modifier_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = $"UPDATE livre SET titre='{txtBx_Titre.Text}', auteur='{txtBx_Auteur.Text}', description='{txtBx_Description.Text}', prix={txtBx_Prix.Text} WHERE id={txtBx_ID.Text}";
                dao.modifier(sql);
                MessageBox.Show("Update Reussie");
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void btn_Supprimer_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = $"DELETE FROM LIVRE WHERE id={txtBx_ID.Text}";
                dao.supprimer(sql);
                MessageBox.Show("SUpppression Reussie ");
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);

        }

        }

    }
}
