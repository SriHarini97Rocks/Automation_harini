using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlowTestSuite.Drivers;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowTestSuite.StepDefinitions
{
    [Binding]
    public class PhpTravelsProfileUpdateStepDefinitions
    { IWebDriver driver;
    private readonly ScenarioContext _context;
        public PhpTravelsProfileUpdateStepDefinitions(ScenarioContext context)
        {
            _context = context;
        }
        [Given(@"Login to the Dashboard")]

        public void GivenLoginToTheDashboard()
        {
            driver = _context.Get<SeleniumDriver>("driver").SetUp();
            driver.Url = "https://www.phptravels.net/login";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("//*[@id=\"fadein\"]/div[1]/div/div[2]/div[2]/div/form/div[1]/div/input")).SendKeys("user@phptravels.com");
            driver.FindElement(By.XPath("//*[@id=\"fadein\"]/div[1]/div/div[2]/div[2]/div/form/div[2]/div[1]/input")).SendKeys("demouser");
            driver.FindElement(By.XPath("//*[@id=\"fadein\"]/div[1]/div/div[2]/div[2]/div/form/div[3]/button")).Click();
            driver.Title.Should().Be("Dashboard - PHPTRAVELS");
        }

        [Given(@"Click the My Profile section")]
        public void GivenClickTheMyProfileSection()
        {
            driver.FindElement(By.XPath("//*[@id=\"fadein\"]/div[1]/div/div[3]/ul/li[4]/a")).Click();
        }

        [Then(@"Profile Page will appear")]
        public void ThenProfilePageWillAppear()
        {
            driver.Title.Should().Be("Profile - PHPTRAVELS");
        }

        [Given(@"New mobile number is entered")]
        public void GivenNewMobileNumberIsEntered()
        {
            driver.FindElement(By.XPath("//*[@id=\"fadein\"]/section[1]/div/div[2]/div/div[1]/div/div/div[2]/form/div[1]/table/tbody/tr[3]/td[3]/div/input")).Clear();
            driver.FindElement(By.XPath("//*[@id=\"fadein\"]/section[1]/div/div[2]/div/div[1]/div/div/div[2]/form/div[1]/table/tbody/tr[3]/td[3]/div/input")).SendKeys("12345678");
            driver.FindElement(By.XPath("//*[@id=\"cookie_stop\"]")).Click();
        }

        [When(@"Update Profile button is clicked")]
        public void WhenUpdateProfileButtonIsClicked()
        {
            Thread.Sleep(3000);
            IWebElement element = driver.FindElement(By.XPath("//*[@id=\"fadein\"]/section[1]/div/div[2]/div/div[1]/div/div/div[2]/form/div[3]/button"));
            IJavaScriptExecutor ex = (IJavaScriptExecutor)driver;
            ex.ExecuteScript("arguments[0].click();", element);

        }

        [When(@"Page is reloaded")]
        public void WhenPageIsReloaded()
        {
            Thread.Sleep(3000);
            driver.Navigate().GoToUrl(driver.Url);
        }

        [Then(@"New mobile number should appear")]
        public void ThenNewMobileNumberShouldAppear()
        {
            string val = driver.FindElement(By.XPath("//*[@id=\"fadein\"]/section[1]/div/div[2]/div/div[1]/div/div/div[2]/form/div[1]/table/tbody/tr[3]/td[3]/div/input")).GetAttribute("value");
           val.Should().Be("12345678");
        }
    }
}
