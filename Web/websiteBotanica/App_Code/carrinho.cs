using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data; //adicionar
using System.Data.SqlClient; //adicionar


public class Carrinho
{
    public System.Collections.Generic.List<Produto> Lista; //relacionada a lista de produtos que o usuário pretende comprar, ela esta vinculada ao objetos do tipo produto, desse modo já fica explicito que cada item da lista é um item produto
    private int codigoUsuario;

    public Carrinho(int cod_cli)
    {
        Lista = new System.Collections.Generic.List<Produto>(); //realiza-se a instanciação da lista que foi "tipada" para produtos 
        codigoUsuario = cod_cli;
    }

    public bool CheckOut()
    {
        try
        {
            Conexao c = new Conexao();
            string sqlPedido = "insert into tblPedido(cod_cli) values (@cod_cli)select scope_identity()"; //o scope_identity utiliza a última sessão que foi gerada (no caso o código da venda que foi realizada) 
            string sqlPedidoProduto = "insert into tblPedido_Produto(cod_ped, cod_prod, qtd_prod, precoItem_ped) values (@cod_ped, @cod_prod, @qtd_prod, @precoItem_ped)";
            c.Conectar();
            c.command.CommandText = sqlPedido;
            c.command.Parameters.Add("@cod_cli", SqlDbType.Int).Value = codigoUsuario;
            int codPedido = Convert.ToInt32(c.command.ExecuteScalar()); // o executeScalar retorna um objeto (no caso um dado a ser retornado, do tipo inteiro)
            System.Collections.IEnumerator it = Lista.GetEnumerator();
            while (it.MoveNext()) // nesse while/moveNext é onde são executadas as sucessivas inserções de vários produtos na lista, referentes a uma mesma venda realizada (que contém vários produtos), do primeiro produto ele vai pro segundo, pro terceiro, até que "ande" por todos os produtos da lista 
            {
                Produto p = (Produto)it.Current; //esse objeto "p" ele vai possuir os dados de cada um dos produtos que foram inseridos na lista (contendo as informações desse produto, como preço, quantidade, valor, código etc) ou seja, ele grava no banco: uma venda -> "n" produtos 
                c.Conectar();
                c.command.CommandText = sqlPedidoProduto;
                c.command.Parameters.Add("@cod_ped", SqlDbType.Int).Value = codPedido;
                c.command.Parameters.Add("@cod_prod", SqlDbType.Int).Value = p.Codigo;
                c.command.Parameters.Add("@qtd_prod", SqlDbType.Int).Value = p.Quantidade;
                c.command.Parameters.Add("@precoItem_ped", SqlDbType.Decimal).Value = p.Preco;
                c.command.ExecuteNonQuery();
                c.FechaConexao();
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    public void limpaLista()
    {
        Lista.Clear();

    }

}