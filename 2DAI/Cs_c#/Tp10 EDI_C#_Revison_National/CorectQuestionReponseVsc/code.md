## Tp 10 Application complète ##
1. Créer la base de données « BDD_Formations 

2. Concevoir les interfaces graphiques de l’application

3. Créer une classe DBConnection qui gère la connexion avec la base de données PostgreSQL. Cette 
classe doit contenir : 

```csharp
    using Npgsql;
    using System.Data;

    public class DbConnection {
        public NpgsqlConnection conn;

        public DbConnection(String connectionString) {
            conn = new NpgsqlConnection(connectionString);
        }
        // 4. Dans la classe DBConnection, créer une méthode F_connexion() de type bool qui
        public bool F_connexion() {
            try {
                if (conn.State == ConnectionState.closed) {
                    conn.open();
                }
                return true;
            } catch {
                return false;
            }
        }
    }
```

5. Créer une classe FormationDAO
```csharp
public class FormationDAO {
    private NpgsqlConnection conn;
    private NpgsqlCommand comm;
    private NpgsqlDataReader dr;

    public FormationDAO(DbConnection db) {
        conn = db.conn;
    }


//6. créer la méthode recupererTitresFormations()
public NpgsqlDataReader recupererTitresFormations() {
    string sql = "SELECT titre FROM formation";
    cmd = new NpgsqlCommand(conn, sql);
    dr = cmd.ExecuteReader();
    return dr;
}


// 7.  créer la méthode recupererDescription(String titre)
public string recupererDescription(string titre) {
    string desc = "";
    try {
        cmd = new NpgsqlCommand("SELECT description FROM formation WHERE titre = '" + titre + "'", conn);
        desc = int.Parse(cmd.executeScalar().toString());
    } catch (Exception ex) {
        MessageBox.show(ex.Message)
    }
    return desc;
}


//  8. créer la méthode getFormationNumero(String titre)
public int getFormationNumero(string titre) {
    int numero = 0;
    try {
        cmd = NpgsqlCommand("SELECT )
    }

}
``