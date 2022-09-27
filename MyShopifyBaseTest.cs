using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QATest.Setup;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

namespace MyShopifyTest
{
          
    [TestClass]

    public class MyShopifyBaseTest
    {
        public TestArguments Parameters { get; private set; }
        public string FilePath => @"C:\My Shopify Test\LogFile.txt";

        [TestInitialize]

        public void Init()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            var downloadDirectory = @"C:\Files";
            var driverDirectory = @"C:\Drivers\";
            var configFilePath = @"C:\My Shopify Test\config.xml";

            Parameters = new TestArguments(configFilePath);
            Driver.Initiliaze(driverDirectory, downloadDirectory, Parameters.Browser);

            //go to page by url
            var loginFilePath = @"C:\My Shopify Test\Login.txt";
            string url = Parameters.Url;
            var webDriver = Driver.Instance;
            Url.GoTo(url);
            string[] lines = File.ReadLines(loginFilePath).ToArray();

            //login with password
            var password = webDriver.FindElement(By.CssSelector("#password"));
            password.SendKeys(lines[0]);
            var enterbutton = webDriver.FindElement(By.CssSelector("body > div > div.content > div:nth-child(2) > form > button"));
            enterbutton.Click();

            //click on catalog link
            var catalog = webDriver.FindElement(By.CssSelector("#shopify-section-header > sticky-header > header > nav > ul > li:nth-child(2) > a > span"));
            catalog.Click();

            //click on first item
            var item = webDriver.FindElement(By.XPath("/html/body/main/div[2]/div[2]/div/ul/li[1]/div/div[1]/div/h3/a"));
            item.Click();

            //add to cart         
            var addToCart = webDriver.FindElement(By.ClassName("product-form__submit"));
            addToCart.Click();
            Thread.Sleep(2000);

            //click on view my cart after 2sec because add to cart can be long operation
            //and view mycart is not yet presented
            var wait=new WebDriverWait(webDriver, System.TimeSpan.FromSeconds(2));
            var viewMyCart = wait.Until(driver => driver.FindElement(By.Id("cart-notification-button")));
            viewMyCart.Click();

        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }

}