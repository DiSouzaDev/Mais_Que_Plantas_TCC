package br.teste;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

import com.google.android.material.floatingactionbutton.FloatingActionButton;

public class duvidas extends AppCompatActivity {

    FloatingActionButton fabMenu;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_duvidas);
        fabMenu = findViewById(R.id.fabMenu);
        getSupportActionBar().hide();
        fabMenu.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent it = new Intent (getBaseContext(), MenuUsuario.class);
                startActivity(it);
            }
        });
    }
}