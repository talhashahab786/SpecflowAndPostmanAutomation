using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Wikia.Test.Pages
{
    public class AddVideosPage:BasePage
    {
        public override string DefaultTitle { get { return "WikiaVideoAdd - QM HomeWork Wikia"; } }
        public static string URL = "/Special:WikiaVideoAdd";
        
        [FindsBy(How = How.Id, Using = "wpWikiaVideoAddUrl")]
        public IWebElement VideoURLBox;

        [FindsBy(How = How.XPath, Using = "//*[@id='mw-content-text']/form/div/input")]
        public IWebElement AddButton;
        internal void TypeVideoURL(string p0)
        {
            VideoURLBox.SendKeys(p0);
        }

        public VideosPage ClickOnAddButton()
        {
            AddButton.Click();
            return GetInstance<VideosPage>(Driver);
        }
    }
}
