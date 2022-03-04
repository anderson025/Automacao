using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Bases;
using DesafioBase2.Pages;
using NUnit.Framework;
using DesafioBase2.Flows;
namespace DesafioBase2.Tests
{
    [TestFixture]
    public class CriarTarefaTests : TestBase
    {
        CriarTarefaPage criarTarefaPage;
        LoginFlows loginFlows;
        string usuario = "administrator";
        string senha = "administrator";
        string resumo = "Desafio Base2";
        string descricao = "Iniciando desafio base2";
        string passos = "1 - implementar os 50 scripts";
        string inforAdicionais = "Informacoes adicionais";

        [Test]
        public void CadastrarNovaTarefa()
        {
            criarTarefaPage = new CriarTarefaPage();
            loginFlows = new LoginFlows();

            loginFlows.EfetuarLogin(usuario, senha);
            criarTarefaPage.ClicarEmMenuCriarTarefa();
            criarTarefaPage.ClicarEmCategoria();
            criarTarefaPage.ClicarEmFrequencia();
            criarTarefaPage.ClicarEmGravidade();
            criarTarefaPage.ClicarEmPrioridade();
            criarTarefaPage.ClicarEmAtribuir();            
            criarTarefaPage.PreencherResumo(resumo);
            criarTarefaPage.PreencherDescricao(descricao);
            criarTarefaPage.PreencherPassosReproduzir(passos);
            criarTarefaPage.PreencherInformacacoesAdicionais(inforAdicionais);
            criarTarefaPage.ClicarEmCriarNovaTarefa();

            string texto = criarTarefaPage.RetornaDescricao();
            Assert.AreEqual(texto, descricao);
        }

        
    }
}
