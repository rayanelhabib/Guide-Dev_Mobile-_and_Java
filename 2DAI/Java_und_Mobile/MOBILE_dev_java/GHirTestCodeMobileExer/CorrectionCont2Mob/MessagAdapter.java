package CorrectionCont2Mob;

import android.content.Context;
import java.util.ArrayList;

import javax.swing.text.View;

public class MessagAdapter {
    Context context;
    ArrayList<String> MsgList;
    LayoutInflater inflater;

    public MessageAdapter(Context context, ArrayList<Message> MsgList) {
        this.context = context;
        this.MsgList = MsgList;
        this.inflater = LayoutInflater.from(context);
    }

    /*
        Les Methdoe qui se trouve dans l adapter personaliser :
        !- getCount() : **retourne le nombre d element dans la liste**
        !- getItem(int position) : **retourne l element a la position donnee**
        ! - getItemId(int position) : **retourne L id de l element a la postion donnee**
        !- getView(int postion, View convertView, ViewGroup parent) : **retourne la vue personnaliser de l element a la position donnee**
     */

        public int getCount() { return MsgList.size(); }

        public Object getItem(int position) { return  MsgList.get(position); }

        public long getItemId(int position) { return position; }

        public View getView(int position, View ConvertView, ViewGroup parent) {
            View view = inflater.inflate(R.layout.item_message, parent, false);

            TextView txtAuthor = view.findViewById(R.id.txtAuthor);
            TextView txtMsg = view.findViewById(R.id.txtMsg);

            Message message = MsgList.get(position);
            txtAuthor.setText(message.getAuthor());
            txtMsg.setText(message.getMsg());

            return view;
        
        }
}
