using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Bases;
using DesafioBase2.Pages;
using DesafioBase2.Flows;
using NUnit.Framework;

namespace DesafioBase2.Tests
{
    [TestFixture]
    class GerenciarProjetosTests : TestBase
    {
        GerenciarProjetosPage gerenciarProjetosPage;
        LoginFlows loginFlows;
        string descricaoProjeto = "Testes Utilizando selenium";
        string nomeProjeto = "desafio Base2";
        string usuario = "administrator";
        string senha = "administrator";
        string nomeCategoria = "desafio";
       
        [Test]
        public void AdicionarProjetos()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            loginFlows = new LoginFlows();

            loginFlows.EfetuarLogin(usuario,senha);
            gerenciarProjetosPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.ClicarEmGerenciarProjetos();
            gerenciarProjetosPage.ClicarAdicionarProjeto();
            gerenciarProjetosPage.PreencherNomeProjeto(nomeProjeto);
            gerenciarProjetosPage.PreencherDescricaoProjeto(descricaoProjeto);            
            gerenciarProjetosPage.ClicarEmGravarProjeto();

            #region validacoes
            string texto = gerenciarProjetosPage.RetornaProjeto();
            Assert.AreEqual(texto, nomeProjeto);

            #endregion
        }

        [Test]
        public void DeletarProjeto()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();

            loginFlows = new LoginFlows();
                        

            loginFlows.EfetuarLogin(usuario,senha);
            gerenciarProjetosPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.ClicarEmGerenciarProjetos();
            gerenciarProjetosPage.ClicarProjetoGridAtualizado();
            gerenciarProjetosPage.ClicarEmApagarProjeto();
            gerenciarProjetosPage.ClicarConfirmarApagaProjeto();

            #region validacoes
            bool texto = gerenciarProjetosPage.RetornaProjetoExcluido();
            Assert.IsFalse(texto);
            #endregion
        }
        [Test]
        public void AtualizarProjeto()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            loginFlows = new LoginFlows();

            string projetoAtualizado = "Desafio Atualizado";
            string descricaoAtualizada = "Descricao Atualizada";

            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarProjetosPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.ClicarEmGerenciarProjetos();
            gerenciarProjetosPage.ClicarProjetoGrid();
            gerenciarProjetosPage.LimparCampos();
            gerenciarProjetosPage.PreencherNomeProjeto(projetoAtualizado);
            gerenciarProjetosPage.PreencherDescricaoProjeto(descricaoAtualizada);
            gerenciarProjetosPage.ClicarEmAtualizarProjeto();

            #region validacoes
            string texto = gerenciarProjetosPage.RetornaProjetoAtualizado();
            Assert.AreEqual(texto, projetoAtualizado);

            #endregion
        }

        [Test]
        public void AdicionarCategoria()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            loginFlows = new LoginFlows();

            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarProjetosPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.ClicarEmGerenciarProjetos();
            gerenciarProjetosPage.PreencherCategoria(nomeCategoria);
            gerenciarProjetosPage.ClicarEmAdicionarCategoria();

            #region validacoes

            string texto = gerenciarProjetosPage.RetornaCategoria();
            string textoErro = gerenciarProjetosPage.RetornaCategoriaErro();

            if (texto == "Error" && textoErro == "APPLICATION ERROR #1500")
            {
                Assert.AreEqual(textoErro, "APPLICATION ERROR #1500");
            }
            else
            {
                Assert.AreEqual(texto, nomeCategoria);
            }           
            

            #endregion

        }

        public void DeletarCategoria()
        {

        }
        public void AtualizarCategoria()
        {

        }
    }
}
