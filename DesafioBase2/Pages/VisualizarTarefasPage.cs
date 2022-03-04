using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Bases;
using OpenQA.Selenium;
namespace DesafioBase2.Pages
{
    
    public class VisualizarTarefasPage : PageBase
    {
        #region Mapping
        //Navegação no menu e selcionar tarefa
        By menuVerTarefas = By.XPath("//span[text()=' Ver Tarefas ']");
        By selecionarTarefa = By.LinkText("0000003");

        // Botão Enviar Lembrete
        By btnEnviarLembrete = By.XPath("//a[text()='Enviar um lembrete']");
        By destinatarioLembrete = By.XPath("//option[text()='administrator']");
        By corpoLembrete = By.Name("body");
        By corpoLembreteAlterado = By.Name("bugnote_text");
        By btnConfirmaEnvioLembrete = By.CssSelector("input[value='Enviar']");
        By btnAlterarLembrete = By.XPath("//button[text()='Alterar']");
        By btnAtualizarInformacacoes = By.CssSelector("input[value='Atualizar Informação']");
        By tornarLembretePrivado = By.XPath("//input[@name='bugnote_set_view_state_token']/following-sibling::button");
        By btnApagarLembrete = By.XPath("//button[text()='Apagar']");
        By btnApagarLembreteConfirma = By.CssSelector("input[value='Apagar Anotação']");

        //Mapeamento do botão Atualizar
        By btnAtualizarTarefa = By.CssSelector("input[value='Atualizar']");
        By resumo = By.Id("summary");
        By descricao = By.Id("description");

        //Botão ir para anotação e adicionar anotaçoes
        By btnIrParaAnotacoes = By.XPath("//a[text()='Ir para as Anotações']");
        By visibilidade = By.CssSelector("span[class='lbl padding-6']");
        By anotacoes = By.Id("bugnote_text");
        By btnAdicionarAnotacao = By.CssSelector("input[value='Adicionar Anotação']");

        //Botão Ir para Histórico e Clicar em Histórico
        By btnIrParaHistorico = By.XPath("//a[text()='Ir para o Histórico']");
        By clicarHistorico = By.CssSelector("tr:nth-child(1) > .small-caption > a");

        //Clicar botão Monitorar
        By btnMonitorar = By.XPath("//input[@value ='Monitorar']");

        //Clicar no botão Marcar Pegajoso
        By btnMarcarPegajoso = By.CssSelector(".pull-left:nth-child(5) .btn");

        //Criar Clone
        By btnCriarClone = By.CssSelector(".pull-left:nth-child(6) .btn");
        By btnCriarNovaTarefa = By.CssSelector("input[value='Criar Nova Tarefa']");

        //Fechar e reabrir Tarefa
        By btnReabrir = By.CssSelector(".pull-left:nth-child(7) .btn");
        By btnFechar = By.CssSelector(".pull-left:nth-child(8) .btn");
        By btnFecharTarefa = By.CssSelector("input[value='Fechar Tarefa']");
        By btnSolicitarRetorno = By.CssSelector("input[value='Solicitar Retorno']");

        //Botão Mover tarefa 
        By btnMover = By.CssSelector(".pull-left:nth-child(9) .btn");
        By moverPara = By.CssSelector("option[value='5']");
        By moverTarefa = By.CssSelector("input[value='Mover Tarefas']");
        By voltarPraTarefa = By.XPath("//td//a[text()='0000003']");

        //Botão Apagar tarefa
        By btnApagar = By.CssSelector(".pull-left:nth-child(10) .btn");
        By btnApagarTarefas = By.CssSelector("input[value='Apagar Tarefas']");

        //Campos Usuário Monitoramento
        By nomeUsuario = By.Id("bug_monitor_list_username");
        By btnAdicionarUsuarioMonitoramento = By.CssSelector(".form-inline:nth-child(3) > .btn");
        By btnRemoverUsuarioMonitoramento = By.CssSelector("i[class='fa fa-times']");

        //Campos Relações
        By tipoRelacionamento = By.XPath("//option[text()='é pai de']");
        By nomeRelacionamento = By.XPath("//input[@name='dest_bug_id']");
        By btnAdicionarRelacionamento = By.XPath("//input[@name='dest_bug_id']/following-sibling::input");
        By btnRemoverRelacionamento = By.CssSelector("i[class='ace-icon fa fa-trash-o']");
        By btnConfirmaRemoverRelacionamento = By.CssSelector("input[value='Apagar']");

        //Botão Alterar status da tarefa (Reaproveitar o mappeamento 'anotacoes' e btnsolicitarRetorno )
        By comboAlterarStatus = By.XPath("//option[text()='admitido']");
        By btnAlterarStatus = By.CssSelector("input[value='Alterar Status:']");

        //Botão alterar Atribuido
        By comboAtribuir = By.XPath("//option[text()='administrator']");
        By btnAtribuir = By.CssSelector("input[value='Atribuir a:']");

        //Pesquisa de tarefas

