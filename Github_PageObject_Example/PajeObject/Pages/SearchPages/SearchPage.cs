using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github_PageObject_Example.PajeObject.Pages.SearchPages
{
    public abstract class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver) : base(driver)
        {
            WaitForLoadingPage();
        }

        [FindsBy(How = How.ClassName, Using = "underline-nav")]
        private IWebElement _navBar;

        [FindsBy(How = How.ClassName, Using = "btn")]
        protected IWebElement SearchButton { get; }

        public UserSearchPage SelectSearchByUser()
        {
            SelectSearcType(SearchType.Users);
            return new UserSearchPage(Driver);
        }

        public CommitSearchPage SelectSearchByCommit()
        {
            SelectSearcType(SearchType.Commits);
            return new CommitSearchPage(Driver);
        }

        public RepositorySearchPage SelectSearchByRepository()
        {
            SelectSearcType(SearchType.Repositories);
            return new RepositorySearchPage(Driver);
        }

        private void SelectSearcType(SearchType searchType)
        {
            _navBar.FindElement(By.PartialLinkText(searchType.ToString())).Click();
        }
    }
}
