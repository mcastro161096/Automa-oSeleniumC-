using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace PrimeiroTesteAutomatizado.Atividade1
{
    [TestClass]
    public class TestInputs
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/inputs");

            IWebElement query = driver.FindElement(By.CssSelector("input[type]"));

            query.SendKeys("1");


            var result = query;
            var expected = "";

           
            Assert.AreEqual(expected, result.Text);
            Thread.Sleep(2000);


            driver.Close();
            driver.Quit();
            driver = null;

        }
    }
}
