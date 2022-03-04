using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Bases;
using NUnit.Framework;
using DesafioBase2.Pages;
using DesafioBase2.Flows;
namespace DesafioBase2.Tests
{
    [TestFixture]
    class GerenciarCamposPersonalizadosTests : TestBase
    {
        GerenciarCamposPersonalizadosPage gerenciarCamposPersonalizadosPage;
        LoginFlows loginFlows;
        GerenciarCamposPersonalizadosFlows gerenciarCamposPersonalizadosFlows;
        string usuario = "administrator";
        string senha = "administrator";
        string teste = "Teste123";
        string testeAtu = "Teste12345";

        [Test]
        public void AdicionarCampoPersonalizado()
        {
            gerenciarCamposPersonalizadosPage = new GerenciarCamposPersonalizadosPage();
            loginFlows = new LoginFlows();
            gerenciarCamposPersonalizadosFlows = new GerenciarCamposPersonalizadosFlows();

            loginFlows.EfetuarLogin(usuario,senha);
            gerenciarCamposPersonalizadosFlows.AcessarMenuGerenciarCamposPersonalizados();

            gerenciarCamposPersonalizadosPage.PreencherNomeCampo(teste);
            gerenciarCamposPersonalizadosPage.ClicarEmNovoCampo();
            gerenciarCamposPersonalizadosFlows.AcessarMenuGerenciarCamposPersonalizados();

            #region validacoes
            string texto = gerenciarCamposPersonalizadosPage.RetornaCampoPersonalizado();
            Assert.AreEqual(texto, teste);
            #endregion
        }

        [Test]
        public void DeletarCampoPersonalizado()
        {
            gerenciarCamposPersonalizadosPage = new GerenciarCamposPersonalizadosPage();
            loginFlows = new LoginFlows();
            gerenciarCamposPersonalizadosFlows = new GerenciarCamposPersonalizadosFlows();

            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarCamposPersonalizadosFlows.AcessarMenuGerenciarCamposPersonalizados();
            gerenciarCamposPersonalizadosPage.ClicarEmNovoCampoGrid();
            gerenciarCamposPersonalizadosPage.ClicarEmApagarCampo();
            gerenciarCamposPersonalizadosPage.ClicarEmConfirmaApagaCampo();

            #region validacoes
            bool texto = gerenciarCamposPersonalizadosPage.RetornaCampoExiste();
            Assert.IsFalse(texto);

            #endregion
        }

        [Test]
        public void AtualizarCampoPersonalizado()
        {
            gerenciarCamposPersonalizadosPage = new GerenciarCamposPersonalizadosPage();
            loginFlows = new LoginFlows();
            gerenciarCamposPersonalizadosFlows = new GerenciarCamposPersonalizadosFlows();

            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarCamposPersonalizadosFlows.AcessarMenuGerenciarCamposPersonalizados();
            gerenciarCamposPersonalizadosPage.ClicarEmNovoCampoGrid();
            gerenciarCamposPersonalizadosPage.LimparCampos();
            gerenciarCamposPersonalizadosPage.PreencherNomeCampo(testeAtu);
            gerenciarCamposPersonalizadosPage.PreencherNomePadrao(testeAtu);
            gerenciarCamposPersonalizadosPage.ClicarEmRequerAtualizacao();
            gerenciarCamposPersonalizadosPage.ClicarEmAtualizarCampo();

            #region validacoes
            string texto = gerenciarCamposPersonalizadosPage.RetornaCampoPersonalizadoAtualizado();
            Assert.AreEqual(texto, testeAtu);

            #endregion

        }
    }
}
