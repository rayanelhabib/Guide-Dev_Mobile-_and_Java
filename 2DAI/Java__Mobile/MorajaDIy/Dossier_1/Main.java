package Dossier_1;
import java.util.*;
public class Main {
    public static void main(String[] args) {
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

            
        }



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
                // ja i pasc compris
            }

        }


        public class ErreurIndice extends Exception {
            public ErreurIndice(String message) {
                System.out.println("Erreur : " + message);
            }
        }

        public class ErreurNiveau {
            public ErreurNiveau(String message) {
                System.out.println("Erreur : " + message);
            }
        }



















        
    }
}
