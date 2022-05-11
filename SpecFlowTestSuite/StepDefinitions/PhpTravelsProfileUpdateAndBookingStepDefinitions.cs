using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowTestSuite.Drivers;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowTestSuite.StepDefinitions
{
    [Binding]
    public class PhpTravelsProfileUpdateAndBookingStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext _context;
        public PhpTravelsProfileUpdateAndBookingStepDefinitions(ScenarioContext context)
        {
            _context = context;
        }
        [Given(@"Login to the Dashboard")]

        public void GivenLoginToTheDashboard()
        {
            driver = _context.Get<SeleniumDriver>("driver").SetUp();
            driver.Url = "https://www.phptravels.net/login";
           // driver.Manage().Window.Maximize();
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
        [Given(@"Click on the Filghts section")]
        public void GivenClickOnTheFilghtsSection()
        {
            driver.FindElement(By.XPath("//*[@id=\"fadein\"]/header/div[2]/div/div/div/div/div[2]/nav/ul/li[3]/a")).Click();
        }

        [Given(@"Choose origin as MAA-Chennai")]
        public void GivenChooseOriginAsMAA_Chennai()
        {
            driver.FindElement(By.XPath("//*[@id=\"autocomplete\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"autocomplete\"]")).SendKeys("MAA");
            if(driver.FindElement(By.XPath("//*[@id=\"onereturn\"]/div[1]/div/div[1]/div/div/div/div/div[1]/div[1]/b")).Text=="MAA")
            {
                driver.FindElement(By.XPath("//*[@id=\"onereturn\"]/div[1]/div/div[1]/div/div/div/div/div[1]/div[1]")).Click();
            }
        }

        [Given(@"Choose destination as BOM-Bombay")]
        public void GivenChooseDestinationAsBOM_Bombay()
        {
            driver.FindElement(By.XPath("//*[@id=\"autocomplete2\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"autocomplete2\"]")).SendKeys("BOM");
            if (driver.FindElement(By.XPath("//*[@id=\"onereturn\"]/div[1]/div/div[2]/div/div[2]/div/div/div[1]/div[1]/b")).Text == "BOM")
            {
                driver.FindElement(By.XPath("//*[@id=\"onereturn\"]/div[1]/div/div[2]/div/div[2]/div/div/div[1]/div[1]")).Click();
            }
        }

        [Given(@"Choose Date (.*)")]
        public void GivenChooseDate(string date)
        {


            driver.FindElement(By.XPath("//*[@id=\"departure\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"departure\"]")).Clear();

            driver.FindElement(By.XPath("//*[@id=\"departure\"]")).SendKeys(date);
        }

        [Given(@"Choose Adults as (.*)")]
        public void GivenChooseAdultsAs(int p0)
        {
            IWebElement ele= driver.FindElement(By.XPath("//*[@id=\"onereturn\"]/div[3]/div/div/div/a/span/span"));
            IJavaScriptExecutor ex = (IJavaScriptExecutor)driver;
            ex.ExecuteScript("arguments[0].click();", ele);

            Thread.Sleep(3000);
            for (int i=1;i<p0;i++)
            driver.FindElement(By.XPath("//*[@id=\"onereturn\"]/div[3]/div/div/div/div/div[1]/div/div/div[2]/i")).Click();
        }

        [When(@"The search button is clicked")]
        public void WhenTheSearchButtonIsClicked()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"onereturn\"]/div[4]/div")));
            element.Click();
        }

        [Then(@"Flight page should appear")]
        public void ThenFlightPageShouldAppear()
        {
            driver.Title.Should().Be("Flights - PHPTRAVELS");
        }

        [When(@"Nonstop flight checkbox is clicked")]
        public void WhenNonstopFlightCheckboxIsClicked()
        {
            driver.FindElement(By.XPath("//*[@id=\"direct\"]")).Click();
        }

        [Then(@"Total flight count should be (.*)")]
        public void ThenTotalFlightCountShouldBe(int p0)
        {
            int c = 0;
            List<IWebElement> elements= driver.FindElements(By.XPath("//*[@id=\"data\"]/ul/li")).ToList();
            if(elements?.Count>0)
            {
              
                foreach(var item in elements)
                {
                    if (item.GetAttribute("class").Contains("oneway_0"))
                        c += 1;
                }
            }
            c.Should().Be(p0);
        }
    }
}
