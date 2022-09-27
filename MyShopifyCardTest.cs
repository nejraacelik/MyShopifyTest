using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QATest.Setup;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopifyTest
{
    [TestClass]
    public class MyShopifyCardTest:MyShopifyBaseTest
    {
        [TestMethod]
        public void Cart_ItemIsInCart()
        {

            var webDriver = Driver.Instance;

            //check that 1 item is in cart
            var firstItem = webDriver.FindElement(By.ClassName("quantity__input"));
            Assert.AreEqual("1", firstItem.GetAttribute("value"));
        }

        [TestMethod]
        public void Cart_FirstDiscountOffer()
        {
            var webDriver = Driver.Instance;
            var fiveItem = webDriver.FindElement(By.ClassName("quantity__input"));
            fiveItem.Clear();
            fiveItem.SendKeys("5");
            fiveItem.Click();
            //check that 5 item is in cart
            Assert.AreEqual("5", fiveItem.GetAttribute("value"));
           //wait 5sec
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            //find discountPrice
            var discountPriceSpan = wait.Until(driver => driver.FindElement(By.ClassName("hulkapps-cart-total")));
            //findoriginalPrice
            var originalPriceSpan = webDriver.FindElement(By.ClassName("hulkapps-cart-original-total"));
           //parse numbers - convert string to decimal
            var originalPrice = decimal.Parse(originalPriceSpan.Text.Replace("Rs. ", ""));
            var discountPrice = decimal.Parse(discountPriceSpan.Text.Replace("Rs. ", ""));
            //compare expected and actual results
            Assert.AreEqual(25, originalPrice - discountPrice);
        }
        [TestMethod]
        public void Cart_SecondDiscountOffer()
        {
            var webDriver = Driver.Instance;
            var fiveItem = webDriver.FindElement(By.ClassName("quantity__input"));
            fiveItem.Clear();
            fiveItem.SendKeys("10");
            fiveItem.Click();
            //check that 10 item is in cart
            Assert.AreEqual("10", fiveItem.GetAttribute("value"));
            //wait 5sec
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            //find discountPrice
            var discountPriceSpan = wait.Until(driver => driver.FindElement(By.ClassName("hulkapps-cart-total")));
            //find originalPrice
            var originalPriceSpan = webDriver.FindElement(By.ClassName("hulkapps-cart-original-total"));
            //parse numbers - convert string to decimal
            var originalPrice = decimal.Parse(originalPriceSpan.Text.Replace("Rs. ", ""));
            var discountPrice = decimal.Parse(discountPriceSpan.Text.Replace("Rs. ", ""));
            //compare expected and actual results
            Assert.AreEqual(150, originalPrice - discountPrice);
        }

        [TestMethod]
        public void Cart_ThirdDiscountOffer()
        {
            var webDriver = Driver.Instance;
            var fiveItem = webDriver.FindElement(By.ClassName("quantity__input"));
            fiveItem.Clear();
            fiveItem.SendKeys("15");
            fiveItem.Click();
            //check that 15 item is in cart
            Assert.AreEqual("15", fiveItem.GetAttribute("value"));
            //wait 5secs
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            //find discountPrice
            var discountPriceSpan = wait.Until(driver => driver.FindElement(By.ClassName("hulkapps-cart-total")));
            //find originalPrice
            var originalPriceSpan = webDriver.FindElement(By.ClassName("hulkapps-cart-original-total"));
            //parse numbers - convert string to decimal
            var originalPrice = decimal.Parse(originalPriceSpan.Text.Replace("Rs. ", ""));
            var discountPrice = decimal.Parse(discountPriceSpan.Text.Replace("Rs. ", ""));
            //compare expected and actual results
            Assert.AreEqual(discountPrice, originalPrice-originalPrice*(decimal)0.15);
        }
        [TestMethod]
        public void Cart_ProductLinePriceCart()
        {
            var webDriver = Driver.Instance;
            var fiveItem = webDriver.FindElement(By.ClassName("quantity__input"));
            fiveItem.Clear();
            fiveItem.SendKeys("1");
            fiveItem.Click();
            //check that 1 item is in cart
            Assert.AreEqual("1", fiveItem.GetAttribute("value"));
            //find checkOut button
            var checkOut = webDriver.FindElement(By.ClassName("cart__checkout-button"));
            //click checkOut button
            checkOut.Click();
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            //find linePrice
            var LinePrice = webDriver.FindElement(By.XPath("/html/body/div/div/aside/div[2]/div[1]/div/div[1]/div/table/tbody/tr/td[3]/span"));
            

            
        }
        [TestMethod]
        public void Cart_CheckOutTotalAndDiscountPrice()
        {
            var webDriver = Driver.Instance;
            var fiveItem = webDriver.FindElement(By.ClassName("quantity__input"));
            fiveItem.Clear();
            fiveItem.SendKeys("7");
            fiveItem.Click();
            //check that 1 item is in cart
            Assert.AreEqual("7", fiveItem.GetAttribute("value"));
            // find checkOut button
            var checkOut = webDriver.FindElement(By.ClassName("cart__checkout-button"));
            // click checkOut button
            checkOut.Click();
            //wait 5sec
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            //find checkOutDiscountPrice
            var CheckOutDiscountPrice = webDriver.FindElement(By.XPath("/html/body/div/div/aside/div[2]/div[1]/div/div[1]/div/table/tbody/tr/td[3]/span"));
            //find checkPutTotalPrice
            var CheckPutTotalPrice = webDriver.FindElement(By.XPath("/html/body/div/div/aside/div[2]/div[1]/div/div[2]/table/tfoot/tr/td/span[2]"));
            // compare checkOutDiscountPrice and  checkPutTotalPrice
            Assert.AreEqual(CheckOutDiscountPrice.Text, CheckPutTotalPrice.Text);

        }
    }
}
