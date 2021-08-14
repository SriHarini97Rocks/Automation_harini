using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SeleniumCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:44352/FrameExampple.aspx");
            driver.Manage().Window.Maximize();//maximize window
            var element = driver.FindElement(By.Id("iframe1"));
            if(element != null)
            {
                driver.SwitchTo().Frame(element);
                var nested=driver.FindElement(By.Id("iframe2"));
                driver.SwitchTo().Frame(nested);
                driver.FindElement(By.Id("text1")).SendKeys("inner");
            }


        }
    }
}
