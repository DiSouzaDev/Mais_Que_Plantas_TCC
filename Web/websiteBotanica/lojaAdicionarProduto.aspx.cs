using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data; //adicionar
using System.Data.SqlClient; //adicionar

public partial class lojaAdicionarProduto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["logado"] == null || Session["logado"].Equals(0))
        {
            Response.Redirect("login.aspx");
        }

    }

    protected void btnAdicionar_Click(object sender, EventArgs e)
    {
        Produto p = new Produto();

        int codigoProduto = Convert.ToInt32 (Request.QueryString["cod"]);

        Carrinho carCompras;

        if (Session["carrinho"] != null)
        {
            carCompras = (Carrinho) Session["carrinho"];
        }
        else
        {
            carCompras = new Carrinho ((int)Session["codigoUsuario"]);
        }

        Conexao c = new Conexao();
        c.Conectar();
        c.command.CommandText = "select * from tblProduto where cod_prod=@cod_prod";
        c.command.Parameters.Add("@cod_prod", SqlDbType.Int).Value = codigoProduto;
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        p.Codigo = codigoProduto;
        p.Quantidade = Convert.ToInt32(txtQuantidade.Text);
        p.Preco = Convert.ToDecimal(dt.Tables[0].DefaultView[0].Row["precoVenda_prod"].ToString());
        p.Nome = dt.Tables[0].DefaultView[0].Row["nome_prod"].ToString();
        carCompras.Lista.Add(p);
        Session["carrinho"] = carCompras;

        txtQuantidade.Text = "";
        txtQuantidade.Focus();

        Response.Redirect("lojaCarrinho.aspx");
    }

}