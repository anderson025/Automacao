using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Bases;
using DesafioBase2.Pages;
using DesafioBase2.Flows;
namespace DesafioBase2.Tests
{   
    [TestFixture]
    public class GerenciarMarcadoresTests : TestBase
    {
        GerenciarMarcadoresPage gerenciarMarcadoresPage;
        LoginFlows loginFlows;
        GerenciarMarcadoresFlows gerenciarMarcadoresFlows;
        string usuario = "administrator";
        string senha = "administrator";
        string nomeMarcador = "Desafio";
        string nomeMarcadorAtu = "Desafio2";
        string descricaoMarcador = "teste desafio";

        [Test]
        public void AdicionarMarcadores()
        {
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();
            loginFlows = new LoginFlows();
            gerenciarMarcadoresFlows = new GerenciarMarcadoresFlows();

            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarMarcadoresFlows.AcessarMenuGerenciarMarcadores();

            gerenciarMarcadoresPage.ClicarEmCriarMarcadores();
            gerenciarMarcadoresPage.PreencherNomeMarcador(nomeMarcador);
            gerenciarMarcadoresPage.PreencherDescricaoMarcador(descricaoMarcador);
            gerenciarMarcadoresPage.ClicarEmGravarMarcador();

            #region validacoes
            string texto = gerenciarMarcadoresPage.RetornaMarcadorAdicionado();
            Assert.AreEqual(texto, nomeMarcador);

            #endregion
        }
        [Test]
        public void DeletarMarcadores()
        {
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();
            loginFlows = new LoginFlows();
            gerenciarMarcadoresFlows = new GerenciarMarcadoresFlows();

            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarMarcadoresFlows.AcessarMenuGerenciarMarcadores();

            gerenciarMarcadoresPage.ClicarNoRegistroNoGrid();
            gerenciarMarcadoresPage.ClicarEmApagarMarcador();
            gerenciarMarcadoresPage.ClicarEmConfirmarApagarMarcador();

            bool texto = gerenciarMarcadoresPage.RetornaMarcadorExcluido();
            Assert.IsFalse(texto);
            

        }
        [Test]
        public void AtualizarMarcadores()
        {
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();
            loginFlows = new LoginFlows();
            gerenciarMarcadoresFlows = new GerenciarMarcadoresFlows();

            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarMarcadoresFlows.AcessarMenuGerenciarMarcadores();
            gerenciarMarcadoresPage.ClicarNoRegistroNoGrid();
            gerenciarMarcadoresPage.ClicarEmAtualizarMarcador();
            gerenciarMarcadoresPage.LimparCampos();
            gerenciarMarcadoresPage.PreencherNomeMarcador(nomeMarcadorAtu);
            gerenciarMarcadoresPage.PreencherDescricaoMarcador(descricaoMarcador);
            gerenciarMarcadoresPage.ClicarEmAtualizarMarcador();

            #region validacoes
            string texto = gerenciarMarcadoresPage.RetornaMarcadorAtualizado();
            Assert.AreEqual(texto, nomeMarcadorAtu);

            #endregion
        }
    }
}
