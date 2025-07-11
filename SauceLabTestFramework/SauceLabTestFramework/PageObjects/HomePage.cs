using OpenQA.Selenium;

namespace SauceLabs_Practical.PageObjects
{
    public class HomePage
    {
        private IWebDriver _driver;
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }


        

        public void AddToCart(string itemNames)
        {
            var items = _driver.FindElements(By.ClassName("inventory_item"));
            foreach (var product in items)
            {
                if (product.Text.Contains(itemNames))
                {
                    var button = product.FindElement(By.TagName("button"));
                    button.Click();
                    break;
                }
          
            }
        }

        public void OpenCart()
        {
            _driver.FindElement(By.ClassName("shopping_cart_link")).Click();
        }

    }
}
