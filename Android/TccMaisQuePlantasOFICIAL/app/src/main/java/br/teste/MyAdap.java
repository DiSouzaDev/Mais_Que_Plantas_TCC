package br.teste;

import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Filter;
import android.widget.Filterable;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.recyclerview.widget.RecyclerView;

import org.w3c.dom.Text;

public class MyAdap extends RecyclerView.Adapter<MyAdap.MyViewHolder> implements Filterable {

    String data3[], data4[];
    int images1[];
    Context context1;
    private int position;

    public MyAdap(Context ct1, String s3[], String s4[], int img1[]){
        context1 = ct1;
        data3 = s3;
        data4 = s4;
        images1 = img1;

    }

    @NonNull
    @Override
    public MyViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        LayoutInflater inflater =  LayoutInflater.from(context1);
        View view = inflater.inflate(R.layout.my_rowtwo, parent, false);
        return new MyViewHolder(view);

    }

    @Override
    public void onBindViewHolder(@NonNull MyViewHolder holder, @SuppressLint("RecyclerView") int position) {
        this.position = position;

        holder.NomeDoenca.setText(data3[position]);
        holder.description2.setText(data4[position]);
        holder.myImageView2.setImageResource(images1[position]);
        holder.mainLayout2.setOnClickListener(new View.OnClickListener()  {
            @Override
            public void onClick(View view){
                Intent intent = new Intent(context1, activitytwo.class);
                intent.putExtra("data3", data3[position]);
                intent.putExtra("data4", data4[position]);
                intent.putExtra("myImageView2", images1[position]);
                context1.startActivity(intent);
            }
        });
    }

    @Override
    public int getItemCount() {
        return images1.length;
    }

    @Override
    public Filter getFilter() {
        return null;
    }

    public class MyViewHolder extends RecyclerView.ViewHolder{

        TextView NomeDoenca, description2;
        ImageView myImageView2;
        ConstraintLayout mainLayout2;

        public MyViewHolder(@NonNull View itemView) {
            super(itemView);
            NomeDoenca = itemView.findViewById(R.id.NomeDoenca);
            description2 = itemView.findViewById(R.id.description2);
            myImageView2 = itemView.findViewById(R.id.myImageView2);
            mainLayout2 = itemView.findViewById(R.id.mainLayout);
        }
    }
}
