using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ED_2DAI_TP_9_Correction
{
    internal class DemandeDAO
    {
        NpgsqlConnection conn;
        NpgsqlCommand cmd;
        public NpgsqlDataReader dr;

        public DemandeDAO(DBConnection db)
        {
            this.conn = db.conn;
        }

        public int genererNouvelleDemande()
        {
            int numero = 0;
            try
            {
                cmd = new NpgsqlCommand("select max(n_demande) from demande",conn);
                numero = int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
            return numero+1;
        }


        public NpgsqlDataReader recupererDemandes()
        {
            try
            {
                cmd = new NpgsqlCommand("select n_demande,date_debut,date_fin,employe.nom||' '||employe.prenom,formation.titre from demande,employe,formation where demande.formation=formation.numero and demande.matricule=employe.matricule",conn);
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
            return dr;
        }
        
        public NpgsqlDataReader recupererDemandesFiltrerDates(DateTime du, DateTime au)
        {
            try
            {
                cmd = new NpgsqlCommand("select n_demande,date_debut,date_fin,employe.nom||' '||employe.prenom,formation.titre from demande,employe,formation where demande.formation=formation.numero and demande.matricule=employe.matricule and date_debut>='"+du+"' and date_fin<='"+au+"'", conn);
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
            return dr;
        }
        public NpgsqlDataReader recupererDemandesFiltrerFormation(String titre)
        {
            try
            {
                cmd = new NpgsqlCommand("select n_demande,date_debut,date_fin,employe.nom||' '||employe.prenom,formation.titre from demande,employe,formation where demande.formation=formation.numero and demande.matricule=employe.matricule and formation.titre like '%"+titre+ "%' ", conn);
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
            return dr;
        }

        public void ajouterDemande(int n_demande,DateTime debut, DateTime fin,int matricule,int formation)
        {
            try
            {
                cmd = new NpgsqlCommand("insert into demande values("+n_demande+",'"+debut+"','"+fin+"',"+matricule+","+formation+")", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }
        public void modifierDemande(int n_demande, DateTime debut, DateTime fin, int matricule, int formation)
        {
            try
            {
                cmd = new NpgsqlCommand("update demande set date_debut='"+debut+"',date_fin='"+fin+"',matricule="+matricule+",formation="+formation+" where n_demande="+n_demande+"", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }
        public void supprimerDemande(int n_demande)
        {
            try
            {
                cmd = new NpgsqlCommand("delete from demande where n_demande = "+n_demande+"", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
