using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace PrimeiroTesteAutomatizado.Atividade1
{
    [TestFixture]
    public class TestVerificaValorEx1Todos : BaseTest
    {
        [Test]
        public void TestMethod1()
        {
            AbreUrl("http://the-internet.herokuapp.com/tables");
            IList<IWebElement> table1Todos = driver.FindElements(By.CssSelector("#table1>tbody>tr"));
            IList<string> valoresEncontrados = new List<string>();
            IList<string> valoresEsperados = new List<string>()
            {
            "Smith John jsmith@gmail.com $50.00 http://www.jsmith.com edit delete",
            "Bach Frank fbach@yahoo.com $51.00 http://www.frank.com edit delete",
            "Doe Jason jdoe@hotmail.com $100.00 http://www.jdoe.com edit delete",
            "Conway Tim tconway@earthlink.net $50.00 http://www.timconway.com edit delete"
            };
            foreach (IWebElement elemento in table1Todos)
            {
                valoresEncontrados.Add(elemento.Text);
            }
            Assert.AreEqual(valoresEsperados, valoresEncontrados);


        }


    }
}

