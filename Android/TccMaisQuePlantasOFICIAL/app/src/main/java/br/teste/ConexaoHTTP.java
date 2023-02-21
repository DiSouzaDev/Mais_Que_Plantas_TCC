package br.teste;

import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

public class ConexaoHTTP
{
    public static StringBuilder sb;
    private static List<String> registros;
    public static void setDados(List<String> l){
        registros = l;
    }
    public static List<String> getDados(){
        return registros;
    }

    public static void conectarHttp(String pagina){
        String texto = null, aux="";
        registros = new ArrayList<String>();
        try{
            int SEGUNDOS = 1000;
            URL url = new URL(pagina);
            HttpURLConnection con = (HttpURLConnection)url.openConnection();
            con.setReadTimeout(10 * SEGUNDOS);
            con.setConnectTimeout(15 * SEGUNDOS);
            con.setRequestMethod("GET");
            con.setDoInput(true);
            con.setDoOutput(false); //SEM PARÂMETROS, MODO OCULTO
            con.connect();
            int resposta = con.getResponseCode();
            if (resposta ==  HttpURLConnection.HTTP_OK){
                InputStream is = con.getInputStream();
                byte[] buffer = new byte[1024];
                ByteArrayOutputStream mbuffer = new ByteArrayOutputStream();
                int bRead;
                while ((bRead = is.read(buffer)) != -1){
                    mbuffer.write(buffer, 0, bRead);
                }
                texto = new String(mbuffer.toByteArray(),"UTF-8");
                is.close();
                //SEPARAÇÃO DOS REGISTROS############################
                int tamanho = texto.length();
                boolean achou=false;
                for(int i=0;i<tamanho;i++){
                    if(texto.charAt(i)=='#'){
                        achou=true;
                        i++;
                    }
                    if(texto.charAt(i)=='^')
                        achou=false;
                    if(achou){
                        if(texto.charAt(i)!=';')
                            aux=aux+texto.charAt(i);
                        else{
                            registros.add(aux);
                            aux="";
                        }
                    }
                }
                //FIM DA SEPARAÇÃO DOS REGISTROS##################################
            }
        }
        catch (Exception e){
            registros = null;
        }
    }
}

