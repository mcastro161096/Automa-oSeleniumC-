using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace PrimeiroTesteAutomatizado.Atividade1
{
    [TestClass]
    public class TestCheckbox
    {
        [TestMethod]
        public void ValidarCheckbox1()
        {


            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/checkboxes");

            IWebElement query = driver.FindElement(By.CssSelector("form>input:nth-child(1)"));

            query.Click();


            


            Thread.Sleep(2000);


            driver.Close();
            driver.Quit();
            driver = null;
        }
    }
}
