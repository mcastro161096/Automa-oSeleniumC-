
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace PrimeiroTesteAutomatizado.Atividade1
{
    [TestFixture]
    public class TestValidaCheckBox : BaseTest
    {
        [Test]
        public void TestMethod1()
        {
            AbreUrl("http://the-internet.herokuapp.com/checkboxes");



            IWebElement query = driver.FindElement(By.CssSelector("form>input:nth-child(3)"));

            bool isChecked = driver.FindElement(By.CssSelector("form>input:nth-child(3)")).Selected;
            bool expected = true;
            Assert.AreEqual(expected, isChecked);

            IWebElement query1 = driver.FindElement(By.CssSelector("form>input:nth-child(1)"));

            bool isChecked1 = driver.FindElement(By.CssSelector("form>input:nth-child(1)")).Selected;
            bool expected1 = false;
            Assert.AreEqual(expected1, isChecked1);





            Thread.Sleep(2000);

            
        }
    }
}
