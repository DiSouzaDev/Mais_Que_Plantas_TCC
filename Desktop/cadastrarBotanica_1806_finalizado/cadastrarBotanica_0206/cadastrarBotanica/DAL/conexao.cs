using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atvBD_PlantasEstoque.DAL
{
    public class conexao
    {
        SqlConnection con = new SqlConnection();

        public conexao()
        {
            con.ConnectionString = @"Data Source=LAPTOP-UC8GBJH9\SQLEXPRESS;Initial Catalog=consultoriaPlantasTCC;Persist Security Info=True;User ID=sa;Password=etesp";
        }

        public SqlConnection conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
