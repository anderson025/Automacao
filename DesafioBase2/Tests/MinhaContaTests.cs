using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Bases;
using DesafioBase2.Pages;
using DesafioBase2.Flows;
using NUnit.Framework;
using System.Windows.Forms;

namespace DesafioBase2.Tests
{
    [TestFixture]
    public class MinhaContaTests : TestBase
    {
        MinhaContaPage minhaContaPage;
        LoginFlows loginFlows;
        string usuario = "administrator";
        string senha = "administrator";
        string nomeReal = "Anderson";

        string plataforma = "Teste2";
        string sistema = "Windows";
        string versaoSistema = "10";
        string descricao = "Testes adicionamento Perfil";

        string nomeToken = "Teste";


        [Test]
        public void ClicarEmMinhaConta()
        {
            minhaContaPage = new MinhaContaPage();
            loginFlows = new LoginFlows();

            #region Action
            loginFlows.EfetuarLogin(usuario,senha);
            minhaContaPage.ClicarEmMenuUsuario();
            minhaContaPage.ClicarEmMinhaConta();
            #endregion

            #region validacoes
            string texto = minhaContaPage.RetornaTexto();
            Assert.AreEqual(texto, "Alterar Conta");            

            #endregion
        }

        [Test]
        public void ClicarEmRSS()
        {
            minhaContaPage = new MinhaContaPage();
            loginFlows = new LoginFlows();

            #region Action

            loginFlows.EfetuarLogin(usuario, senha);
            minhaContaPage.ClicarEmMenuUsuario();
            minhaContaPage.ClicarEmRSS();

            #endregion

            #region Validation

            string texto = minhaContaPage.RetornaTextoRSS();
            Assert.AreEqual(texto, "This XML file does not appear to have any style information associated with it. The document tree is shown below.");

            #endregion
        }

        [Test]
        public void ClicarEmSair()
        {
            minhaContaPage = new MinhaContaPage();
            loginFlows = new LoginFlows();

            #region Action
            loginFlows.EfetuarLogin(usuario, senha);
            minhaContaPage.ClicarEmMenuUsuario();
            minhaContaPage.ClicarEmSair();
            #endregion

            #region Validation
            string texto = minhaContaPage.RetornaTextoLogin();
            Assert.AreEqual(texto, "Entrar");
            #endregion

        }

        [Test]
        public void AtualizarNomeVerdadeiro()
        {
            minhaContaPage = new MinhaContaPage();
            loginFlows = new LoginFlows();

            #region Action
            loginFlows.EfetuarLogin(usuario, senha);

            minhaContaPage.ClicarEmMenuUsuario();
            minhaContaPage.ClicarEmMinhaConta();
            minhaContaPage.LimparCampos();
            minhaContaPage.PreencherNomeReal(nomeReal);
            minhaContaPage.ClicarEmAtualizarUsuario();

            #endregion

            #region Validation

            string texto = minhaContaPage.RetornaNomeVerdadeiro();
            Assert.AreEqual(texto, "administrator " + "( "+ nomeReal +" )");

            #endregion
        }
        [Test]
        public void AtualizarPreferencias()
        {
            minhaContaPage = new MinhaContaPage();
            loginFlows = new LoginFlows();

            #region Action

            loginFlows.EfetuarLogin(usuario, senha);

            minhaContaPage.ClicarEmMenuUsuario();
            minhaContaPage.ClicarEmMinhaConta();

            minhaContaPage.ClicarEmMenuPreferencias();
            minhaContaPage.ClicarEmEnviarEmailStatus();
            minhaContaPage.ClicarEmEnviarEmailPrioridade();
            minhaContaPage.ClicarEmAtualizarPreferencias();

            #endregion

            #region Validation
            bool selecionadoStatus = minhaContaPage.RetornaEmailStatus();
            bool selecionadoPrioridade = minhaContaPage.RetornaEmailStatus();
            Assert.IsTrue(selecionadoStatus);
            Assert.IsTrue(selecionadoPrioridade);

            #endregion


        }

        [Test]
        public void RedefinirPreferencias()
        {
            minhaContaPage = new MinhaContaPage();
            loginFlows = new LoginFlows();

            #region Action
            loginFlows.EfetuarLogin(usuario, senha);
            minhaContaPage.ClicarEmMenuUsuario();
            minhaContaPage.ClicarEmMinhaConta();
            minhaContaPage.ClicarEmMenuPreferencias();
            minhaContaPage.ClicarEmEnviarEmailStatus();
            minhaContaPage.ClicarEmEnviarEmailPrioridade();
            minhaContaPage.ClicarEmAtualizarPreferencias();
            minhaContaPage.ClicarEmRedefinirPreferencias();

            #endregion
            #region validations
            bool selecionadoStatus = minhaContaPage.RetornaEmailStatus();
            bool selecionadoPrioridade = minhaContaPage.RetornaEmailStatus();
            Assert.IsFalse(selecionadoStatus);
            Assert.IsFalse(selecionadoPrioridade);

            #endregion

        }
        [Test]
        public void AdicionarPerfil()
        {
            minhaContaPage = new MinhaContaPage();
            loginFlows = new LoginFlows();

            #region Action

            loginFlows.EfetuarLogin(usuario, senha);
            minhaContaPage.ClicarEmMenuUsuario();
            minhaContaPage.ClicarEmMinhaConta();
            minhaContaPage.ClicarEmMenuPerfis();
            minhaContaPage.PreencherPlataforma(plataforma);
            minhaContaPage.PreencherSistemaOperacional(sistema);
            minhaContaPage.PreencherVersaoSistema(versaoSistema);
            minhaContaPage.PreencherDescricao(descricao);
            minhaContaPage.ClicarEmAdicionarPerfil();
            #endregion

            #region Validation
            string texto = minhaContaPage.RetornaPerfilAdicionado();
            Assert.AreEqual(texto, plataforma +" " + sistema + " "+ versaoSistema);
            #endregion
        }
        [Test]
        public void CriarToken()
        {
            minhaContaPage = new MinhaContaPage();
            loginFlows = new LoginFlows();

            #region Action
            loginFlows.EfetuarLogin(usuario, senha);

            minhaContaPage.ClicarEmMenuUsuario();
            minhaContaPage.ClicarEmMinhaConta();
            minhaContaPage.ClicarEmMenuToken();
            minhaContaPage.PreencherNomeToken(nomeToken);
            minhaContaPage.ClicarEmCriarToken();
            #endregion

            #region Validation

            // Quando já existir registro no banco de dados

            //string texto = minhaContaPage.RetornaTextoErroCriarToken();
            //Assert.AreEqual(texto, "APPLICATION ERROR #3000");

            //teste positivo

            string texto = minhaContaPage.RetornaTextoCriarToken();
            Assert.AreEqual(texto, "Token que deve ser usado ao acessar API.");


            #endregion
        }
    }
}
