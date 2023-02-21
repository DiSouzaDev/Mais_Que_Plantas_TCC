package br.teste;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.SearchView;
import androidx.cardview.widget.CardView;
import androidx.core.view.MenuItemCompat;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.widget.ArrayAdapter;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;

public class ActivityPlantas extends AppCompatActivity {

    RecyclerView recyclerView;

    String s1[], s2[], s3[];

    int images [] = {R.drawable.afelandra,R.drawable.anturio,R.drawable.asplenio,R.drawable.papagaio,
            R.drawable.calathea_zebrina, R.drawable.castelo_fada, R.drawable.difenbachia,R.drawable.monstera_deliciosa,
            R.drawable.croton_amarelo,R.drawable.dracena, R.drawable.espada_sao_jorge,R.drawable.hera_verde,
            R.drawable.jade_verde,R.drawable.lambari_roxo,R.drawable.lavanda_francesa, R.drawable.lirio_paz,
            R.drawable.pacova, R.drawable.peperomia_melancia,R.drawable.peperomia_verde, R.drawable.zamioculca};

    int imageslumi [] = {R.drawable.meia_sombra,R.drawable.meia_sombra,R.drawable.meia_sombra,R.drawable.luz_plena,
            R.drawable.pouca_luz,R.drawable.luz_plena,R.drawable.meia_sombra,R.drawable.meia_sombra,
            R.drawable.luz_plena,R.drawable.meia_sombra,R.drawable.pouca_luz,R.drawable.pouca_luz,
            R.drawable.meia_sombra,R.drawable.meia_sombra, R.drawable.meia_sombra,R.drawable.meia_sombra,
            R.drawable.pouca_luz,R.drawable.meia_sombra,R.drawable.meia_sombra,R.drawable.pouca_luz};

    int imagesrega [] = {R.drawable.rego_semanal,R.drawable.rego_semanal,R.drawable.rego_semanal,R.drawable.rego_semanal,
            R.drawable.rego_semanal,R.drawable.rego_mensal,R.drawable.rego_semanal,R.drawable.rego_semanal,
            R.drawable.rego_quinzenal,R.drawable.rego_quinzenal,R.drawable.rego_mensal,R.drawable.rego_mensal,
            R.drawable.rego_quinzenal, R.drawable.rego_semanal, R.drawable.rego_semanal, R.drawable.rego_semanal,
            R.drawable.rego_semanal,R.drawable.rego_semanal,R.drawable.rego_semanal,R.drawable.rego_quinzenal};

    int imagespet [] = {R.drawable.pet_friendly, R.drawable.not_pet_friendly,R.drawable.pet_friendly,R.drawable.not_pet_friendly,
            R.drawable.pet_friendly,R.drawable.pet_friendly,R.drawable.not_pet_friendly,R.drawable.not_pet_friendly,
            R.drawable.not_pet_friendly,R.drawable.not_pet_friendly,R.drawable.not_pet_friendly,R.drawable.not_pet_friendly,
            R.drawable.not_pet_friendly,R.drawable.not_pet_friendly,R.drawable.not_pet_friendly,R.drawable.not_pet_friendly,
            R.drawable.not_pet_friendly,R.drawable.pet_friendly,R.drawable.pet_friendly,R.drawable.not_pet_friendly};

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_plantas);
        recyclerView = findViewById(R.id.recyclerView);
        getSupportActionBar().hide();


        s1 = getResources().getStringArray(R.array.Plantas);
        s2 = getResources().getStringArray(R.array.Description);
        s3 = getResources().getStringArray(R.array.NomeCientifico);

        MyAdapter myAdapter = new MyAdapter(this, s1, s2, s3, images, imageslumi, imagesrega, imagespet);
        recyclerView.setAdapter(myAdapter);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater menuInflater = getMenuInflater();
        menuInflater.inflate(R.menu.menu, menu);
        MenuItem item  = menu.findItem(R.id.action_search);
        SearchView searchView = (SearchView) MenuItemCompat.getActionView(item);
        searchView.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String query) {


                for(int i = 0; i< s1.length; i++){
                    if(query.equals(s1[i])){
                        Toast.makeText(getApplicationContext(),"Achou : "+s1[i],Toast.LENGTH_SHORT).show();
                    }
                }

                return false;
            }

            @Override
            public boolean onQueryTextChange(String newText) {
                return false;
            }
        });

        return true;
    }
}
