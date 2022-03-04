using DesafioBase2.Bases;
using DesafioBase2.DataBaseSteps;
using DesafioBase2.Helpers;
using DesafioBase2.Pages;
using NUnit.Framework;
using System.Collections;
namespace DesafioBase2.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {

        #region Pages and Flows Objects
        LoginPage loginPage;       
        MainPage mainPage;
        //DataBaseHelpers dataBaseHelpers;
        #endregion

        
        public void RealizarLoginComSucesso()
        {
            loginPage = new LoginPage();           
            mainPage = new MainPage();

            #region Parameters
            string usuario = "anderson.silva@base2.com.br";
            string senha = "Andin@25";
            #endregion

            loginPage.ClicarEmProsseguir();
            loginPage.PreencherUsuario(usuario);
            loginPage.PreencherSenha(senha);
            loginPage.ClicarEmLogin(); 




            //Assert.AreEqual(usuario, mainPage.RetornaUsernameDasInformacoesDeLogin());
        }

    }
}
