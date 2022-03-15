using OpenQA.Selenium;
using SpecFlowTestSuite.Drivers;

namespace SpecFlowTestSuite.StepDefinitions
{
    [Binding]
    public sealed class PhpTravelsAuthenticationStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        IWebDriver driver;
        private readonly ScenarioContext _context;
       public PhpTravelsAuthenticationStepDefinitions(ScenarioContext context)
        {
            _context= context;
        }
        [Given(@"Navigate to the site of the PhpTravels login page")]
        public void GivenNavigateToTheSiteOfThePhpTravelsLoginPage()
        {
            driver = _context.Get<SeleniumDriver>("driver").SetUp();
            driver.Url = "https://www.phptravels.net/login";
        
        }
        [Given(@"Enter the username as user@phptravels.com")]
        public void GivenEnterTheUsername()
        {
            driver.FindElement(By.XPath("//*[@id=\"fadein\"]/div[1]/div/div[2]/div[2]/div/form/div[1]/div/input")).SendKeys("user@phptravels.com");
        }
        [Given(@"Enter the password as demouser")]
        public void GivenEnterThePassword()
        {
            driver.FindElement(By.XPath("//*[@id=\"fadein\"]/div[1]/div/div[2]/div[2]/div/form/div[2]/div[1]/input")).SendKeys("demouser");
        }
        [When(@"the login button is clicked after entering username and password")]
        public void GivenTheLoginButtonIsClickedAfterEnteringUsernameAndPassword()
        {
            driver.FindElement(By.XPath("//*[@id=\"fadein\"]/div[1]/div/div[2]/div[2]/div/form/div[3]/button")).Click();
        }
        [Then(@"the page should be redirected to dashboard page")]
        public void GivenThePageShouldBeRedirectedToDashboardPage()
        {
            driver.Title.Should().Be("Dashboard - PHPTRAVELS");
        }
    }
}