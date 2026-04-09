<!--/*
* *2.Écrire le code de la page JSP listeOuvrages.jsp qui affiche la collection « ouvrages » 
* *dans un tableau HTML en utilisant JSTL <c:forEach> et EL
 */
-->
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<html>
    <head>
    <title>Liste des ouvrages</title>
</head>
<body>
    <h1>Liste des ouvrages</h1>
    <table border="1">
        <thead>
            <th>ID</th>
            <th>Titre</th>
            <th>Catégorie</th>
            <th>Disponibilité</th>
            <th>Actions</th>
        </thead>
        <tbody>
            <c:forEach var="o" items="${ouvrages}">
                <tr>
                    <td>${o.id}</td>
                    <td>${o.titre}</td>
                    <td>${o.categorie}</td>
                    <td>${o.disponible ? "Disponible" : "Indisponible"}</td>
                    <td><a href="reserverOuvrage?id=${o.id}">Réserver</a></td>
                </tr>
                <!--
            3. Dans cette même JSP, afficher « Disponible » si l’ouvrage est disponible, sinon «
            Indisponible », en utilisant <c:choose>, <c:when> et <c:otherwise>.
            4. Écrire le formulaire HTML/JSP placé dans chaque ligne du tableau permettant d’envoyer 
l’identifiant de l’ouvrage à réserver à la servlet /reservation via la méthode POST.
            -->

            
                <c:choose>
                    <c:when test="${o.disponible}">
                        <td>Disponible</td>
                        <form action="reservation" method="post">
                            <input type="hidden" name="id" value="${o.id}">
                            <input type="submit" value="Réserver">
                            <td><a href="reserverOuvrage?id=${o.id}">Réserver</a></td>
                        </form>
                    </c:when>
                    <c:otherwise>
                        <td>Indisponible</td>
                        <td>Réserver</td>
                    </c:otherwise>
                </c:choose>
            </c:forEach>

            
            
            
        </tbody>
    </table>
</body>
</html>
    