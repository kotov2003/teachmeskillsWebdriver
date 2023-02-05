using OpenQA.Selenium;

namespace Selenium.Pages
{
    public class LoginPage : BasePage
    {
        public static string StandardUser = "standard_user";
        public static string DefaultPassword = "secret_sauce";

        private By UserNameField = By.Id("user-name");

        private By PasswordField = By.Id("password");

        private By LoginButton = By.Id("login-button");

        private By ErrorMessage = By.CssSelector(".error-message-container.error");


        public LoginPage(WebDriver driver) : base(driver) { }

        public LoginPage SetUserName(string userName)
        {
            driver.FindElement(UserNameField).SendKeys(userName);
            return this;
        }

        public LoginPage SetPassword(string password)
        {
            driver.FindElement(PasswordField).SendKeys(password);
            return this;
        }

        internal ProductsPage LoginWithStandardUser()
        {
            SetUserName(StandardUser);
            SetPassword(DefaultPassword);
            ClickLogin();

            return new ProductsPage(driver);
        }

        internal void LoginWithStandardUser(string name, string password)
        {
            SetUserName(name);
            SetPassword(password);
            ClickLogin();
        }


        public LoginPage ClickLogin()
        {
            driver.FindElement(LoginButton).Click();
            return this;
        }

        public bool GetErrorMessage()
        {
            return driver.FindElement(ErrorMessage).Displayed;
        }
    }
}
