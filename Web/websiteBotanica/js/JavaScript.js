
/* CÓDIGO PARA APARECER O MENU QUANDO MINIMIZADO */

const botaoMenu = document.getElementsByClassName('botao-menu')[0]
const cabecalhoMenuLinks = document.getElementsByClassName('cabecalho-menu-links')[0]

botaoMenu.addEventListener('click', () => {
    cabecalhoMenuLinks.classList.toggle('active')
})

/* FIM DO CÓDIGO MENU*/

/* CÓDIGO PARA APARECER O MENU DA LOJA QUANDO MINIMIZADO */

const lojaBotaoMenu = document.getElementsByClassName('loja-botao-menu')[0]
const lojaCabecalhoMenuLinks = document.getElementsByClassName('loja-cabecalho-menu-links')[0]

lojaBotaoMenu.addEventListener('click', () => {
    lojaCabecalhoMenuLinks.classList.toggle('active')
})

/* FIM DO CÓDIGO MENU DA LOJA*/


//FUNÇÃO PARA VALIDAR EMAIL E OUTROS ITENS
//function ValidarEmail(email) {
//    var emailPattern = /^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$/;
//    return emailPattern.test(email);
//}
//console.log('teste');
//console.log(ValidarEmail('teste@teste@teste.com'));
//console.log(ValidarEmail('teste@teste.com'));
//console.log(ValidarEmail('teste@.teste.com.br'));