using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github_PageObject_Example.PajeObject.Pages.SearchPages
{
    public class CommitSearchPage : SearchPage
    {
        private const string SEARCH_RESULT_ID = "commit_search_results";

        public CommitSearchPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.Id, Using = SEARCH_RESULT_ID)]
        private IWebElement _searchResult;

        protected override By ElementIsloadedPage => By.Id(SEARCH_RESULT_ID);

        public String GetCommitTitle()
        {
            return _searchResult.FindElement(By.ClassName("f5")).Text;
        }

        public String GetCommitDetail()
        {
            return _searchResult.FindElement(By.ClassName("f6")).Text;
        }
    }
}
