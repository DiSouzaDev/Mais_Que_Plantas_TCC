package br.teste;

import androidx.appcompat.app.AppCompatActivity;

import android.app.ProgressDialog;
import android.content.Intent;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    Button btnEntrar, btnCad;
    EditText edtLogin, edtSenha;
    private ProgressDialog mProgressDialog;
    List<String> mDados;
    String Login, Senha;
    Compartilha cp = new Compartilha();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        btnEntrar = findViewById(R.id.btnEntrar);
        edtLogin = findViewById(R.id.edtLogin);
        edtSenha = findViewById(R.id.edtSenha);
        btnCad = findViewById(R.id.btnCad);
        getSupportActionBar().hide();
        btnEntrar.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View view){
                Login = edtLogin.getText().toString();
                Senha = edtSenha.getText().toString();
                new SincronismoHTTP().execute();

                //Intent it = new Intent(getBaseContext(),MenuUsuario.class);
                //startActivity(it);
            }
        });

        btnCad.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                startActivity(new Intent(Intent.ACTION_VIEW, Uri.parse("http://google.com.br")));
            }
        });
    }

    private class SincronismoHTTP extends AsyncTask<Void, Void, Void> {
        @Override
        protected void onPreExecute(){
            super.onPreExecute();
            mProgressDialog = new ProgressDialog(MainActivity.this);
            mProgressDialog.setTitle("Sincronizando");
            mProgressDialog.setMessage("Buscando Dados...");
            mProgressDialog.setIcon(R.mipmap.ic_launcher_round);
            mProgressDialog.setCancelable(false);
            mProgressDialog.show();
        }

        @Override
        protected Void doInBackground(Void... params){
            try{
                ConexaoHTTP.conectarHttp("http://10.0.2.2/login.aspx?login="+Login+"&senha="+Senha);
            }
            catch (Exception e){}
            return null;
        }

        @Override
        protected void onPostExecute(Void vd){
            super.onPostExecute(vd);
            mDados = new ArrayList<String>();
            try {
                mDados = ConexaoHTTP.getDados();
                if(mDados.size() > 0){
                    String []y = mDados.get(0).split(",");
                    cp.setIdCli(y[0]);
                    Intent it = new Intent(getBaseContext(),MenuUsuario.class);
                    startActivity(it);
                    finish();
                }
                else
                {
                    Toast.makeText(getBaseContext(),"Credencial inválida",Toast.LENGTH_LONG).show();
                }
            }catch (Exception erro){}
            mProgressDialog.dismiss();
        }
    }
}