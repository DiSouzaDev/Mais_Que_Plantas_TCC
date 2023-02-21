package br.teste;

import androidx.appcompat.app.AppCompatActivity;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

public class ConsultarPlantas extends AppCompatActivity {

    ListView lstContatos;
    private ProgressDialog mProgressDialog;
    List<String> mDados;
    String cli;
    Compartilha cp = new Compartilha();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_consultar_plantas);
        lstContatos = findViewById(R.id.lstContatos);
        String dados = cp.getIdCli();
        cli = new String(dados);
        new SincronismoHTTP().execute();
        getSupportActionBar().hide();
    }

    private class SincronismoHTTP extends AsyncTask<Void, Void, Void> {
        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            mProgressDialog = new ProgressDialog(ConsultarPlantas.this);
            mProgressDialog.setTitle("Sincronizando");
            mProgressDialog.setMessage("Buscando Dados...");
            mProgressDialog.setIcon(R.mipmap.ic_launcher_round);
            mProgressDialog.setCancelable(false);
            mProgressDialog.show();
        }

        //ALTERAR PÁGINAS APSX
        @Override
        protected Void doInBackground(Void... params) {
            try {

                ConexaoHTTP.conectarHttp("http://10.0.2.2/consulta.aspx?id=" + cli);
            } catch (Exception e) {
            }
            return null;
        }

        @Override
        protected void onPostExecute(Void vd) {
            super.onPostExecute(vd);
            mDados = new ArrayList<String>();
            try {
                mDados = ConexaoHTTP.getDados();
                List<String>aux = new ArrayList<>();
                for(int i=0;i<mDados.size();i++)
                {
                    String []x = mDados.get(i).split(",");
                    aux.add(x[2]+"\n"+x[3]);
                }
                ArrayAdapter<String> adp = new ArrayAdapter<String>(getBaseContext(), android.R.layout.simple_list_item_1, aux);
                lstContatos.setAdapter(adp);

                lstContatos.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                    @Override
                    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                        Object o = parent.getAdapter().getItem(position);
                        String texto = o.toString();
                        Toast.makeText(getBaseContext(), " " + texto + " ",
                                Toast.LENGTH_LONG).show();
                    }
                });
            } catch (Exception erro) {
            }
            mProgressDialog.dismiss();
        }
    }
}