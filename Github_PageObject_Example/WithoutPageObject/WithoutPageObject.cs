using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github_PageObject_Example
{
    [TestFixture]
    [Parallelizable]
    public class WithoutPageObject
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
            _driver.Navigate().GoToUrl("https://github.com/");
            _driver.FindElement(By.Name("q")).SendKeys("Petr Konopelko");
            _driver.FindElement(By.Name("q")).Submit();
            _driver.FindElement(By.PartialLinkText("User")).Click();
            WebDriverWait waitLoading = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement searchresult = waitLoading.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.Id("user_search_results")));
            Assert.AreEqual("petr-konopelko", searchresult.FindElement(By.TagName("em")).Text);
        }

        [Test]
        public void CheckByCommitName()
        {
            _driver.Navigate().GoToUrl("https://github.com/");
            _driver.FindElement(By.Name("q")).SendKeys("add js for draw suite summary");
            _driver.FindElement(By.Name("q")).Submit();
            _driver.FindElement(By.PartialLinkText("Commits")).Click();
            WebDriverWait waitLoading = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement searchresult = waitLoading.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.Id("commit_search_results")));
            StringAssert.Contains("add js for draw suite summary", searchresult.FindElement(By.CssSelector(".f5")).Text);
            StringAssert.Contains("petr-konopelko", searchresult.FindElement(By.CssSelector(".f6")).Text);
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            _driver.Close();
        }

    }
}
