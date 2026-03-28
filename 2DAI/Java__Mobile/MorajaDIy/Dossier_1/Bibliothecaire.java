package Dossier_1;
import java.util.*;
public class Bibliothecaire extends Personne {
    private int indice;
    private Date dateAffectation;

    public Bibliothecaire(String num, String nom, int indice, Date dateAffectation) throws ErreurIndice{
        super(num, nom);
        this.indice = indice;
        
        if(indice < 100 || indice > 900 ) {
            throw new ErreurIndice("Erreur Indice");
        }
        this.dateAffectation = dateAffectation;
    }

    public double calculer() {
        double salaireBrut = indice * 30;
        double salaireNet = salaireBrut - (salaireBrut * 0.36);
        return salaireNet;
    }

    public int existeBibliothecaire(Bibliothecaire b) {
        
    }
}
