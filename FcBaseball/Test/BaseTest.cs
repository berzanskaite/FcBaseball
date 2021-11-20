using FcBaseball.Drivers;
using FcBaseball.Page;
using FcBaseball.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FcBaseball.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static HomePage _homePage;
        public static KrepselisPage _krepselisPage;
        public static ProductPage _productPage;
        public static AtsiskaitymasPage _atsiskaitymasPage;
        

        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            _homePage = new HomePage(driver);
            _krepselisPage = new KrepselisPage(driver);
            _productPage = new ProductPage(driver);
            _atsiskaitymasPage = new AtsiskaitymasPage(driver);
        }

        [TearDown]

        public static void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreenshot(driver);
        }

        [OneTimeTearDown]

        public static void TearDown()
        {
            
            //driver.Quit();
        }
    }
}
