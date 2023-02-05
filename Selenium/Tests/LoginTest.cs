using NUnit.Framework;

namespace Selenium.Tests
{
    [TestFixture]
    public class LoginTest : LoginBaseTest
    {
        [Test]
        public void CorrectLogin()
        {
            var productsPageOpened =
                loginPage.
                    LoginWithStandardUser().
                    IsProductsPageOpened();

            Assert.IsTrue(productsPageOpened);
        }

        [Test]
        public void TestEmptyPassword()
        {
            var errorMessageDisplayed =
                loginPage.
                    SetUserName("standart_user").
                    ClickLogin().
                    GetErrorMessage();

            Assert.IsTrue(errorMessageDisplayed);
        }
    }
}
