## Partie 1 JAVA POO :

1. **Créer la classe Salle avec les attributs :**
```java
public class Salle {
    private int idSalle;
    private String nom;
    private int capacite;
    private String bloc;

    public Salle(int idSalle, String nom, int capacite, String bloc) {
        this.idSalle = idSalle;
        this.nom = nom;
        this.capacite = capacite;
        this.bloc = bloc;
    }

    public int getIdSalle() { return idSalle; }

    public String getNom() { return nom; }

    public int getCapacite() { return capacite; }

    public String getBloc() { return bloc; }

    @Override
    public String toString() {
        return "Salle{" +
                "idSalle=" + idSalle +
                ", nom='" + nom + '\'' +
                ", capacite=" + capacite +
                ", bloc='" + bloc + '\'' +
                '}';
}
```

2. Creer Classe Reservation 
```java
public class Reservation {
    private int idReservation;
    private String nomDemandeur;
    private Date dateReservation;
    private String heureDebut;
    private String heureFin;
    private Salle salle;

    public Reservation(int idReservation, String nomDemandeur, Date dateReservation, String heureDebut, String heureFin, Salle salle) {
        this.idReservation = idReservation;
        this.nomDemandeur = nomDemandeur;
        this.dateReservation = dateReservation;
        this.heureDebut = heureDebut;
        this.heureFin = heureFin;
        this.salle = salle;
    }
    //3. Ajouter dans Reservation une méthode dureeEnHeures() qui retourne la durée de la réservation.
    public int dureeEnHeures() {
        Stringheuredebut = this.heureDebut.substring(0, 2);
        String heurefin = this.heureFin.substring(0, 2);
        return Integer.parseInt(heurefin) - Integer.parseInt(heuredebut);
    }
}
```

4. Écrire une classe TestReservation qui crée 2 salles et 3 réservations puis affiche leurs informations.
```java
public class TestReservation {
    public static void main(String[] args) {
        Salle salle1 = new Salle(1, "Salle A", 100, "A");
        Salle salle2 = new Salle(2, "Salle B", 50, "B");

        Reservation reservation1 = new Reservation(1, "John Doe", new Date(), "10:00", "12:00", salle1);
        Reservation reservation2 = new Reservation(2, "Jane Smith", new Date(), "14:00", "16:00", salle2);
        Reservation reservation3 = new Reservation(3, "Bob Johnson", new Date(), "18:00", "20:00", salle1);

        System.out.println("Salle 1: " + salle1);
        System.out.println("Salle 2: " + salle2);
        System.out.println("Réservation 1: " + reservation1);
        System.out.println("Réservation 2: " + reservation2);
        System.out.println("Réservation 3: " + reservation3);
    }


}
```

## Partie 2 : Client / Serveur TCP/IP 
1. Écrire le code principal d'un serveur TCP Java écoutant sur le port 5000.
```java
public class Serveur {
    public static void main(String[] args) {
        try {
            ServerSocket ss = new ServerSocket(5000);
            System.out.println("Serv dem dans P5000");
//2. Le serveur doit accepter plusieurs clients de manière simple (Thread par client ou Runnable). 
//Présenter le principe général.
            while(true) {
                Socket client = serverSocket.accept();
                new Thread(new Clienthandler(client)).start();


            }
        }
    }
}

public class Clienthandler implements Runnable {
    private Socket clientSocket;
    public Clienthandler(Socket clientSocket) {
        this.clientSocket = clientSocket;
    }

    @Override
    public void run() {
        try {
            BufferedReader in = new BufferedReader(new InputStreamreader(clientSocket.getInputStream()));
            String demande = in.readline();
            System.out,println("demande recue"+ demande);


        }
    }
}
```

## Partie IV - JEE : Servlet / JSP / JSTL :
1. Écrire une servlet ListeReservationServlet qui récupère les réservations depuis la couche DAO puis 
les place dans l'attribut request reservations. 
```java
public class ListeReservationServlet extends HttpServlet {
    protected void doGet(HttpSerletRequest request, HttpServletResponse response) throws ServletException, IOException {
        list<Reservation> reservations = reservation.findAll();
        request.setAttribute("reservations", reservations);

        //2. Faire le forward vers la page reservations.jsp
        request.getRequestDispatcher("/WEB-INF/reservations.jsp").forward(request, response);
        
}
```
3. Écrire le code JSP permettant d'afficher un tableau HTML des réservations avec JSTL <c:forEach>. 
```jsp
<table border="1">
    <thead>
        <tr>
            <th>ID</th>
            <th>Nom demandeur</th>
            <th>Date</th>
            <th>Heure début</th>
            <th>Heure fin</th>
            <th>Salle</th>
        </tr>
    </thead>
    <tbody>
        <c:forEach var="r" items="${reservations}">
            <tr>
                <td>${r.getIdReservation()}</td>
                <td>${r.getNomDemandeur()}</td>
                <td>${r.getDateReservation()}</td>
                <td>${r.getHeureDebut()}</td>
                <td>${r.getHeureFin()}</td>
                <td>${r.getSalle().getNom()}</td>
            </tr>
        </c:forEach>
        <tr>
        <c:choose>
            <c:when test="${reservations.isEmpty()}">
                Aucune réservation disponible'
        </c:choose>

        </tr>
    </tbody>
```
