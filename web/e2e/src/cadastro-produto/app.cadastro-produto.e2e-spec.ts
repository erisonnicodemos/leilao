import { AppLeilaoPage } from './app.cadastro-leilao.po';
import { browser, logging } from 'protractor';

describe('Testes do formulario de cadastro', () => {
  let page: AppLeilaoPage;

  beforeEach(() => {
    page = new AppLeilaoPage();
  });

  it('deve navegar até leiloes', () => {
    page.iniciarNavegacao();
    expect(page.obterTituloLeilaos()).toEqual('Lista de Leilaos');    
  });

  it('deve preencher formulário de leiloes com sucesso', () => {
    
    page.navegarParaNovoLeilao();
    page.selecionarFornecedor();

    page.nome.sendKeys('Leilao Teste Automatizado');
    page.descricao.sendKeys('Leilao \nTeste Automatizado');
    page.valor.sendKeys('1234,50');
    page.selecionarImagem();
    page.ativo.click;

    page.botaoLeilao.click();    

    page.esperar(6000);

    expect(page.obterTituloLeilaos()).toEqual('Lista de Leilaos'); 
  });
 
  afterEach(async () => {
    // Assert that there are no errors emitted from the browser
    const logs = await browser.manage().logs().get(logging.Type.BROWSER);
    expect(logs).not.toContain(jasmine.objectContaining({
      level: logging.Level.SEVERE,
    } as logging.Entry));
  });
});
