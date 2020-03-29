using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PrimeiroTesteAutomatizado.Atividade1
{
    [TestClass]
    public class TestExemploSlides
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://www.google.com/");

            IWebElement query = driver.FindElement(By.Name("q"));

            query.SendKeys("GVDASA");
            Thread.Sleep(2000);

            query.Submit();

            


            var wait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.StartsWith("GVDASA", StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual("GVDASA - Pesquisa Google", driver.Title);

            IWebElement name = driver.FindElement(By.LinkText("A GVDASA – GVdasa"));
            name.Click();
            Assert.AreEqual("A GVDASA – GVdasa", driver.Title);
            driver.Close();
            driver.Quit();
            driver = null;

        }
    }
}
