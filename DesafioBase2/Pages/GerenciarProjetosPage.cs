using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Bases;
using OpenQA.Selenium;

namespace DesafioBase2.Pages
{
    public class GerenciarProjetosPage: PageBase
    {
        #region Mapping
        By clicarGerenciarProjetos = By.XPath("//a[text()='Gerenciar Projetos']");
        By nomeProjeto = By.CssSelector("input[id='project-name']");
        By descricaoProjeto = By.CssSelector("textarea[id='project-description']");
        By btnAdicionarProjeto = By.XPath("//button[@class='btn btn-primary btn-white btn-round']");
        By btnGravarProjeto = By.CssSelector("input[value='Adicionar projeto']");
        By btnAtualizarProjeto = By.CssSelector("input[value='Atualizar Projeto']");
        By btnApagarProjeto = By.CssSelector("input[value='Apagar Projeto']");
        By confirmaApagarProjeto = By.CssSelector("input[value = 'Apagar Projeto']");

        By categoria = By.CssSelector("input[name='name']");
        By btnAdicionarCategoria = By.CssSelector("input[value='Adicionar Categoria']");
        
        
        By selecionarProjetoGrid = By.XPath("//a[text()='desafio Base2']");        
        By menuGerenciar = By.CssSelector("ul li i[class = 'menu-icon fa fa-gears']");


        //validações

        By textoAtualizado = By.XPath("//a[text()='Desafio Atualizado']");
        By textoCategoria = By.XPath("//td[text()='desafio']");
        By textoCategoriaErro = By.XPath("//div/p[text()='APPLICATION ERROR #1500']");

        #endregion

        #region Actions
        public void PreencherNomeProjeto(string nomeDoProjeto)
        {
            SendKeys(nomeProjeto, nomeDoProjeto);
        }

        public void PreencherDescricaoProjeto(string descricao)
        {
            SendKeys(descricaoProjeto, descricao);
        }

        public void PreencherCategoria(string nomeCategoria)
        {
            SendKeys(categoria, nomeCategoria);
        }

        public void ClicarConfirmarApagaProjeto()
        {
            Click(confirmaApagarProjeto);

        }


        public void ClicarMenuGerenciar()
        {
            Click(menuGerenciar);
        }

        public void ClicarEmApagarProjeto()
        {
            Click(btnApagarProjeto);
        }

        public void ClicarProjetoGrid()
        {
            Click(selecionarProjetoGrid);
        }

        public void ClicarProjetoGridAtualizado()
        {
            Click(textoAtualizado);
        }

        public void ClicarEmGerenciarProjetos()
        {
            Click(clicarGerenciarProjetos);
        }
        public void ClicarAdicionarProjeto()
        {
            Click(btnAdicionarProjeto);
        }

        public void ClicarEmGravarProjeto()
        {
            Click(btnGravarProjeto);
        }

        public void ClicarEmAtualizarProjeto()
        {
            Click(btnAtualizarProjeto);
        }

        public void ClicarEmAdicionarCategoria()
        {
            Click(btnAdicionarCategoria);
        }

        public void LimparCampos()
        {
            Clear(nomeProjeto);
            Clear(descricaoProjeto);            
        }

        public string RetornaProjeto()
        {
            string texto = GetText(selecionarProjetoGrid);
            return texto;
        }

        public string RetornaProjetoAtualizado()
        {
            string texto = GetText(textoAtualizado);
            return texto;
        }

        public bool RetornaProjetoExcluido()
        {
            bool texto = ReturnIfElementExist(textoAtualizado);
            return texto;
        }

        public string RetornaCategoria()
        {
            string texto = GetTextError(textoCategoria);
            return texto;
        }

        public string RetornaCategoriaErro()
        {
            string texto = GetTextError(textoCategoriaErro);
            return texto;
        }

        #endregion
    }
}
