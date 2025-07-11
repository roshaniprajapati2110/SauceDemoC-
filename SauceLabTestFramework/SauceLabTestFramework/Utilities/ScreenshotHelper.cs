using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceLabTestFramework.Utilities
{
    public class ScreenshotHelper
    {
        public static void TakeScreenshot(IWebDriver driver, string filePath)
        {
            try
            {
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string dir = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
                Directory.CreateDirectory(dir);
                string fileName = $"{DateTime.Now:yyyyMMdd_HHmmss}.png";
                screenshot.SaveAsFile(Path.Combine(dir, fileName));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error taking screenshot: {ex.Message}");
            }
        }
        
        
    }
}
