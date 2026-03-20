package CorrectionCont2Mob;
public class Message {
    private String id;
    private String msg;
    private String author;

    public Message() {}

    public Message(String id, String msg, String author) {
        this.id = id;
        this.msg = msg;
        this.author = author;
    }

    public String getId() { return this.id;}
    //public void setId(String id) { this.id = id; }

    public String getMsg() { return this.msg; }
    public void setMsg(String msg) { this.msg = msg; };

    public String getAuthor() { return this.author; }
    public void setAuthor(String author) { this.author = author; }
}
