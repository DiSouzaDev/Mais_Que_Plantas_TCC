<%@ Page Language="C#" Debug="true" %>
<%@ import Namespace="System.IO"%>
<%@ import Namespace="System.Data"%>
<%@ import Namespace="System.Data.SqlClient"%>

<script runat="server">

	public void Page_Load()
	{
		string id = (Request.QueryString["id"]);
		String strConexao = "Password=etesp; Persist Security Info=True; User ID=sa; Initial Catalog=consultoriaPlantasTCC; Data Source=" + Environment.MachineName  + "\\SQLEXPRESS";
		//String strConexao = "Password=12345; Persist Security Info=True; User ID=sa; Initial Catalog=consultoriaPlantasTCC; Data Source=" + Environment.MachineName + "\\SQLEXPRESS";
		SqlConnection objConexao = new SqlConnection(strConexao);
		String concatena = ""; //utilizado para unir os campos de dados da tabela contatos do banco de dados
		String strSQL = "SELECT * FROM tblColecao WHERE cod_usu = " + id;
		SqlCommand objCommand = new SqlCommand(strSQL, objConexao);
		SqlDataReader dr;
		objConexao.Open();
		dr = objCommand.ExecuteReader();
		concatena = "#"; //marcador de início de dados
		while (dr.Read())
		{
			concatena += (dr[0].ToString()) + ","; //campo id do banco de dados
			concatena += (dr[2].ToString()) + ","; //campo idCli do banco de dados
			concatena += (dr[1].ToString()) + ","; //campo nome do banco de dados
			concatena += (dr[3].ToString()) + ";"; //campo fone do banco de dados
		}
		concatena+="^"; //marcador de fim de dados
		Label1.Text = concatena;
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