<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="lojaPedido.aspx.cs" Inherits="lojaPedido" %>

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
            <h1 class="conteudo-principal-escrito-titulo">Visualização dos Pedidos</h1>
            <br />
            <div>
                <asp:GridView ID="dgvHistorico" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceBotanica" DataKeyNames="cod_ped" CssClass="dgvProdutos">
                    <Columns>
                        <asp:BoundField DataField="cod_ped" HeaderText="Nº do Pedido:" SortExpression="cod_ped" InsertVisible="False" ReadOnly="True" />
                        <asp:BoundField DataField="nomeLogin_cli" HeaderText="Login do Cliente:" SortExpression="nomeLogin_cli" />
                        <asp:HyperLinkField DataNavigateUrlFields="cod_ped" DataNavigateUrlFormatString="lojaPedidoDetalhe.aspx?cod={0}" Text="Detalhes da Venda" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSourceBotanica" runat="server" ConnectionString="<%$ ConnectionStrings:consultoriaPlantasTCCConnectionString %>"
                    SelectCommand="SELECT a.cod_ped, b.nomeLogin_cli from tblPedido as A inner join tblCliente as B on a.cod_cli = B.cod_cli WHERE B.cod_cli = @cod_cli">
                    <SelectParameters>
                        <asp:SessionParameter Name="cod_cli" SessionField="codigoUsuario" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
    </section>
</asp:Content>

<%--   <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceBotanica" DataKeyNames="cod_ped">
                    <Columns>
                        <asp:BoundField DataField="cod_ped" HeaderText="cod_ped" SortExpression="cod_ped" InsertVisible="False" ReadOnly="True" />
                        <asp:HyperLinkField DataNavigateUrlFields="cod_ped" DataNavigateUrlFormatString="lojaPedidoDetalhe.aspx?cod={0}" Text="Detalhes da Venda" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:consultoriaPlantasTCCConnectionString %>" 
                    SelectCommand="SELECT [cod_ped], [cod_cli] FROM [tblPedido] WHERE ([cod_cli] = @cod_cli)">
                    <SelectParameters>
                        <asp:SessionParameter Name="cod_cli" SessionField="codigoUsuario" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>--%>