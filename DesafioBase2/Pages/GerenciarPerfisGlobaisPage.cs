using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Bases;
using OpenQA.Selenium;

namespace DesafioBase2.Pages
{
    
    public class GerenciarPerfisGlobaisPage: PageBase
    {
        #region Mapping
        By clicarGerenciarProjetos = By.CssSelector("ul li i[class = 'menu-icon fa fa-gears']");
        By clicarGerenciarPerfisGlobais = By.XPath("//a[text()='Gerenciar Perfís Globais']");
        By plataforma = By.Name("platform");
        By sistemaOperacional = By.Name("os");
        By versaoSistema = By.Name("os_build");
        //By versaoEditar = By.Name("os_build");
        By descricaoAdicional = By.Name("description");
        By btnAdicionarPerfil = By.CssSelector("input[value='Adicionar Perfil']");
        By btnEditar = By.XPath("//tr//td/label[1]//input[@value='edit']/following-sibling::span");
        By btnDeletar = By.XPath("//tr//td/label[1]//input[@value='delete']/following-sibling::span");
        //By comboSelecionarPerfil = By.XPath("//option[text()='Teste Windows Windows 10']");
        By comboSelecionarPerfil = By.XPath("//option[last()]");
        By btnEnviar = By.CssSelector("input[value='Enviar']");
        By btnAtualizarPerfil = By.CssSelector("input[value='Atualizar Perfil']");

        //validações
        By textoPerfil = By.XPath("//option[text()='Teste Windows Windows 10']");
        #endregion

        #region Actions

        public void ClicarEmGerenciarProjetos()
        {
            Click(clicarGerenciarProjetos);
        }
        public void ClicarEmMenuGerenciarPerfisGlobais()
        {
            Click(clicarGerenciarPerfisGlobais);
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

        public void PreencherDescricaoAdicional(string descricao)
        {
            SendKeys(descricaoAdicional,descricao);
        }

        public void ClicarEmAdicionarPerfil()
        {
            Click(btnAdicionarPerfil);
        }

        public void LimparCampos()
        {
            Clear(plataforma);
            Clear(sistemaOperacional);
            Clear(versaoSistema);
            Clear(descricaoAdicional);
        }

        public void ClicarEmEditar()
        {
            Click(btnEditar);
        }

      
        public void ClicarEmDeletar()
        {
            Click(btnDeletar);
        }

        public void ClicarEmSelecionarCombo()
        {
            Click(comboSelecionarPerfil);
        }

        public void ClicarEmEnviar()
        {
            Click(btnEnviar);
        }

        public void ClicarEmAtualizarPerfil()
        {
            Click(btnAtualizarPerfil);
        }

        //public void PreencherVersaoEditar(string editarVersao)
        //{
        //    SendKeys(versaoEditar, editarVersao);
        //}

        public string RetornaPerfilGlobal()
        {
            string texto = GetText(textoPerfil);
            return texto;
        }

        public string RetornaPerfilGlobalAtualizado()
        {
            string texto = GetText(comboSelecionarPerfil);
            return texto;
        }

        public bool RetornaPerfilExcluido()
        {
            bool texto = ReturnIfElementExist(comboSelecionarPerfil);
            return texto;
        }
        #endregion
    }
}
