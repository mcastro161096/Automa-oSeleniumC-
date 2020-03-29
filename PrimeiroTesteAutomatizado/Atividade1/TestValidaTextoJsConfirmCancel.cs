using NUnit.Framework;
using OpenQA.Selenium;

namespace PrimeiroTesteAutomatizado.Atividade1
{
    [TestFixture]
    public class TestValidaTextoJsConfirmCancel : BaseTest
    {
        [Test]
        public void TestMethod1()
        {
            AbreUrl("http://the-internet.herokuapp.com/javascript_alerts");
            IWebElement botaoJsConfirm = driver.FindElement(By.CssSelector("button[onclick='jsConfirm()']"));
            botaoJsConfirm.Click();
            IAlert result = driver.SwitchTo().Alert();
            Assert.AreEqual("I am a JS Confirm", result.Text);
            result.Dismiss();
            IWebElement mensagemConfirmacao = driver.FindElement(By.CssSelector("#result"));
            Assert.AreEqual("You clicked: Cancel", mensagemConfirmacao.Text);
        }
    }
}
