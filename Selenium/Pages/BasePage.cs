using OpenQA.Selenium;

namespace Selenium.Pages
{
    public abstract class BasePage
    {
        protected WebDriver driver;

        public BasePage(WebDriver driver)
        {
            this.driver = driver;
        }
    }
}


