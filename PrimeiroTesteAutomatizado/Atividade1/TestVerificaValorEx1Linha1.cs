using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace PrimeiroTesteAutomatizado.Atividade1
{
    [TestFixture]
    public class TestVerificaValorEx1Linha1 : BaseTest
    {
        [Test]
        public void TestMethod1()
        {
            //AbreUrl("http://the-internet.herokuapp.com/tables");
            //IWebElement ultimoNome = driver.FindElement(By.CssSelector("#table1>tbody>tr:nth-child(1)>td:nth-child(1)"));
            //IWebElement primeiroNome = driver.FindElement(By.CssSelector("#table1>tbody>tr:nth-child(1)>td:nth-child(2)"));
            //IWebElement email = driver.FindElement(By.CssSelector("#table1>tbody>tr:nth-child(1)>td:nth-child(3)"));
            //IWebElement vencimento = driver.FindElement(By.CssSelector("#table1>tbody>tr:nth-child(1)>td:nth-child(4)"));
            //IWebElement webSite = driver.FindElement(By.CssSelector("#table1>tbody>tr:nth-child(1)>td:nth-child(5)"));
            //IWebElement acaoEditar = driver.FindElement(By.CssSelector("#table1>tbody>tr:nth-child(1)>td:nth-child(6)>a[href='#edit']"));
            //IWebElement acaoDeletar = driver.FindElement(By.CssSelector("#table1>tbody>tr:nth-child(1)>td:nth-child(6)>a[href='#delete']"));
            //Assert.AreEqual("Smith", ultimoNome.Text);
            //Assert.AreEqual("John", primeiroNome.Text);
            //Assert.AreEqual("jsmith@gmail.com", email.Text);
            //Assert.AreEqual("$50.00", vencimento.Text);
            //Assert.AreEqual("http://www.jsmith.com", webSite.Text);
            //Assert.AreEqual("edit", acaoEditar.Text);
            //Assert.AreEqual("delete", acaoDeletar.Text);
            AbreUrl("http://the-internet.herokuapp.com/tables");
            IList<IWebElement> table1 = driver.FindElements(By.CssSelector("#table1>tbody>tr:nth-child(1)>td"));
            IList<string> valoresEncontrados = new List<string>();
            IList<string> valoresEsperados = new List<string>()
            {
                "Smith", "John", "jsmith@gmail.com", "$50.00", "http://www.jsmith.com","edit delete",
            };
            foreach (IWebElement elemento in table1)
            {
                valoresEncontrados.Add(elemento.Text);
            }
            Assert.AreEqual(valoresEsperados, valoresEncontrados);

        }
    }
}
