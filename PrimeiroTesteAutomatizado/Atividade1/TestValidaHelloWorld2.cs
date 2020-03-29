using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace PrimeiroTesteAutomatizado.Atividade1
{
    [TestFixture]
    public class TestValidaHelloWorld2 : BaseTest
    {
        [Test]
        public void TestMethod1()
        {
            AbreUrl("http://the-internet.herokuapp.com/dynamic_loading");
            IWebElement exemplo2= driver.FindElement(By.CssSelector("a[href^='/dynamic_loading/2']"));
            exemplo2.Click();
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
