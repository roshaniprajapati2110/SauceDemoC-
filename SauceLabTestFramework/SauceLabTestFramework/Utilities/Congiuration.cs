using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceLabTestFramework.Utilities
{
    internal class Congiuration
    {
        private static TestContext TestContext;
        public static void testContext(TestContext testContext)
        {
            TestContext = testContext;
        }

        public static string BaseUrl => TestContext.Properties["BaseUrl"]?.ToString();

        public static string UserName => TestContext.Properties["username"]?.ToString();

        public static string Password => TestContext.Properties["password"]?.ToString();
    }
}
