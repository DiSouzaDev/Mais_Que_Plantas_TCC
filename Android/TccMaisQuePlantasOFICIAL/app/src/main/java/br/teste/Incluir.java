package br.teste;

import androidx.appcompat.app.AppCompatActivity;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

public class Incluir extends AppCompatActivity {

    Button btnIncluir, btnVoltar;
    TextView lblIdCli;
    EditText txtPlantaCli, txtDescCli;
    private ProgressDialog mProgressDialog;
    String planta, desc, cli;
    Compartilha cp = new Compartilha();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_incluir);
        lblIdCli = findViewById(R.id.lblIdCli);
        btnIncluir = findViewById(R.id.btnIncluir);
        btnVoltar = findViewById(R.id.btnVoltar);
        txtPlantaCli = findViewById(R.id.txtPlantaCli);
        txtDescCli = findViewById(R.id.txtDescCli);
        String dados = cp.getIdCli();
        getSupportActionBar().hide();
        String []x = dados.split(",");
        // lblIdCli.setText(x[0]);
        lblIdCli.setText(dados);

        btnIncluir.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View view){
                cli = lblIdCli.getText().toString();
                planta = txtPlantaCli.getText().toString();
                desc = txtDescCli.getText().toString();
                new SincronismoHTTP().execute();
                Intent it = new Intent(getBaseContext(),MinhasPlantas.class);
                startActivity(it);
            }
        });
        btnVoltar.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View view){
                finish();
            }
        });
    }

    private class SincronismoHTTP extends AsyncTask<Void, Void, Void> {
        @Override
        protected void onPreExecute(){
            super.onPreExecute();
            mProgressDialog = new ProgressDialog(Incluir.this);
            mProgressDialog.setTitle("Sincronizando");
            mProgressDialog.setMessage("Buscando Dados...");
            mProgressDialog.setIcon(R.mipmap.ic_launcher_round);
            mProgressDialog.setCancelable(false);
            mProgressDialog.show();
        }

        @Override
        protected Void doInBackground(Void... params){
            try{
                String x = planta.replace(" ","%20");
                String y = desc.replace(" ","%20");
                String url="http://10.0.2.2/inserir.aspx?cod_usu="+cli+"&nomeplantaCli="+x+"&descPlanta="+y;
                ConexaoHTTP.conectarHttp(url);
            }
            catch (Exception e){}
            return null;
        }

        @Override
        protected void onPostExecute(Void vd){
            super.onPostExecute(vd);
            try {
                Toast.makeText(getBaseContext(),"Registro Incluido com Sucesso!",Toast.LENGTH_LONG).show();
                lblIdCli.setText("");
                txtPlantaCli.setText("");
                txtDescCli.setText("");

            }catch (Exception erro){}
            mProgressDialog.dismiss();
        }
    }
}