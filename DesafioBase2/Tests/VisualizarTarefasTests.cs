using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Bases;
using DesafioBase2.Pages;
using NUnit.Framework;
using DesafioBase2.Flows;
namespace DesafioBase2.Tests
{   
    [TestFixture]
    public class VisualizarTarefasTests : TestBase
    {
        #region Pages and Flows Objects
        VisualizarTarefasPage visualizarTarefasPage;
        LoginFlows loginFlows;
        string usuario = "administrator";
        string senha = "administrator";
        string informacaoLembrete = "Nao esquecer a tarefa x";
        string informacaoLembreteAlterado = "Nao esquecer a tarefa x,y e z";

        string resumoAtualizado = "Desafio Base2 Atualizada";
        string descricaoAtualizada = "Iniciando desafio base2 atualizada";

        string anotacao = "Teste Anotacao";
        string anotacaoReabrir = "Teste Anotacao Reabrir";
        string anotacaoStatus = "Teste Anotacao Mudança de status";

        string resumoClone = "Desafio Base2 Clone";
        string descricaoClone = "Iniciando desafio base2 Clone";

        string relaciomento = "1";

        #endregion

        public void CarregarTarefa()
        {
            visualizarTarefasPage = new VisualizarTarefasPage();
            loginFlows = new LoginFlows();

            loginFlows.EfetuarLogin(usuario, senha);

            visualizarTarefasPage.ClicarMenuVerTarefas();
            visualizarTarefasPage.ClicarEmSelecionarTarefa();
        }

        [Test]
        public void EnviarLembrete()
        {

            #region Action
            CarregarTarefa();

            visualizarTarefasPage.ClicarEmEnviarLembrete();
            visualizarTarefasPage.ClicarEmDestinatarioLembrete();
            visualizarTarefasPage.PreencherInformacaoLembrete(informacaoLembrete);
            visualizarTarefasPage.ClicarEmConfirmarEnvioLembrete();

            #endregion

            #region Validation
            string texto = visualizarTarefasPage.RetornaLembrete();
            Assert.AreEqual(texto, "Lembrete mandado para: administrator\r\n\r\nNao esquecer a tarefa x");
            #endregion
        }

        [Test]
        public void AtualizarLembrete()
        {
            CarregarTarefa();

            visualizarTarefasPage.ClicarEmAlterarLembrete();
            visualizarTarefasPage.LimparCampos();
            visualizarTarefasPage.PreencherCorpoLembreteAlterado(informacaoLembreteAlterado);
            visualizarTarefasPage.ClicarEmAtualizarInformacoes();

            string texto = visualizarTarefasPage.RetornaLembreteAtu();
            Assert.AreEqual(texto, "Nao esquecer a tarefa x,y e z");

        }

        [Test]
        public void DeletarLembrete()
        {
            CarregarTarefa();

            string texto = visualizarTarefasPage.RetornaLembreteCodigo();
            visualizarTarefasPage.ClicarEmApagarLembrete();
            visualizarTarefasPage.ClicarEmApagarLembreteConfirmar();

            string apagado = visualizarTarefasPage.RetornaLembreteExcluido();
            Assert.AreNotEqual(texto, apagado);
        }

        [Test]
        public void TornarLembretePrivado()
        {
            CarregarTarefa();

            visualizarTarefasPage.ClicarEmTornarPrivado();

            string texto = visualizarTarefasPage.RetornaPrivado();
            Assert.AreEqual(texto, "Tornar Público");
        }

        [Test]
        public void AtualizarTarefa()
        {
            #region Action
            CarregarTarefa();
            visualizarTarefasPage.ClicarEmAtualizarTarefa();
            visualizarTarefasPage.LimparCamposAtualizacao();
            visualizarTarefasPage.PreencherResumo(resumoAtualizado);
            visualizarTarefasPage.PreencherDescricao(descricaoAtualizada);
            visualizarTarefasPage.ClicarEmAtualizarInformacoes();

            #endregion

            #region Validation
            string texto = visualizarTarefasPage.RetornaDescricaoAtu();
            Assert.AreEqual(texto, descricaoAtualizada);
            #endregion


        }

        [Test]
        public void IrParaAnotacoes()
        {
            #region Action
            CarregarTarefa();
            visualizarTarefasPage.ClicarEmIrParaAnotacoes();
            visualizarTarefasPage.ClicarEmVisibilidade();
            visualizarTarefasPage.PreencherAnotacao(anotacao);
            visualizarTarefasPage.ClicarEmAdicionarAnotacao();

            #endregion

            #region Validation

            string texto = visualizarTarefasPage.RetornaAnotacao();
            Assert.AreEqual(texto, anotacao);

            #endregion

        }


        [Test]
        public void IrParaHistórico()
        {
            #region Action
            CarregarTarefa();
            visualizarTarefasPage.ClicarEmIrParaHistorico();
            visualizarTarefasPage.ClicarEmHistorico();

            #endregion

            #region Validation
            string texto = visualizarTarefasPage.RetornaHistorico();
            Assert.AreEqual(texto, "Linha do tempo");

            #endregion

        }

        [Test]
        public void MonitorarTarefa()
        {
            #region Action
            CarregarTarefa();
            visualizarTarefasPage.ClicarEmMonitorar();

            #endregion

            #region Validation

            string texto = visualizarTarefasPage.RetornaMonitorar();
            Assert.AreEqual(texto, "Parar de Monitorar");

            #endregion

        }

