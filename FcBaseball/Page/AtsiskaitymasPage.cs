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
    public class AtsiskaitymasPage : BasePage
    {
        private const string PageAddress = "https://fcbaseball.eu/checkout/";
        private const string KlaidosPranesimas = "yra būtinas laukelis";
        private const string EmailKlaidosPranesimas = "Netinkamas registracijos el.paštas";
        private IWebElement KlaidosLaukas => Driver.FindElement(By.XPath("//*[@id='post-8']/div/div/form/div[1]/ul/li"));
        private IWebElement ButtonApmoketi => Driver.FindElement(By.Id("place_order"));
        private IWebElement EmailLaukelis => Driver.FindElement(By.CssSelector("#billing_email"));

        public AtsiskaitymasPage(IWebDriver webdriver) : base(webdriver)
        { }

        public AtsiskaitymasPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public AtsiskaitymasPage ZinutesTekstoTikrinimas()
        {
            Assert.IsTrue(KlaidosLaukas.Text.Contains(KlaidosPranesimas), "Klaidos pranesimas neatsirado");
            return this;
        }
        
        
        public AtsiskaitymasPage ApmoketiButtonClick()
        {
            ButtonApmoketi.Click();
            return this;
        }

        public AtsiskaitymasPage WaitForButton()
        {
            WebDriverWait w = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            w.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='place_order']")));
            return this;
        }

        public AtsiskaitymasPage Wait()
        {
            Thread.Sleep(1000);
            return this;
        }
      
        public AtsiskaitymasPage IvestiEmail(string elpastas)
        {
            EmailLaukelis.SendKeys(elpastas);
            return this;
        }

        public AtsiskaitymasPage PatikrintiEmail()
        {
            Assert.IsTrue(KlaidosLaukas.Text.Contains(EmailKlaidosPranesimas), "Klaidos pranesimas neatsirado");
            return this;
        }
        
    }
}
