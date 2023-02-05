using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Selenium.Pages;
using NUnit.Framework;

namespace Selenium.Tests
{
    public class LoginBaseTest
    {
        protected WebDriver driver;
        protected LoginPage loginPage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage = new LoginPage(driver);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
