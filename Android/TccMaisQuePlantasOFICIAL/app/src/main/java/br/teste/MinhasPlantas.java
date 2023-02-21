package br.teste;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class MinhasPlantas extends AppCompatActivity {

    Button btnConsulta,btnAdicionarPlanta,btnExcluirPlanta,btnAtualizar, btnVoltar1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_minhas_plantas);
        btnAdicionarPlanta = findViewById(R.id.btnAdicionarPlanta);
        btnConsulta = findViewById(R.id.btnConsulta);
        btnExcluirPlanta = findViewById(R.id.btnExcluirPlanta);
        btnAtualizar = findViewById(R.id.btnAtualizar);
        btnVoltar1 = findViewById(R.id.btnVoltar1);
        getSupportActionBar().hide();
        btnVoltar1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent it = new Intent(getBaseContext(),MenuUsuario.class);
                startActivity(it);
            }
        });
        btnAdicionarPlanta.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent it = new Intent(getBaseContext(),Incluir.class);
                startActivity(it);
            }
        });
        btnConsulta.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent it = new Intent(getBaseContext(),ConsultarPlantas.class);
                startActivity(it);
            }
        });
        btnExcluirPlanta.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent it = new Intent(getBaseContext(),ConsultarExcluir.class);
                startActivity(it);
            }
        });
        btnAtualizar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent it = new Intent(getBaseContext(),ConsultarAlterar.class);
                startActivity(it);
            }
        });
    }
}