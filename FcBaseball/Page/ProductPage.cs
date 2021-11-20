using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FcBaseball.Page
{
    public class ProductPage : BasePage
    {
        private const string PageAddress = "https://fcbaseball.eu/p/marskineliai-vasara-2021/";
        private const string TekstasIdetas = "- įdėtas į krepšelį";
        private IWebElement MarskineliaiPirktiButton => Driver.FindElement(By.XPath("//*[@id='product-515']/div[2]/form/div/div[2]/button"));
        private SelectElement DydisDropDown => new SelectElement(Driver.FindElement(By.Id("dydis")));
        private IWebElement ProduktoPavadinimas => Driver.FindElement(By.CssSelector("#product-515>div.summary.entry-summary>h1"));
        private IWebElement ZinutesTekstas => Driver.FindElement(By.XPath("/html/body/div[1]/div/div/main/div[1]/div"));
        private IWebElement NewsletterButton => Driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/button"));
        public ProductPage(IWebDriver webdriver) : base(webdriver)
        {  }

        public ProductPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public ProductPage MarskineliaiPirkti()
        {
            MarskineliaiPirktiButton.Click();
            return this;
        }
        public ProductPage PasirinktiDydiPagalValue(string text)
        {
            DydisDropDown.SelectByValue(text);
            return this;
        }
        public ProductPage CheckText()
        {
            Assert.IsTrue(ZinutesTekstas.Text.EndsWith(TekstasIdetas), "Zinute neteisinga");
            Assert.IsTrue(ZinutesTekstas.Text.Contains(ProduktoPavadinimas.Text), "Zinute neteisinga");
            return this;
        }
        
        public ProductPage CheckAlert()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.That(alert.Text, Is.EqualTo("Pasirinkite produkto savybes prieš pridėdami šį produktą į savo krepšelį."));
            alert.Accept();
            return this;
        }

        public ProductPage FocusOnFrame()
        {
            Driver.SwitchTo().Frame(0);
            return this;
        }
        public ProductPage SwitchBack()
        {
            Driver.SwitchTo().DefaultContent();
            return this;
        }
        public ProductPage NewsLetterClose()
        {
            NewsletterButton.Click();
            return this;
        }
    }
}
