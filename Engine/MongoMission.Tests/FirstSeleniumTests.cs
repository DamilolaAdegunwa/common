using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MongoMission.Tests
{
    public class FirstSeleniumTests
    {
        private IWebDriver _driver;
        public FirstSeleniumTests()
        {
            _driver = new ChromeDriver();
        }

        [Fact]
        public void CorrectTitleDisplay_When_NavigatedToHomePage()
        {

        }
    }
}
