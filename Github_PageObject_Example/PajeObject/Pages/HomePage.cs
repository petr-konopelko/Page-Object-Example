using Github_PageObject_Example.PajeObject.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github_PageObject_Example.PajeObject
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        public HomePage Open()
        {
           Navigate("https://github.com/");
           return this;
        }

        
    }
}
