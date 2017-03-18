using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Github_PageObject_Example.PajeObject.Pages.SearchPages
{
    public class RepositorySearchPage : SearchPage
    {
        public RepositorySearchPage(IWebDriver driver) : base(driver) {  }

        protected override By ElementIsloadedPage => By.ClassName("codesearch-results");
    }
}
