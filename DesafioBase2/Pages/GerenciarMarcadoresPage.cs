using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Bases;
using OpenQA.Selenium;

namespace DesafioBase2.Pages
{
    public class GerenciarMarcadoresPage : PageBase
    {
        #region Mapping

        By clicarGerenciarProjetos = By.CssSelector("ul li i[class = 'menu-icon fa fa-gears']");
        By clicarGerenciarMarcadores = By.XPath("//a[text()='Gerenciar Marcadores']");
        By btnCriarMarcador = By.XPath("//a[text()='Criar Marcador']");
        By nomeMarcador = By.Id("tag-name");
        By descricaoMarcador = By.Id("tag-description");
        By btnGravarMarcador = By.CssSelector("input[value='Criar Marcador']");
        //By selecionarRegistroGrid = By.XPath("//a[text()='Desafio']");
        By selecionarRegistroGrid = By.XPath("//tbody//tr[last()]//td/a");
        By btnApagarMarcador = By.CssSelector("input[value = 'Apagar Marcador']");
        By btnConfirmarApagarMarcador = By.CssSelector("input[value='Apagar Marcador']");
        By btnAtualizarMarcador = By.CssSelector("input[value='Atualizar Marcador']");

        By textoMarcador = By.XPath("//tr[2]//td[2]");

        #endregion

        #region Actions

        public void ClicarEmGerenciarProjetos()
        {
            Click(clicarGerenciarProjetos);
        }

        public void ClicarEmGerenciarMarcadores()
        {
            Click(clicarGerenciarMarcadores);
        }

        public void ClicarEmCriarMarcadores()
        {
            Click(btnCriarMarcador);
        }

        public void PreencherNomeMarcador(string marcador)
        {
            SendKeys(nomeMarcador, marcador);
        }

        public void PreencherDescricaoMarcador(string descricao)
        {
            SendKeys(descricaoMarcador, descricao);
        }

        public void ClicarEmGravarMarcador()
        {
            Click(btnGravarMarcador);
        }

        public void ClicarNoRegistroNoGrid()
        {
            Click(selecionarRegistroGrid);
        }

        public void ClicarEmApagarMarcador()
        {
            Click(btnApagarMarcador);
        }

        public void ClicarEmConfirmarApagarMarcador()
        {
            Click(btnConfirmarApagarMarcador);
        }
        public void LimparCampos()
        {
            Clear(nomeMarcador);
            Clear(descricaoMarcador);
        }

        public void ClicarEmAtualizarMarcador()
        {
            Click(btnAtualizarMarcador);
        }

        public string RetornaMarcadorAdicionado()
        {
            string texto = GetText(selecionarRegistroGrid);
            return texto;
        }

        public string RetornaMarcadorAtualizado()
        {
            string texto = GetText(textoMarcador);
            return texto;
        }

        public bool RetornaMarcadorExcluido()
        {
            bool texto = ReturnIfElementExist(selecionarRegistroGrid);
            return texto;
        }

        #endregion
    }
}
