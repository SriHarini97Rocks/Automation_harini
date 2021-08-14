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

    public class Tests
    {
        private IWebDriver driver = null;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

        }

        [Test]
        public void TExtboxandCheckbox()
        {
            driver.Navigate().GoToUrl("https://localhost:44352/WebForm1.aspx");
            Thread.Sleep(20000);
            var element = driver.FindElement(By.XPath("html/body/form/div[2]/input[1]"));
            if (element != null)
            {
                element.SendKeys("Harini");
                driver.FindElement(By.XPath("/html/body/form/div[2]/input[6]")).Click();

                String label = driver.FindElement(By.XPath("/html/body/form/div[2]/span")).Text;
                Assert.AreEqual(label, "you entered Hariniyou didn't check checbox");
            }
        }
        [Test]

        public void Calendar()
        {
            int diff = 0;
            string expectedDate = "23 August 2022";
            driver.Navigate().GoToUrl("https://localhost:44352/WebForm1.aspx");
            var currentDate = driver.FindElement(By.XPath("/html/body/form/div[2]/table/tbody/tr[1]/td/table/tbody/tr/td[2]")).Text;//september 2022

            var current = "01 " + currentDate;

            var currentDateTime = DateTime.Parse(current);
            var targetDateTime = DateTime.Parse(expectedDate);
            diff = (currentDateTime.Year * 12 + currentDateTime.Month) - (targetDateTime.Year * 12 + targetDateTime.Month);
            if(diff>0)
            {
                ///html/body/form/div[2]/table/tbody/tr[1]/td/table/tbody/tr/td[1]/a
                for (int i = 0; i <Math.Abs( diff); i++)
                    driver.FindElement(By.XPath("/html/body/form/div[2]/table/tbody/tr[1]/td/table/tbody/tr/td[1]/a")).Click();
            }
            else
            {
                for (int i = 0; i <Math.Abs( diff); i++)
                    driver.FindElement(By.XPath("/html/body/form/div[2]/table/tbody/tr[1]/td/table/tbody/tr/td[3]/a")).Click();
            }

            List<IWebElement> dateElements =new List<IWebElement>( driver.FindElements(By.XPath("/html/body/form/div[2]/table/tbody/tr/td")));
            if (dateElements != null)
            {
                foreach(var element in dateElements)
                {
                    string data = element.Text;
                    if(data==expectedDate.Split(' ')[0])
                    {
                        element.Click();break;
                    }
                }
            }
            Thread.Sleep(1000);
            ///html/body/form/div[2]/input[3]
            var test = driver.FindElement(By.XPath("/html/body/form/div[2]/input[3]")).GetAttribute("value");
            Assert.AreEqual(expectedDate, test);            
        }

        [Test]

        public void Radio()
        {

        }
        

    }
}