using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace Wikia.Test.Pages
{
    public class VideosPage:BasePage
    {
        
           
        public static string URL = "/Special:Videos";
        public override string DefaultTitle { get { return "Videos on this wiki - QM HomeWork Wikia"; } }
        
        [FindsBy(How = How.PartialLinkText, Using = "File:")]
        public IWebElement SuccessMessage;

        [FindsBy(How = How.Id,Using = "youtubeVideoPlayer")]
        public IWebElement YouTubeVideoPlayer;

        [FindsBy(How = How.XPath, Using = "//*[@id='WikiaPageHeader']/div/div[1]/h1")]
        public IWebElement HeaderContainingVideoName;
      
        internal void IsTextPresent(string p0)
        {
            Assert.IsTrue(IsTextOnPage(p0));
        }
       
        internal void IsSuccessMessagePresent(string p0)
        {
            Assert.IsTrue(IsTextOnPage(p0));
        }

        internal void IsTitleNameSameAsFileName()
        {
            throw new NotImplementedException();
        }


         internal void ClickOnSuccessMessageAndCheckVideo(string p0)
         {
             SuccessMessage.Click();
             AssertElementPresent(YouTubeVideoPlayer,"Video player");
             AssertElementText(HeaderContainingVideoName, p0, "Header with video");
         }
    }
}
