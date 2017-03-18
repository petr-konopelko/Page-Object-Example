using Github_PageObject_Example.PajeObject.Pages.SearchPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
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
        protected IWebElement SearchBoxElement;

        protected IWebDriver Driver { get; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public String SearchBox
        {
            get { return SearchBoxElement.Text; }
            set
            {
                if (value != null)
                    SearchBoxElement.SendKeys(value);
            }
        }

        public void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public RepositorySearchPage Search(String searchTerms)
        {
            SearchBox = searchTerms;
            SearchBoxElement.Submit();
            return new RepositorySearchPage(Driver);
        }

        protected abstract By ElementIsloadedPage { get; }

        protected void WaitForLoadingPage()
        {
            WebDriverWait waitLoading = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement element = waitLoading.Until<IWebElement>(ExpectedConditions.ElementIsVisible(ElementIsloadedPage));
        }
    }
}
