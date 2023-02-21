using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnSaibaMaisEmpresa_Click(object sender, EventArgs e)
    {
        Response.Redirect("empresa.aspx");
    }

    protected void btnSaibaMaisLoja_Click(object sender, EventArgs e)
    {
        Response.Redirect("loja.aspx");
    }

    protected void btnSaibaMaisAplicativo_Click(object sender, EventArgs e)
    {
        Response.Redirect("aplicativo.aspx");
    }

    protected void btnSaibaMaisCadastro_Click(object sender, EventArgs e)
    {
        Response.Redirect("cadastroCliente.aspx");
    }

    protected void btnSaibaMaisFaq_Click(object sender, EventArgs e)
    {
        Response.Redirect("faq.aspx");
    }
}