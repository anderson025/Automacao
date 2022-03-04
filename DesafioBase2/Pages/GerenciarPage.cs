using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using DesafioBase2.Bases;

namespace DesafioBase2.Pages
{
    public class GerenciarPage : PageBase
    {
        #region Mapping
        By menuGerenciar = By.CssSelector("ul li i[class = 'menu-icon fa fa-gears']");
        By gerenciarUsuarios = By.XPath("//a[text()='Gerenciar Usuários']");
        By btnCriarNovaConta = By.XPath(" //a[text()='Criar nova conta']");

        By nomeUsuario = By.CssSelector("input[name ='username']");
        By nomeVerdadeiro = By.CssSelector("input[name ='realname']"); 
        By inputEmail = By.CssSelector("input[name ='email']"); 
        By btnCriarUsuario = By.CssSelector("input[type = 'submit']");

        By clicarUsuarioGrid = By.XPath("//a[text()='teste']");
        By clicarUsuarioGridAtualizado = By.XPath("//a[text()='Teste2']");
        By apagarUsuario = By.CssSelector("input[value='Apagar Usuário']");
        By apagarConta = By.CssSelector("input[value='Apagar Conta']");
        By atualizarUsuario = By.CssSelector("input[value='Atualizar Usuário']");

        //validações

        By textoInclusao = By.XPath("//a[text()='teste']");
        By textoInclusaoAtualizado = By.XPath("//a[text()='Teste2']");

        #endregion

        #region Actions
        public void ClicarMenuGerenciar()
        {
            Click(menuGerenciar);
        }
        public void ClicarEmGerenciarUsuarios()
        {
            Click(gerenciarUsuarios);
        }

        public void ClicarEmCriarNovaConta()
        {
            Click(btnCriarNovaConta);
        }

        public void PreencherUsuario(string usuario)
        {
            SendKeys(nomeUsuario, usuario);
        }

        public void PreencherNomeVerdadeiro(string nomeCompleto)
        {
            SendKeys(nomeVerdadeiro, nomeCompleto);
        }

        public void PreencherEmail(string email)
        {
            SendKeys(inputEmail, email);
        }

        public void ClicarEmCriarUsuario()
        {
            Click(btnCriarUsuario);
        }

        public void ClicarUsuarioGrid()
        {
            Click(clicarUsuarioGrid);
        }

        public void ClicarUsuarioGridAtualizado()
        {
            Click(clicarUsuarioGridAtualizado);
        }

        public void ClicarApagarUsuario()
        {
            Click(apagarUsuario);
        }

        public void ClicarApagarConta()
        {
            Click(apagarConta);
        }
        public void ClicarAtualizarUsuario()
        {
            Click(atualizarUsuario);
        }

        public void LimparCampos()
        {
            Clear(nomeUsuario);
            Clear(nomeVerdadeiro);
            Clear(inputEmail);
        }

        public string RetornaContaIncluida()
        {
            string texto = GetText(textoInclusao);
            return texto;
        }

        public string RetornaContaAtualizada()
        {
            string texto = GetText(textoInclusaoAtualizado);
            return texto;
        }

        public bool RetornaContaExcluida()
        {
            bool texto = ReturnIfElementExist(textoInclusaoAtualizado);
            return texto;
        }

        #endregion
    }


}