        [Test]
        public void MarcarComoPegajoso()
        {
            #region Action

            CarregarTarefa();
            visualizarTarefasPage.ClicarEmMarcarPegajoso();

            #endregion

            #region Validation

            string texto = visualizarTarefasPage.RetornaPegajoso();
            Assert.AreEqual(texto, "Desmarcar como Pegajoso");

            #endregion
        }

        [Test]
        public void CriarCloneTarefa()
        {
            #region Action

            CarregarTarefa();
            visualizarTarefasPage.ClicarEmClicarClone();
            visualizarTarefasPage.LimparCamposAtualizacao();
            visualizarTarefasPage.PreencherResumo(resumoClone);
            visualizarTarefasPage.PreencherDescricao(descricaoClone);
            visualizarTarefasPage.ClicarEmCriarNovaTarefa();

            #endregion

            #region Validation
            string texto = visualizarTarefasPage.RetornaClone();
            Assert.AreEqual(texto, descricaoClone);

            #endregion
        }

        [Test]
        public void FecharTarefa()
        {
            CarregarTarefa();
            visualizarTarefasPage.ClicarEmFechar();
            visualizarTarefasPage.PreencherAnotacao(anotacao);
            visualizarTarefasPage.ClicarEmfecharTarefa();

            string texto = visualizarTarefasPage.RetornaTarefaFechada();
            Assert.AreEqual(texto, "fechado");
        }

        [Test]
        public void ReabrirTarefa()
        {
            CarregarTarefa();
            visualizarTarefasPage.ClicarbtnReabrir();
            visualizarTarefasPage.PreencherAnotacao(anotacaoReabrir);
            visualizarTarefasPage.ClicarEmSolicitarRetorno();

            string texto = visualizarTarefasPage.RetornaTarefaReaberta();
            Assert.AreEqual(texto, "retorno");
        }

        [Test]
        public void MoverTarefa()
        {
            CarregarTarefa();
            visualizarTarefasPage.ClicarEmMover();
            visualizarTarefasPage.ClicarEmMoverPara();
            visualizarTarefasPage.ClicarEmMoverTarefa();
            visualizarTarefasPage.ClicarNaTarefa();

            string texto = visualizarTarefasPage.RetornaMoverTarefa();
            Assert.AreEqual(texto, "desafio Base2");
        }

        [Test]
        public void ApagarTarefa()
        {
            CarregarTarefa();
            visualizarTarefasPage.ClicarEmApagar();
            visualizarTarefasPage.ClicarEmApagarTarefa();
        }

        [Test]
        public void AdicionarUsuarioMonitoramento()
        {
            CarregarTarefa();
            visualizarTarefasPage.PreencherNomeUsuarioMonitoramento(usuario);
            visualizarTarefasPage.ClicarEmAdicionarUsuarioMonitoramento();

            #region Validation

            string texto = visualizarTarefasPage.RetornaMonitoramento();
            Assert.AreEqual(texto, usuario);

            #endregion
        }

        [Test]
        public void RemoverUsuarioMonitorTarefa()
        {
            CarregarTarefa();
            visualizarTarefasPage.ClicarEmRemoverUsuarioMonitoramento();

            bool texto = visualizarTarefasPage.RetornaMonitoramentoExcluido();
            Assert.IsFalse(texto);


        }

        [Test]
        public void AdicionarRelacionamento()
        {
            CarregarTarefa();
            #region Action
            visualizarTarefasPage.ClicarEmTipoRelacionamento();
            visualizarTarefasPage.PreencherNomeRelacionamento(relaciomento);
            visualizarTarefasPage.ClicarEmAdicionarRelacionamento();

            #endregion

            #region Validation
            string texto = visualizarTarefasPage.RetornaRelacionamento();
            Assert.AreEqual(texto, "0000001");

            #endregion
        }

        [Test]
        public void RemoverRelacionamento()
        {
            CarregarTarefa();
            visualizarTarefasPage.ClicarEmRemoverRelacionamento();
            visualizarTarefasPage.ClicarEmConfirmarRemoverRelacionamento();

            bool texto = visualizarTarefasPage.RetornaRelacionamentoExcluido();
            Assert.IsFalse(texto);
            

        }

        [Test]
        public void AlterarStatus()
        {
            CarregarTarefa();
            visualizarTarefasPage.ClicarEmComboAlterarStatus();
            visualizarTarefasPage.ClicarEmAlterarStatus();
            visualizarTarefasPage.PreencherAnotacao(anotacaoStatus);
            visualizarTarefasPage.ClicarEmSolicitarRetorno();

            string texto = visualizarTarefasPage.RetornaStatus();
            Assert.AreEqual(texto, "admitido");
        }

        [Test]
        public void AlterarAtribuido()
        {
            CarregarTarefa();
            visualizarTarefasPage.ClicarEmComboAtribuir();
            visualizarTarefasPage.ClicarEmAtribuir();

            string texto = visualizarTarefasPage.RetornaAtribuido();
            Assert.AreEqual(texto, "administrator");

        }

        [Test]
        public void PesquisarTarefa()
        {
            #region Action

            CarregarTarefa();
            visualizarTarefasPage.PreencherNumeroTarefa("4");
            visualizarTarefasPage.ClicarEnter();

            #endregion

            #region Validation
            string texto = visualizarTarefasPage.RetornaPesquisa();
            Assert.AreEqual(texto, "0000004");
            #endregion
        }

        [Test]
        public void NavegacaoNaTarefa()
        {
            CarregarTarefa();
            visualizarTarefasPage.ClicarNavegacaoDireita();
            visualizarTarefasPage.ClicarNavegacaoDireita();
            visualizarTarefasPage.ClicarNavegacaoEsquerda();
            visualizarTarefasPage.ClicarNavegacaoEsquerda();
        }



    }
}
