using DesafioBase2.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBase2.Pages
{
    public class LoginPage : PageBase
    {
        #region Mapping

        By prosseguirButton = By.CssSelector("a[class='cc-btn cc-dismiss']");
        By usernameField = By.Id("login");
        By passwordField = By.Id("password");
        By loginButton = By.CssSelector("button[class='btn btn-crowdtest btn-block']");
        By mensagemErroTextArea = By.XPath("/html/body/div[2]/font"); //exemplo de mapping incorreto
        #endregion

        #region Actions
        public void PreencherUsuario(string usuario)
        {
            SendKeys(usernameField, usuario);
        }

        public void PreencherSenha(string senha)
        {
            SendKeys(passwordField, senha);
        }

        public void ClicarEmLogin()
        {
            Click(loginButton);
        }

        public void ClicarEmProsseguir()
        {
            Click(prosseguirButton);
        }

        public string RetornaMensagemDeErro()
        {
            return GetText(mensagemErroTextArea);
        }
        #endregion
    }
}
