import java.util.*;
public class Main {
    public static void main(String[] args) {
        
    }
}


/*
 TODO : DOSSIER I : GESTION DES ADHÉRENTS ET DES OUVRAGES 
* 1. Donner le code du constructeur avec arguments de la classe abstraite Personne.
 */
abstract class Personne {
    private String num;
    private String nom;

    public Personne(String num, String nom) {
        this.num = num;
        this.nom = nom;
    }

/*
* *2. Redéfinir la méthode toString() de la classe Personne afin de retourner : « Numéro : xxx,
*/
    @Override
    public String toString() {
        return "Numero : " + this.num + ", Nom : " + this.nom;
    }

/*
* *3. Redéfinir la méthode equals(Object obj) pour comparer deux personnes selon l’attribut 
num, sans tenir compte de la casse.
*/
    @Override
    public boolean equals(Object obj) {
        if(obj instanceof Personne) {
            Personne p = (Personne) obj;
            return this.num.equalsIgnoreCase(p.num);
        }
        return false;
    }

    public abstract double calculer();
}



/*
* *4. Écrire le constructeur avec arguments de la classe Bibliothecaire. Ce constructeur 
* *déclenche une exception ErreurIndice si l’indice est inférieur à 100 ou supérieur à 900. 
*/
class Bibliothecaire extends Personne {
    private int indice;
    private Date dateAffectation;

    public Bibliothecaire(String num, String nom, int indice, Date dateAfffectation) throws ErreurIndice  {
        super(num, nom);
        if(indice < 100 || indice > 900) {
            throw new ErreurIndice("L'indice doit être compris entre 100 et 900");
        }
        this.indice = indice;
        this.dateAffectation = dateAffectation;
        }

    class ErreurIndice  extends Exception {
        public ErreurIndice(String message) {
            super(message);
        }
    }
/*
* *5. Redéfinir la méthode calculer() de la classe Bibliothecaire sachant que : salaireBrut = 
* *indice * 30 et salaireNet = salaireBrut - (salaireBrut * 0,36).
 */
    @Override
    public double calculer() {
        double salaireBrut = this.indice * 30;
        double salaireNet = salaireBrut - (salaireBrut * 0.36);
        return salaireNet;
    }
}


/*
* *6. Écrire le constructeur avec arguments de la classe Adherent. Le niveau doit être égal à 1, 
* *2 ou 3, sinon une exception ErreurNiveau est déclenchée. (
 */
class Adherent extends Personne {
    private int niveau;
    private Date dateInscription;
    

    public Adherent(String num, String nom, int niveau, Date dateInscription) throws ErreurNiveau {
        super(num, nom);
        if(niveau == 1 || niveau == 2 || niveau == 3) {
            this.niveau = niveau;
            this.dateInscription = dateInscription;
        } else {
            throw new ErreurNiveau("Le niveau doit être égal à 1, 2 ou 3");
        }
    }
    class ErreurNiveau extends Exception {
        public ErreurNiveau(String msg) {
            super(msg);
        }
    }
/*
* *7. Redéfinir la méthode calculer() de la classe Adherent pour retourner le montant de la 
* *cotisation annuelle : 200 + (niveau * 50).
 */
    @Override
    public double calculer() {
        return 200 + (this.niveau * 50);
    }

}

/*
* *8. Dans la classe Bibliotheque, écrire le constructeur qui initialise le nom de la bibliothèque 
* *et les deux collections.
 */
class Ouvrage {
    private String code;
    private String titre;
    private boolean disponible;

    public Ouvrage(String code, String titre, boolean disponible) {
        this.code = code;
        this.titre = titre;
        this.disponible = disponible;
    }
    public String getCode() { return this.code; }
    public Boolean getDisponible() { return this.disponible; }
    public void setDisponible(boolean disponible) { this.disponible = disponible; }
}

class Bibliotheque {
    private String nomBib;
    private ArrayList<Bibliothecaire> listeBibliothecaires;
    private ArrayList<Ouvrage> listeOuvrages;
    
    public Bibliotheque(String nomBib) {
        this.nomBib = nomBib;
        this.listeBibliothecaires = new ArrayList<>();
        this.listeOuvrages = new ArrayList<>();
    }

/*
* *9. Écrire la méthode existeBibliothecaire(Bibliothecaire b) qui retourne l’indice du 
* *bibliothécaire dans la liste, ou -1 s’il n’existe pas
 */
    public int existeBibliothecaire(Bibliothecaire b) {
        int i;
        for(i = 0 ; i< this.listeBibliothecaires.size() ; i++) {
            if(this.listeBibliothecaires.get(i).equals(b)) {
                return i;
            }
        }
        return -1;
    }
/*
* *10. Écrire la méthode ajouterBibliothecaire(Bibliothecaire b) qui évite les doublons.
*/
    public void ajouterBibliothecaire(Bibliothecaire b) {
        if(this.existeBibliothecaire(b) == -1) {
            this.listeBibliothecaires.add(b);
        } else {
            System.out.println("le biblio existe deja");
        }
    }

/*
* *11. Écrire la méthode ajouterOuvrage(Ouvrage o) qui ajoute un ouvrage uniquement si son 
* *code n’existe pas déjà
 */
    public boolean ajouterOuvrage(Ouvrage o) {
        int i;
        for(i = 0 ; i < this.listeOuvrages.size() ; i++) {
            if(this.listeOuvrages.get(i).getCode().equals(o.getCode())) {
                System.out.println("L'ouvrage existe deja");
                return false;
            }
        }
        this.listeOuvrages.add(o);
        return true;
    }

/*
* *12. Écrire la méthode emprunter(String code) qui met disponible à false si l’ouvrage existe 
et est disponible.
*/
    public boolean emprunter(String code) {
        int i;
        for(i = 0; i < this.listeOuvrages.size(); i++) {
            if(this.listeOuvrages.get(i).getCode().equals(code) && this.listeOuvrages.get(i).getDisponible()) {
                this.listeOuvrages.get(i).setDisponible(false);
                return true;
            }
        }
        return false;
    }
}






















