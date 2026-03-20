using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ED_2DAI_TP_5_Correction
{
    internal class DAO
    {
        private NpgsqlConnection cnx;
        // Remplacer le type de la variable 'cmd' de NpgsqlTransaction à NpgsqlCommand
        private NpgsqlCommand cmd;

        public DAO(string connectionString)
        {
            try
            {
                cnx = new NpgsqlConnection(connectionString);
                cnx.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur de connexion : " + ex.Message);
            }
        }


        public void inserer(string sql)
        {
            try
            {
                cmd = new 
                    NpgsqlCommand(sql, cnx);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur insertion : " + ex.Message);
            }
        }


        public void modifier(string sql)
        {
            try
            {
                cmd = new NpgsqlCommand(sql, cnx);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur modification : " + ex.Message);
            }
        }


        public void supprimer(string sql)
        {
            try
            {
                cmd = new NpgsqlCommand(sql, cnx);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }


        }
}
