# SauceDemo Automation Framework (Selenium + C# + MSTest)

## 🧾 Overview

This automation framework tests the end-to-end purchase flow of the [SauceDemo](https://www.saucedemo.com/) application using **Selenium WebDriver**, **C#**, and **MSTest**. It follows industry-standard best practices:

- ✅ Page Object Model (POM)
- ✅ Test run configuration via `test.runsettings`
- ✅ Parameterized test data
- ✅ Screenshot capture on failure
- ✅ No hardcoded waits – uses **dynamic waits** (`WebDriverWait`)

---

## 🧪 Test Scenario

The test covers the complete purchase flow:

1. **Login** using the first accepted username from config
2. **Add 2 items to cart** (parameterized)
3. **Validate cart contents**
4. **Complete checkout** with **personal details**
5. **Validate** item price, quantity, and total calculations
6. **Confirm final success message**

---

## 📁 Project Structure

SauceDemoFramework/  
├── Pages/ → Page Object classes  
│   ├── LoginPage.cs ├── InventoryPage.cs ├── CartPage.cs ├── CheckoutPage.cs └── CheckoutOverviewPage.cs  
├── TestData/ → Test data for items  
│   └── TestItems.cs  
├── Utilities/ → Helpers for config, random data, screenshot  
│   ├── ConfigReader.cs ├── ScreenshotHelper.cs 
├── Tests/ → MSTest test files  
│   └── EndToEndTest.cs  
├── Test.runsettings → Configuration file (URL, credentials)  
└── README.md → Project documentation
Configuration (test.runsettings)


## Create a test.runsettings file in the root folder:

``<?xml version="1.0" encoding="utf-8"?> <RunSettings> <RunConfiguration> <ResultsDirectory>TestResults</ResultsDirectory> </RunConfiguration> <TestRunParameters> <Parameter name="baseUrl" value="https://www.saucedemo.com/" /> <Parameter name="username" value="standard_user" /> <Parameter name="password" value="secret_sauce" /> </TestRunParameters> </RunSettings>``


### Parameterization

- Login credentials & URL are configured in Test.runsettings

- Items to be added are defined in TestItems.cs


### No Hardcoded Waits

All waits are implemented using WebDriverWait:

`` WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
wait.Until(ExpectedConditions.ElementIsVisible(By.Id("someId"))); `` 

### Screenshot on Failure

ScreenshotHelper.CaptureScreenshot(driver, testName); is called in [TestCleanup] if the test fails. Screenshots are saved under /Screenshots folder with timestamped filenames.

### Running the Tests

Prerequisites:

- .NET 6.0 or later

- MSTest.TestAdapter & MSTest.TestFramework NuGet packages

- Selenium.WebDriver

- Selenium.Support




