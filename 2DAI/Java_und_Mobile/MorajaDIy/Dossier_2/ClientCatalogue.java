package Dossier_2;
import java.io.ObjectInputStream;
import java.io.PrintWriter;
import java.net.*;
import java.util.ArrayList;

import Dossier_1.Ouvrage;

public class ClientCatalogue {
    private String IP;
    private int Port;
    private Socket s;

    public ClientCatalogue(String IP, int Port) {
        this.IP = IP;
        this.Port = Port;
    }

    public boolean setConnexion() {
        try {
            s = new Socket(IP, Port);
            PrintWriter out = new PrintWriter(s.getOutputStream(), true);
            ObjectInputStream in = new ObjectInputStream(s.getInputStream());
            return true;
        } catch (Exception e) {
            return false;
        }
    }

    public void  demanderOuvragesDisponibles(String categorie) {
        try {
            // nseft Category
            out.println(categorie);

            // n9ra Collection ouvrage
            return (ArrayList<Ouvrage>) in.readObject();
        } catch (Exception e) {
            return null;
        }
    }

}
