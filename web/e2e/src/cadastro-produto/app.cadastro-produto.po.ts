import { browser, by, element } from 'protractor';
import { AppBasePage } from '../app.base.po';
import * as path from "path";

export class AppLeilaoPage extends AppBasePage {
    constructor() { super(); }

    navegarParaLeilaos() {
        this.navegarPorLink('Leilaos');
    }

    navegarParaNovoLeilao() {
        this.navegarPorLink('Novo Leilao');
    }

    iniciarNavegacao() {
        this.navegarParaHome();
        this.login();
        this.navegarParaLeilaos();
    }

    obterTituloLeilaos() {
        return this.obterElementoXpath('/html/body/app-root/leilao-app-root/app-lista/div/h1').getText();
    }

    selecionarFornecedor() {
        this.listaFornecedores.get(2).click();
    }

    listaFornecedores = element.all(by.tagName('option'));
    nome = element(by.id('nome'));
    descricao = element(by.id('descricao'));
    valor = element(by.id('valor'));
    ativo = element(by.id('ativo'));

    botaoLeilao = element(by.id('cadastroLeilao'));

    selecionarImagem() {
        let caminho = path.resolve(__dirname, 'imagem_teste.jpg');
        element(by.id('imagem')).sendKeys(caminho);
    }

}