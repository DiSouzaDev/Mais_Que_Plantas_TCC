<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cadastroCliente.aspx.cs" Inherits="cadastroCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="css/StyleSheet.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="cadastro-cliente" id="cadastro-cliente" style="padding-bottom: 146px;">
        <div class="cadastro-cliente-title">
            <h1 id="titulo-cadastro">Cadastro de Clientes</h1>
            <h2 id="subtitulo-cadastro">Realize seu cadastro para utilizar nosso APP</h2>
            <br />
        </div>
        <div>
            <div id="formCliente" class="campo" method="post" runat="Server">
                <div class="cadastro-row">
                    <div class="campo-cadastro">
                        <asp:Label ID="lblNomeLogin" runat="server" Text="Nome de Login:"></asp:Label>
                        <asp:TextBox ID="txtLogin" placeholder="(Login do Usuário)" name="" runat="server" type="text" pattern="^[a-záàâãéèêíïóôõöúçñ]+$" maxlenght="25"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtLogin" runat="server" ErrorMessage="Preencher o campo" CssClass="mensagem-erro"></asp:RequiredFieldValidator>
                    </div>

                    <div class="campo-cadastro">
                        <asp:Label ID="lblSenhaLogin" runat="server" Text="Senha de Login:"></asp:Label>
                        <asp:TextBox ID="txtSenha" type="password" placeholder="(Senha de Login)" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtSenha" runat="server" ErrorMessage="Preencher o campo" maxlenght="15" CssClass="mensagem-erro"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="cadastro-row">
                    <div class="campo-cadastro">
                        <asp:Label ID="lblNomeCompleto" runat="server" Text="Nome Completo:"></asp:Label>
                        <asp:TextBox ID="txtNome" placeholder="(Nome Completo)" runat="server" maxlenght="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtNome" runat="server" ErrorMessage="Preencher o campo" CssClass="mensagem-erro"></asp:RequiredFieldValidator>
                    </div>

                    <div class="campo-cadastro">
                        <asp:Label ID="lblEmail" runat="server" Text="E-mail:"></asp:Label>
                        <asp:TextBox ID="txtEmail" placeholder="(Ex: email@modelo.com)" runat="server" type="text" pattern="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" title="Digite um e-mail válido"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtEmail" runat="server" ErrorMessage="Informe corretamente o e-mail" maxlenght="100" CssClass="mensagem-erro"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Informe corretamente o e-mail" ForeColor="#003300" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="cadastro-row">
                    <div class="campo-cadastro">
                        <asp:Label ID="lblCelular" runat="server" Text="Celular/What's app:"></asp:Label>
                        <asp:TextBox ID="txtCelular" placeholder="(Apenas Números - Ex: 11900000000)" runat="server" type="number" MaxLength="11" pattern="^[1-9]{2}[0-9]{4,5}[0-9]{4}$"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtCelular" runat="server" ErrorMessage="Somente os números com o DDD" CssClass="mensagem-erro"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtCelular" ErrorMessage="Somente os números com o DDD" ForeColor="#003300" SetFocusOnError="True" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                    </div>

                    <div class="campo-cadastro">
                        <asp:Label ID="lblCPF" runat="server" Text="CPF:"></asp:Label>
                        <asp:TextBox ID="txtCPF" placeholder="(CPF - Somente Números)" type="number" runat="server" maxlenght="11"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredCPF" ControlToValidate="txtCPF" runat="server" ErrorMessage="Preencher o campo" CssClass="mensagem-erro"></asp:RequiredFieldValidator>
                    </div>

                </div>

                <div class="cadastro-row">
                    <div class="campo-cadastro">
                        <asp:Label ID="lblEndereco" runat="server" Text="Endereço Completo:"></asp:Label>
                        <asp:TextBox ID="txtEndereco" placeholder="(Rua ou Avenida)" runat="server" maxlenght="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtEndereco" runat="server" ErrorMessage="Preencher o campo" CssClass="mensagem-erro"></asp:RequiredFieldValidator>
                    </div>

                    <div class="campo-cadastro">
                        <asp:Label ID="lblNumEnd" runat="server" Text="Número:"></asp:Label>
                        <asp:TextBox ID="txtNumEnd" placeholder="(Número da Casa ou Prédio)" runat="server" Type="number" max="99999"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtNumEnd" runat="server" EnableViewState="False" ErrorMessage="Somente Número" CssClass="mensagem-erro"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtNumEnd" EnableViewState="False" ErrorMessage="Somente Número" SetFocusOnError="True" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="cadastro-row">
                    <div class="campo-cadastro">
                        <asp:Label ID="lblComplemento" runat="server" Text="Complemento:"></asp:Label>
                        <asp:TextBox ID="txtComplemento" placeholder="(Ex: Número do Apartamento)" runat="server" maxlenght="25"></asp:TextBox>
                    </div>

                    <div class="campo-cadastro">
                        <asp:Label ID="lblBairro" runat="server" Text="Bairro:"></asp:Label>
                        <asp:TextBox ID="txtBairro" placeholder="(Bairro)" runat="server" maxlenght="25"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtBairro" runat="server" ErrorMessage="Preencher o campo" CssClass="mensagem-erro"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="cadastro-row">
                    <div class="campo-cadastro">
                        <asp:Label ID="estado_cli" runat="server" Text="Estado:"></asp:Label>
                        <asp:DropDownList ID="ddlEstado" runat="server" DataSourceID="SqlDataSource2" DataTextField="nome_estado" DataValueField="cod_estado" AutoPostBack="True"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:consultoriaPlantasTCCConnectionString %>" SelectCommand="SELECT [cod_estado], [nome_estado] FROM [tblEstado]"></asp:SqlDataSource>
                    </div>

                    <div class="campo-cadastro">
                        <asp:Label ID="cidade_cli" runat="server" Text="Cidade:"></asp:Label>
                        <asp:DropDownList ID="ddlCidade" runat="server" DataSourceID="SqlDataSource1" DataTextField="nome_municipio" DataValueField="cod_municipio"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:consultoriaPlantasTCCConnectionString %>" SelectCommand="SELECT [cod_municipio], [nome_municipio], [cod_estado] FROM [tblMunicipio] WHERE ([cod_estado] = @cod_estado)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlEstado" Name="cod_estado" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>

                <div class="cadastro-row">
                    <div class="campo-cadastro">
                        <asp:Label ID="lblCep" runat="server" Text="CEP:"></asp:Label>
                        <asp:TextBox ID="txtCep" placeholder="(CEP - Somente Números)" runat="server" Type="number" max="999999999"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtCep" runat="server" ErrorMessage="Somente Número" CssClass="mensagem-erro"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtCep" ErrorMessage="Somente Número" ForeColor="#003300" SetFocusOnError="True" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                    </div>

                </div>
                <div class="cadastro-row-termo">
                    <div class="campo-cadastro-termo">
                        <asp:Label ID="lblTermoSeg" runat="server" Text="Você concorda com nossa Política de Segurança?"></asp:Label><a href="imgs/termoSeg.pdf">
                            <br />
                            <strong>(PDF - Política de Segurança)</strong></a>
                        <br />
                        <asp:DropDownList ID="ddlTermoSeg" runat="server">
                            <asp:ListItem Text="Selecione sua Resposta" Value="Não"></asp:ListItem>
                            <asp:ListItem Text="Sim" Value="Sim"></asp:ListItem>
                            <asp:ListItem Text="Não" Value="Não"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <br />
                <br />
                <br />
                <div class="cadastro-cliente-button">
                    <asp:Button ID="BtnCadastroCliente" CssClass="BtnCadastroCliente" runat="server" Text="Realizar Cadastro" OnClick="BtnCadastroCliente_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

