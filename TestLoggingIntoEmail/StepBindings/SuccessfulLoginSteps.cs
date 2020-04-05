using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TestLoggingIntoEmail.WebServices;

namespace TestLoggingIntoEmail.StepBindings
{
    [Binding]
    public class SuccessfulLoginSteps : IDisposable
    {
        private ChromeDriver driver = new ChromeDriver();

        [Given(@"I navigate to google homepage")]
        public void GivenINavigateToGoogleHomepage()
        {
            Webpage page = new Webpage(driver);
            driver.Navigate().GoToUrl(page.googleHomepage);
        }
        
        [Given(@"I search for ""(.*)"" in the search field")]
        public void GivenISearchForInTheSearchField(string searchText)
        {
            Webpage page = new Webpage(driver);
            page.GoogleSearch(page.googleSearchText);
            Thread.Sleep(2000);
        }
        
        [Given(@"I press the Google search button")]
        public void GivenIPressTheGoogleSearchButton()
        {
            Webpage page = new Webpage(driver);
            page.ClickGoogleSearchButton();
        }

        [Given(@"I select abv site")]
        public void GivenISelectAbvSite()
        {
            Webpage page = new Webpage(driver);
            page.SelectItemFromResults();
        }


        [When(@"I enter ""(.*)"" as username")]
        public void WhenIEnterAsUsername(string username)
        {
            Webpage page = new Webpage(driver);
            page.EnterAbvUsername(username);
        }
        
        [When(@"I enter ""(.*)"" as password")]
        public void WhenIEnterAsPassword(string password)
        {
            Webpage page = new Webpage(driver);
            page.EnterAbvPassword(password);
        }

        [When(@"I press the Enter button")]
        public void WhenIPressTheEnterButton()
        {
            Webpage page = new Webpage(driver);
            page.ClickAbvEnterButton();
            Thread.Sleep(2000);
        }

        [Then(@"I will see a Write button")]
        public void ThenIWillSeeAWriteButton()
        {
            Webpage page = new Webpage(driver);
            Assert.IsTrue(page.IsLoggedIntoEmail());
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
