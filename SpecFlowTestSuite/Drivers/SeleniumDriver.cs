using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowTestSuite.Drivers
{
    public class SeleniumDriver
    {
        private IWebDriver _webDriver;
        private readonly ScenarioContext _context;
        public SeleniumDriver(ScenarioContext context)=>_context= context;
        public IWebDriver SetUp()
        {

            var chromeOptions = new ChromeOptions();
            _webDriver = new RemoteWebDriver(new Uri("http://localhost:9515"), chromeOptions.ToCapabilities());

            _context.Set(_webDriver, "WebDriver");
            _webDriver.Manage().Window.Maximize();
            return _webDriver;
        }
    }
}
