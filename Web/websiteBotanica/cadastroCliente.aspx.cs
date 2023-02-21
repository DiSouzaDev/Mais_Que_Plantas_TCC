using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// deve-se fazer a chamada das bibliotecas para que não haja erro
using System.Data;
using System.Data.SqlClient;

public partial class cadastroCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnCadastroCliente_Click(object sender, EventArgs e)
    {
        if (txtLogin.Text == "")
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "erro", "<script>alert('Login precisa ser preenchido');</script>");
        }

        //if (ddlTermoSeg.Text == "")
        //{
        //    ClientScript.RegisterClientScriptBlock(GetType(), "erro", "<script>alert('Responda o termo da Política de Segurança');</script>");
        //}

        String nomeLogin_cli;
        String senha_cli;
        String nome_cli;
        String cpf_cli;
        String email_cli;
        String celular_cli;
        String endereco_cli;
        String numEnd_cli;
        String complemento_cli;
        String bairro_cli;
        String cidade_cli;
        String estado_cli;
        String cep_cli;
        String termoSeg_cli;

        nomeLogin_cli = txtLogin.Text;
        senha_cli = txtSenha.Text;
        nome_cli = txtNome.Text;
        cpf_cli = txtCPF.Text;
        email_cli = txtEmail.Text;
        celular_cli = txtCelular.Text;
        endereco_cli = txtEndereco.Text;
        numEnd_cli = txtNumEnd.Text;
        complemento_cli = txtComplemento.Text;
        bairro_cli = txtBairro.Text;
        cidade_cli = ddlCidade.Text;
        estado_cli = ddlEstado.Text;
        cep_cli = txtCep.Text;
        termoSeg_cli = ddlTermoSeg.Text;

        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        Conexao c = new Conexao();

        c.Conectar();
        c.command.CommandText = "insert into tblCliente (nomeLogin_cli, senha_cli, nome_cli, cpf_cli, email_cli, celular_cli, status_cli, endereco_cli, numEnd_cli, complemento_cli, bairro_cli, cidade_cli, estado_cli, cep_cli, termoSeg_cli) values (@nomeLogin_cli, @senha_cli, @nome_cli, @cpf_cli, @email_cli, @celular_cli, @status_cli, @endereco_cli, @numEnd_cli, @complemento_cli, @bairro_cli, @cidade_cli, @estado_cli, @cep_cli, @termoSeg_cli)";
        c.command.Parameters.Add("@nomeLogin_cli", System.Data.SqlDbType.VarChar).Value = nomeLogin_cli;
        c.command.Parameters.Add("@senha_cli", System.Data.SqlDbType.VarChar).Value = senha_cli;
        c.command.Parameters.Add("@nome_cli", System.Data.SqlDbType.VarChar).Value = nome_cli;
        c.command.Parameters.Add("@cpf_cli", System.Data.SqlDbType.VarChar).Value = cpf_cli;
        c.command.Parameters.Add("@email_cli", System.Data.SqlDbType.VarChar).Value = email_cli;
        c.command.Parameters.Add("@celular_cli", System.Data.SqlDbType.VarChar).Value = celular_cli;
        c.command.Parameters.Add("@status_cli", System.Data.SqlDbType.VarChar).Value = "Ativo";
        c.command.Parameters.Add("@endereco_cli", System.Data.SqlDbType.VarChar).Value = endereco_cli;
        c.command.Parameters.Add("@numEnd_cli", System.Data.SqlDbType.Int).Value = numEnd_cli;
        c.command.Parameters.Add("@complemento_cli", System.Data.SqlDbType.VarChar).Value = complemento_cli;
        c.command.Parameters.Add("@bairro_cli", System.Data.SqlDbType.VarChar).Value = bairro_cli;
        c.command.Parameters.Add("@cidade_cli", System.Data.SqlDbType.VarChar).Value = cidade_cli;
        c.command.Parameters.Add("@estado_cli", System.Data.SqlDbType.VarChar).Value = estado_cli;
        c.command.Parameters.Add("@cep_cli", System.Data.SqlDbType.VarChar).Value = cep_cli;
        c.command.Parameters.Add("@termoSeg_cli", System.Data.SqlDbType.VarChar).Value = termoSeg_cli;

        c.command.ExecuteNonQuery();
        c.FechaConexao();

        txtLogin.Text = "";
        txtSenha.Text = "";
        txtNome.Text = "";
        txtCPF.Text = "";
        txtEmail.Text = "";
        txtCelular.Text = "";
        txtEndereco.Text = "";
        txtNumEnd.Text = "";
        txtComplemento.Text = "";
        txtBairro.Text = "";
        ddlCidade.ClearSelection();
        ddlEstado.ClearSelection();
        txtCep.Text = "";
        ddlTermoSeg.ClearSelection();
        txtLogin.Focus();

        Response.Write("Dados Cadastrados com Sucesso");
        //Response.Redirect("index.aspx");
    }
}