<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="lojaPedidoDetalhe.aspx.cs" Inherits="lojaPedidoDetalhe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="loja">
        <aside>
            <nav class="loja-cabecalho-menu">
                <div>
                    <img class="loja-logo" src="imgs/logoCarrinho.png" alt="logo da loja" />
                </div>
                <div class="loja-logo-menu-hamburguer">
                    <div>
                        <a href="#" class="loja-botao-menu">
                            <span class="loja-bar"></span>
                            <span class="loja-bar"></span>
                            <span class="loja-bar"></span>
                        </a>
                    </div>
                </div>
                <div class="loja-cabecalho-menu-links">
                    <ul>
                        <li><a class="loja-cabecalho-menu-item" href="loja.aspx">Produtos</a></li>
                        <li><a class="loja-cabecalho-menu-item" href="lojaCarrinho.aspx">Carrinho</a></li>
                        <li><a class="loja-cabecalho-menu-item" href="lojaPedido.aspx">Pedidos</a></li>
                    </ul>
                </div>
            </nav>
        </aside>
        <div class="conteudo-principal-carrinho">
            <h1 class="conteudo-principal-escrito-titulo">Detalhamento dos Pedidos</h1>
            <br />
            <div>
                <asp:GridView ID="dgvHistoricoDetalhe" runat="server" AutoGenerateColumns="False" DataKeyNames="cod_ped_prod" DataSourceID="SqlDataSourceBotanica" CssClass="dgvProdutos">
                    <Columns>
                        <asp:BoundField DataField="cod_ped_prod" HeaderText="Código da Venda:" InsertVisible="False" ReadOnly="True" SortExpression="cod_ped_prod" />
                        <asp:BoundField DataField="cod_ped" HeaderText="Código do Pedido:" SortExpression="cod_ped" />
                        <asp:BoundField DataField="cod_prod" HeaderText="Código do Produto:" SortExpression="cod_prod" />
                        <asp:BoundField DataField="qtd_prod" HeaderText="Quantidade:" SortExpression="qtd_prod" />
                        <asp:BoundField DataField="precoItem_ped" HeaderText="Preço Unitário:" SortExpression="precoItem_ped" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSourceBotanica" runat="server" ConnectionString="<%$ ConnectionStrings:consultoriaPlantasTCCConnectionString %>"
                    SelectCommand="SELECT * FROM tblPedido AS P
	INNER JOIN tblCliente AS C
		ON P.cod_cli = C.cod_cli
			INNER JOIN tblPedido_Produto AS PP
				ON PP.cod_ped = P.cod_ped   WHERE C.cod_cli = @cod_cli AND P.cod_ped = @cod_ped

">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="cod_ped" QueryStringField="cod" Type="Int32" />
                        <asp:SessionParameter Name="cod_cli" SessionField="codigoUsuario" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
    </section>
</asp:Content>