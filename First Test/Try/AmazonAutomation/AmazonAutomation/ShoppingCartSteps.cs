using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace AmazonTests
{

    [Binding]
    public class ShoppingCartSteps
    {
        private AmazonPage amazonPage;
        private ShoppingCartPage shoppingCartPage;
        public string searchedItem = "TP-Link N450 WiFi Router - Wireless Internet Router for Home (TL-WR940N)";

        [Given(@"I am an unregistered user on Amazon website")]
        public void GivenIAmAnUnregisteredUserOnAmazonWebsite()
        {
            amazonPage = new AmazonPage();
            amazonPage.NavigateToAmazon();
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string itemName)
        {
            amazonPage.SearchForItem(itemName);
        }

        [When(@"I add the corresponding item to the cart")]
        public void WhenIAddTheCorrespondingItemToTheCart()
        {
            amazonPage.AddItemToCart(searchedItem);
        }

        [When(@"I navigate to the cart")]
        public void WhenINavigateToTheCart()
        {
            shoppingCartPage.NavigateToCart();
        }

        [Then(@"I should see the correct item and amount displayed in the cart")]
        public void ThenIShouldSeeTheCorrectItemAndAmountDisplayedInTheCart()
        {
            List<String> cartItemName = shoppingCartPage.GetCartItemNames();
            List<String> cartItemPrice = shoppingCartPage.GetCartItemPrices();
            decimal cartItemZeroPrice = decimal.Parse(cartItemPrice[0]);

           // Assert.That(ShoppingCartSteps, cartItemName, "Incorrect item name in the cart");
            Assert.That(cartItemZeroPrice > 0, "Invalid item price in the cart");
        }
    }


       public class AmazonPage
        {
            private IWebDriver driver;

            public AmazonPage()
            {
                // Initialize the Chrome driver
                driver = new ChromeDriver();
            }

            // Method to navigate to Amazon website
            public void NavigateToAmazon()
            {
                driver.Navigate().GoToUrl("https://www.amazon.com/");
            }

            // Method to search for a product on Amazon
            public void SearchForItem(string productName)
            {
                IWebElement searchBox = driver.FindElement(By.Id("twotabsearchtextbox"));
                searchBox.SendKeys(productName);
                searchBox.SendKeys(Keys.Enter);
            }

            // Method to add a product to the cart
            public void AddItemToCart(string productTitle)
            {
                // Click on the product
                IWebElement productLink = driver.FindElement(By.PartialLinkText(productTitle));
                productLink.Click();

                // Click on the "Add to Cart" button
                IWebElement addToCartButton = driver.FindElement(By.Id("add-to-cart-button"));
                addToCartButton.Click();
            }

            // Method to close the browser
            public void CloseBrowser()
            {
                driver.Quit();
            }
        }

        public class ShoppingCartPage
        {
            private IWebDriver driver;

            public ShoppingCartPage(IWebDriver driver)
            {
                this.driver = driver;
            }

            // Method to navigate to the shopping cart
            public void NavigateToCart()
            {
                IWebElement cartIcon = driver.FindElement(By.Id("nav-cart-count"));
                cartIcon.Click();
            }


        // Method to get names of items in the shopping cart
        public List<string> GetCartItemNames()
        {
            // Navigate to the shopping cart
            NavigateToCart();

            // Initialize a list to store item names
            List<string> itemNames = new List<string>();

            // Get list of items in the cart
            IReadOnlyCollection<IWebElement> itemRows = driver.FindElements(By.CssSelector(".a-spacing-mini.sc-list-item"));

            // Iterate through each item row and extract name
            foreach (IWebElement itemRow in itemRows)
            {
                // Get item name
                IWebElement itemNameElement = itemRow.FindElement(By.CssSelector(".a-text-left.sc-product-link"));
                string itemName = itemNameElement.Text;

                // Add item name to the list
                itemNames.Add(itemName);
            }

            return itemNames;
        }

        // Method to get prices of items in the shopping cart
        public List<string> GetCartItemPrices()
        {
            // Navigate to the shopping cart
            NavigateToCart();

            // Initialize a list to store item prices
            List<string> itemPrices = new List<string>();

            // Get list of items in the cart
            IReadOnlyCollection<IWebElement> itemRows = driver.FindElements(By.CssSelector(".a-spacing-mini.sc-list-item"));

            // Iterate through each item row and extract price
            foreach (IWebElement itemRow in itemRows)
            {
                // Get item price
                IWebElement itemPriceElement = itemRow.FindElement(By.CssSelector(".a-color-price"));
                string itemPrice = itemPriceElement.Text;

                // Add item price to the list
                itemPrices.Add(itemPrice);
            }

            return itemPrices;
        }
        
        // Method to get the total price of items in the shopping cart
        public double GetTotalPrice()
            {
                IWebElement totalPriceElement = driver.FindElement(By.CssSelector("[data-name='Subtotals'] .a-color-price"));
                string totalPriceText = totalPriceElement.Text;
                // Parse the total price string into a double
                double totalPrice = double.Parse(totalPriceText.Replace("$", ""));
                return totalPrice;
            }
        }
    }