        By numeroTarefa = By.CssSelector(".input-icon:nth-child(1) > input");

        //Botao Navegacao >>

        By btnNavegacaoDireita = By.LinkText(">>");
        By btnNavegacaoEsquerda = By.LinkText("<<");

        //validações

        By textoRelacionamento = By.XPath("//td/a[text()='0000001']");
        By textoMonitoramento = By.XPath("//div/a[text()='administrator']");
        By textoAtribuido = By.XPath("//td[@class='bug-assigned-to']//a[text()='administrator']");
        By textoStatus = By.XPath("//td[@class='bug-status']");
        By textoDescricaoAtu = By.XPath("//td[text()='Iniciando desafio base2 atualizada']");
        By textoClone = By.XPath("//td[text()='Iniciando desafio base2 Clone']");
        By textoLembrete = By.XPath("//td[text()='Nao esquecer a tarefa x	']");
        By textoLembreteAtu = By.XPath("//tr[@id='c2']//td[@class='bugnote-note bugnote-public']");
        By textoLembreteCodigo =By.XPath("//a[@title='Link direto para a anotação']");

        By textoAnotacao = By.XPath("//tr//td[@class='bugnote-note bugnote-private']");
        By textoHistorico = By.XPath("//div[@id='timeline']//h4[@class='widget-title lighter']");
        By textoPegajoso = By.XPath("//input[@value ='Desmarcar como Pegajoso']");
        By textoMonitorar = By.XPath("//input[@value ='Parar de Monitorar']");
        By textoMoverTarefa = By.XPath("//td[@class='bug-project']");
        By textoPesquisa = By.XPath("//td[@class='bug-id']");
        By textoTarefaFechada = By.XPath("//td[text()=' fechado']");
        By textoTarefaReaberta = By.XPath("//td[text()=' retorno']");
        By textoBotaoTornaPublico = By.XPath("//button[text()='Tornar Público']");

        #endregion

        #region Actions
        public void ClicarMenuVerTarefas()
        {
            Click(menuVerTarefas);
        }

        public void ClicarEmSelecionarTarefa()
        {
            Click(selecionarTarefa);
        }
        public void ClicarEmEnviarLembrete()
        {
            Click(btnEnviarLembrete);
        }

        public void ClicarEmDestinatarioLembrete()
        {
            Click(destinatarioLembrete);
        }

        public void PreencherInformacaoLembrete(string lembrete)
        {
            SendKeys(corpoLembrete, lembrete);
        }

        public void ClicarEmConfirmarEnvioLembrete()
        {
            Click(btnConfirmaEnvioLembrete);
        }

        public void ClicarEmAlterarLembrete()
        {
            Click(btnAlterarLembrete);
        }

        public void LimparCampos()
        {
            Clear(corpoLembreteAlterado);
        }

        public void LimparCamposAtualizacao()
        {
            Clear(resumo);
            Clear(descricao);
        }

        public void PreencherCorpoLembreteAlterado(string corpoAlterado)
        {
            SendKeys(corpoLembreteAlterado, corpoAlterado);
        }

        public void ClicarEmAtualizarInformacoes()
        {
            Click(btnAtualizarInformacacoes);
        }

        public void ClicarEmTornarPrivado()
        {
            Click(tornarLembretePrivado);
        }

        public void ClicarEmApagarLembrete()
        {
            Click(btnApagarLembrete);
        }

        public void ClicarEmApagarLembreteConfirmar()
        {
            Click(btnApagarLembreteConfirma);
        }

        public void ClicarEmAtualizarTarefa()
        {
            Click(btnAtualizarTarefa);
        }

        public void PreencherResumo(string campoResumo)
        {
            SendKeys(resumo, campoResumo);
        }

        public void PreencherDescricao(string campoDescricao)
        {
            SendKeys(descricao, campoDescricao);
        }

        public void ClicarEmIrParaAnotacoes()
        {
            Click(btnIrParaAnotacoes);
        }

        public void ClicarEmVisibilidade()
        {
            Click(visibilidade);
        }

        public void PreencherAnotacao(string campoAnotacao)
        {
            SendKeys(anotacoes, campoAnotacao);
        }

        public void ClicarEmAdicionarAnotacao()
        {
            Click(btnAdicionarAnotacao);
        }

        public void ClicarEmIrParaHistorico()
        {
            Click(btnIrParaHistorico);
        }

        public void ClicarEmHistorico()
        {
            Click(clicarHistorico);
        }

        public void ClicarEmMonitorar()
        {
            Click(btnMonitorar);
        }

        public void ClicarEmMarcarPegajoso()
        {
            Click(btnMarcarPegajoso);
        }
        public void ClicarEmClicarClone()
        {
            Click(btnCriarClone);
        }

        public void ClicarEmCriarNovaTarefa()
        {
            Click(btnCriarNovaTarefa);
        }

        public void ClicarEmFechar()
        {
            Click(btnFechar);
        }

        public void ClicarEmMover()
        {
            Click(btnMover);
        }

