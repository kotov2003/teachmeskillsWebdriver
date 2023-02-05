using OpenQA.Selenium;

namespace Selenium.Pages
{
    public class ProductItemPage : BasePage
    {
        private By BackToProductButton = By.Id("back-to-products");

        private By ProductTitleTxt = By.CssSelector(".inventory_details_name.large_size");

        private By ProductDescriptionTxt = By.CssSelector(".inventory_details_desc.large_size");

        private By ProductPriceTxt = By.CssSelector(".inventory_details_price");

        private By AddToCartButton = By.Id("add-to-cart-sauce-labs-backpack");

        private By RemoveButton = By.Id("remove-sauce-labs-backpack");

        private By CartBadge = By.CssSelector(".shopping_cart_badge");

        private By CartLink = By.CssSelector(".shopping_cart_link");


        public ProductItemPage(WebDriver driver) : base(driver) { }

        public bool IsProductItemPageDisplayed()
        {
            return driver.FindElement(BackToProductButton).Displayed;
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

        public ProductItemPage AddProductToCartPrice()
        {
            driver.FindElement(AddToCartButton).Click();
            return this;
        }

        public bool IsProductMovedToCart()
        {
            var removeButtonDisplayed = driver.FindElement(RemoveButton).Displayed;
            var cartBadgeDisplayed = driver.FindElement(CartBadge).Displayed;
            return removeButtonDisplayed && cartBadgeDisplayed;
        }

        public CartPage OpenCartPage()
        {
            driver.FindElement(CartLink).Click();
            return new CartPage(driver);
        }
    }
}