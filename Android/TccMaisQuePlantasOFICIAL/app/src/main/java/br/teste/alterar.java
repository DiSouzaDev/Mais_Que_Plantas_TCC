package br.teste;

import androidx.appcompat.app.AppCompatActivity;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import java.util.List;

public class alterar extends AppCompatActivity {

    TextView lblId;
    EditText txtNomePlantinha, txtDescPlantinha;
    Button btnAlterar, btnVoltarAlterar;
    private ProgressDialog mProgressDialog;
    String id, planta, desc;
    Compartilha cp = new Compartilha();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_alterar);
        lblId = findViewById(R.id.lblId);
        txtNomePlantinha = findViewById(R.id.txtNomePlantinha);
        txtDescPlantinha = findViewById(R.id.txtDescPlantinha);
        btnAlterar = findViewById(R.id.btnAlterar);
        btnVoltarAlterar= findViewById(R.id.btnVoltarAlterar);
        getSupportActionBar().hide();
        String dados = cp.getDadosAlterar();
        String []x = dados.split(",");
        lblId.setText(x[0]);
        txtNomePlantinha.setText(x[1]);
        txtDescPlantinha.setText(x[2]);
        btnAlterar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                id = lblId.getText().toString();
                planta = txtNomePlantinha.getText().toString();
                desc = txtDescPlantinha.getText().toString();
                new alterar.SincronismoHTTP().execute();
                Intent it = new Intent(getBaseContext(),MinhasPlantas.class);
                startActivity(it);
            }
        });
        btnVoltarAlterar.setOnClickListener(new View.OnClickListener() {
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
            mProgressDialog = new ProgressDialog(alterar.this);
            mProgressDialog.setTitle("Sincronizando");
            mProgressDialog.setMessage("Buscando Dados...");
            mProgressDialog.setIcon(R.mipmap.ic_launcher_round);
            mProgressDialog.setCancelable(false);
            mProgressDialog.show();
        }

        @Override
        protected Void doInBackground(Void... params){
            try{
                ConexaoHTTP.conectarHttp("http://10.0.2.2/update.aspx?id="+id+"&nomeplantaCli="+planta+"&descPlanta="+desc);
            }
            catch (Exception e){}
            return null;
        }

        @Override
        protected void onPostExecute(Void vd){
            super.onPostExecute(vd);
            try {
                Toast.makeText(getBaseContext(),"Registro Alterardo com Sucesso!!!",Toast.LENGTH_LONG).show();
                lblId.setText("");
                txtNomePlantinha.setText("");
                txtDescPlantinha.setText("");
            }catch (Exception erro){}
            mProgressDialog.dismiss();
        }
    }
}