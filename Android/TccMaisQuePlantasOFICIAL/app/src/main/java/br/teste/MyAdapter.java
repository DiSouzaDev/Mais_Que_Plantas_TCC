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
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.recyclerview.widget.RecyclerView;

import org.w3c.dom.Text;

import java.util.ArrayList;

public class MyAdapter extends RecyclerView.Adapter<MyAdapter.MyViewHolder> implements Filterable {

    String data1[], data2[], data3[];
    int images[], imageslumi[], imagesrega[], imagespet[];
    Context context;
    private int position;
    int qtde;


    public MyAdapter(Context ct, String s1[], String s2[], String s3[], int img[], int imgLumi[], int imgRega[], int imgPet[]){
        context = ct;
        data1 = s1;
        data2 = s2;
        data3 = s3;
        images = img;
        imageslumi = imgLumi;
        imagesrega = imgRega;
        imagespet = imgPet;
    }



    @NonNull
    @Override
    public MyViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        LayoutInflater inflater =  LayoutInflater.from(context);
        View view = inflater.inflate(R.layout.my_row, parent, false);
        return new MyViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull MyViewHolder holder, @SuppressLint("RecyclerView") int position) {
        this.position = position;

        holder.NomePlantas.setText(data1[position]);
        holder.lblCientifico.setText(data3[position]);
        holder.lblDescription.setText(data2[position]);
        holder.myImageView.setImageResource(images[position]);
        holder.myImageView5.setImageResource(imageslumi[position]);
        holder.myImageView6.setImageResource(imagesrega[position]);
        holder.myImageView7.setImageResource(imagespet[position]);
        holder.mainLayout.setOnClickListener(new View.OnClickListener()  {
            @Override
            public void onClick(View view){
                Intent intent = new Intent(context, SecondActivity.class);
                intent.putExtra("data1", data1[position]);
                intent.putExtra("data2", data2[position]);
                intent.putExtra("myImageView", images[position]);
                context.startActivity(intent);
            }
        });
    }

    @Override
    public int getItemCount() {
        //int x=(images.length + imageslumi.length + imagesrega.length + imagespet.length);

        return 20;
    }


    @Override
    public Filter getFilter() {
        return null;
    }

    public class MyViewHolder extends RecyclerView.ViewHolder{

        TextView NomePlantas, lblCientifico, lblDescription;
        ImageView myImageView, myImageView5, myImageView6, myImageView7;
        ConstraintLayout mainLayout;

        public MyViewHolder(@NonNull View itemView) {
            super(itemView);
            NomePlantas = itemView.findViewById(R.id.NomePlanta);
            lblCientifico = itemView.findViewById(R.id.lblCientifico);
            myImageView = itemView.findViewById(R.id.myImageView);
            mainLayout = itemView.findViewById(R.id.mainLayout);
            myImageView5 = itemView.findViewById(R.id.myImageView5);
            myImageView6 = itemView.findViewById(R.id.myImageView6);
            myImageView7 = itemView.findViewById(R.id.myImageView7);
            lblDescription = itemView.findViewById(R.id.lblDescription);
        }
    }
}
