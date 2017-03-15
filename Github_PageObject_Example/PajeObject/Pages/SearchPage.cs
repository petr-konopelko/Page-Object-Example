using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github_PageObject_Example.PajeObject.Pages
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.ClassName, Using = "menu")]
        private IWebElement _navBar;


        public SearchPage SelectSearcType(SearchType searchType)
        {
            _navBar.FindElement(By.PartialLinkText(searchType.ToString()));
            return new SearchPage(Driver);
        }
    }
}
