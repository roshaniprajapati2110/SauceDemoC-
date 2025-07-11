using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemoAutomation.Utilities;
using SauceLabs_Practical.PageObjects;
using SauceLabTestFramework.PageObjects;
using SauceLabTestFramework.Utilities;

namespace SauceLabTestFramework.Tests
{
    [TestClass]
    public class SauceLabTests
    {

        private IWebDriver driver;
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Setup()
        {
            Congiuration.testContext(TestContext);
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Congiuration.BaseUrl);
        }

        [TestMethod]
        public void SauceLabTest()
        {
            // Arrange
            var username = Congiuration.UserName;
            var password = Congiuration.Password;

            var loginPage = new LoginPage(driver);
            var homePage = new HomePage(driver);
            var checkout = new CheckOutPage(driver);
            var cart = new CartPage(driver);

            //Login to the application and enter the username and password
            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);
            loginPage.ClickLoginButton();

            //Add two items to the cart
            foreach (var item in TestData.ItemsToAdd)
            {
                homePage.AddToCart(item);
            }

            //Open the cart and verify the items
            homePage.OpenCart();

            var itemsInCart = cart.GetCartItems();
            foreach (var item in TestData.ItemsToAdd)
            {
                Assert.IsTrue(itemsInCart.Contains(item));
            }

            // Proceed to checkout
            cart.ClickCheckout();

            // Fill in the checkout information
            checkout.FillInformation("Roshani", "Prajapati", "98215");

            // Verify the checkout overview
            string total = checkout.GetTotalPrice();
            Assert.IsTrue(total.Contains("Total"), "Total label missing");

            // Click finish to complete the order get the Thank You message
            checkout.Finish();
            string confirmation = checkout.GetConfirmationText();
            Assert.AreEqual("THANK YOU FOR YOUR ORDER", confirmation);

        }

        [TestCleanup]
        public void Cleanup()
        {
            var testStatus = TestContext.CurrentTestOutcome;
           
            if (testStatus!= UnitTestOutcome.Passed)
            {
                ScreenshotHelper.TakeScreenshot(driver, TestContext.TestName);
               
            }
            driver.Quit();

        }
    }
}
