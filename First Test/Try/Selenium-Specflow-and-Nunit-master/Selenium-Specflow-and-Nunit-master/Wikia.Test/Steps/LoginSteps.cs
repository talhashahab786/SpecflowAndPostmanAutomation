using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Wikia.Test.Pages;

namespace Wikia.Test
{
    [Binding]
    public class LoginSteps:BaseSteps
    {
        [Given(@"I am on the QM Homework wikia")]
        public void GivenIAmOnTheQMHomeworkWikia()
        {
            CurrentPage = (BasePage)BasePage.LoadIndexPage(CurrentDriver, BasePage.BaseUrl);
        }

        [Given(@"I am not logged in")]
        public void GivenIAmNotLoggedIn()
        {
            CurrentPage.As<IndexPage>().IsSignInLinkVisible();
        }

        [When(@"I hover over over the Sign In button")]
        public void WhenIHoverOverOverTheSignInButton()
        {
            CurrentPage.As<IndexPage>().HoverOverSignInLink();
        }

        [When(@"I enter ""(.*)"" into the username column")]
        public void WhenIEnterIntoTheUsernameColumn(string p0)
        {
            CurrentPage.As<IndexPage>().EnterUserName(p0);
        }

        [When(@"I enter ""(.*)"" into the password column")]
        public void WhenIEnterIntoThePasswordColumn(string p0)
        {
            CurrentPage.As<IndexPage>().EnterPassword(p0);
        }

        [When(@"I click the Log In button")]
        public void WhenIClickTheLogInButton()
        {
            CurrentPage.As<IndexPage>().ClickLogin();
        }


        [Then(@"I should be logged in to the system")]
        public void ThenIShouldBeLoggedInToTheSystem()
        {
            
        }

        [Then(@"I should not see Sign In")]
        public void ThenIShouldNotSeeSignIn()
        {
            CurrentPage.As<IndexPage>().CheckSignInLabelNotPresent();
        }
 
       



    }
}
