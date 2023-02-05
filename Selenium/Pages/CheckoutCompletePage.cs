using OpenQA.Selenium;

namespace Selenium.Pages
{
    public class CheckoutCompletePage : BasePage
    {
        public static string PageTitle = "CHECKOUT: COMPLETE!";

        private By CheckoutCompletePageTitleTxt = By.CssSelector(".title");

        private By HeaderTxt = By.CssSelector(".complete-header");

        private By MessageTxt = By.CssSelector(".complete-text");

        private By ShippingServiceImage = By.XPath($"//img[@alt=\"Pony Express\"]");

        private By BackToProductsButton = By.CssSelector("#back-to-products");


        public CheckoutCompletePage(WebDriver driver) : base(driver) { }

        public bool IsCheckoutCompletePageDisplayed()
        {
            var titleDisplayed = driver.FindElement(CheckoutCompletePageTitleTxt).Displayed;
            var titleIsRight = driver.FindElement(CheckoutCompletePageTitleTxt).Text == PageTitle;
            return titleDisplayed && titleIsRight;
        }

        public string GetHeader()
        {
            return driver.FindElement(HeaderTxt).Text;
        }

        public string GetMessage()
        {
            return driver.FindElement(MessageTxt).Text;
        }

        public bool IsShippingServiceImageDisplаyed()
        {
            return driver.FindElement(ShippingServiceImage).Displayed;
        }
    }
}