using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PrimeiroTesteAutomatizado.Atividade1
{
    [TestClass]
    public class TestCheckBox2
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/checkboxes");

            IWebElement query = driver.FindElement(By.CssSelector("form>input:nth-child(3)"));

            query.Click();





            Thread.Sleep(2000);


            driver.Close();
            driver.Quit();
            driver = null;
        }
    }
}
