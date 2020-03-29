using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace PrimeiroTesteAutomatizado.Atividade2
{
    [TestFixture]
    public class TestAdicionar3ItensAoCarrinhoTest1 : BaseTest
    {
        [Test]
        public void Adicionar3ItensAoCarrinho()
        {
            AbreUrl("http://automationpractice.com/index.php");
            IWebElement produto = driver.FindElement(By.LinkText("Faded Short Sleeve T-shirts"));
            Actions action = new Actions(driver);
            action.MoveToElement(produto).Perform();
            IWebElement addToCart = driver.FindElement(By.CssSelector(".button-container>[data-id-product='1']"));
            addToCart.Click();

            var esperaBotaoVisivel = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            esperaBotaoVisivel.Until(ExpectedConditions.ElementIsVisible(By.TagName("[title='Continue shopping']")));

            IWebElement continueShopping = driver.FindElement(By.TagName("[title='Continue shopping']"));
            continueShopping.Click();

            IWebElement summerDress = driver.FindElement(By.CssSelector("#homefeatured>li:nth-child(5)"));
            action.MoveToElement(summerDress).Perform();

            IWebElement more = driver.FindElement(By.CssSelector(".button[href='http://automationpractice.com/index.php?id_product=5&controller=product']"));
            more.Click();

            IWebElement size = driver.FindElement(By.Id("group_1"));
            size.Click();

            IWebElement tamanhoM = driver.FindElement(By.CssSelector("select>option[value='2']"));
            tamanhoM.Click();

            IWebElement campoQuantidade = driver.FindElement(By.Id("quantity_wanted"));
            campoQuantidade.Clear();
            campoQuantidade.SendKeys("2");

            IWebElement addToCart2Itens = driver.FindElement(By.Id("add_to_cart"));
            addToCart2Itens.Click();

            var esperaMensagemSucesso = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            esperaMensagemSucesso.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".layer_cart_product.col-xs-12.col-md-6>h2")));

            IWebElement mensagemSucesso = driver.FindElement(By.CssSelector(".layer_cart_product.col-xs-12.col-md-6>h2"));
            Assert.AreEqual("Product successfully added to your shopping cart",mensagemSucesso.Text);
            IWebElement proceedToCheckout = driver.FindElement(By.CssSelector("[title='Proceed to checkout']"));
            proceedToCheckout.Click();

            IList<IWebElement> tabelaDescricaoProduto = driver.FindElements(By.CssSelector("#product_5_23_0_0>td"));
            IList<string> valoresEncontrados = new List<string>();
            foreach (IWebElement elemento in tabelaDescricaoProduto)
            {
                valoresEncontrados.Add(elemento.Text);
            }
            IList<string> valoresEsperados = new List<string>()
            {
                "",
                "Printed Summer Dress\r\nSKU : demo_5\r\nColor : Yellow, Size : M",
                "In stock",
                "$28.98  -5%  $30.51",
                "",
                "$57.96",
                ""
            };
            Assert.AreEqual(valoresEsperados, valoresEncontrados);

            IList<IWebElement> tabelaTotalizadores = driver.FindElements(By.CssSelector("tfoot>tr"));
            IList<string> valoresEncontradosTotalizadores = new List<string>();
            foreach (IWebElement elemento in tabelaTotalizadores)
            {
                valoresEncontradosTotalizadores.Add(elemento.Text);
            }
            IList<string> valoresEsperadosTotalizadores = new List<string>()
            {
                "Total products $74.47",
                "",
                "Total shipping $2.00",
                "",
                "Total $76.47",
                "Tax $0.00",
                "TOTAL $76.47"
            };
            IWebElement mensagemTotalItens = driver.FindElement(By.ClassName("heading-counter"));
            Assert.AreEqual(valoresEsperadosTotalizadores, valoresEncontradosTotalizadores);
            Assert.AreEqual("Your shopping cart contains: 3 Products", mensagemTotalItens.Text);


        }
    }
}
