using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Selenium.Pages;
using NUnit.Framework;

namespace Selenium.Tests
{
    public class BaseTest
    {
        protected WebDriver driver;
        protected LoginPage loginPage;
        protected ProductsPage productsPage;
        protected ProductItemPage productItemPage;
        protected CartPage cartPage;
        protected CheckoutPage checkoutPage;
        protected CheckoutOverviewPage checkoutOverviewPage;
        protected CheckoutCompletePage checkoutCompletePage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage = new LoginPage(driver);
            loginPage.LoginWithStandardUser();
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
