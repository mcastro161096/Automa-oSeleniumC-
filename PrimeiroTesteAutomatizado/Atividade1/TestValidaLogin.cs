using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PrimeiroTesteAutomatizado.Atividade1
{
    [TestFixture]
    public class TestValidaLogin : BaseTest
    {
        [Test]
        public void TestMethod1()
        {
            AbreUrl("http://the-internet.herokuapp.com/login");

            IWebElement campoUser = driver.FindElement(By.CssSelector("#username"));
            campoUser.SendKeys("tomsmith");
            IWebElement campoSenha = driver.FindElement(By.CssSelector("#password"));
            campoSenha.SendKeys("SuperSecretPassword!");
            Thread.Sleep(1000);
            campoUser.Submit();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".subheader")));
            IWebElement telaDeConfirmacao = driver.FindElement(By.CssSelector(".subheader"));
            Assert.AreEqual("Welcome to the Secure Area. When you are done click logout below.", telaDeConfirmacao.Text);
            Thread.Sleep(1000);

        }
    }
}
