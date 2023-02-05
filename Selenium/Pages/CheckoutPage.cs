using OpenQA.Selenium;

namespace Selenium.Pages
{
    public class CheckoutPage : BasePage
    {
        public static string PageTitle = "CHECKOUT: YOUR INFORMATION";
        public static string DefaultFirstName = "John";
        public static string DefaultLastName = "Smith";
        public static string Default_ZIP = "60007";

        private By CheckoutPageTitleTxt = By.CssSelector(".title");

        private By FirstNameField = By.Id("first-name");

        private By LastNameField = By.Id("last-name");

        private By ZIP_PostaCodeField = By.Id("postal-code");

        private By ContinueButton = By.Id("continue");


        public CheckoutPage(WebDriver driver) : base(driver) { }

        public bool IsCheckoutPageDisplayed()
        {
            var titleDisplayed = driver.FindElement(CheckoutPageTitleTxt).Displayed;
            var titleIsRight = driver.FindElement(CheckoutPageTitleTxt).Text == PageTitle;
            return titleDisplayed && titleIsRight;
        }

        public CheckoutPage SetFirstName(string userName)
        {
            driver.FindElement(FirstNameField).SendKeys(userName);
            return this;
        }

        public CheckoutPage SetLastName(string userName)
        {
            driver.FindElement(LastNameField).SendKeys(userName);
            return this;
        }

        public CheckoutPage SetZIP_PostaCode(string userName)
        {
            driver.FindElement(ZIP_PostaCodeField).SendKeys(userName);
            return this;
        }

        public CheckoutPage ClickContinue()
        {
            driver.FindElement(ContinueButton).Click();
            return this;
        }

        internal CheckoutOverviewPage CheckoutWithStandardUser()
        {
            SetFirstName(DefaultFirstName);
            SetLastName(DefaultLastName);
            SetZIP_PostaCode(Default_ZIP);
            ClickContinue();

            return new CheckoutOverviewPage(driver);
        }

        internal CheckoutPage CheckoutWithStandardUser(string firstName, string lastName, string zip)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetZIP_PostaCode(zip);
            ClickContinue();

            return new CheckoutPage(driver);
        }
    }
}
