using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace PrimeiroTesteAutomatizado.Atividade2
{
    [TestFixture]
    public class TestRemover1ItemDoCarrinho : BaseTest
    {
        [Test]
        public void Remover1ItemDoCarrinho()
        {
            AbreUrl("http://automationpractice.com/index.php");

            IWebElement printedDress = driver.FindElement(By.LinkText("Printed Dress"));
            Actions action = new Actions(driver);
            action.MoveToElement(printedDress).Perform();
            printedDress.Click();

            var esperaBotaoPlusVisivel = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            esperaBotaoPlusVisivel.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".icon-plus")));

            IWebElement botaoPlus = driver.FindElement(By.CssSelector(".icon-plus"));
            botaoPlus.Click();

            IWebElement campoSize = driver.FindElement(By.Id("group_1"));
            campoSize.Click();

            IWebElement tamanhoM = driver.FindElement(By.CssSelector("select>option[value='2']"));
            tamanhoM.Click();

            IWebElement addToCart2Itens = driver.FindElement(By.Id("add_to_cart"));
            addToCart2Itens.Click();

            var esperaBotaoContinueShopping = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            esperaBotaoContinueShopping.Until(ExpectedConditions.ElementIsVisible(By.TagName("[title='Continue shopping']")));

            IWebElement continueShopping = driver.FindElement(By.TagName("[title='Continue shopping']"));
            continueShopping.Click();

            var esperaMyCartVisivel = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            esperaMyCartVisivel.Until(ExpectedConditions.ElementIsVisible(By.TagName("[title='View my shopping cart']")));

            IWebElement myCart = driver.FindElement(By.TagName("[title='View my shopping cart']"));
            myCart.Click();

            var esperaLixeiraVisivel = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            esperaLixeiraVisivel.Until(ExpectedConditions.ElementIsVisible(By.ClassName("icon-trash")));

            IWebElement quantidade = driver.FindElement(By.CssSelector("[type='hidden'][value='2']"));
            Assert.AreEqual("2", quantidade.GetAttribute("value"));

            IList<IWebElement> tabelaTotalizadores = driver.FindElements(By.CssSelector("tfoot>tr"));
            IList<string> valoresEncontradosTotalizadores = new List<string>();
            foreach (IWebElement elemento in tabelaTotalizadores)
            {
                valoresEncontradosTotalizadores.Add(elemento.Text);
            }
            IList<string> valoresEsperadosTotalizadores = new List<string>()
            {
                "Total products $52.00",
                "",
                "Total shipping $2.00",
                "",
                "Total $54.00",
                "Tax $0.00",
                "TOTAL $54.00"
            };
            Assert.AreEqual(valoresEsperadosTotalizadores, valoresEncontradosTotalizadores);

            IWebElement botaoMenos = driver.FindElement(By.CssSelector(".icon-minus"));
            botaoMenos.Click();

            IWebElement total = driver.FindElement(By.Id("total_price_container"));

            var esperaTotal28Visivel = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            esperaTotal28Visivel.Until(ExpectedConditions.TextToBePresentInElement(total, "$28.00"));

            IWebElement quantidadeDepoisDeClicarNoBotaoMenos = driver.FindElement(By.CssSelector("[type='hidden'][value='1']"));
            Assert.AreEqual("1", quantidadeDepoisDeClicarNoBotaoMenos.GetAttribute("value"));

            IList<IWebElement> tabelaTotalizadoresAlterada = driver.FindElements(By.CssSelector("tfoot>tr"));
            IList<string> valoresEncontradosTotalizadoresAlterados = new List<string>();
            foreach (IWebElement elemento in tabelaTotalizadoresAlterada)
            {
                valoresEncontradosTotalizadoresAlterados.Add(elemento.Text);
            }
            IList<string> valoresEsperadosTotalizadoresAlterados = new List<string>()
            {
                "Total products $26.00",
                "",
                "Total shipping $2.00",
                "Total $28.00",
                "Tax $0.00",
                "TOTAL $28.00"
            };
            Assert.AreEqual(valoresEsperadosTotalizadoresAlterados, valoresEncontradosTotalizadoresAlterados);


        }
    }
}
