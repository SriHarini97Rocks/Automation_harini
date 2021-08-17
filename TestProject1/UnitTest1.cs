using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        public void Test1()
        {
            driver.Navigate().GoToUrl("http://localhost:82/sample.aspx");
            string s = driver.Title;
            Assert.AreEqual(true, string.IsNullOrEmpty(s));driver.Close();
        }
        [Test]
        public void Test2()
        {
            driver.Navigate().GoToUrl("http://localhost:82/sample.aspx");
             driver.FindElement(By.XPath("/html/body/form/input[9]")).Click();
            string s = driver.FindElement(By.XPath("/html/body/form/span[7]")).Text;
            Assert.AreEqual(s, "Please agree to terms and conditions1"); driver.Close();
        }

    }
}