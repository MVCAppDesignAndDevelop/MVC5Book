using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class 
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [TestInitialize]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:58645/";
            verificationErrors = new StringBuilder();
        }
        
        [TestCleanup]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [TestMethod]
        public void TheTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/product");
            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys("ASP.NET MVC 4 網站開發美學");
            driver.FindElement(By.Id("Length")).Clear();
            driver.FindElement(By.Id("Length")).SendKeys("30");
            driver.FindElement(By.Id("Width")).Clear();
            driver.FindElement(By.Id("Width")).SendKeys("20");
            driver.FindElement(By.Id("Height")).Clear();
            driver.FindElement(By.Id("Height")).SendKeys("10");
            driver.FindElement(By.Id("Weight")).Clear();
            driver.FindElement(By.Id("Weight")).SendKeys("10");
            new Select(driver.FindElement(By.Id("Company"))).SelectByText("黑貓");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            Assert.AreEqual("200", driver.FindElement(By.Id("fee")).Text);
            new Select(driver.FindElement(By.Id("Company"))).SelectByText("新竹貨運");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            Assert.AreEqual("254.16", driver.FindElement(By.Id("fee")).Text);
            new Select(driver.FindElement(By.Id("Company"))).SelectByText("郵局");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            Assert.AreEqual("180", driver.FindElement(By.Id("fee")).Text);
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
