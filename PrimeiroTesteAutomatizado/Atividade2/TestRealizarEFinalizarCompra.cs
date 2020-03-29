using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace PrimeiroTesteAutomatizado.Atividade2
{
    [TestFixture]
    public class TestRealizarEFinalizarCompra : BaseTest
    {
        [Test]
        public void RealizarEFinalizarCompra()
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

            var esperaIconeVisivel = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            esperaIconeVisivel.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".icon-ok")));

            IWebElement proceedToCheckout = driver.FindElement(By.CssSelector("[title='Proceed to checkout']>span"));
            proceedToCheckout.Click();

            var esperaIconeSumir = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            esperaIconeSumir.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("[title='Proceed to checkout']>span")));

            IWebElement proceedToCheckoutStandart = driver.FindElement(By.CssSelector("[class*='standard-checkout button'][title*='checkout']"));
            proceedToCheckoutStandart.Click();

            var esperaBotaoCreateVisivel = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            esperaBotaoCreateVisivel.Until(ExpectedConditions.ElementIsVisible(By.Id("SubmitCreate")));

            IWebElement campoEmailCreate = driver.FindElement(By.Id("email_create"));
            var email = "referenzbil@grlksjhnbdfpfdshdftdhdfasaz.com";
            var password = "12345";
            campoEmailCreate.SendKeys(email);

            IWebElement botaoCreate = driver.FindElement(By.Id("SubmitCreate"));
            botaoCreate.Click();

            bool possuiConta = false;
            try
            {
                var esperaMensagemVisivel = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                esperaMensagemVisivel.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#create_account_error>ol>li")));
                possuiConta = true;
            }
            catch (WebDriverTimeoutException)
            {
                possuiConta = false;
            }


            if (possuiConta is false)
            {
                var esperaMisterVisivel = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                esperaMisterVisivel.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#uniform-id_gender2")));

                IWebElement mister = driver.FindElement(By.CssSelector("#uniform-id_gender2"));
                mister.Click();

                IWebElement campoFirstName = driver.FindElement(By.Id("customer_firstname"));
                campoFirstName.SendKeys("Teste");

                IWebElement campoLastName = driver.FindElement(By.Id("customer_lastname"));
                campoLastName.SendKeys("Automatizado");

                IWebElement campoPassword = driver.FindElement(By.Id("passwd"));
                campoPassword.SendKeys(password);

                IWebElement campoAddress1 = driver.FindElement(By.Id("address1"));
                campoAddress1.SendKeys("gvdasa");

                IWebElement campoCity = driver.FindElement(By.Id("city"));
                campoCity.SendKeys("sao leo");

                IWebElement campoState = driver.FindElement(By.Id("id_state"));
                SelectElement seletor = new SelectElement(campoState); 
                seletor.SelectByText("Alabama");

                IWebElement campoPostalCode = driver.FindElement(By.Id("postcode"));
                campoPostalCode.SendKeys("00000");

                IWebElement campoMobilePhone = driver.FindElement(By.Id("phone_mobile"));
                campoMobilePhone.SendKeys("123456789");

                IWebElement botaoRegister = driver.FindElement(By.Id("submitAccount"));
                botaoRegister.Click();
                
            }
            else  if (possuiConta is true)


            {
                IWebElement campoEmail = driver.FindElement(By.Id("email"));
                campoEmail.SendKeys(email);

                IWebElement campoSenha = driver.FindElement(By.Id("passwd"));
                campoSenha.SendKeys(password); 

                IWebElement botaoEnter = driver.FindElement(By.Id("SubmitLogin"));
                botaoEnter.Click();

            }

            var esperaAbaAdressVisivel = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            esperaAbaAdressVisivel.Until(ExpectedConditions.ElementIsVisible(By.Name("processAddress")));

            IWebElement proceedToCheckoutAbaAdress = driver.FindElement(By.Name("processAddress"));
            proceedToCheckoutAbaAdress.Click();

            var esperaAbaShipingVisivel = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            esperaAbaShipingVisivel.Until(ExpectedConditions.ElementIsVisible(By.Name("processCarrier")));

            IWebElement aceiteDeTermos = driver.FindElement(By.ClassName("checker"));
            aceiteDeTermos.Click();

            IWebElement proceedToCheckoutAbaShiping = driver.FindElement(By.Name("processCarrier"));
            proceedToCheckoutAbaShiping.Click();

            var esperaTransferenciaVisivel = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            esperaTransferenciaVisivel.Until(ExpectedConditions.ElementIsVisible(By.ClassName("bankwire")));

            IWebElement pagarViaTransferencia = driver.FindElement(By.ClassName("bankwire"));
            pagarViaTransferencia.Click();

            var esperaBotaoConfirmVisivel = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            esperaBotaoConfirmVisivel.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[class*='button-medium'][type=submit]")));

            IWebElement botaoConfirm = driver.FindElement(By.CssSelector("[class*='button-medium'][type=submit]"));
            botaoConfirm.Click();

        }
    }
}

