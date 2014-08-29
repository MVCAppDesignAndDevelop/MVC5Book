using System;
using System.Text;
using CalculateShippingFee.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

//using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CalculateShippingFee.Tests.Features
{
    [Binding]
    [Scope(Feature = "計算運費")]
    public class 計算運費Steps
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [BeforeScenario]
        public void BeforeScenario()
        {
            //driver = new FirefoxDriver();
            driver = new ChromeDriver();
            baseURL = "http://localhost:58645/";
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

        [Given(@"計算運費頁面")]
        public void Given計算運費頁面()
        {
            driver.Navigate().GoToUrl(baseURL + "product");
        }

        [When(@"商品規格為")]
        public void When商品規格為(Table table)
        {
            var productModels = table.CreateInstance<ProductModels>();

            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys(productModels.Name);
            driver.FindElement(By.Id("Length")).Clear();
            driver.FindElement(By.Id("Length")).SendKeys(productModels.Length.ToString());
            driver.FindElement(By.Id("Width")).Clear();
            driver.FindElement(By.Id("Width")).SendKeys(productModels.Width.ToString());
            driver.FindElement(By.Id("Height")).Clear();
            driver.FindElement(By.Id("Height")).SendKeys(productModels.Height.ToString());
            driver.FindElement(By.Id("Weight")).Clear();
            driver.FindElement(By.Id("Weight")).SendKeys(productModels.Weight.ToString());
        }

        [When(@"選擇(.*)")]
        public void When選擇(string shipperName)
        {
            new SelectElement(driver.FindElement(By.Id("Company"))).SelectByText(shipperName);
        }

        [When(@"點選計算運費")]
        public void When點選計算運費()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        [Then(@"運費結果應為 (.*)")]
        public void Then運費結果應為(double fee)
        {
            Assert.AreEqual(fee.ToString(), driver.FindElement(By.Id("fee")).Text);
        }
    }
}