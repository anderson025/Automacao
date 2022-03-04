using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Bases;


namespace DesafioBase2.Pages
{
    public class LoginMantisPage : PageBase   
    {

        #region Mapping     
        By usernameField = By.Name("username");
        By passwordField = By.Name("password");
        By loginButton = By.CssSelector("input[type='submit']");
        By nomeUsuario = By.CssSelector("span[class='user-info']");
        //By mensagemErroTextArea = By.XPath("/html/body/div[2]/font"); //exemplo de mapping incorreto
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

        public void ClicarEmEntrar()
        {
            Click(loginButton);
        }

        //public string RetornaMensagemDeErro()
        //{
        //    return GetText(mensagemErroTextArea);
        //}
        #endregion

        #region Using JS

        public void PreencherUsuarioJS(string usuario)
        {
            SendKeysJavaScript(usernameField, usuario);
        }

        public void PreencherSenhaJS(string senha)
        {
            SendKeysJavaScript(passwordField, senha);
        }

        public void ClicarEmEntrarJS()
        {
            ClickJavaScript(loginButton);
        }

        public string BuscarNomeUsuario()
        {
            string usuario = GetText(nomeUsuario);

            return usuario;
        }

        #endregion
    }
}
