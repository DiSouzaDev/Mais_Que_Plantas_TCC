using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// add essas para o banco
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descrição resumida de conexao
/// </summary>
public class Conexao
{
    //criar duas variáveis para linkar/abrir/fechar o banco
    public SqlConnection con;
    public SqlCommand command;

    // pode-se usar a string com usuário e senha (1ª) ou utilizando a autenticação do windows (2ª)

    
    //String strConexao = @"Server=localhost; Database=consultoriaPlantasTCC; trusted_connection=true";

    String strConexao = "Server=LAPTOP-UC8GBJH9\\SQLEXPRESS; Database=consultoriaPlantasTCC; user id = sa; password=etesp";

    //String strConexao = "Server=LAB02T-03\\SQLEXPRESS; Database=consultoriaPlantasTCC; user id = sa; password=etesp";



    public void Conectar()
    {
        try
        {
            con = new SqlConnection(strConexao);
            con.Open();
            command = new SqlCommand();
            command.Connection = con;
        }
        catch (Exception e)
        {
            FechaConexao();
        }
    }

    public void FechaConexao()
    {
        command = null;
        con.Close();
        con = null;
    }
}