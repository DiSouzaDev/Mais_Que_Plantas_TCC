<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="loja.aspx.cs" Inherits="plantasOrnamentais" %>

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
<%--            <div class="conteudo-principal-escrito">
                <div class="conteudo-aplicativo">
                </div>
            </div>--%>
            <div>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
     <%--               <asp:Label ID="Label1" runat="server" Text="Buscar Produto:"></asp:Label>--%>
                        <asp:TextBox ID="txtNome" runat="server" Visible="false"></asp:TextBox>
                  <%--      <asp:Button ID="btnPesquisar" runat="server" Text="Buscar" OnClick="btnPesquisar_Click" />--%>
                        <br />
                        <asp:GridView ID="dgvProdutos" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceBotanica" GridLines="None" CssClass="dgvProdutos">
                            <Columns >
                                <asp:ImageField DataImageUrlField="cod_prod" DataImageUrlFormatString="imgs/{0}.jpeg">
                                    <ControlStyle Height="200px" Width="200px" />
                                </asp:ImageField>
                                <asp:BoundField DataField="nome_prod" HeaderText="Produto:" SortExpression="nome_prod" />
                                <asp:BoundField DataField="precoVenda_prod" HeaderText="Preço:" SortExpression="precoVenda_prod" />
                                <asp:BoundField DataField="desc_prod" HeaderText="Descrição:" SortExpression="desc_prod" />
                                <asp:BoundField DataField="estoq_prod" HeaderText="Estoque:" SortExpression="estoq_prod" />
                                <asp:BoundField DataField="status_prod" HeaderText="Status:" SortExpression="status_prod" />
                                <asp:HyperLinkField DataNavigateUrlFields="cod_prod" DataNavigateUrlFormatString="lojaAdicionarProduto.aspx?cod={0}" Text="Comprar" ControlStyle-CssClass="btnLoja"/>
                            </Columns>
                        </asp:GridView>

                        <asp:SqlDataSource ID="SqlDataSourceBotanica" runat="server" ConnectionString="<%$ ConnectionStrings:consultoriaPlantasTCCConnectionString %>"
                            SelectCommand="SELECT  [cod_prod], [nome_prod], [precoVenda_prod], [desc_prod], [estoq_prod], [status_prod] FROM [tblProduto] WHERE ([status_prod] = @status_prod)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="txtNome" DefaultValue="Disponível" Name="status_prod" PropertyName="Text" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </section>
</asp:Content>
