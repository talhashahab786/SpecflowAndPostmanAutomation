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
    public class IndexPage: BasePage
    {
        public static string URL = "/";
        public override string DefaultTitle { get { return "QM HomeWork Wikia"; } }
        
        [FindsBy(How = How.ClassName, Using = "sign-in-label")]
        public IWebElement SignInLink;

        [FindsBy(How = How.Id, Using = "usernameInput")]
        public IWebElement UserNameField;

        [FindsBy(How = How.Id, Using = "passwordInput")]
        public IWebElement PasswordField;

        [FindsBy(How = How.XPath, Using = "//*[@id='UserLoginDropdown']/form/fieldset/div[*]/input")]
        public IWebElement LogInButton;

        [FindsBy(How = How.ClassName, Using = "links-container")]
        public IWebElement Avatar;

        //[FindsBy(How = How.LinkText, Using = "Contribute")]
        //public IWebElement ContributeButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='WikiHeader']/div[1]/nav")]
        public IWebElement ContributeButton;
        

        [FindsBy(How = How.LinkText, Using = "Add a Video")]
        public IWebElement VideoSelectionInContribute;

        

        
        //[FindsBy(How = How.LinkText, Using = "Log off")]
        //public IWebElement LogoutButton;

       
       

        internal void IsSignInLinkVisible()
        {
            if (!SignInLink.Displayed)
                throw new Exception("Sign In link is not visible");
            AssertElementText(SignInLink, "Sign in", "Sign in link");
        }

       


        //internal void IsLogoutButtonAvailable()
        //{
        //    if (LogoutButton == null)
        //        throw new Exception("Unable to find the logout button on the page");
        //}


        public void HoverOverSignInLink()
        {

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("sign-in-label")));
            Actions builder = new Actions(Driver);
            builder.MoveToElement(element).Perform();

            
        }
        public void EnterUserName(string username)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("usernameInput")));
            UserNameField.SendKeys(username);
            Actions builder = new Actions(Driver);
            builder.MoveToElement(element).Click().Build().Perform();
        }

        public void EnterPassword(string password)
        {
            PasswordField.SendKeys(password);
        }

        public IndexPage ClickLogin()
        {
            LogInButton.SendKeys(Keys.Return);
            //LogInButton.Click();
            return GetInstance<IndexPage>(Driver);
        }

        internal void ClickOnContributeButton()
        {
            WaitUpTo(10000,ContributeButtonVisible, "Waiting for contribute button to be displayed");
            ContributeButton.Click();
        }

        private bool ContributeButtonVisible()
        {
           return ContributeButton.Displayed;
        }

       
        public AddVideosPage SelectAddVideoFromContributeDropdown()
        {
           VideoSelectionInContribute.Click();
           return GetInstance<AddVideosPage>(Driver);
        }

        internal void FocusOnUserNameBox()
        {
            new Actions(Driver).MoveToElement(UserNameField).Click().Perform(); 
        }

        internal void CheckSignInLabelNotPresent()
        {
            Assert.IsTrue(Avatar.Displayed);
        }
    }
}
