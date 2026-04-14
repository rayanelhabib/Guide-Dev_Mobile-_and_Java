using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace ED_2DAI_TP_9_Correction
{
    internal class DBConnection
    {
        public NpgsqlConnection conn;
        public DBConnection(String connectionString)
        {
            conn = new NpgsqlConnection(connectionString);
        }
        public bool connexion()
        {
            bool x = false;
            try
            {
                conn.Open();
                x = true;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
            return x;
        }

    }
}
