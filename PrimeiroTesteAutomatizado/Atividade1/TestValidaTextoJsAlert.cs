using NUnit.Framework;
using OpenQA.Selenium;

namespace PrimeiroTesteAutomatizado.Atividade1
{
    [TestFixture]
    public class TestValidaTextoJsAlert : BaseTest
    {
        [Test]
        public void TestMethod1()
        {
            AbreUrl("http://the-internet.herokuapp.com/javascript_alerts");
            IWebElement botaoJsAlert = driver.FindElement(By.CssSelector("button[onclick='jsAlert()']"));
            botaoJsAlert.Click();
            IAlert result = driver.SwitchTo().Alert();
            string expected = "I am a JS Alert";
            Assert.AreEqual(expected, result.Text);
            result.Accept();
            IWebElement mensagemConfirmacao = driver.FindElement(By.CssSelector("#result"));
            Assert.AreEqual("You successfuly clicked an alert", mensagemConfirmacao.Text);
        }
    }
}
