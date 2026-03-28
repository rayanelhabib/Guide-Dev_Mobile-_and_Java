package Dossier_1;
import java.util.*;
public class Adherent extends Personne {
    private int niveau;
    private Date dateInscription;

    public Adherent(String nom, String num, int niveau, Date dateInscription) throws ErreurNiveau {
        super(nom, num);
        this.dateInscription = dateInscription;
        if(niveau < 1 || niveau > 3) {
            throw new ErreurNiveau("Erreur Niveau");
        }
        this.niveau = niveau;
    }

    @Override
    public double calculer() {
        double montant =  200 + (niveau * 50);
        return montant;
    }




}
