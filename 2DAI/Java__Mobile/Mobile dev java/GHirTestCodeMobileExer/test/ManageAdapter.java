package test;

import com.sun.jdi.BooleanType;

import CorrectionControle2Mob.Message;

import java.rmi.server.UID;
import java.util.ArrayList;

import javax.naming.Context;
import javax.swing.text.View;

/*public class ManageAdapter extends BaseAdapter {
    private Context context;
    private List<ManageItem> items;

    public ManageAdapter(Context context, List<ManageItem> items) {
        this.context = context;
        this.items = items;
    }

    @Override
    public int getCount() {
        return items.size();
    }

    @Override
    public Object getItem(int position) {
        return items.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        if (convertView == null) {
            convertView = LayoutInflater.from(context).inflate(R.layout.manage_item_layout, parent, false);
        }

        TextView title = convertView.findViewById(R.id.manage_item_title);
        ImageView icon = convertView.findViewById(R.id.manage_item_icon);

        ManageItem item = items.get(position);
        title.setText(item.getTitle());
        icon.setImageResource(item.getIconResId());

        return convertView;
    }

}*/


public class ManageAdapter extends BaseAdapter {
    Context context;
    ArrayList<Message> Lmsg;
    LayoutInflater inflater;
    
    public ManageAdapter(Context context, ArrayList<Message> lmsg) {
        this.context = context;
        this.Lmsg = lmsg;
        this.inflater = LyoutInflater.from(context)
    }

    public int getCount() {
        return lmsg.size();
    }

    public Object getItem(int position) {
        return lmsg.get(position);
    }

    public int getItemId(int position) {
        return position;
    }

    public View getView(int position, View convertView, ViewGroup parent) {
        View view = inflater.inflate(R.item_message, parent, false);
        TextView author = View.findViewById(R.id.author);
        TextView message = View.findViewById(R.id.message);

        Message msg = lmsg.get(position);
        author.setText(msg.getAuthor());
        message.setText(msg.getMessage());
        return view;
    }



        Button btnAjouter = findViewById(R.id.btn_manage);
        editText edAuthor = findViewById(R.id.ed_author);
        editText edContent = findViewById(R.id.ed_content);

        btnAjouter.setOnclickListener(v-> {
            String author = edAuthor.getText().toString();
            String Content = edContent.getText().toString();

            if(author.isEmpty()) edAuthor.setError("Author is required");
            if(Content.isEmpty()) edContent.setError("Content is required");

            String id = UID.randomUUID().toString();
            Message msg = new Message(id, authore, Content);

            Lmsg.add(msg);
            adapter.notifyDataSetChanged();
        
    });
}   