using atvBD_PlantasEstoque.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace atvBD_PlantasEstoque.Modelo
{
    public class Controle
    {

        public ArrayList acessar(String login, String senha)
        {
            LoginDaoComando loginDao = new LoginDaoComando();
            ArrayList dadosFuncionario = loginDao.VerificaLogin(login, senha);
            //Console.WriteLine("{0}ola", dadosFuncionario[0]);
            return dadosFuncionario;
        }
        
        
    }
}
