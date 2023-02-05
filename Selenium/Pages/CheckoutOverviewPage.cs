using OpenQA.Selenium;

namespace Selenium.Pages
{
    public class CheckoutOverviewPage : BasePage
    {
        public static string PageTitle = "CHECKOUT: OVERVIEW";

        private By CheckoutPageTitleTxt = By.CssSelector(".title");

        private By ProductItemInCart = By.CssSelector(".cart_item");

        private By ProductTitleTxt = By.CssSelector(".inventory_item_name");

        private By ProductDescriptionTxt = By.CssSelector(".inventory_item_desc");

        private By ProductPriceTxt = By.CssSelector(".inventory_item_price");

        private By ProductQuantityTxt = By.CssSelector(".cart_quantity");

        private By SummaryValueTxt = By.CssSelector(".summary_value_label");

        private By SummarySubtotalValueTxt = By.CssSelector(".summary_subtotal_label");

        private By SummaryTaxValueTxt = By.CssSelector(".summary_tax_label");

        private By SummaryTotalValueTxt = By.CssSelector(".summary_total_label");

        private By FinishButton = By.Id("finish");


        public CheckoutOverviewPage(WebDriver driver) : base(driver) { }

        public bool IsCheckoutOverviewPageDisplayed()
        {
            var titleDisplayed = driver.FindElement(CheckoutPageTitleTxt).Displayed;
            var titleIsRight = driver.FindElement(CheckoutPageTitleTxt).Text == PageTitle;
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

        public string GetPaymentInformation()
        {
            return driver.FindElements(SummaryValueTxt).First().Text;
        }

        public string GetShippingInformation()
        {
            return driver.FindElements(SummaryValueTxt).Last().Text; ;
        }

        public string GetSummarySubtotal()
        {
            return driver.FindElement(SummarySubtotalValueTxt).Text;
        }

        public string SummaryTaxValue()
        {
            return driver.FindElement(SummaryTaxValueTxt).Text;
        }

        public string SummaryTotalValue()
        {
            return driver.FindElement(SummaryTotalValueTxt).Text;
        }

        public bool TotalValueCalculationCheck()
        {
            var summarySubtotalDouble = double.Parse(GetSummarySubtotal().Substring(13));
            var summaryTaxDouble = double.Parse(SummaryTaxValue().Substring(6));
            var summaryTotalDouble = double.Parse(SummaryTotalValue().Substring(8));

            var isTotalCorrect = summaryTotalDouble == summarySubtotalDouble + summaryTaxDouble;
            return isTotalCorrect;
        }

        public bool TaxValueCalculationCheck()
        {
            var summarySubtotalDouble = double.Parse(GetSummarySubtotal().Substring(13));
            var summaryTaxDouble = double.Parse(SummaryTaxValue().Substring(6));
            var summarySubtotalDoubleTaxProcent = Math.Round((summarySubtotalDouble * 0.08), 2, MidpointRounding.AwayFromZero);

            var isTaxCorrect = summaryTaxDouble == summarySubtotalDoubleTaxProcent;
            return isTaxCorrect;

        }

        public CheckoutCompletePage OpenCheckoutCompletePage()
        {
            driver.FindElement(FinishButton).Click();
            return new CheckoutCompletePage(driver);
        }        
    }
}