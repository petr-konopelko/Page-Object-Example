using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Github_PageObject_Example.PajeObject.Pages.SearchPages
{
    public class UserSearchPage : SearchPage
    {
        private const string SEARCH_RESULT_ID = "user_search_results";

        public UserSearchPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.Id, Using = SEARCH_RESULT_ID)]
        private IWebElement _searchList;

        protected override By ElementIsloadedPage => By.Id(SEARCH_RESULT_ID);

        public string GetUserName()
        {
            return _searchList.FindElement(By.CssSelector(".user-list-info a")).Text;
        }
    }
}
