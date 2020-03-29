using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace PrimeiroTesteAutomatizado.Atividade2
{
    [TestFixture]
    public class TestAdicionar1ItemAoCarrinho : BaseTest
    {
        [Test]
        public void Adicionar1ItemAoCarrinho()
        {
            AbreUrl("http://automationpractice.com/index.php");
                 IWebElement tShirts = driver.FindElement(By.CssSelector("li:nth-child(3)>[title='T-shirts']"));
                 tShirts.Click();
            var espera = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            espera.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("img[title='Faded Short Sleeve T-shirts']")));
            IWebElement produto = driver.FindElement(By.CssSelector("img[title='Faded Short Sleeve T-shirts']"));
            Actions action = new Actions(driver);
            action.MoveToElement(produto).Perform();
            IWebElement addToCart = driver.FindElement(By.CssSelector(".button-container>[data-id-product='1']"));
                     addToCart.Click();
            espera.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".icon-ok")));
                    IWebElement mensagemSucesso = driver.FindElement(By.CssSelector(".layer_cart_product.col-xs-12.col-md-6>h2"));
            Assert.AreEqual("Product successfully added to your shopping cart", mensagemSucesso.Text);

            IWebElement proceedToCheckout = driver.FindElement(By.CssSelector("[title='Proceed to checkout']>span"));
            proceedToCheckout.Click();
            espera.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("[title='Proceed to checkout']>span")));
            IList<IWebElement> tabelaDescricao = driver.FindElements(By.CssSelector("#product_1_1_0_0>td"));
            IList<string> valoresEncontrados = new List<string>();
            foreach (IWebElement item in tabelaDescricao)
            {
                valoresEncontrados.Add(item.Text);
            };
            IList<string> valoresEsperados = new List<string>()
            {
                "",
               "Faded Short Sleeve T-shirts\r\nSKU : demo_1\r\nColor : Orange, Size : S",
               "In stock",
               "$16.51",
               "",
               "$16.51",
               ""
            };
            Assert.AreEqual(valoresEsperados, valoresEncontrados);

            IList<IWebElement> totalizadores = driver.FindElements(By.CssSelector("tfoot>tr"));
            IList<string> valoresEncontradosTotalizadores = new List<string>();
            foreach (IWebElement item1 in totalizadores)
            {
                valoresEncontradosTotalizadores.Add(item1.Text);
            };
            IList<string> valoresEsperadosTotalizadores = new List<string>()
            {
                "Total products $16.51",
                "",
                "Total shipping $2.00",
                "",
                "Total $18.51",
                "Tax $0.00",
               "TOTAL $18.51"
            };
            Assert.AreEqual(valoresEsperadosTotalizadores, valoresEncontradosTotalizadores);



        }
    }
}
