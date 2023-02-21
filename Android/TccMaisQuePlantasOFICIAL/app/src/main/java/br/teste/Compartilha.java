package br.teste;

import java.util.List;

public class Compartilha {

    private static String idCli;
    public void setIdCli(String val){
        idCli = val;
    }
    public String getIdCli(){
        return  idCli;
    }

    private static String dadosExcluir;
    public void setDadosExcluir(String val){
        dadosExcluir = val;
    }
    public String getDadosExcluir(){
        return  dadosExcluir;
    }

    private static String dadosAlterar;
    public void setDadosAlterar(String val){
        dadosAlterar = val;
    }
    public String getDadosAlterar(){
        return  dadosAlterar;
    }
}
