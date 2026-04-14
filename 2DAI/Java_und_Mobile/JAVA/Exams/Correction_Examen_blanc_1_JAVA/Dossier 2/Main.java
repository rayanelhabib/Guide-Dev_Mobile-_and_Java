import java.io.*;
import java.net.*;
import java.util.ArrayList;
public class Main {
    public static void main(String[] args) {
        
    }
}

/*
    TODO : DOSSIER II : CONSULTATION DISTANTE DU CATALOGUE
 */
class ClientCatalogue {
    private String IP;
    private int Port;
    private Socket s;
    private PrintWriter out;
    private ObjectInputStream in;


/*
* *1. Écrire le constructeur de la classe ClientCatalogue.
*/
    public ClientCatalogue(String IP, int Port) {
        this.IP = IP;
        this.Port = Port;
    }

/*
* *2. Écrire la méthode setConnexion() qui établit la connexion TCP/IP avec le serveur et 
* *initialise les flux out et in. La méthode retourne true en cas de succès et false sinon.
*/
    public boolean setConnexion() {
        try {
            s = new Socket(IP, Port);
            out = new PrintWriter(s.getOutputStream(),true);
            in = new ObjectInputStream(s.getInputStream());
            return true;
            
        } catch (Exception e) {
            return false;
        }
    }


/*
* *3. Écrire la méthode demanderOuvragesDisponibles(String categorie) qui envoie la 
* *catégorie au serveur puis récupère la collection d’ouvrages reçue
*/
    public ArrayList demanderOuvragesDisponibles(String categorie) {
        try {
            out.println(categorie);
            ArrayList<Ouvrage> listeOuvrages = (ArrayList<Ouvrage>) in.readObject();
            return listeOuvrages;

        } catch (Exception e) {
            return null;
        }
    }

/*
* *5. Écrire le code du bloc try/catch/finally permettant de fermer proprement les flux et la 
* *socket côté client.
 */
    public void fermer() {
        try {
            if(i != null) in.close();
            if(out != null) out.close();
            if(s != null) s.close();
        } catch (Exception e) {
                System.out.println("cannot close all connections: " + e.getMessage());
        }
    }

/*
    6. Proposer le type exact des objets Java à utiliser côté serveur pour lire la catégorie 
envoyée par le client et renvoyer la collection d’ouvrages. Justifier brièvement.
*/


}
