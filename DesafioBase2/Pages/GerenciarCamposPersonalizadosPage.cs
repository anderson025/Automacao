using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Bases;
using OpenQA.Selenium;

namespace DesafioBase2.Pages
{
    public class GerenciarCamposPersonalizadosPage : PageBase
    {
        #region Mapping
        By clicarGerenciarProjetos = By.CssSelector("ul li i[class = 'menu-icon fa fa-gears']");
        By clicarGerenciarCampos = By.XPath("//a[text()='Gerenciar Campos Personalizados']");
        By nomeCampo = By.Name("name");
        By btnNovoCampo = By.CssSelector("input[class='btn btn-primary btn-sm btn-white btn-round']");
        By btnApagarCampo = By.CssSelector("input[class='btn btn-primary btn-sm btn-white btn-round']");
        By btnAtualizarCampo = By.CssSelector("input[class='btn btn-primary btn-white btn-round']");
        By selecionarRegistroGrid = By.XPath("//a[text()='Teste123']");
        By btnConfirmaApagaCampo = By.CssSelector("input[value='Apagar Campo']");
        By nomePadrao = By.Name("default_value");
        By requeridoAtualizacao = By.XPath("//label//input[@name='require_update']/following-sibling::span");

        //validações
        By textoNomePernalizado = By.XPath("//tbody//tr[last()]//a");
        By textoAtualizado = By.XPath("//a[text()='Teste12345']");

        #endregion

        #region Actions

        public void ClicarEmGerenciarProjetos()
        {
            Click(clicarGerenciarProjetos);
        }

        public void ClicarEmGerenciarCamposPersonalizados()
        {
            Click(clicarGerenciarCampos);
        }
        public void PreencherNomeCampo(string nome)
        {
            SendKeys(nomeCampo, nome);
        }

        public void ClicarEmNovoCampo()
        {
            Click(btnNovoCampo);
        }

        public void ClicarEmApagarCampo()
        {
            Click(btnApagarCampo);
        }

        public void ClicarEmAtualizarCampo()
        {
            Click(btnAtualizarCampo);
        }

        public void LimparCampos()
        {
            Clear(nomeCampo);
        }

        public void ClicarEmNovoCampoGrid()
        {
            Click(selecionarRegistroGrid);
        }
        public void ClicarEmConfirmaApagaCampo()
        {
            Click(btnConfirmaApagaCampo);
        }

        public void PreencherNomePadrao(string padrao)
        {
            SendKeys(nomePadrao, padrao);
        }

        public void ClicarEmRequerAtualizacao()
        {
            Click(requeridoAtualizacao);
        }

        public string RetornaCampoPersonalizado()
        {
            string texto = GetText(textoNomePernalizado);
            return texto;
        }

        public string RetornaCampoPersonalizadoAtualizado()
        {
            string texto = GetText(textoAtualizado);
            return texto;
        }

        public bool RetornaCampoExiste()
        {
            bool texto = ReturnIfElementExist(selecionarRegistroGrid);
            return texto;
        }

        #endregion
    }
}
