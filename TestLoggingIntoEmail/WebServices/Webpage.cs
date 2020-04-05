using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLoggingIntoEmail.WebServices
{
    class Webpage
    {
        public string googleHomepage = "https://www.google.com/";
        public string googleSearchText = "abv.bg";
        readonly By googleSearchArea = By.Name("q");
        readonly By googleSearchButton = By.Name("btnK");
        readonly By abvSearchResult = By.CssSelector("#rso > div:nth-child(1) > div > div > div.r > a > h3");
        readonly By abvUsernameField = By.Id("username");
        readonly By abvPasswordField = By.Id("password");
        readonly By abvEnterButton = By.Id("loginBut");
        readonly By abvWriteButton = By.CssSelector("#main > div > div:nth-child(4) > div > div:nth-child(4) > div > div:nth-child(2) > div > div:nth-child(2) > div > div:nth-child(3) > div");
        readonly By abvLoginError = By.Id("form.errors");

        private IWebDriver driver;

        public Webpage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToSite(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void GoogleSearch(string searchText)
        {
            driver.FindElement(googleSearchArea).Clear();
            driver.FindElement(googleSearchArea).SendKeys(searchText);
        }

        public void ClickGoogleSearchButton()
        {
            driver.FindElement(googleSearchButton).Click();
        }

        public void SelectItemFromResults()
        {
            driver.FindElement(abvSearchResult).Click();
        }

        public void EnterAbvUsername(string username)
        {
            driver.FindElement(abvUsernameField).Clear();
            driver.FindElement(abvUsernameField).SendKeys(username);
        }

        public void EnterAbvPassword(string password)
        {
            driver.FindElement(abvPasswordField).Clear();
            driver.FindElement(abvPasswordField).SendKeys(password);
        }

        public void ClickAbvEnterButton()
        {
            driver.FindElement(abvEnterButton).Click();
        }

        public bool IsLoggedIntoEmail()
        {
            return driver.FindElement(abvWriteButton).Displayed;
        }

        public bool IsNotLoggedIn()
        {
            return driver.FindElement(abvLoginError).Displayed;
        }
    }
}
