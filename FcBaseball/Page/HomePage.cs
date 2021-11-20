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
    public class HomePage : BasePage
    {
        private const string PageAddress = "https://fcbaseball.eu/";
        
        private IWebElement IKrepseliLuna => Driver.FindElement(By.XPath("//*[@id='post-328']/div/div/div/div/div/div/div/div/div/div/ul/li[5]/div[2]/a"));
        private IWebElement IKrepseliMaisas => Driver.FindElement(By.XPath("//*[@id='post-328']/div/div/div/div/div/div/div/div/div/div/ul/li[4]/div[2]/a"));
        private IWebElement IKrepseliVorai => Driver.FindElement(By.XPath("//*[@id='post-328']/div/div/div/div/div/div/div/div/div/div/ul/li[1]/div[2]/a"));
        private IWebElement NewsletterButton => Driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/button"));
        private IWebElement PerziuretiKrepseli => Driver.FindElement(By.LinkText("Peržiūrėti krepšelį"));
        private IWebElement ProductMarskineliai => Driver.FindElement(By.XPath("/html/body/div/div/div/main/article/div/div/div/div/div/div/div/div/div/div/ul/li[2]/div[2]/a"));
        private IWebElement MenuAtsiskaitymas => Driver.FindElement(By.XPath("//*[@id='menu-item-32']"));
        
        public HomePage(IWebDriver webdriver) : base(webdriver)
        {
          
        }

        public HomePage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public HomePage ButtonVoraiClick()
        {
            IKrepseliVorai.Click();
            return this;
        }
        public HomePage ButtonMaisasClick()
        {
            IKrepseliMaisas.Click();
            return this;
        }
        public HomePage ButtonLunaClick()
        {
            IKrepseliLuna.Click();
            return this;
        }

        public HomePage ButtonKrepselisClick()
        {
            PerziuretiKrepseli.Click();
            return this;
        }

        public HomePage FocusOnFrame()
        {
            Driver.SwitchTo().Frame(0);
            return this;
        }
        public HomePage SwitchBack()
        {
            Driver.SwitchTo().DefaultContent();
            return this;
        }
        public HomePage NewsLetterClose()
        {
            NewsletterButton.Click();
            return this;
        }

        public HomePage TextToWait()
        {
            WebDriverWait w = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            w.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='post-328']/div/div/div/div/div/div/div/div/div/div/ul/li[5]/div[2]/a[2]")));
            return this;
        }
        public HomePage Marskineliai()
        {
            ProductMarskineliai.Click();
            return this;
        }

        public HomePage AtsiskaitymasButtonClick()
        {
            MenuAtsiskaitymas.Click();
            return this;
        }





    }
}
