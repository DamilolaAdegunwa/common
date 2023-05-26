using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace MongoMission.Tests
{
    public class FirstSeleniumTests: IDisposable
    {
        private IWebDriver _chromeDriver;
        private IWebDriver _firefoxDriver;
        public FirstSeleniumTests()
        {
            //chrome
            _chromeDriver = new ChromeDriver();
            _chromeDriver.Manage().Window.Maximize();

            //firefox
            _firefoxDriver = new FirefoxDriver();
            _firefoxDriver.Manage().Window.Maximize();
        }

        [Fact]
        public void CorrectTitleDisplay_When_NavigatedToHomePage_OnChrome()
        {
            _chromeDriver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app/");
            Assert.Equal("Sample page - lambdatest.com", _chromeDriver.Title);

            //using (var driver = new ChromeDriver())
            //{
            //    driver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app/");
            //    Assert.Equal("Sample page - lambdatest.com", driver.Title);
            //}
        }

        [Fact]
        public void CorrectTitleDisplay_When_NavigatedToHomePage_OnFirefox()
        {
            _firefoxDriver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app/");
            Assert.Equal("Sample page - lambdatest.com", _firefoxDriver.Title);

            //using (var firefoxDriver = new FirefoxDriver())
            //{
            //    firefoxDriver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app/");
            //    Assert.Equal("Sample page - lambdatest.com", firefoxDriver.Title);
            //}
        }

        public void Dispose()
        {
            //_chromeDriver.Quit();
            //_firefoxDriver.Quit();
            //throw new NotImplementedException();
        }
    }
}
