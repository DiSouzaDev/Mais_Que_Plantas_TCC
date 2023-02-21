<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="lojaAdicionarProduto.aspx.cs" Inherits="lojaAdicionarProduto" %>

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
        <div class="conteudo-principal-loja">
            <div class="produtos">
                <div class="qtdProdutos">
                    <asp:Label ID="lblQuantidade" runat="server" Text="Quantidade:" Font-Size="25px"></asp:Label>
                    <asp:TextBox ID="txtQuantidade" runat="server" Width ="60px" Height="40px" Font-Size="25px"></asp:TextBox>
                    <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" CssClass="btnLoja" />
                </div>
                <div>
                    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="SqlDataSourceBotanica" CssClass="dgvProdutos">
                        <Fields>
                            <asp:ImageField DataImageUrlField="cod_prod" DataImageUrlFormatString="imgs/{0}.jpeg">
                                <ControlStyle Height="250px" />
                                <ItemStyle Height="250px" />
                            </asp:ImageField>
                            <asp:BoundField DataField="nome_prod" HeaderText="Produto" />
                            <asp:BoundField DataField="precoVenda_prod" HeaderText="Preço (R$)" />
                        </Fields>
                    </asp:DetailsView>
                    <br />
                    <br />
                    <asp:SqlDataSource ID="SqlDataSourceBotanica" runat="server" ConnectionString="<%$ ConnectionStrings:consultoriaPlantasTCCConnectionString %>"
                        SelectCommand="SELECT [cod_prod], [nome_prod], [precoVenda_prod] FROM [tblProduto] WHERE ([cod_prod] = @cod_prod)">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="cod_prod" QueryStringField="cod" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
            </div>
        </div>
    </section>

</asp:Content>

