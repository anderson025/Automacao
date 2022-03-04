using DesafioBase2.Pages;
using NUnit.Framework;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Helpers;

namespace DesafioBase2.Flows
{
    public class LoginFlows
    {
        #region Page Object and Constructor
        LoginMantisPage loginMantisPage;        
        

        public LoginFlows()
        {
            loginMantisPage = new LoginMantisPage();            
        }
        #endregion
        
        public void EfetuarLogin(string usuario, string senha)
        {
            loginMantisPage.PreencherUsuarioJS(usuario);
            loginMantisPage.ClicarEmEntrarJS();
            loginMantisPage.PreencherSenhaJS(senha);
            loginMantisPage.ClicarEmEntrarJS();
        }
    }
}
