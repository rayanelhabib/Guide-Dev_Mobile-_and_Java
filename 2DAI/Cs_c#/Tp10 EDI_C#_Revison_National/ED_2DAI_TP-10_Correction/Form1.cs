using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ED_2DAI_TP_9_Correction
{
    public partial class Form1 : Form
    {
        DBConnection db;
        DemandeDAO demande;
        FormationDAO formation;
        EmployeDao employe;
        NpgsqlDataReader reader;

        public Form1()
        {
            InitializeComponent();
            db = new DBConnection("server=127.0.0.1;database=BDD_FORMATIONS;userid=postgres;password=1312");
            if (db.connexion())
            {
                demande = new DemandeDAO(db);
                formation = new FormationDAO(db);
                employe = new EmployeDao(db);
            }
           
        }

        private void btn_Generer_Click(object sender, EventArgs e)
        {
            txtBx_Demande.Text = demande.genererNouvelleDemande().ToString();
        }

        public void afficherTitres()
        {
            //afficher titres formations)
            cmbBx_Titre.Items.Clear();
            reader = formation.recupererTitresFormations();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cmbBx_Titre.Items.Add(reader[0]);
                }
            }
            reader.Close();
            formation.dr.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            afficherTitres();

            //afficher employes fullname
            reader = employe.recupererEmployesFullname();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cmbBx_Employe.Items.Add(reader[0]);
                }
            }
            reader.Close();
            employe.dr.Close();

            afficherDemande();



        }

        public void afficherDemande()
        {//afficher les demandes
            reader = demande.recupererDemandes();
            if (reader.HasRows)
            {
                DGV_Demande.Rows.Clear();
                while (reader.Read())
                {
                    DGV_Demande.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
                }
            }
            reader.Close();
            demande.dr.Close();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            //delete formation
            formation.deleteFormation(cmbBx_Titre.Text);
            afficherTitres();
        }

        private void cmbBx_Titre_SelectedIndexChanged(object sender, EventArgs e)
        {
            rTxtBx_Description.Text= formation.recupererDecsription(cmbBx_Titre.Text);
        }

        private void cmbBx_Employe_SelectedIndexChanged(object sender, EventArgs e)
        {
            DGV_Employe.Rows.Clear();
            reader = employe.recupererEmployeNbrFormations(cmbBx_Employe.Text);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DGV_Employe.Rows.Add(reader[0], reader[1], reader[2]);
                }
            }
            reader.Close();
            employe.dr.Close();
        }

        private void btn_FiltrerDate_Click(object sender, EventArgs e)
        {
            reader = demande.recupererDemandesFiltrerDates(dTp_du.Value,dTp_au.Value);
            
            if (reader.HasRows)
            {
                DGV_Demande.Rows.Clear();
                while (reader.Read())
                {
                    DGV_Demande.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
                }
            }
            reader.Close();
            demande.dr.Close();
        }

        private void txtBx_FiltrerTitre_TextChanged(object sender, EventArgs e)
        {
            reader = demande.recupererDemandesFiltrerFormation(txtBx_FiltrerTitre.Text);

            if (reader.HasRows)
            {
                DGV_Demande.Rows.Clear();
                while (reader.Read())
                {
                    DGV_Demande.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
                }
            }
            reader.Close();
            demande.dr.Close();
        }

        private void btn_Ajouter_Click(object sender, EventArgs e)
        {
            int n_demande = int.Parse(txtBx_Demande.Text);
            DateTime du = dTp_du.Value;
            DateTime au = dTp_au.Value;
            int matricule = employe.getEmployeMatricule(cmbBx_Employe.Text);
            int numero = formation.getFormationNumero(cmbBx_Titre.Text);
            demande.ajouterDemande(n_demande, du, au, matricule, numero);
            afficherDemande();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btn_Modifier_Click(object sender, EventArgs e)
        {

            int n_demande = int.Parse(txtBx_Demande.Text);
            DateTime du = dTp_du.Value;
            DateTime au = dTp_au.Value;
            int matricule = employe.getEmployeMatricule(cmbBx_Employe.Text);
            int numero = formation.getFormationNumero(cmbBx_Titre.Text);
            demande.modifierDemande(n_demande, du, au, matricule, numero);
            afficherDemande();
        }

        private void btn_Supprimer_Click(object sender, EventArgs e)
        {
            int n_demande = int.Parse(txtBx_Demande.Text);
            demande.supprimerDemande(n_demande);
            afficherDemande();
        }

        private void selectionnerDemande()
        {
            txtBx_Demande.Text = DGV_Demande.CurrentRow.Cells[0].Value.ToString();
            dTp_du.Value = DateTime.Parse(DGV_Demande.CurrentRow.Cells[1].Value.ToString());
            dTp_au.Value = DateTime.Parse(DGV_Demande.CurrentRow.Cells[2].Value.ToString());
            cmbBx_Employe.Text = DGV_Demande.CurrentRow.Cells[3].Value.ToString();
            cmbBx_Titre.Text = DGV_Demande.CurrentRow.Cells[4].Value.ToString();
        }

        private void DGV_Demande_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectionnerDemande();
        }
    }
}
