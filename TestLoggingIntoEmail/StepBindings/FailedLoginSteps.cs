using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TestLoggingIntoEmail.WebServices;

namespace TestLoggingIntoEmail.StepBindings
{
    [Binding]
    public class FailedLoginSteps : IDisposable
    {
        private ChromeDriver driver = new ChromeDriver();

        [Given(@"I navigate to google")]
        public void GivenINavigateToGoogle()
        {
            Webpage page = new Webpage(driver);
            driver.Navigate().GoToUrl(page.googleHomepage);
        }
        
        [Given(@"I search for ""(.*)""")]
        public void GivenISearchFor(string searchText)
        {
            Webpage page = new Webpage(driver);
            page.GoogleSearch(page.googleSearchText);
            Thread.Sleep(2000);
        }
        
        [Given(@"I press the search button")]
        public void GivenIPressTheSearchButton()
        {
            Webpage page = new Webpage(driver);
            page.ClickGoogleSearchButton();
        }

        [Given(@"I select abv\.bg website")]
        public void GivenISelectAbv_BgWebsite()
        {
            Webpage page = new Webpage(driver);
            page.SelectItemFromResults();
        }

        [When(@"I enter ""(.*)"" in the username field")]
        public void WhenIEnterInTheUsernameField(string username)
        {
            Webpage page = new Webpage(driver);
            page.EnterAbvUsername(username);
        }
        
        [When(@"I enter ""(.*)"" in the password field")]
        public void WhenIEnterInThePasswordField(string password)
        {
            Webpage page = new Webpage(driver);
            page.EnterAbvPassword(password);
        }

        [When(@"I press the button Enter")]
        public void WhenIPressTheButtonEnter()
        {
            Webpage page = new Webpage(driver);
            page.ClickAbvEnterButton();
            Thread.Sleep(1000);
        }


        [Then(@"I will see an error message")]
        public void ThenIWillSeeAnErrorMessage()
        {
            Webpage page = new Webpage(driver);
            Assert.IsTrue(page.IsNotLoggedIn());
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
