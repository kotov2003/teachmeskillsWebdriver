using NUnit.Framework;
using Selenium.Pages;

namespace Selenium.Tests
{
    [TestFixture]
    public class ProductListTest : BaseTest
    {
        const string productName = "Sauce Labs Backpack";
        const string productDescription = "carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.";
        const string productPrice = "$29.99";

        [Test]
        public void ProductsPage_NumberOfProducts()
        {
            var expectedItemsNumber = 6;
            productsPage = new ProductsPage(driver);

            var actualItemsNumber = productsPage.GetItemsNumber();

            Assert.AreEqual(expectedItemsNumber, actualItemsNumber);
        }


        [Test]
        public void ProductItemPage_ProductDetails()
        {
            productsPage = new ProductsPage(driver);
            productItemPage = new ProductItemPage(driver);


            var productItemPageDisplayed =
                productsPage.
                    OpenProductItemPage(productName).
                    IsProductItemPageDisplayed();
            Assert.IsTrue(productItemPageDisplayed);

            var actualProductName = productItemPage.GetProductItemTitle();
            var actualDescription = productItemPage.GetProductDescription();
            var actualPrice = productItemPage.GetProductPrice();


            Assert.AreEqual(productName, actualProductName);
            Assert.AreEqual(productDescription, actualDescription);
            Assert.AreEqual(productPrice, actualPrice);
        }


        [Test]
        public void ProductItemPage_AddProductToCart()
        {
            var productName = "Sauce Labs Backpack";
            productsPage = new ProductsPage(driver);

            var productAddedToCart =
                productsPage.
                    OpenProductItemPage(productName).
                    AddProductToCartPrice().
                    IsProductMovedToCart();

            Assert.IsTrue(productAddedToCart);
        }


        [Test]
        public void CartPage_ProductDetails()
        {
            var expectedItemsNumber = 1;
            var productQuantity = "1";
            productsPage = new ProductsPage(driver);
            cartPage = new CartPage(driver);


            var cartPageDisplayed =
                productsPage.
                    OpenProductItemPage(productName).
                    AddProductToCartPrice().
                    OpenCartPage().
                    IsCartPageDisplayed();
            Assert.IsTrue(cartPageDisplayed);

            var actualItemsNumber = cartPage.GetItemsNumber();
            var actualTitle = cartPage.GetProductItemTitle();
            var actualDescription = cartPage.GetProductDescription();
            var actualPrice = cartPage.GetProductPrice();
            var actualQuantity = cartPage.GetQuantityTxtPrice();


            Assert.AreEqual(expectedItemsNumber, actualItemsNumber);
            Assert.AreEqual(productName, actualTitle);
            Assert.AreEqual(productDescription, actualDescription);
            Assert.AreEqual(productPrice, actualPrice);
            Assert.AreEqual(productQuantity, actualQuantity);
        }


        [Test]
        public void CheckoutPage_FillingOutForm()
        {
            productsPage = new ProductsPage(driver);
            checkoutPage = new CheckoutPage(driver);

            var checkoutPageDisplayed =
                productsPage.
                    OpenProductItemPage(productName).
                    AddProductToCartPrice().
                    OpenCartPage().
                    OpenCheckoutPage().
                    IsCheckoutPageDisplayed();
            Assert.IsTrue(checkoutPageDisplayed);

            var checkoutOverviewPageDisplayed =
                checkoutPage.
                    CheckoutWithStandardUser().
                    IsCheckoutOverviewPageDisplayed();
            Assert.IsTrue(checkoutOverviewPageDisplayed);
        }


