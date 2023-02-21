using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lojaCarrinho : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["logado"] == null || Session["logado"].Equals(0))
        {
            Response.Redirect("login.aspx");
        }

        btnFazerPedido.Visible = false;
        if (Session["carrinho"] != null)
        {
            Carrinho c = (Carrinho) Session["carrinho"];
            dgvCarrinho.DataSource = c.Lista;
            dgvCarrinho.DataBind();
            btnFazerPedido.Visible = true;
        }
    }

    protected void btnFazerPedido_Click(object sender, EventArgs e)
    {
        Carrinho c = (Carrinho) Session["carrinho"];
        if (c.CheckOut())
        {
            respCarrinho.Attributes.Add("class", "respCarrinho");
            c.limpaLista();
            Session["carrinho"] = null;
            Response.Redirect("lojaPedido.aspx");

        }
        else
        {
            respCarrinho.InnerHtml = "Houve um erro ao gravar os dados";
        }
    }

    protected void dgvCarrinho_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Carrinho c = (Carrinho)Session["carrinho"];
        c.Lista.RemoveAt(e.RowIndex);
        Session["carrinho"] = c;
        dgvCarrinho.DataSource = c.Lista;
        dgvCarrinho.DataBind();
    }
}