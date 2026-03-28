package Dossier_1;
import java.util.ArrayList;

public class Bibliotheque {
    public String nomBib;
    public ArrayList<Bibliothecaire> listeBibliothecaires;
    public ArrayList<Ouvrage> listeOuvrages;

    public Bibliotheque(String nomBib) {
        this.nomBib =  nomBib;
        this.listeBibliothecaires = new ArrayList<>();
        this.listeOuvrages = new ArrayList<>();
    }

    public int existeBibliothecaire(Bibliothecaire b) {
        return listeBibliothecaires.indexOf(b);
    }

    public void ajouterBibliothecaire(Bibliothecaire b) {
        listeBibliothecaires.add(b);
    }

    public void ajouterOuvrage(Ouvrage o) {
        if(!listeOuvrages.contains(o)) listeOuvrages.add(o);

    }

    // Écrire la méthode emprunter(String code) qui met disponible à false si l’ouvrage existe  et est disponible.
    public void emprunter(String code) {
        
    }

}
