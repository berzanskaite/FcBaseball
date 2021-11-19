using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FcBaseball.Page
{
    public class KrepselisPage : BasePage
    {
        private const string PageAddress = "https://fcbaseball.eu/cart/";
        
        private IWebElement Suma => Driver.FindElement(By.XPath("//*[@id='post-7']/div/div/div[2]/div/table/tbody/tr[2]/td/strong/span/bdi"));
           
        public KrepselisPage(IWebDriver webdriver) : base(webdriver)
        {
            
        }

        public KrepselisPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public KrepselisPage Lyginimas(string suma)
        {
            Assert.IsTrue(Suma.Text.Contains(suma), $"Result is wrong, not {suma}");
            return this;
        }
       

    }
}
