using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace TestProject1
{
    public enum MonthMapping
    {
        January = 1, February = 2, March = 3, April = 4, May = 5, June = 6, July = 7, August = 8, September = 9, October = 10, November = 11, December = 12
    }

    [TestFixture]
    public class Tests
    {
        private IWebDriver driver = null;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("no-sandbox");
             driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));

        }
        [Test]
        public void CheckTitle(){
            driver.Url="https://localhost:7054";
            driver.Manage().Window.Maximize();
            var s=driver.FindElement(By.XPath("//*[@id=\"navbarSupportedContent\"]/ul/li[2]/a")).Text;
Assert.AreEqual(s,"Contact us1");
        }

        
    }
}