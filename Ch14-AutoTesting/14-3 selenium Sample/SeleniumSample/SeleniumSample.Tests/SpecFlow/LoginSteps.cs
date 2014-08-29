using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace SeleniumSample.Tests.SpecFlow
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:4993/";
            verificationErrors = new StringBuilder();
        }

        [AfterScenario]
        public void AfterScenario()
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

        [Given(@"Login的頁面")]
        public void GivenLogin的頁面()
        {
            driver.Navigate().GoToUrl(baseURL + "/Login/Index");
        }

        [When(@"在帳號輸入""(.*)""")]
        public void When在帳號輸入(string id)
        {
            driver.FindElement(By.Id("id")).Clear();
            driver.FindElement(By.Id("id")).SendKeys(id);
        }

        [When(@"在密碼輸入""(.*)""")]
        public void When在密碼輸入(string password)
        {
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys(password);
        }

        [When(@"按下登入")]
        public void When按下登入()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        [Then(@"顯示""(.*)""")]
        public void Then顯示(string message)
        {
            Assert.AreEqual(message, driver.FindElement(By.Id("message")).Text);
        }
    }
}