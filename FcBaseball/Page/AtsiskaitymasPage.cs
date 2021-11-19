using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FcBaseball.Page
{
    public class AtsiskaitymasPage : BasePage
    {
        private const string PageAddress = "https://fcbaseball.eu/checkout/";
        private const string KlaidosPranesimas = "yra būtinas laukelis";
        private IWebElement VardoLaukelis => Driver.FindElement(By.Id("billing_first_name"));
        private IWebElement PavardesLaukelis => Driver.FindElement(By.Id("billing_last_name"));
        private IWebElement TelefonoLaukelis => Driver.FindElement(By.Id("billing_phone"));
        private IWebElement ElPastoLaukelis => Driver.FindElement(By.Id("billing_email"));
        private IWebElement KlaidosLaukas => Driver.FindElement(By.CssSelector(".woocommerce-error"));
        

        public AtsiskaitymasPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }

        public AtsiskaitymasPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public AtsiskaitymasPage ZinutesTekstoTikrinimas()
        {
            if (VardoLaukelis.Text == "" || PavardesLaukelis.Text == "" || TelefonoLaukelis.Text == "" || ElPastoLaukelis.Text == "")
            {
                Assert.IsTrue(KlaidosLaukas.Text.Contains(KlaidosPranesimas), "Klaidos pranesimas neatsirado");
            }
            return this;
        }


    }
}
