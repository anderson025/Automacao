using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Pages;
namespace DesafioBase2.Flows
{
    public class GerenciarMarcadoresFlows
    {
        #region Page Object and Constructor
        GerenciarMarcadoresPage gerenciarMarcadoresPage;


        public GerenciarMarcadoresFlows()
        {
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();
        }
        #endregion

        public void AcessarMenuGerenciarMarcadores()
        {
            gerenciarMarcadoresPage.ClicarEmGerenciarProjetos();
            gerenciarMarcadoresPage.ClicarEmGerenciarMarcadores();
        }
    }
}
