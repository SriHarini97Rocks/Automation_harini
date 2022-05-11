using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    class HomePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "account")]
        public IWebElement MyAccount { get; set; }
    }
}
