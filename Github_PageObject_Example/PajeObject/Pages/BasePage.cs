using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github_PageObject_Example.PajeObject.Pages
{
    public abstract class BasePage
    {
        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement SearchBoxElement { get; }

        protected IWebDriver Driver { get; }

        public String SearchBox
        {
            get { return SearchBoxElement.Text; }
            set
            {
                if (value != null)
                    SearchBoxElement.SendKeys(value);
            }
        }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public SearchPage Search(String searchTerms)
        {
            SearchBox = searchTerms;
            SearchBoxElement.Submit();
            return new SearchPage(Driver);
        }

    }
}
