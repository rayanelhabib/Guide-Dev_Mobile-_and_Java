using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ED_2DAI_TP_9_Correction
{
    internal class FormationDAO
    {
        NpgsqlConnection conn;
        NpgsqlCommand cmd;
        public NpgsqlDataReader dr;

        public FormationDAO(DBConnection db)
        {
            this.conn = db.conn;
        }

        public NpgsqlDataReader recupererTitresFormations()
        {
            try
            {
                cmd = new NpgsqlCommand("select titre from formation", conn);
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
            return dr;
        }

        public void deleteFormation(String titre)
        {
            try
            {
                cmd = new NpgsqlCommand("select numero from formation where titre='"+titre+"'",conn);
                int numero = int.Parse(cmd.ExecuteScalar().ToString());

                cmd = new NpgsqlCommand("delete from demande where formation='" + numero + "'", conn);
                cmd.ExecuteNonQuery();

                cmd = new NpgsqlCommand("delete from formation where numero='" + numero + "'", conn);
                cmd.ExecuteNonQuery();


                cmd = new NpgsqlCommand("delete from formation where titre='"+titre+"'", conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        public String recupererDecsription(String titre)
        {
            String desc = "";
            try
            {
                cmd = new NpgsqlCommand("select description from formation where titre='" + titre + "'", conn);
                desc = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
            return desc;
        }
        public int getFormationNumero(String titre)
        {
            int numero = 0;
            try
            {
                cmd = new NpgsqlCommand("select numero from formation where titre='" + titre + "'", conn);
                numero = int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
            return numero;
        }

    }
}
