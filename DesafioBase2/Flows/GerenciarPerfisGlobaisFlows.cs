using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Pages;
namespace DesafioBase2.Flows
{
    public class GerenciarPerfisGlobaisFlows
    {
        #region Page Object and Constructor
        GerenciarPerfisGlobaisPage gerenciarPerfisGlobaisPage;


        public GerenciarPerfisGlobaisFlows()
        {
            gerenciarPerfisGlobaisPage = new GerenciarPerfisGlobaisPage();
        }
        #endregion

        public void AcessarMenuGerenciarPerfisGlobais()
        {
            gerenciarPerfisGlobaisPage.ClicarEmGerenciarProjetos();
            gerenciarPerfisGlobaisPage.ClicarEmMenuGerenciarPerfisGlobais();
        }
    }
}
