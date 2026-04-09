import java.sql.*;
public class Main {
    
}
class ConnexionBiblio {
    private String url, user, password;
    private Connection conn;


/*
* *1. Donner l’URL JDBC complète permettant de se connecter à la base « BiblioDB » sur ce 
* *serveur MySQL
! url = "jdbc:mysql://192.168.1.20:3306/BiblioDB";
 */

/*
* *2.Écrire le constructeur de la classe ConnexionBiblio.
 */
    public ConnexionBiblio(String url, String user, String password) {
        this.url = url;
        this.user = user;
        this.password = password;
    }


/*
* *3. Écrire la méthode connecter() qui se connecte à la base en utilisant les attributs déjà 
* *initialisés. Elle retourne true en cas de succès et false en cas d’échec.
 */
    public boolean connecter() {
        try {
            conn = DriverManager.getConnection(url, user, password);
            return true;
        } catch (Exception e) {
            return false;
        }
    }



/*
* *4. Écrire la méthode lireOuvragesDisponibles(String categorie) qui retourne tous les 
* *ouvrages disponibles d’une catégorie donnée sous forme d’un ResultSet. En cas d’échec, la 
* *méthode retourne null.
 */
    public ResultSet lireOuvragesDisponibles(String categorie) {
        try {
            String sql = "SELECT * FROM Ouvrage WHERE categorie = ?;";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1,categorie);
            ResultSet rs = ps.executeQuery();
            return rs;
        } catch (Exception e) {
            return null;
        }
    }


/*
* *5. Écrire la méthode ajouterOuvrage(Ouvrage o) en utilisant une requête SQL paramétrée.
 */
    public boolean ajouterOuvrage(Ouvrage o) {
        try {
            String sql = "INSERT INTO Ouvrage(code, titre, disponible) VALUES(?,?,?)";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1,o.getCode());
            ps.setString(2,o.getTitre());
            ps.setBoolean(3,o.getDisponible());
            ps.executeUpdate();
            return true;

        } catch (Exception e) {
            return false;
        }
    }


/*
* *6. Écrire la méthode modifierDisponibilite(int id, boolean disponible) qui met à jour le champ 
* *disponible d’un ouvrage
 */
    public boolean modifierDisponibilite(int id, boolean disponible) {
        try {
            String sql = "UPDATE Ouvrage SET disponible = ? where id = ?;";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setBoolean(1, disponible);
            ps.setInt(2, id);
            ps.executeUpdate();
            return true;
        } catch (Exception e) {
            return false;
        }
    }


/*
* *7. Écrire la méthode fermer() permettant de fermer la connexion à la base de données. 
 */

    public boolean fermer() {
        try {
            if(conn != null) {
                conn.close();
                return true;
            }
        } catch (Exception e) {
            return false;
        }
    }











}
