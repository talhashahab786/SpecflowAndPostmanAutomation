using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using OpenQA.Selenium;
using Wikia.Test.Pages;

namespace Wikia.Test
{
public abstract partial class BasePage
{
    public static string BaseUrl {
        get
        {
            return ConfigurationManager.AppSettings["seleniumBaseUrl"];
        }
    }

    public static IndexPage LoadIndexPage(IWebDriver driver, string baseURL)
    {
        if (driver == null)
            driver = Browser.Current;
        driver.Navigate().GoToUrl(baseURL.TrimEnd(new char[] { '/' }) + IndexPage.URL);
        return GetInstance<IndexPage>(driver, baseURL, "");
    }
    public static LoginPage LoadLoginPage(IWebDriver driver,string baseURL)
    {
        if (driver == null)
            driver = Browser.Current;
        driver.Navigate().GoToUrl(baseURL.TrimEnd(new char[] { '/' }) + LoginPage.URL);
        return GetInstance<LoginPage>(driver, baseURL, "");
    }
}
}
