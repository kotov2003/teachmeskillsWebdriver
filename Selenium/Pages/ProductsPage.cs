using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Tests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Selenium.Pages
{
    public class ProductsPage : BasePage
    {
        public static string PageTitle = "PRODUCTS";

        private By ProductsPageTitleTxt = By.CssSelector(".title");

        private By InventoryItem = By.CssSelector(".inventory_item");

        private By InventoryItemNameTxt = By.CssSelector(".inventory_item_name");

        private By SortingDropdown = By.CssSelector(".product_sort_container");

        private By SelectedSortingOption = By.CssSelector(".active_option");

        private By InventoryItemPriceTxt = By.CssSelector(".inventory_item_price");



        public ProductsPage(WebDriver driver) : base(driver) { }

        public bool IsProductsPageOpened()
        {
            var titleDisplayed = driver.FindElement(ProductsPageTitleTxt).Displayed;
            var titleIsRight = driver.FindElement(ProductsPageTitleTxt).Text == PageTitle;
            return titleDisplayed && titleIsRight;
        }

        public int GetItemsNumber()
        {
            return driver.FindElements(InventoryItem).Count;
        }

        public ProductItemPage OpenProductItemPage(string productName)
        {
            var itemImage = By.XPath($"//img[@alt=\"{productName}\"]");
            driver.FindElement(itemImage).Click();
            return new ProductItemPage(driver);
        }

        public bool IsProducltListSortedAZ()
        {
            IList<IWebElement> itemList = driver.FindElements(InventoryItemNameTxt);
            var titleList = itemList.Select(item => item.Text);
            var sorted = new List<string>();
            sorted.AddRange(titleList.OrderBy(o => o));

            var isListSortedAZ = titleList.SequenceEqual(sorted);
            return isListSortedAZ;
        }

        public bool IsProducltListSortedZA()
        {
            IList<IWebElement> itemList = driver.FindElements(InventoryItemNameTxt);
            var titleList = itemList.Select(item => item.Text);
            var sorted = new List<string>();
            sorted.AddRange(titleList.OrderByDescending(o => o));

            var isListSortedAZ = titleList.SequenceEqual(sorted);
            return isListSortedAZ;
        }

        public bool IsProducltListSortedLowHigh()
        {
            IList<IWebElement> itemList = driver.FindElements(InventoryItemPriceTxt);
            var priceList = itemList.Select(item => Convert.ToDouble(item.Text.Substring(1))).ToList<double>(); ;
            var sorted = new List<double>();
            sorted.AddRange(priceList.OrderBy(o => o));

            var isListSortedLowHigh = priceList.SequenceEqual(sorted);
            return isListSortedLowHigh;
        }

        public bool IsProducltListSortedHighLow()
        {
            IList<IWebElement> itemList = driver.FindElements(InventoryItemPriceTxt);
            var priceList = itemList.Select(item => Convert.ToDouble(item.Text.Substring(1))).ToList<double>(); ;
            var sorted = new List<double>();
            sorted.AddRange(priceList.OrderByDescending(o => o));

            var isListSortedLowHigh = priceList.SequenceEqual(sorted);
            return isListSortedLowHigh;
        }

        public ProductsPage SelectSortType(SortingType sortTypeOption)
        {
            switch (sortTypeOption)
            {
                case SortingType.AZ:
                    SelectSorting("Name (A to Z)");
                    break;
                case SortingType.ZA:
                    SelectSorting("Name (Z to A)");
                    break;
                case SortingType.LowHigh:
                    SelectSorting("Price (low to high)");
                    break;
                case SortingType.HighLow:
                    SelectSorting("Price (high to low)");
                    break;
            }
            return this;
        }

        private void SelectSorting(string sortType)
        {
            var dropDown = new SelectElement(driver.FindElement(SortingDropdown));
            dropDown.SelectByText(sortType);
            string selectedSortTypeOption = driver.FindElement(SelectedSortingOption).Text;
            Assert.True(selectedSortTypeOption.Contains(sortType.ToUpper()), $"The expected type of sorting {sortType} was not selected. The actual text was: {selectedSortTypeOption}.");
        }
    }
}
