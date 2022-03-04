using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Pages;
using DesafioBase2.Bases;
using NUnit.Framework;
using DesafioBase2.Flows;

namespace DesafioBase2.Tests
{
    [TestFixture]
    public class GerenciarPluginTests : TestBase
    {
        GerenciarPluginsPage gerenciarPluginsPage;
        LoginFlows loginFlows;
        GerenciarPluginsFlows gerenciarPluginsFlows;
        string usuario = "administrator";
        string senha = "administrator";

        [Test]
        public void AdicionarPlugin()
        {
            gerenciarPluginsPage = new GerenciarPluginsPage();
            loginFlows = new LoginFlows();
            gerenciarPluginsFlows = new GerenciarPluginsFlows();

            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPluginsFlows.AcessarMenuGerenciarPlugins();
            gerenciarPluginsPage.ClicarEmInstalar();

            #region validacoes
            string texto = gerenciarPluginsPage.RetornaPluginInstalado();
            Assert.AreEqual(texto, "Desinstalar");
            #endregion

        }
        [Test]
        public void DeletarPlugin()
        {
            gerenciarPluginsPage = new GerenciarPluginsPage();
            loginFlows = new LoginFlows();
            gerenciarPluginsFlows = new GerenciarPluginsFlows();

            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarPluginsFlows.AcessarMenuGerenciarPlugins();
            gerenciarPluginsPage.ClicarEmDesinstalar();
            gerenciarPluginsPage.ClicarEmConfirmarDesinstalacao();

            #region validacoes
            string texto = gerenciarPluginsPage.RetornaPluginDesinstalado();
            Assert.AreEqual(texto, "Instalar");


            #endregion

        }
    }
}
