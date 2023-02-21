<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="faq.aspx.cs" Inherits="faq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <section class="conteudo-principal">
        <h1 class="conteudo-principal-escrito-titulo">Perguntas e Respostas Frequentes</h1>
        <div class="conteudo-principal-escrito">
            <br />
            <div>
                <asp:GridView ID="dgvFaq" runat="server" GridLines="None" CssClass="dgvProdutos" DataSourceID="SqlDataSourceBotanica" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="pergunta_faq" HeaderText="Pergunta:" SortExpression="pergunta_faq" />
                        <asp:BoundField DataField="resposta_faq" HeaderText="Resposta:" SortExpression="resposta_faq" />
                    </Columns>
                </asp:GridView>

                <asp:SqlDataSource ID="SqlDataSourceBotanica" runat="server" ConnectionString="<%$ ConnectionStrings:consultoriaPlantasTCCConnectionString %>" 
                    SelectCommand="SELECT [pergunta_faq], [resposta_faq] FROM [tblFaq] WHERE ([status_faq] = @status_faq)">
                            <SelectParameters>
                                <asp:QueryStringParameter DefaultValue="Ativo" Name="status_faq" QueryStringField="txtName" Type="String" />
                            </SelectParameters>
                   </asp:SqlDataSource>
            </div>
        </div>
    </section>
</asp:Content>
