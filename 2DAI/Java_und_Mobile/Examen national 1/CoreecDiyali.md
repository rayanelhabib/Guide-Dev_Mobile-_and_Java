## Dossier 1 Structure ui :





2. interface utilisateur
   2. 1. XMl "
```xml
<LinearLayout
    xmlns:android="http://schemas.android.com/apk/res/android"
    android:orientation = "vertical"
    android:layout_width = "match_parent"
    android:layout_height = "mathc_parent">

    <EditText
        android:id = "+id/nomPatient"
        android:hint = "Nom du patient"
        android:layout_width = "match_parent"
        android:layout_height = "wrap_content" />

    <Button
        android:id = "+id/ajouter"
        android:text = "Ajouter"
        android:layout_height = "wrap_content"
        android:layout_width = "wrap_content" />

    <ListeView
        android:id = "+id/liste"
        android:layout_height = "wrap_content"
        android:laout_width = "match_parent">
</LinearLayout>
```

4. 1. Donner le code Java permettant de gérer le clic du bouton
```java
Button btn = finViewById(R.id.ajouter);
EditText nom = findViewById(R.id.nomPatient);
btn.setOnclickListener(v -> {
    String n = nom.getText().toString();
})
```
4. 2.  Afficher un Toast contenant le nom saisi.
```java
Toast.makeText(this, n, TOAST_LENGTH_SHORT).show();
```


## DOSSIER 2
1. Créer une classe Patien
```java
class Patient {
    int id;
    String nom;
    int age;
}

class Rendezous {
    String date;
    String description;
}
```

I. Cycle de vie Activity :
a. 
   - onCreate();
   - onStarrt();
   - onResume();
   - onPause();
   - onStop();
   - onDestroy();

b. Role de Create et Pause et Destroy 


### II. SharedPreferences :
a. auvegarder une valeur :
```java
SharedPreferences sp = SharedPreferences("app", MODE_PRIVATE);
sp.edit().put("nom", "Ali").apply();

```

b. Écrire le code permettant de récupérer cette valeur.
```java
String nom = sp.getString("nom", "");
```

c. Premier Ouverture
```java
boolean first = sp.getBoolean("firstlaunch", false);

if (first) {
    startActivity(new Intent(this, WelcomeActivity.class))
    sp.edit().putBoolean("firstLaunch", false).apply();
}
```


### III Gestion Fichiers :
1. Difference entre stockage interne et externe

2. Sauvegarder texte dasn un fichier
```java
FileOutputStream fos = openFileOutput("data.txt", MODE_APPEND);
String id = UUID.randomUUID().toString();

BUfferedWriter writer = new BufferredWriter(new OutputStreamWriter(openFileOutput("patients.txt", MODE_APPEND)));

writer.write(id + ";" + "Amina" + ";" + 28);
writer.newLine();
writer.close();



ArrayaList<Patient> liste_pateints = new ArrayList<>();
BufferedReader reader = new BufferedReader(new InputStreamReader(openFileInput("patients.txt")));

String ligne;
while ((line = reader.readLine()) != null) {
    String[] p = ligne.split(";");
    Patient patient = new Patient(
        Integer.parseInt(p[0]), p[1],
        Integer.parseInt(p[2])
    );
     liste_patients.add(patient);
}
reader.close();
```



## DOSSIER 3 : LISTES & SQLITE :
1. AdapterView :
1. Roles :
 - Adapter  : relie les donnees ave vue
 - ListView : afficeh les donneees

```java
ArrayAdapter<String> adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, liste);

listeView.setAdapter(adapter);
```

2. SQLite :
a- Dbhelpet (Creation SQLite Databse table) :
```java
public class DBHelper extends SQLiteOpenHelper {
    public DBHelper(Context c) {
        super(c, "db", null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL("CREATE TABLE PATIENT(ID INTEGER PRIMARY KEY,
        nom TEXT, age INTEGER)");
        db.execSQL("CREATE TABLE RendezVous ("+
            "id INTEGER PRIMARY KEY AUTOINCREMENT," +
            "date TEXT, description TEXT,"+
            "patient_id INTEGER, " +
            "FOREIGN KEY(patinet_id) REFERENCES Patient(id)) "
        );
    }
    
    @Override
    pubnlic void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS PATIENT");
        db.execSQL("DROP TABLE IF EXISTS RendezVous");
        onCreate(db);
    }
}

```
b. requete SQL insert, update, delete :
```java
public void insertPatient(Stirng nom , Int age) {
    SQLiteDatabase db = getWritableDatabase();
    ContentValues values = new ContentValues();
    values.put("nom", nom);
    values.put("age", age);
    
    db.insert("Patient", null, values);
    db.close();
}

public void updatePatient(int id, String nom, int age) {
    SQLiteDatabse db = getWritableDatabase();
    ContentValues values = new ContentValues();
    values.put("nom", nom);
    values.put("age", age);
    db.update("Patient", values, "id = ?", new String[]{String.valueOf(id)});
    db.close();
}

public void deletePatient(int id) {
    SQLiteDatabase db = getWritableDatabase();
    db.delete("Patient", "id = ?", new String[]{String.valueOf(id)});
    db.close();
}
```

c. Requete recupere tout les patients :
```java
public ArrayList<Patient> getAllPatients() {
    ArrayList<Patient> liste = new ArrayaList<>();
    SQLiteDatabase db = getReadableDatabase();
    Cursor cursor = db.rawQuery("SELECT * FROM Patient", null);
    if (cursor.moveTOFirst()) {
        do {
            int id = cursor.getInt(0);
            String nom = cursor.getString(1);
            int age = cursor.getInt(2);

            Patient p = new Patient(id, nom, age);
            liste.add(p);
        } while (cursor.moveToNext());

    }
    cursor.close();
    db.close();
    return liste;
}
```


d. enregistrer redezvous:
```java
public void insertRendezVous(RendezVous rdv) {
    SQLiteDatabase db = DBHelper.getWritableDatabase();
    COntentValues values = new ContentValues();
    values.put("data", rdv.date);
    values.put("description", rdv.description);
    values.put("patient_id", rdv.patient_id);
    db.insert("Patient", null, values);
    db.close();
}

public ArrayaList<RendezVous> getRendezVousByPatient(int patient_id) {
    ArrayList<RendezVous> = new ArrayList<>();
    SQLiteDatabase db = DBHelper.getReadableDatabase();
    Cursor cursor = db.rawQuery("SELECT * FROM RendezVous WHERE id = ?", new String[]{String.valueOf(patient_id)});

    if(cursor.moveTOFirst()) {
        do {
            cursor.getInt(0);
            cuursor.getString(1);
            cursor.getString(2);
            cursor.getInt(3);
            
            RendezVous rdv = new RendezVous(id, date, description, patient_id);
            liste.add(rdv);
        } while (cursor.moveToNext());
    }
    cursor.close();
    db.close();
    return liste;
}
```

## Dossier 4  IV : FIREBASE & APLLICA
1. ajoute patient et lire // Lire un patient :
```java
FireBaseDatabase db = FirebaseDatabse.getInstance();

// Get a reference to a specific path (e.g., "users")
DatabaseReference ref = db.getReference("patients");

ref.push().setvalue(patient);

ref.addValueEventListener(new ValueEventListener() {
    public void onDataChange(DataSnapshot ds) {
        for (DataSnapshot d : ds.getChildren()) {
            Patient p = d.getValue(Patient.class);
        }
    }
    }
);
```

