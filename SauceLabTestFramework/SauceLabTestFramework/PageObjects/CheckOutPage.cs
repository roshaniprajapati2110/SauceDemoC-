using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceLabs_Practical.PageObjects
{
    public class CheckOutPage
    {
        private IWebDriver driver;
        public CheckOutPage(IWebDriver driver) => this.driver = driver;

        public void FillInformation(string firstName, string lastName, string zip)
        {
            driver.FindElement(By.Id("first-name")).SendKeys(firstName);
            driver.FindElement(By.Id("last-name")).SendKeys(lastName);
            driver.FindElement(By.Id("postal-code")).SendKeys(zip);
            driver.FindElement(By.XPath("//input[contains(@class,'btn_primary ')]")).Click();
        }

        public string GetTotalPrice() =>
            driver.FindElement(By.ClassName("summary_total_label")).Text;

        public void Finish() =>
            driver.FindElement(By.XPath("//a[text()='FINISH']")).Click();

        public string GetConfirmationText() =>
            driver.FindElement(By.ClassName("complete-header")).Text;
    }
}

