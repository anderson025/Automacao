using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Pages;
using DesafioBase2.Bases;
using DesafioBase2.Flows;
using NUnit.Framework;

namespace DesafioBase2.Tests
{
    [TestFixture]
    class GerenciarPerfisGlobaisTests: TestBase
    {
        #region Pages and Flows Objects

        GerenciarPerfisGlobaisPage gerenciarPerfisGlobaisPage;
        LoginFlows loginFlows;
        GerenciarPerfisGlobaisFlows gerenciarPerfisGlobaisFlows;
        string plataforma = "Teste";
        string plataforma2 = "Teste2";
        string sistemaOperacional = "Windows";
        string versao = "Windows 10";
        string descricao = "Teste windows 10";
        string usuario = "administrator";
        string senha = "administrator";

        #endregion


        [Test]
        public void AdicionarPerfil()
        {
            gerenciarPerfisGlobaisPage = new GerenciarPerfisGlobaisPage();
            loginFlows = new LoginFlows();
            gerenciarPerfisGlobaisFlows = new GerenciarPerfisGlobaisFlows();

            loginFlows.EfetuarLogin(usuario,senha);
            gerenciarPerfisGlobaisFlows.AcessarMenuGerenciarPerfisGlobais();
            gerenciarPerfisGlobaisPage.PreencherPlataforma(plataforma);
            gerenciarPerfisGlobaisPage.PreencherSistemaOperacional(sistemaOperacional);
            gerenciarPerfisGlobaisPage.PreencherVersaoSistema(versao);
            gerenciarPerfisGlobaisPage.PreencherDescricaoAdicional(descricao);
            gerenciarPerfisGlobaisPage.ClicarEmAdicionarPerfil();

            #region validacoes
            string texto = gerenciarPerfisGlobaisPage.RetornaPerfilGlobal();
            Assert.AreEqual(texto, plataforma + " " + sistemaOperacional + " " + versao);

            #endregion

        }
        [Test]
        public void EditarPerfil()
        {
            gerenciarPerfisGlobaisPage = new GerenciarPerfisGlobaisPage();
            loginFlows = new LoginFlows();
            gerenciarPerfisGlobaisFlows = new GerenciarPerfisGlobaisFlows();

            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.AcessarMenuGerenciarPerfisGlobais();
            gerenciarPerfisGlobaisPage.ClicarEmEditar();            
            gerenciarPerfisGlobaisPage.ClicarEmSelecionarCombo();
            gerenciarPerfisGlobaisPage.ClicarEmEnviar();
            gerenciarPerfisGlobaisPage.LimparCampos();
            gerenciarPerfisGlobaisPage.PreencherPlataforma(plataforma2);
            gerenciarPerfisGlobaisPage.PreencherSistemaOperacional(sistemaOperacional);
            gerenciarPerfisGlobaisPage.PreencherVersaoSistema(versao);
            gerenciarPerfisGlobaisPage.PreencherDescricaoAdicional(descricao);
            gerenciarPerfisGlobaisPage.ClicarEmAtualizarPerfil();

            #region validacoes
            string texto = gerenciarPerfisGlobaisPage.RetornaPerfilGlobalAtualizado();
            Assert.AreEqual(texto, plataforma2 + " " + sistemaOperacional + " " + versao);

            #endregion

        }

        [Test]
        public void DeletarPerfil()
        {
            gerenciarPerfisGlobaisPage = new GerenciarPerfisGlobaisPage();
            loginFlows = new LoginFlows();
            gerenciarPerfisGlobaisFlows = new GerenciarPerfisGlobaisFlows();

            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPerfisGlobaisFlows.AcessarMenuGerenciarPerfisGlobais();
            gerenciarPerfisGlobaisPage.ClicarEmDeletar();
            gerenciarPerfisGlobaisPage.ClicarEmSelecionarCombo();
            gerenciarPerfisGlobaisPage.ClicarEmEnviar();

            #region validacoes
            bool texto = gerenciarPerfisGlobaisPage.RetornaPerfilExcluido();
            Assert.IsFalse(texto);

            #endregion
        }
    }
}
