using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace PrimeiroTesteAutomatizado.Atividade1
{
    [TestFixture]
    public class TestValidaHelloWord1 : BaseTest
    {
        [Test]
        public void TestMethod1()
        {
            AbreUrl("http://the-internet.herokuapp.com/dynamic_loading");
            IWebElement exemplo1 = driver.FindElement(By.CssSelector("a[href^='/dynamic_loading/1']"));
                exemplo1.Click();
            IWebElement start = driver.FindElement(By.CssSelector("div>button"));
                start.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("div[id='loading']")));
            IWebElement result = driver.FindElement(By.CssSelector("div[id]>h4"));
            string expected = ("Hello World!");
            Assert.AreEqual(expected, result.Text);
        }
    }
}
