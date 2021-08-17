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
            driver = new ChromeDriver();

        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://www.guru99.com/selenium-csharp-tutorial.html");
            string s = driver.Title;
            Assert.AreEqual(false, s.Contains("Selenium"));driver.Close();
        }
       

    }
}