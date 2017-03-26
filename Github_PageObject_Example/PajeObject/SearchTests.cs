using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github_PageObject_Example.PajeObject
{
    [TestFixture]
    [Parallelizable]
    public class SearchTests
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void CreateWebdriver()
        {
            _driver = new ChromeDriver(TestContext.CurrentContext.TestDirectory);
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void CheckByUserName()
        {
            HomePage homePage = new HomePage(_driver);

            String userName = homePage.Open().
                Search("Petr Konopelko").
                SelectSearchByUser().
                GetUserName();
            Assert.AreEqual("petr-konopelko", userName, "user name isn't equal to expected");
        }

        [Test]
        public void CheckByCommitName()
        {
            HomePage homePage = new HomePage(_driver);

            var commitSearchPage = homePage.Open().
                Search("add js for draw suite summary").
                SelectSearchByCommit();

            String commitTitle = commitSearchPage.GetCommitTitle();
            String commitDetails = commitSearchPage.GetCommitDetail();

            StringAssert.Contains("add js for draw suite summary", commitTitle, "Commit title doesn't contain expected commit name");
            StringAssert.Contains("petr-konopelko", commitDetails, "Commit details doesn't contain username");    
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            _driver.Close();
        }
    }
}
