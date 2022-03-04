using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Bases;
using OpenQA.Selenium;

namespace DesafioBase2.Pages
{
    public class CriarTarefaPage : PageBase
    {
        By menuCriarTarefa = By.XPath("//span[text()=' Criar Tarefa ']");
        By categoria = By.XPath("//option[text()='[Todos os Projetos] General']");
        By frequencia = By.XPath("//option[text()='sempre']");
        By gravidade = By.XPath("//option[text()='pequeno']");
        By prioridade = By.XPath("//option[text()='normal']");
        By atribuir = By.XPath("//option[text()='administrator']");
        By resumo = By.Id("summary");
        By descricao = By.Id("description");
        By passosReproduzir = By.Id("steps_to_reproduce");
        By informacoesAdicionais = By.Id("additional_info");
        By btnCriarNovaTarefa = By.CssSelector("input[value='Criar Nova Tarefa']");

        //validações

        By textoDescricao = By.XPath("//tr//td[@class='bug-description']");

        
        public void ClicarEmMenuCriarTarefa()
        {
            Click(menuCriarTarefa);
        }

        public void ClicarEmCategoria()
        {
            Click(categoria);
        }

        public void ClicarEmFrequencia()
        {
            Click(frequencia);
        }

        public void ClicarEmGravidade()
        {
            Click(gravidade);
        }

        public void ClicarEmPrioridade()
        {
            Click(prioridade);
        }

        public void ClicarEmAtribuir()
        {
            Click(atribuir);
        }

        public void PreencherResumo(string campoResumo)
        {
            SendKeys(resumo, campoResumo);
        }

        public void PreencherDescricao(string campoDescricao)
        {
            SendKeys(descricao, campoDescricao);
        }

        public void PreencherPassosReproduzir(string campoPassos)
        {
            SendKeys(passosReproduzir, campoPassos);
        }

        public void PreencherInformacacoesAdicionais(string campoInfo)
        {
            SendKeys(informacoesAdicionais, campoInfo);
        }

        public void ClicarEmCriarNovaTarefa()
        {
            Click(btnCriarNovaTarefa);
        }

        public string RetornaDescricao()
        {
            string texto = GetText(textoDescricao);
            return texto;
        }


    }
}
