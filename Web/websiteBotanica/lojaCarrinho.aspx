<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="lojaCarrinho.aspx.cs" Inherits="lojaCarrinho" %>

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
        <div>
        <div class="conteudo-principal-carrinho">
            <h1 class="conteudo-principal-escrito-titulo">Carrinho de Compras</h1>
        </div>
        <div>
            <asp:GridView ID="dgvCarrinho" runat="server" AutoGenerateColumns="False" CssClass="dgvProdutos"
                OnRowDeleting="dgvCarrinho_RowDeleting">
                <Columns>
                    <asp:BoundField HeaderText="Produto:" DataField="Nome" />
                    <asp:BoundField HeaderText="Preço Unitário (R$):" DataField="Preco" />
                    <asp:BoundField HeaderText="Quantidade:" DataField="Quantidade" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnFazerPedido" runat="server" Text="Finalizar Pedido" CssClass="btnFechaPedido"
                OnClick="btnFazerPedido_Click" />
            <div id="respCarrinho" runat="server"></div>
        </div>
        </div>
    </section>
</asp:Content>

