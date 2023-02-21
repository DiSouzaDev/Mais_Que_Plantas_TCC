package br.teste;

import androidx.appcompat.app.AppCompatActivity;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import java.util.List;

public class excluir extends AppCompatActivity {

    TextView lblId,lblNomePlanta,lblDescPlanta;
    Button btnExcluir,btnCancelarExcluir;
    private ProgressDialog mProgressDialog;
    String id;
    Compartilha cp = new Compartilha();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_excluir);
        lblId = findViewById(R.id.lblId);
        lblNomePlanta = findViewById(R.id.lblNomePlanta);
        lblDescPlanta = findViewById(R.id.lblDescPlanta);
        btnExcluir = findViewById(R.id.btnExcluir);
        btnCancelarExcluir = findViewById(R.id.btnCancelarExcluir);
        //String dados = cp.getDadosExcluir();
        getSupportActionBar().hide();
        String dados = cp.getDadosExcluir();
        String []x = dados.split(",");
        lblId.setText(x[0]);
        lblNomePlanta.setText(x[1]);
        lblDescPlanta.setText(x[2]);
        btnExcluir.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                id = lblId.getText().toString();
                new excluir.SincronismoHTTP().execute();
                Intent it = new Intent(getBaseContext(),MinhasPlantas.class);
                startActivity(it);
            }
        });
        btnCancelarExcluir.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent it = new Intent(getBaseContext(),MinhasPlantas.class);
                startActivity(it);
            }
        });
    }

    private class SincronismoHTTP extends AsyncTask<Void, Void, Void> {
        @Override
        protected void onPreExecute(){
            super.onPreExecute();
            mProgressDialog = new ProgressDialog(excluir.this);
            mProgressDialog.setTitle("Sincronizando");
            mProgressDialog.setMessage("Buscando Dados...");
            mProgressDialog.setIcon(R.mipmap.ic_launcher_round);
            mProgressDialog.setCancelable(false);
            mProgressDialog.show();
        }

        @Override
        protected Void doInBackground(Void... params){
            try{
                ConexaoHTTP.conectarHttp("http://10.0.2.2/delete.aspx?id="+id);
            }
            catch (Exception e){}
            return null;
        }

        @Override
        protected void onPostExecute(Void vd){
            super.onPostExecute(vd);
            try {
                Toast.makeText(getBaseContext(),"Registro Excluido com Sucesso!",Toast.LENGTH_LONG).show();
                lblId.setText("");
                lblNomePlanta.setText("");
                lblDescPlanta.setText("");
            }catch (Exception erro){}
            mProgressDialog.dismiss();
        }
    }
}