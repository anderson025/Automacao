using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Bases;
using OpenQA.Selenium;

namespace DesafioBase2.Pages
{   
    
    public class GerenciarPluginsPage : PageBase
    {
        #region Mapping
        By clicarGerenciarProjetos = By.CssSelector("ul li i[class = 'menu-icon fa fa-gears']");
        By clicarGerenciarPlugins = By.XPath("//a[text()='Gerenciar Plugins']");
        By btnDesinstalar = By.LinkText("Desinstalar");
        By btnInstalar = By.LinkText("Instalar");
        By btnConfirmarDesinstalacao = By.CssSelector("input[class='btn btn-primary btn-white btn-round']");

        //validacoes

        By textoPluginInstalado = By.XPath("//tr[1]//td//a[@class='btn btn-primary btn-white btn-round btn-xs']");

        By textoPluginDesinstalado = By.XPath("//tbody/tr[1]//td[4]/a");

        #endregion

        #region Actions

        public void ClicarEmGerenciarProjetos()
        {
            Click(clicarGerenciarProjetos);
        }

        public void ClicarEmGerenciarPlugins()
        {
            Click(clicarGerenciarPlugins);
        }
        public void ClicarEmInstalar()
        {
            Click(btnInstalar);

        }

        public void ClicarEmDesinstalar()
        {
            Click(btnDesinstalar);
        }

        public void ClicarEmConfirmarDesinstalacao()
        {
            Click(btnConfirmarDesinstalacao);
        }

        public string RetornaPluginInstalado()
        {
            string texto = GetText(textoPluginInstalado);
            return texto;
        }

        public string RetornaPluginDesinstalado()
        {
            string texto = GetText(textoPluginDesinstalado);
            return texto;
        }

        #endregion
    }
}
