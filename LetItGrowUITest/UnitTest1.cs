using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace LetItGrowUITest
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\seleniumDrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            _driver.Navigate().GoToUrl("http://localhost:3002/"); //BEMÆRK 3002 ?!?!?!
            string title = _driver.Title;

            //IWebElement buttonElement = _driver.FindElement(By.Id("getAllPlantsButton"));
            //buttonElement.Click();

          

            //WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20)); 
            //IWebElement plantCard = wait.Until(d => d.FindElement(By.Id("plantDeck")));

            //Assert.IsTrue(plantCard.Text.Contains("tietongue"));
        }
    }
}
