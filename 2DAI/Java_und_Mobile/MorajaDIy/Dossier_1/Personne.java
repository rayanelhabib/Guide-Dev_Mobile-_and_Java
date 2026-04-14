package Dossier_1;
import java.util.*;
public abstract class  Personne {
    private String num;
    private String nom;

    public Personne(String num, String nom) {
        this.num = num;
        this.nom = nom;
    }

    @Override
    public String toString() {
        return "Numero : "+ this.num + " Nom : " + this.nom;
    }

    @Override
    public boolean equals(Object obj) {
        if(obj instanceof Personne) {
            Personne p = (Personne) obj;
            if(this.num.equals(p.num)) return true;
            else return false;
        
        }

    }
}