using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Pages;

namespace DesafioBase2.Flows
{
    public class GerenciarPluginsFlows
    {
        #region Page Object and Constructor
        GerenciarPluginsPage gerenciarPluginsPage;

        #endregion

        public GerenciarPluginsFlows()
        {
            gerenciarPluginsPage = new GerenciarPluginsPage();
        }
        public void AcessarMenuGerenciarPlugins()
        {
            gerenciarPluginsPage.ClicarEmGerenciarProjetos();
            gerenciarPluginsPage.ClicarEmGerenciarPlugins();
        }
    }
}
