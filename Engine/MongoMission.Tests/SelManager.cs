using OpenQA.Selenium.Chrome;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace MongoMission.Tests
{  
    public class SelManager
    {
        [Fact]
        public void CorrectTitleDisplay_When_NavigatedToHomePage_OnChrome()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app/");
                Assert.Equal("Sample page - lambdatest.com", driver.Title);
            }
            int x = 0;
            x.ShouldBeEquivalentTo(0);
            Should.NotThrow(() => 5);
        }
    }
}

