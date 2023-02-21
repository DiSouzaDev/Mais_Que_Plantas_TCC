<%@ Page Language="C#" Debug="true" %>
<%@ import Namespace="System.IO"%>
<%@ import Namespace="System.Data"%>
<%@ import Namespace="System.Data.SqlClient"%>

<script runat="server">

	public void Page_Load()
	{
		string login = (Request.QueryString["login"]);
		string senha = (Request.QueryString["senha"]);
	    //String strConexao = "Password=12345; Persist Security Info=True; User ID=sa; Initial Catalog=consultoriaPlantasTCC; Data Source=" + Environment.MachineName + "\\SQLEXPRESS";
		String strConexao = "Password=etesp; Persist Security Info=True; User ID=sa; Initial Catalog=consultoriaPlantasTCC; Data Source=" + Environment.MachineName  + "\\SQLEXPRESS";
		SqlConnection objConexao = new SqlConnection(strConexao);
		String cliente = "";
		String strSQL = "SELECT cod_cli, nomeLogin_cli, senha_cli FROM tblCliente WHERE nomeLogin_cli='"+login+"' and senha_cli='"+senha+"'";
		SqlCommand objCommand = new SqlCommand(strSQL, objConexao);
		SqlDataReader dr;
		objConexao.Open();
		dr = objCommand.ExecuteReader();
		cliente = "#";
		while (dr.Read())
		{
			cliente += (dr[0].ToString()) + ",";
			cliente += (dr[1].ToString()) + ",";
			cliente += (dr[2].ToString()) + ";";
		}
		cliente += "^";
		Label1.Text = cliente;
	}
</script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://ww.w3.org/TR/xhtml1/DTD/xhtml1-transitional.detd">

<html xmlns="http://www.w3.org/1999.xhtml">
<head id = "Head1" runat = "server">
 <title></title>
</head>
<body>
 <form id = "form1" runat = "server">
 <div>
	<asp:Label ID = "Label1" runat = "server"></asp:Label>
 </div>
 </form>
</body>
</html>