using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceLabs_Practical.PageObjects
{
    public class CartPage
    {
        private IWebDriver driver;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public List<string> GetCartItems()
        {
            var itemElements = driver.FindElements(By.ClassName("inventory_item_name"));
            var itemNames = new List<string>();

            foreach (var item in itemElements)
            {
                itemNames.Add(item.Text);
            }

            return itemNames;
        }

        public void ClickCheckout()
        {
            driver.FindElement(By.XPath("//a[text()='CHECKOUT']")).Click();
        }
    }
}

