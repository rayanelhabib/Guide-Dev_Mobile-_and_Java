
import java.io.*;
public class Main {
    
}


/*
 TODO DOSSIER IV : RÉSERVATION WEB DES OUVRAGES (JEE : Servlet / JSP / JSTL
 */


/*
* *1. Écrire le code de la méthode doGet() de la servlet ReservationServlet permettant de 
* *récupérer la liste des ouvrages disponibles via OuvrageDAO, de placer cette liste dans un 
* *attribut request nommé « ouvrages », puis de faire un forward vers /WEB-
* *INF/views/listeOuvrages.jsp.
 */

class ReservationServlet extends HttpServlet {
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        try {
            OuvrageDAO dao = new OuvrageDAO();
            List<Ouvrage> ouvrages = dao.getOuvragesDisponibles();
            request.setAttribute("ouvrages", ouvrages);
            request.getRequestDispatcher("/WEB-INF/views/listeOuvrages.jsp").forward(request, response);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}

/*
* *2.Écrire le code de la page JSP listeOuvrages.jsp qui affiche la collection « ouvrages » 
* *dans un tableau HTML en utilisant JSTL <c:forEach> et EL
 */
