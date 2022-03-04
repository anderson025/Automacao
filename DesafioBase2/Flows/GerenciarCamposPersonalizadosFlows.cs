using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Pages;
namespace DesafioBase2.Flows
{
    class GerenciarCamposPersonalizadosFlows
    {
        #region Page Object and Constructor
        GerenciarCamposPersonalizadosPage gerenciarCamposPersonalizadosPage;


        public GerenciarCamposPersonalizadosFlows()
        {
            gerenciarCamposPersonalizadosPage = new GerenciarCamposPersonalizadosPage();
        }
        #endregion

        public void AcessarMenuGerenciarCamposPersonalizados()
        {
            gerenciarCamposPersonalizadosPage.ClicarEmGerenciarProjetos();
            gerenciarCamposPersonalizadosPage.ClicarEmGerenciarCamposPersonalizados();
        }
    }
}
