```java
public class Device implements Comparable, Serializale {
    private String ref, libelle, adrIp;
    private Date dateFab;

    // 1) Définir un constructeur avec 4 arguments
    public Device(String ref, String libelle, String adrIp, Date dateFab) throws DataNullException{
        if (ref == null || libelle == null || adrIp == null || dateFab == null)throw new DataNullException();
        this.ref = ref;
        this.libelle = libelle;
        this.adrIp = adrIp;
        this.dateFab = dateFab;
    }

    public class DataNullException extends Exception {
        public DataNullException(String message) {
            super(message);
        }
    }


    // 2) Définir un constructeur avec 3 arguments pour initialiser les trois premiers attributs de cette classe. La date de fabrication prend celle du système. Ce constructeur lève l’exception personnalisée nommée « DataNullException »
    public Device(String r, String lib, String ip) throws DataNullException{
        if (ref == null || libelle == null || adrIp == null)throw new DataNullException();
        this.ref = r;
        this.libelle = lib;
        this.adrIp = ip;
        this.dateFab = new Date();
    }


    // 3) Redéfinir la méthode « equals »
    @Override
    public boolean equals(Object ob) {
        if (ob instanceof Device) {
            Device dv = (Device) ob;
            return this.ref.equalsIgnoreCase(dv.ref);
        }
        return false;
        }



    // 4) Redéfinir la méthode « compareTo »
    @Override
    public int compareTo(Object ob) {
        if (ob instanceof Device) {
            Device dv = (Device) ob;
            return this.ref.compareToIgnoreCase(dv.ref);
        }
         return 0;
       
    }


    // 5) Redéfinir la méthode « toString »
    @Override
    public String toString() {
        return "Référence " + this.ref + "Libelle" + this.libelle + "Adresse IP" + this.adrIp + "Date de fabrication" + this.dateFab;
    }

}



// Implémentation de la classe « Publisher » :
public class Publisher extends Device {
    private String natureInformation;

    // 1) Définir un constructeur de 5 arguments
    public Publisher(String ref, String libelle, String adrIp, Date dateFab, String natureInformation) throws DataNullException {
        super(ref, libelle, adrIp, dateFab);
        this.natureInformation = natureInformation;
    }


    // 2) Donner la définition de la méthode « toString »,

    @Override
    public String toString() {
        return super.toString() + "Nature d'information" + this.natureInformation;
    }
}




// Implémentation de la classe « Broker » :
public class Broker {
    private int num;
    private ArrayList<Device> listeDev;

    // 1) Donner le code du constructeur avec un seul argument q
    public Brocker(int num) {
        this.num = num;
        this.listeDev = new ArrayList<>();
    }


    // 2) Donner le code de la méthode addDevice(…)
    public boolean addDevice(Device dev) {
        if(dev !== null) {
            this.listeDev.add(dev);
            return true;
        }
        return false;
    }


    // 3) Donner le corps de la méthode delDevice(int ..) qui supprime un Device de la collection 
    public Device delDevice(int index) {
        for(int i = 0; i < this.listeDev.size(); i++) {
            if(i == index) {
                return this.listeDev.remove(i);
            }
        }
        return null;
    }

    // 4) Coder la méthode delDevice(Device …)
    public boolean delDevice(Device dev) {
        for(int i = 0; i < this.listeDev.size(); i++) {
            if(this.listeDev.get(i).equals(dev)) {
                this.listeDev.remove(i);
                return true;
            }
        }
        return false;
    }



// 5) updateDevice(…) permet de modifier un Device déjà
public Device updateDevice(int index, Device newDev) {
    if(index>=0 && index<this.listeDev.size()) {
        this.listeDev.set(index, newDev);
        return newDev;
    }
    return null;
}



// 6) toString () retourne
@Override
public String toString() {
    String brocker = ""
    for(int i = 0; i < this.listeDev.size(); i++) {
        brocker += this.listeDev.get(i).toString() + "\n";
    }
    return brocker;

}


// 7) sort () permet de trier tous les Devices de la collection
public void sort() {
    Collection.sort(this.listeDev);
}

// 8) savePublishers (String f) permet de sauvegarder tous les équipements « Publishers » dans un fichier d’objets. Donner le code de cette méthode
public boolean savedPublishers(String f) {
    try {
        ObjectOutputStream oos = new ObjectOutputStream(new FileOutputStream(f));
        for(int i = 0; i < this.listeDev.size(); i++) {
            if(this.listeDev.get(i) instanceof Publisher) {
                oos.writeObject(this.listeDev.get(i));
            }
        }
        return true
    } catch (Exception e) {
        return false;
    }
}

```