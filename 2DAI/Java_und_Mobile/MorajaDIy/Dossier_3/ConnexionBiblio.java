package Dossier_3;
import java.io.*;
import java.sql.*;

public class ConnexionBiblio {
    private String url;
    private String user;
    private String password;
    private Connection cn;



    public ConnexionBibio(String url, String user, String password) {
        this.url = url;
        this.user = user;
        this.password = password;
    }

    public boolean Connection() {
        try {
            cn = DriverManager.getConnection(url, user, password);
            return true;
        } catch (Exception e) {
            return false;
        }
    }


    public ResultSet lireOuvrageDisponible(String categorie) {
        try {
            String sql = "SELECT * FROM OUVRAGE WHERE categorie = ? AND disponible = true";
            PreparedStatement ps = cn.preparedStatement(sql);
            ps.setString(1, categorie);
            return ps.executeQuery();


        } catch {
            return null;
        }
    }







}

