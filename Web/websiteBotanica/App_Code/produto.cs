using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data; //adicionar
using System.Data.SqlClient; //adicionar

/// <summary>
/// Descrição resumida de produto
/// </summary>
public class Produto
{
    public Produto()
    {
        //
        // TODO: Adicionar lógica do construtor aqui
        //
    }

    private int _codigo;
    public int Codigo
    {
        get { return _codigo; }
        set { _codigo = value; }
    }

    private string _nome;
    public string Nome
    {
        get { return _nome; }
        set { _nome = value; }
    }

    private decimal _preco;
    public decimal Preco
    {
        get { return _preco; }
        set { _preco = value; }
    }

    private int _quantidade;
    public int Quantidade
    {
        get { return _quantidade; }
        set { _quantidade = value; }
    }

    private string _descricao;
    public string Descricao
    {
        get { return _descricao; }
        set { _descricao = value; }
    }
}