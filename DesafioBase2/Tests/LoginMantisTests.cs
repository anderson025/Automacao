using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBase2.Bases;
using NUnit.Framework;
using DesafioBase2.Pages;
using System.IO;
using OfficeOpenXml;
using OpenQA.Selenium.Remote;
using DesafioBase2.Helpers;
using DesafioBase2.Flows;



namespace DesafioBase2.Tests
{
    [TestFixture]
    class LoginMantisTests : TestBase
    {
        #region Pages and Flows Objects
        //LoginMantisPage loginMantisPage;
        LoginFlows loginFlows;        
        string usuario1 = "";
        string senha1 = "administrator";
        LoginMantisPage page;
        PageBase pageBase;
        #endregion

        [Test]
        public void RealizarLoginComBD()
        {
            List<string> lista = DataBaseHelpers.RetornaDadosUsuario();
                      
            usuario1 = lista[0].ToString();
            //senha1 = lista[1].ToString();     

            loginFlows = new LoginFlows();
            pageBase = new PageBase();
            page = new LoginMantisPage();

            #region Actions

            loginFlows.EfetuarLogin(usuario1, senha1);

            #endregion

            #region validations           

            string titulo = pageBase.GetTitle();
            string nomeUsuario = page.BuscarNomeUsuario();

            Assert.AreEqual(nomeUsuario, usuario1);
            Assert.AreEqual(titulo, "Minha Visão - MantisBT");

            #endregion
        }

        [Test, TestCaseSource("ReadExcel")]
        public void RealizarLoginComDatadriven(string usuario, string senha)
        {           
          
            loginFlows = new LoginFlows();
            pageBase = new PageBase();
            page = new LoginMantisPage();

            #region Actions

            loginFlows.EfetuarLogin(usuario, senha);

            #endregion

            #region validations
            
            string titulo = pageBase.GetTitle();
            string nomeUsuario = page.BuscarNomeUsuario();

            Assert.AreEqual(nomeUsuario, usuario1);
            Assert.AreEqual(titulo, "Minha Visão - MantisBT");

            #endregion

        }

        private static IEnumerable<object[]> ReadExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage arquivo = new ExcelPackage(new FileInfo(@"C:\Users\Anderson da Silva\source\repos\DesafioBase2\DesafioBase2\Dados1.xlsx")))
            {
                ExcelWorksheet ws = arquivo.Workbook.Worksheets["Dados1"];
                int rowCount = ws.Dimension.End.Row;

                for (int i = 1; i <= rowCount; i++)
                {
                    yield return new object[]
                    {
                        ws.Cells[i,1].Value?.ToString().Trim(),
                        ws.Cells[i,2].Value?.ToString().Trim()
                    };
                }
            }

        }
    }
}
