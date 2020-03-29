using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace PrimeiroTesteAutomatizado.Atividade1
{
    [TestFixture]
    public class TestValidaLabels : BaseTest
    {
        [Test]
        public void TestMethod1()
        {
            AbreUrl("http://the-internet.herokuapp.com/login");

            IWebElement userName = driver.FindElement(By.CssSelector("[for='username']"));
            IWebElement password = driver.FindElement(By.CssSelector("[for='password']"));
            IWebElement textoBotao = driver.FindElement(By.CssSelector(".radius>.fa"));
            Assert.AreEqual("Username", userName.Text);
            Assert.AreEqual("Password", password.Text);
            Assert.AreEqual("Login", textoBotao.Text);
            Thread.Sleep(1000);

        }
    }
}
