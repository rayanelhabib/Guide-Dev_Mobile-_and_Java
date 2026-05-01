```java
// 1) Classe DAo
public class DAO {
    private Connection con;
    private String URL;
    private String user;
    private String pwd;

    public DAO(String URL, String user, String pwd) {
        this.URL = URL;
        this.user = user;
        this.pwd = pwd;
    }


     // 2) Donner le code de la méthode insertDevice()
     public boolean insertDevice(Device dev) {
        try {
            this.con = DriverManager.getConnection(this.URL, this.user, this.pwd);
            

        }
     }
}
```