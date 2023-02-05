using OpenQA.Selenium;

namespace Selenium.Pages
{
    public class CartPage : BasePage
    {
        public static string PageTitle = "YOUR CART";

        private By YourCartPageTitleTxt = By.CssSelector(".title");

        private By ProductItemInCart = By.CssSelector(".cart_item");

        private By ProductTitleTxt = By.CssSelector(".inventory_item_name");

        private By ProductDescriptionTxt = By.CssSelector(".inventory_item_desc");

        private By ProductPriceTxt = By.CssSelector(".inventory_item_price");

        private By ProductQuantityTxt = By.CssSelector(".cart_quantity");

        private By CheckoutButton = By.Id("checkout");


        public CartPage(WebDriver driver) : base(driver) { }

        public bool IsCartPageDisplayed()
        {
            var titleDisplayed = driver.FindElement(YourCartPageTitleTxt).Displayed;
            var titleIsRight = driver.FindElement(YourCartPageTitleTxt).Text == PageTitle;
            return titleDisplayed && titleIsRight;
        }

        public int GetItemsNumber()
        {
            return driver.FindElements(ProductItemInCart).Count;
        }

        public string GetProductItemTitle()
        {
            return driver.FindElement(ProductTitleTxt).Text;
        }

        public string GetProductDescription()
        {
            return driver.FindElement(ProductDescriptionTxt).Text;
        }

        public string GetProductPrice()
        {
            return driver.FindElement(ProductPriceTxt).Text;
        }

        public string GetQuantityTxtPrice()
        {
            return driver.FindElement(ProductQuantityTxt).Text;
        }

        public CheckoutPage OpenCheckoutPage()
        {
            driver.FindElement(CheckoutButton).Click();
            return new CheckoutPage(driver);
        }
    }
}