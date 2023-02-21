<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <section class="conteudo-principal">
        <h1 class="conteudo-principal-escrito-titulo">Seja bem-vindo(a) a Mais Que Plantas - Consultoria e Paisagismo</h1>
        <div class="conteudo-principal-escrito">
            <br />
            <div class="conteudo-principal-escrito-boxes">
                <div>
                    <div class="separa-texto-imagem">
                        <div>
                            <h3>Sobre nós</h3>
                            <p class="conteudo-principal-escrito-texto">
                                Nosso propósito é auxiliar nossos clientes na realização de consultorias e projetos paisagísticos, na venda online de plantas ornamentais (kokedamas) e disponibilização de informações sobre o cultivo das principais espécies de plantas utilizadas em ambientes urbanos.                     
                            </p>
                        </div>
                        <div>
                            <img class="imagem-home" src="imgs/empresa.png" alt="Imagem da tela inicial do APP" />
                        </div>
                    </div>
                    <div class="conteudo-principal-escrito-botao">
                        <asp:Button ID="btnSaibaMaisEmpresa" CssClass="btnSaibaMais" runat="server" Text="Sobre Nós" OnClick="btnSaibaMaisEmpresa_Click" />
                    </div>
                </div>
            </div>
            <br />
            <div class="conteudo-principal-escrito-boxes">
                <div>
                    <div>
                        <div class="separa-texto-imagem">
                            <div>
                                <h3>Nossos Produtos</h3>
                                <p class="conteudo-principal-escrito-texto">
                                    A Kokedama (苔玉) é uma técnica japonesa que une a arte e a botânica no cultivo de plantas ornamentais. Confira os produtos disponibilizados em nossa loja online.                 
                                </p>
                            </div>
                            <div>
                                <img class="imagem-home" src="imgs/koke.png" alt="Imagem da tela inicial do APP" />
                            </div>
                        </div>
                    </div>
                    <div class="conteudo-principal-escrito-botao">
                        <br />
                        <asp:Button ID="btnSaibaMaisLoja" CssClass="btnSaibaMais" runat="server" Text="Produtos" OnClick="btnSaibaMaisLoja_Click" />
                    </div>
                </div>
            </div>
            <br />
            <div class="conteudo-principal-escrito-boxes">
                <div>
                    <div class="separa-texto-imagem">
                        <div>
                            <h3>Aplicativo Mobile</h3>
                            <p class="conteudo-principal-escrito-texto">
                                Nosso app é voltado à disponibilização de conteúdo técnico-científico para auxiliar o usuário no cultivo, manejo e cuidado de plantas ornamentais em ambientes internos e extrernos.              
                            </p>
                        </div>
                        <div>
                            <img class="imagem-home" src="imgs/mobile.png" alt="Imagem da tela inicial do APP" />
                        </div>
                    </div>
                    <div class="conteudo-principal-escrito-botao">
                        <br />
                        <asp:Button ID="btnSaibaMaisAplicativo" CssClass="btnSaibaMais" runat="server" Text="Nosso APP" OnClick="btnSaibaMaisAplicativo_Click" />
                    </div>
                </div>
            </div>
            <br />
            <div class="conteudo-principal-escrito-boxes">
                <div>
                    <div class="separa-texto-imagem">
                        <div>
                            <h3>Realize seu Cadastro</h3>
                            <p class="conteudo-principal-escrito-texto">
                                Para ter acesso ao nosso aplicativo mobile e à compra de produtos na loja online, realize seu cadastro aqui no site e utilize nossos serviços de forma gratuita.                     
                            </p>
                        </div>
                        <div>
                            <img class="imagem-home" src="imgs/cadastro.jpg" alt="Imagem da tela inicial do APP" />
                        </div>
                    </div>
                    <div class="conteudo-principal-escrito-botao">
                        <br />
                        <asp:Button ID="btnSaibaMaisCadastro" CssClass="btnSaibaMais" runat="server" Text="Cadastre-se" OnClick="btnSaibaMaisCadastro_Click" />
                    </div>
                </div>
            </div>
            <br />
             <div class="conteudo-principal-escrito-boxes">
                <div>
                    <div class="separa-texto-imagem">
                        <div>
                            <h3>Alguma Dúvida?</h3>
                            <p class="conteudo-principal-escrito-texto">
                               Em caso de dúvidas, acesse nosso FAQ contendo as perguntas mais frequentes de nossos clientes e nossas respostas a elas. Caso ainda haja algum questionamento, entre em contato conosco via what's app ou email.                      
                            </p>
                        </div>
                        <div>
                            <img class="imagem-home" src="imgs/faq.png" alt="Imagem da tela inicial do APP" />
                        </div>
                    </div>
                    <div class="conteudo-principal-escrito-botao">
                        <br />
                        <asp:Button ID="Button1" CssClass="btnSaibaMais" runat="server" Text="FAQ" OnClick="btnSaibaMaisFaq_Click" />
                    </div>
                </div>
            </div>
            <br />


        </div>
    </section>
</asp:Content>
