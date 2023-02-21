/*using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cadastrarBotanica;

namespace atvBD_PlantasEstoque.DAL
{
    public class LoginDaoComando
    {
        bool roleAdm;
        int cod_func;
        public int dataCodFunc
        {
            get
            {
                return this.cod_func;
            }
            set
            {
                this.cod_func = value;
            }
        }
        public bool permissaoAdmin
        {
            get
            {
                return this.roleAdm;
            }
            set
            {
                this.roleAdm = value;
            }
        }

        SqlCommand cmd = new SqlCommand();

        conexao con = new conexao();
        SqlDataReader dr;
        public bool verificarLogin(String login, String senha)
        {
            bool funcionario = false;
            cmd.CommandText = "SELECT * FROM tblFuncionario where nomeLogin_func=@login and senha_func=@senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);
            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    permissaoAdmin = (bool)dr["adm_func"]; //força transformar em bool
                    Console.WriteLine(dr["cod_func"]);
                    //Console.WriteLine(dr.ToString());
                    dataCodFunc = (int)dr["cod_func"];
                    funcionario = true;
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return funcionario;
        }
    }
    
}*/


using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace atvBD_PlantasEstoque.DAL
{
    public class LoginDaoComando
    {
        public ArrayList VerificaLogin(String login, String senha)
        {
            ArrayList data_user = new ArrayList();
            SqlCommand cmd = new SqlCommand();
            conexao con = new conexao();
            SqlDataReader dr;
            cmd.CommandText = "SELECT * FROM tblFuncionario where nomeLogin_func=@login and senha_func=@senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);
            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    Console.WriteLine(dr["adm_func"]);
                    data_user.Add(dr["cod_func"]);
                    data_user.Add(dr["adm_func"]);
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return data_user;
        }
    }
}