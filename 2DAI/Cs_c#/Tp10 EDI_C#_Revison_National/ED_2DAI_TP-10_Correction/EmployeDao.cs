using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace ED_2DAI_TP_9_Correction
{
    internal class EmployeDao
    {
        NpgsqlConnection conn;
        NpgsqlCommand cmd;
        public NpgsqlDataReader dr;

        public EmployeDao(DBConnection db)
        {
            this.conn = db.conn;
        }

        public NpgsqlDataReader recupererEmployesFullname()
        {
            try
            {
                cmd = new NpgsqlCommand("select nom||' '||prenom from employe", conn);
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
            return dr;
        }

        public NpgsqlDataReader recupererEmployeNbrFormations(String fullname)
        {
            try
            {
                int matricule = getEmployeMatricule(fullname);
                cmd = new NpgsqlCommand("select employe.matricule,employe.nom||' '||employe.prenom,count(demande.matricule) from employe,demande where employe.matricule=demande.matricule and employe.matricule="+matricule+" group by employe.matricule", conn);
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
            return dr;
        }




        public int getEmployeMatricule(String fullname)
        {
            int matricule = 0;
            try
            {
                cmd = new NpgsqlCommand("select matricule from employe where nom||' '||prenom='"+fullname+"'",conn);
                matricule = int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
            return matricule;
        }

    }
}
