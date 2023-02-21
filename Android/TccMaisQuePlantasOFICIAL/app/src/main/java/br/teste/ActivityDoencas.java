package br.teste;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.SearchView;
import androidx.core.view.MenuItemCompat;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.widget.Toast;

public class ActivityDoencas extends AppCompatActivity {

    RecyclerView recyclerView2;

    String s3[], s4[];

    int images [] = {R.drawable.acaro_rajado,R.drawable.besouros,R.drawable.cochonilha,R.drawable.ferrugem,
            R.drawable.fumagina, R.drawable.mildio_verdadeiro, R.drawable.mosca_branca,R.drawable.mosca_fungos,
            R.drawable.queimadura_solar,R.drawable.raiz_podre};

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_doencas);
        recyclerView2 = findViewById(R.id.recyclerView2);
        getSupportActionBar().hide();

        s3 = getResources().getStringArray(R.array.Doenças);
        s4 = getResources().getStringArray(R.array.Descricao);

        MyAdap myAdap = new MyAdap(this, s3, s4, images);
        recyclerView2.setAdapter(myAdap);
        recyclerView2.setLayoutManager(new LinearLayoutManager(this));

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


                for(int i = 0; i< s3.length; i++){
                    if(query.equals(s3[i])){
                        Toast.makeText(getApplicationContext(),"Achou : "+s3[i],Toast.LENGTH_SHORT).show();
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
