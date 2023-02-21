<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="conteudo-principal">

        <div class="campo-login" runat="server" id="divLogin">
            <asp:Label ID="Label1" runat="server" Text="Login" Font-Size="25px"></asp:Label>
            <asp:TextBox ID="TextBoxLogin" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label2" runat="server" Text="Senha" Font-Size="25px"></asp:Label>
            <asp:TextBox ID="TextBoxSenha" type="password" runat="server"></asp:TextBox><br />
            <br />
            <asp:Button CssClass="BtnLogin" ID="ButtonLogar" runat="server" Text="Logar" OnClick="ButtonLogar_Click1" />
            <br />

            <asp:Label ID="LabelResposta" runat="server" Text=""></asp:Label>
        </div>
    </section>
</asp:Content>