        [Test]
        public void CheckoutOverviewPage_ProductDetails()
        {
            var expectedItemsNumber = 1;
            var productQuantity = "1";
            var expectedPaymentInformation = "SauceCard #31337";
            var expectedShippingInformation = "FREE PONY EXPRESS DELIVERY!";
            var expectedSummarySubtotal = $"Item total: {productPrice}";
            productsPage = new ProductsPage(driver);
            checkoutOverviewPage = new CheckoutOverviewPage(driver);


            var checkoutOverviewPageDisplayed =
                productsPage.
                    OpenProductItemPage(productName).
                    AddProductToCartPrice().
                    OpenCartPage().
                    OpenCheckoutPage().
                    CheckoutWithStandardUser().
                    IsCheckoutOverviewPageDisplayed();
            Assert.IsTrue(checkoutOverviewPageDisplayed);

            var actualItemsNumber = checkoutOverviewPage.GetItemsNumber();
            var actualTitle = checkoutOverviewPage.GetProductItemTitle();
            var actualDescription = checkoutOverviewPage.GetProductDescription();
            var actualPrice = checkoutOverviewPage.GetProductPrice();
            var actualQuantity = checkoutOverviewPage.GetQuantityTxtPrice();
            var actualPaymentInformation = checkoutOverviewPage.GetPaymentInformation();
            var actualShippingInformation = checkoutOverviewPage.GetShippingInformation();
            var actualSummarySubtotal = checkoutOverviewPage.GetSummarySubtotal();
            var taxCalculationIsCorrect = checkoutOverviewPage.TaxValueCalculationCheck();
            var totalCalculationIsCorrect = checkoutOverviewPage.TotalValueCalculationCheck();


            Assert.AreEqual(expectedItemsNumber, actualItemsNumber);
            Assert.AreEqual(productName, actualTitle);
            Assert.AreEqual(productQuantity, actualQuantity);
            Assert.AreEqual(productDescription, actualDescription);
            Assert.AreEqual(productPrice, actualPrice);
            Assert.AreEqual(expectedPaymentInformation, actualPaymentInformation);
            Assert.AreEqual(expectedShippingInformation, actualShippingInformation);
            Assert.AreEqual(expectedSummarySubtotal, actualSummarySubtotal);
            Assert.IsTrue(taxCalculationIsCorrect);
            Assert.IsTrue(totalCalculationIsCorrect);
        }


        [Test]
        public void CheckoutCompletePage_Content()
        {
            var expectedHeader = "THANK YOU FOR YOUR ORDER";
            var expectedMessage = "Your order has been dispatched, and will arrive just as fast as the pony can get there!";
            var productName = "Sauce Labs Backpack";
            productsPage = new ProductsPage(driver);
            checkoutCompletePage = new CheckoutCompletePage(driver);


            var checkoutCompletePageDisplayed =
                productsPage.
                    OpenProductItemPage(productName).
                    AddProductToCartPrice().
                    OpenCartPage().
                    OpenCheckoutPage().
                    CheckoutWithStandardUser().
                    OpenCheckoutCompletePage().
                    IsCheckoutCompletePageDisplayed();
            Assert.IsTrue(checkoutCompletePageDisplayed);

            var actualHeader = checkoutCompletePage.GetHeader();
            var actualMessage = checkoutCompletePage.GetMessage();
            var IsShippingServiceImageDisplаyed = checkoutCompletePage.IsShippingServiceImageDisplаyed();


            Assert.AreEqual(expectedHeader, actualHeader);
            Assert.AreEqual(expectedMessage, actualMessage);
            Assert.IsTrue(IsShippingServiceImageDisplаyed);
        }


        [Test]
        public void ProductsPage_DefaultAZProductSorting()
        {
            productsPage = new ProductsPage(driver);

            var isProducltListSortedAZ = productsPage.IsProducltListSortedAZ();

            Assert.IsTrue(isProducltListSortedAZ);
        }

        [Test]
        public void ProductsPage_ZAProductSorting()
        {
            productsPage = new ProductsPage(driver);

            var isProducltListSortedZA =
                productsPage.
                    SelectSortType(SortingType.ZA).
                    IsProducltListSortedZA(); ;


            Assert.IsTrue(isProducltListSortedZA);
        }

        [Test]
        public void ProductsPage_LowHighPriceProductSorting()
        {
            productsPage = new ProductsPage(driver);

            var isProducltListSortedLowHigh =
                productsPage.
                    SelectSortType(SortingType.LowHigh).
                    IsProducltListSortedLowHigh();

            Assert.IsTrue(isProducltListSortedLowHigh);
        }

        [Test]
        public void ProductsPage_HighLowhPriceProductSorting()
        {
            productsPage = new ProductsPage(driver);

            var isProducltListSortedHighLow =
                productsPage.
                    SelectSortType(SortingType.HighLow).
                    IsProducltListSortedHighLow();

            Assert.IsTrue(isProducltListSortedHighLow);
        }
    }


    public enum SortingType
    {
        AZ,
        ZA,
        LowHigh,
        HighLow
    }
}