        public void ClicarNaTarefa()
        {
            Click(voltarPraTarefa);
        }
        public void ClicarEmApagar()
        {
            Click(btnApagar);
        }
        
        public void ClicarEmfecharTarefa()
        {
            Click(btnFecharTarefa);
        }

        public void ClicarEmSolicitarRetorno()
        {
            Click(btnSolicitarRetorno);
        }

        public void ClicarbtnReabrir()
        {
            Click(btnReabrir);
        }

        public void ClicarEmMoverPara()
        {
            Click(moverPara);
        }

        public void ClicarEmMoverTarefa()
        {
            Click(moverTarefa);
        }

        public void ClicarEmApagarTarefa()
        {
            Click(btnApagarTarefas);
        }

        public void PreencherNomeUsuarioMonitoramento(string nome)
        {
            SendKeys(nomeUsuario, nome);
        }

        public void ClicarEmAdicionarUsuarioMonitoramento()
        {
            Click(btnAdicionarUsuarioMonitoramento);
        }

        public void ClicarEmRemoverUsuarioMonitoramento()
        {
            Click(btnRemoverUsuarioMonitoramento);
        }

        public void ClicarEmTipoRelacionamento()
        {
            Click(tipoRelacionamento);
        }

        public void PreencherNomeRelacionamento( string relacionamento)
        {
            SendKeys(nomeRelacionamento, relacionamento);
        }

        public void ClicarEmAdicionarRelacionamento()
        {
            Click(btnAdicionarRelacionamento);
        }

        public void ClicarEmRemoverRelacionamento()
        {
            Click(btnRemoverRelacionamento);
        }

        public void ClicarEmConfirmarRemoverRelacionamento()
        {
            Click(btnConfirmaRemoverRelacionamento);
        }

        public void ClicarEmComboAlterarStatus()
        {
            Click(comboAlterarStatus);
        }

        public void ClicarEmAlterarStatus()
        {
            Click(btnAlterarStatus);
        }


        public void ClicarEmComboAtribuir()
        {
            Click(comboAtribuir);
        }

        public void ClicarEmAtribuir()
        {
            Click(btnAtribuir);
        }

        public void PreencherNumeroTarefa(string numero)
        {
            SendKeys(numeroTarefa, numero);
        }

        public void ClicarEnter()
        {
            SendKeys(numeroTarefa);
        }
        
        public void ClicarNavegacaoDireita()
        {
            Click(btnNavegacaoDireita);
        }

        public void ClicarNavegacaoEsquerda()
        {
            Click(btnNavegacaoEsquerda);
        }

        public string RetornaRelacionamento()
        {
            string texto = GetText(textoRelacionamento);
            return texto;
        }

        public bool RetornaRelacionamentoExcluido()
        {
            bool texto = ReturnIfElementExist(textoRelacionamento);
            return texto;
        }

        public string RetornaMonitoramento()
        {
            string texto = GetText(textoMonitoramento);
            return texto;
        }
        public string RetornaAtribuido()
        {
            string texto = GetText(textoAtribuido);
            return texto;
        }

        public string RetornaStatus()
        {
            string texto = GetText(textoStatus);
            return texto;
        }

        public string RetornaDescricaoAtu()
        {
            string texto = GetText(textoDescricaoAtu);
            return texto;
        }

        public string RetornaClone()
        {
            string texto = GetText(textoClone);
            return texto;
        }

        public string RetornaLembrete()
        {
            string texto = GetText(textoLembrete);
            return texto;
        }

        public string RetornaLembreteAtu()
        {
            string texto = GetText(textoLembreteAtu);
            return texto;
        }

        public string RetornaAnotacao()
        {
            string texto = GetText(textoAnotacao);
            return texto;
        }

        public string RetornaHistorico()
        {
            string texto = GetText(textoHistorico);
            return texto;
        }

        public string RetornaPegajoso()
        {
            string texto = GetValue(textoPegajoso);
            return texto;
        }

        public string RetornaMonitorar()
        {
            string texto = GetValue(textoMonitorar);
            return texto;
        }

        public string RetornaMoverTarefa()
        {
            string texto = GetText(textoMoverTarefa);
            return texto;
        }

        public string RetornaPesquisa()
        {
            string texto = GetText(textoPesquisa);
            return texto;
        }

        public string RetornaLembreteCodigo()
        {
            string texto = GetText(textoLembreteCodigo);
            return texto;
        }

        public string RetornaLembreteExcluido()
        {
            string texto = GetText(textoLembreteCodigo);
            return texto;
        }

        public bool RetornaMonitoramentoExcluido()
        {
            bool texto = ReturnIfElementExist(textoMonitoramento);
            return texto;
        }

        public string RetornaTarefaFechada()
        {
            string texto = GetText(textoTarefaFechada);
            return texto;
        }

        public string RetornaTarefaReaberta()
        {
            string texto = GetText(textoTarefaReaberta);
            return texto;
        }

        public string RetornaPrivado()
        {
            string texto = GetText(textoBotaoTornaPublico);
            return texto;
        }

        #endregion
    }
}
