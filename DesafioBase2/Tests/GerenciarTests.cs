using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Bases;
using NUnit.Framework;
using DesafioBase2.Pages;
using DesafioBase2.Helpers;
using DesafioBase2.Flows;

namespace DesafioBase2.Tests
{
    [TestFixture]
    class GerenciarTests : TestBase
    {
        GerenciarPage gerenciarPage;
        LoginFlows loginFlows;
        string usuario = "administrator";
        string senha = "administrator";
        string nome = "teste";
        string nomeAtu = "Teste2";
        string nomeVerdadeiro = "Teste silva";
        string email = "email@email";


        [Test]
        public void CadastrarNovoUsuario()
        {
            gerenciarPage = new GerenciarPage();
            loginFlows = new LoginFlows();          
               
            #region Action

            loginFlows.EfetuarLogin(usuario,senha);
            gerenciarPage.ClicarMenuGerenciar();
            gerenciarPage.ClicarEmGerenciarUsuarios();
            gerenciarPage.ClicarEmCriarNovaConta();
            gerenciarPage.PreencherUsuario(nome);
            gerenciarPage.PreencherNomeVerdadeiro(nomeVerdadeiro);
            gerenciarPage.PreencherEmail(email);
            gerenciarPage.ClicarEmCriarUsuario();
            gerenciarPage.ClicarEmGerenciarUsuarios();

            #endregion

            #region validations

            string texto = gerenciarPage.RetornaContaIncluida();
            Assert.AreEqual(texto, nome);

            #endregion
        }
        [Test]
        public void DeletarUsuario()
        {
            gerenciarPage = new GerenciarPage();
            loginFlows = new LoginFlows();

            #region Action
            //CadastrarNovoUsuario();
            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPage.ClicarMenuGerenciar();
            gerenciarPage.ClicarEmGerenciarUsuarios();
            gerenciarPage.ClicarUsuarioGridAtualizado();
            gerenciarPage.ClicarApagarUsuario();
            gerenciarPage.ClicarApagarConta();
            gerenciarPage.ClicarEmGerenciarUsuarios();

            #endregion

            #region validations

            bool texto = gerenciarPage.RetornaContaExcluida();
            Assert.IsFalse(texto);

            #endregion

        }
        [Test]
        public void AtualizarUsuario()
        {
            gerenciarPage = new GerenciarPage();
            loginFlows = new LoginFlows();

            #region Action
            //CadastrarNovoUsuario();

            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPage.ClicarMenuGerenciar();
            gerenciarPage.ClicarEmGerenciarUsuarios();
            gerenciarPage.ClicarUsuarioGrid();
            gerenciarPage.LimparCampos();
            gerenciarPage.PreencherUsuario(nomeAtu);
            gerenciarPage.PreencherNomeVerdadeiro(nomeVerdadeiro);
            gerenciarPage.PreencherEmail(email);

            gerenciarPage.ClicarAtualizarUsuario();
            gerenciarPage.ClicarEmGerenciarUsuarios();
            #endregion

            #region validations
            string texto = gerenciarPage.RetornaContaAtualizada();
            Assert.AreEqual(texto, nomeAtu);

            #endregion

        }

    }
}
