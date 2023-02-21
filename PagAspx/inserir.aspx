<%@ Page Language="C#" Debug="true" %>
<%@ import Namespace="System.IO"%>
<%@ import Namespace="System.Data"%>
<%@ import Namespace="System.Data.SqlClient"%>

<script runat="server">

	public void Page_Load()
	{
		string cod_usu = (Request.QueryString["cod_usu"]);
		// String nomePlanta = ((Request.QueryString["nomePlanta"]);)
		string nomeplantaCli = (Request.QueryString["nomeplantaCli"]);
		string descPlanta = (Request.QueryString["descPlanta"]);
		//String strConexao = "Password=12345; Persist Security Info=True; User ID=sa; Initial Catalog=consultoriaPlantasTCC; Data Source=" + Environment.MachineName + "\\SQLEXPRESS";
		String strConexao = "Password=etesp; Persist Security Info=True; User ID=sa; Initial Catalog=consultoriaPlantasTCC; Data Source=" + Environment.MachineName  + "\\SQLEXPRESS";
		SqlConnection objConexao = new SqlConnection(strConexao);
		String contato;
		// String strSQL = "INSERT INTO tblColecao (nomePlanta, nome_plantaCliente, desc_plantaCliente) VALUES ('" + nomePlanta + "','" + nomeplantaCli + "','" + descPlanta + "')";
		String strSQL = "INSERT INTO tblColecao VALUES ( '" + nomeplantaCli + "','" + cod_usu + "','" + descPlanta + "')";
		SqlCommand objCommand = new SqlCommand(strSQL, objConexao);
		objConexao.Open();
		objCommand.ExecuteNonQuery();
		Label1.Text = "Dados inseridos com sucesso!";
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