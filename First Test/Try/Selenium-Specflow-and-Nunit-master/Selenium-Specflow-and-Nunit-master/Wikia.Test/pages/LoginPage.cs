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
    public class LoginPage:BasePage
    {
        public static string URL = "/Special:UserLogin";
        public override string DefaultTitle { get { return "Log in - QM HomeWork Wikia"; } }

        [FindsBy(How = How.Name, Using = "username")]
        public IWebElement LoginBox;
        
        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement PasswordBox;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        public IWebElement LoginButton;

        public IndexPage DoLogin(string p0, string p1)
        {
            
            LoginBox.SendKeys(p0);
            PasswordBox.SendKeys(p1);
            LoginButton.Click();
            return GetInstance<IndexPage>(Driver);

        }
    }
}
