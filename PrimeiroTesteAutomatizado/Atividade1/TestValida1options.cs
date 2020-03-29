using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace PrimeiroTesteAutomatizado.Atividade1
{
    [TestFixture]
    public class TestValida1options : BaseTest
    {
        [Test]
        public void TestMethod1()
        {
            AbreUrl(" http://the-internet.herokuapp.com/dropdown");
            IWebElement dropdown = driver.FindElement(By.CssSelector("select[id = 'dropdown']"));
                dropdown.Click();
            IWebElement option1 = driver.FindElement(By.CssSelector("option[value='1']"));
                option1.Click();
            bool check = driver.FindElement(By.CssSelector("select > option[value = '1']")).Selected;
                bool expected = true;
            Assert.AreEqual(expected, check);

            Thread.Sleep(5000);
        }
    }
}
