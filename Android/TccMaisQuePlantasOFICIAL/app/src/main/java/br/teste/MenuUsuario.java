package br.teste;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageButton;

import com.google.android.material.floatingactionbutton.FloatingActionButton;

public class MenuUsuario extends AppCompatActivity {

    ImageButton imgbtn, imgbtn1, imgbtn2;
    FloatingActionButton btnDuvidas;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu_usuario);
        imgbtn = findViewById(R.id.imgbtn);
        imgbtn1 = findViewById(R.id.imgbtn1);
        imgbtn2 = findViewById(R.id.imgbtn2);
        btnDuvidas = findViewById(R.id.btnDuvidas);
        btnDuvidas.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent it = new Intent(getBaseContext(), duvidas.class);
                startActivity(it);
            }
        });
        getSupportActionBar().hide();
        imgbtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent it = new Intent(getBaseContext(),ActivityPlantas.class);
                startActivity(it);
            }
        });

        imgbtn1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent it = new Intent(getBaseContext(),ActivityDoencas.class);
                startActivity(it);
            }
        });

        imgbtn2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent it = new Intent(getBaseContext(),MinhasPlantas.class);
                startActivity(it);
            }
        });
    }
}