package br.teste;

import androidx.appcompat.app.AppCompatActivity;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

public class ConsultarAlterar extends AppCompatActivity {

    ListView lstContatosAlterar;
    private ProgressDialog mProgressDialog;
    List<String> mDados;
    String cli;
    Compartilha cp = new Compartilha();
    List<String>codPlan = new ArrayList<>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_consultar_alterar);
        lstContatosAlterar = findViewById(R.id.lstContatosAlterar);
        String dados = cp.getIdCli();
        cli = new String(dados);
        new SincronismoHTTP().execute();
        getSupportActionBar().hide();
    }

    private class SincronismoHTTP extends AsyncTask<Void, Void, Void> {
        @Override
        protected void onPreExecute(){
            super.onPreExecute();
            mProgressDialog = new ProgressDialog(ConsultarAlterar.this);
            mProgressDialog.setTitle("Sincronizando");
            mProgressDialog.setMessage("Buscando Dados...");
            mProgressDialog.setIcon(R.mipmap.ic_launcher_round);
            mProgressDialog.setCancelable(false);
            mProgressDialog.show();
        }

        //Fazer Páginas ASPX
        @Override
        protected Void doInBackground(Void... params){
            try{
                ConexaoHTTP.conectarHttp("http://10.0.2.2/consulta.aspx?id="+cli);
            }
            catch (Exception e){}
            return null;
        }

        @Override
        protected void onPostExecute(Void vd) {
            super.onPostExecute(vd);
            mDados = new ArrayList<String>();
            try {
                mDados = ConexaoHTTP.getDados();
                List<String>aux = new ArrayList<>();
                codPlan = new ArrayList<>();
                for(int i=0;i<mDados.size();i++)
                {
                    String []x = mDados.get(i).split(",");
                    aux.add(x[2]+"\n"+x[3]);
                    codPlan.add(x[0]+","+x[2]+","+x[3]);
                }
                ArrayAdapter<String> adp = new ArrayAdapter<String>(getBaseContext(), android.R.layout.simple_list_item_1, aux);
                lstContatosAlterar.setAdapter(adp);

                lstContatosAlterar.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                    @Override
                    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                        Object o = parent.getAdapter().getItem(position);
                        String texto = o.toString();
                        cp.setDadosAlterar(codPlan.get(position));
                        Intent it = new Intent(getBaseContext(),alterar.class);
                        startActivity(it);
                    }
                });
            }catch (Exception erro){}
            mProgressDialog.dismiss();
        }
    }
}