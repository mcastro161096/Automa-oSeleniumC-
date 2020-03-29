using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace PrimeiroTesteAutomatizado.Atividade2
{
    [TestFixture]
    public class TestRemoverTodosItensDoCarrinho : BaseTest
    {
        [Test]
        public void RemoverTodosItensDoCarrinho()
        {
            AbreUrl("http://automationpractice.com/index.php");

            IWebElement produto = driver.FindElement(By.CssSelector("img[title='Faded Short Sleeve T-shirts']"));

            Actions action = new Actions(driver);
            action.MoveToElement(produto).Perform();

            IWebElement botaoAddToCart = driver.FindElement(By.CssSelector(".button-container>[data-id-product='1']"));
            botaoAddToCart.Click();

            var esperaIconeVisivel = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            esperaIconeVisivel.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".icon-ok")));

            IWebElement mensagemSucesso = driver.FindElement(By.CssSelector(".layer_cart_product.col-xs-12.col-md-6>h2"));
            Assert.AreEqual("Product successfully added to your shopping cart", mensagemSucesso.Text);

            IWebElement botaoContinueShoping = driver.FindElement(By.TagName("[title='Continue shopping']"));
            botaoContinueShoping.Click();

            var esperaIconeSumir = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            esperaIconeSumir.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".icon-ok")));

            IWebElement myCart = driver.FindElement(By.TagName("[title='View my shopping cart']"));
            myCart.Click();

            var esperaLixeiraVisivel = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            esperaLixeiraVisivel.Until(ExpectedConditions.ElementIsVisible(By.ClassName("icon-trash")));

            IWebElement botaoLixeira = driver.FindElement(By.ClassName("icon-trash"));
            botaoLixeira.Click();

            var esperaMensagemCarrinhoVazio = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            esperaMensagemCarrinhoVazio.Until(ExpectedConditions.ElementIsVisible(By.ClassName("alert")));

            IWebElement MensagemCarrinhoVazio = driver.FindElement(By.ClassName("alert"));
            Assert.AreEqual("Your shopping cart is empty.", MensagemCarrinhoVazio.Text);


        }
    }
}
