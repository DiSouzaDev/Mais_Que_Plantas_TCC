using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data; //adicionar
using System.Data.SqlClient; //adicionar

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void ButtonLogar_Click1(object sender, EventArgs e)
    {
        Conexao c = new Conexao();

        c.Conectar();
        SqlDataAdapter dadapter = new SqlDataAdapter();
        DataSet dt = new DataSet();

        String nomeLogin_cli = TextBoxLogin.Text.Trim();
        String senha_cli = TextBoxSenha.Text.Trim();

        c.command.CommandText = "autenticar";
        c.command.CommandType = CommandType.StoredProcedure;

        c.command.Parameters.Add("@nomeLogin_cli", SqlDbType.VarChar).Value = nomeLogin_cli;
        c.command.Parameters.Add("@senha_cli", SqlDbType.VarChar).Value = senha_cli;
        c.command.Parameters[0].Direction = ParameterDirection.Input;
        c.command.Parameters[1].Direction = ParameterDirection.Input;

        dadapter.SelectCommand = c.command;
        dadapter.Fill(dt);

        c.FechaConexao();

        if (dt.Tables[0].DefaultView.Count == 1)
        {

            Session["logado"] = 1;
            Session["codigoUsuario"] = Convert.ToInt32(dt.Tables[0].DefaultView[0].Row["cod_cli"]);
            Session["usuario"] = dt.Tables[0].DefaultView[0].Row["nomeLogin_cli"].ToString();
            Session["tipoUsuario"] = dt.Tables[0].DefaultView[0].Row["tipo"].ToString();

            TextBoxLogin.Text = "";
            TextBoxSenha.Text = "";

            LabelResposta.Text = "Usuário Logado com Sucesso";
        }
        else
        {
            TextBoxLogin.Text = "";
            TextBoxSenha.Text = "";
            TextBoxLogin.Focus();

            LabelResposta.Text = "Usuário Incorreto";
        }
    }
}