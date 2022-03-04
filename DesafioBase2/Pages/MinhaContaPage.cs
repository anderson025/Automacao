using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Bases;
using OpenQA.Selenium;

namespace DesafioBase2.Pages
{
    public class MinhaContaPage : PageBase
    {
        #region Mapping
        //Acessar Minha conta
        By menuUsuario = By.LinkText("administrator");
        By minhaConta = By.LinkText("Minha Conta");

        //Validações
        By textoAlterarConta = By.XPath("//h4[@class='widget-title lighter']");
        By textoRSS = By.CssSelector("body > div[class='header'] > span");
        By textoLogin = By.XPath("//h4[@class='header lighter bigger']");
        By textoErroCriarToken = By.XPath("//div/div/p[text()='APPLICATION ERROR #3000']");
        By textoCriarToken = By.XPath("//h2[text()='Token que deve ser usado ao acessar API.']");
        By textoNomeReal = By.XPath("//ul[@class='breadcrumb']/li/a");
        By textoPerfilAdicionado = By.XPath("//tr//td//select[@class='input-sm']//option[last()]");
        

        //RSS
        By rss = By.LinkText("RSS");

        //Sair
        By sairDoSistema = By.LinkText("Sair");

        //Alterar Conta
        By nomeReal = By.Name("realname");
        By atualizarUsuario = By.CssSelector("input[value='Atualizar Usuário']");

        //Preferencias
        By preferencias = By.LinkText("Preferências");
        By menuPreferencia = By.LinkText("Preferências");
        By checkEnviarEmailStatus = By.XPath("//input[@name='email_on_status']/following-sibling::span");
        By checkEnviarEmailPrioridade = By.XPath("//input[@name='email_on_priority']/following-sibling::span");
        By btnAtualizarPreferencias = By.CssSelector("input[value='Atualizar Preferências']"); 
        By btnRedefinirPreferencias = By.CssSelector("input[value='Redefinir Preferências']");

        //Adicionar Perfil

        By menuPerfis = By.LinkText("Perfís");
        By plataforma = By.Id("platform");
        By sistemaOperacional = By.Id("os");
        By versaoSistema = By.Id("os-version");
        By descricao = By.Id("description");
        By btnAdicionarPerfil = By.CssSelector("input[value='Adicionar Perfil']");

        //Criar Token
        By menuToken = By.LinkText("Tokens API");
        By nomeToken = By.Id("token_name");
        By btnCriarToken = By.CssSelector("input[value='Criar Token API']");



        #endregion

        #region Actions

        public void ClicarEmMenuUsuario()
        {
            Click(menuUsuario);
        }

        public void ClicarEmMinhaConta()
        {
            Click(minhaConta);
        }

        public void ClicarEmRSS()
        {
            Click(rss);
        }

        public void ClicarEmSair()
        {
            Click(sairDoSistema);
        }

        public void PreencherNomeReal(string real)
        {
            SendKeys(nomeReal, real);
        }

        public void ClicarEmAtualizarUsuario()
        {
            Click(atualizarUsuario);
        }

        public void LimparCampos()
        {
            Clear(nomeReal);
        }

        public void ClicarNoMenuPreferencias()
        {
            Click(menuPreferencia);
        }

        public void ClicarEmEnviarEmailStatus()
        {
            Click(checkEnviarEmailStatus);
        }

        public void ClicarEmEnviarEmailPrioridade()
        {
            Click(checkEnviarEmailPrioridade);
        }

        public void ClicarEmMenuPreferencias()
        {
            Click(preferencias);
        }

        public void ClicarEmAtualizarPreferencias()
        {
            Click(btnAtualizarPreferencias);
        }

        public void ClicarEmRedefinirPreferencias()
        {
            Click(btnRedefinirPreferencias);
        }

        public void ClicarEmMenuPerfis()
        {
            Click(menuPerfis);
        }
        public void PreencherPlataforma(string nomePlataforma)
        {
            SendKeys(plataforma, nomePlataforma);
        }

        public void PreencherSistemaOperacional(string so)
        {
            SendKeys(sistemaOperacional, so);
        }

        public void PreencherVersaoSistema(string versao)
        {
            SendKeys(versaoSistema, versao);
        }

        public void PreencherDescricao(string campoDescricao)
        {
            SendKeys(descricao, campoDescricao);
        }

        public void ClicarEmAdicionarPerfil()
        {
            Click(btnAdicionarPerfil);
        }

        public void ClicarEmMenuToken()
        {
            Click(menuToken);
        }

        public void PreencherNomeToken(string token)
        {
            SendKeys(nomeToken, token);
        }

        public void ClicarEmCriarToken()
        {
            Click(btnCriarToken);
        }

        public string RetornaTexto()
        {
            string texto = GetText(textoAlterarConta);
            return texto;
        }

        public string RetornaTextoRSS()
        {
            string texto = GetText(textoRSS);
            return texto;
        }

        public string RetornaTextoLogin()
        {
            string texto = GetText(textoLogin);
            return texto;
        }

        public string RetornaTextoErroCriarToken()
        {
            string texto = GetText(textoErroCriarToken);
            return texto;
        }

        public string RetornaTextoCriarToken()
        {
            string texto = GetText(textoCriarToken);
            return texto;
        }

        public bool RetornaEmailStatus()
        {
            bool selecionado = ReturnIfElementIsSelected(checkEnviarEmailStatus);
            return selecionado;
        }

        public bool RetornaEmailPrioridade()
        {
            bool selecionado = ReturnIfElementIsSelected(checkEnviarEmailPrioridade);
            return selecionado;
        }

        public string RetornaNomeVerdadeiro()
        {
            string texto = GetText(textoNomeReal);
            return texto;
        }

        public string RetornaPerfilAdicionado()
        {
            string texto = GetText(textoPerfilAdicionado);
            return texto;
        }
        

        #endregion
    }
}
