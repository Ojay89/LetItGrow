using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace LetItGrowUITest
{
    [TestClass]
    public class UiTest
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
            //_driver.Dispose();
        }

        [TestMethod]
        public void TestGetAllButton()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/"); 
           

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            IWebElement buttonElement = wait.Until(d => d.FindElement(By.Id("GetAllPlantsButton")));
            buttonElement.Click();
            IWebElement plantCard = wait.Until(d => d.FindElement(By.Id("plantDeck")));
            Assert.IsTrue(plantCard.Text.Contains("southern red oak"));
        }

        //[TestMethod] //lav den når vi ikke har opbrugt vores azure guldbank
        //public void TestWeatherInRealTime()
        //{
        //    //Denne test har virket da jeg lavede den. Men da data bliver sendt hver 3. sekund vil testen faile.
        //    _driver.Navigate().GoToUrl("http://localhost:3000/");
        //    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        //    _driver.Manage().Window.Maximize();


            
        //}

        [TestMethod]
        public void TestSearchButtonInNav()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            _driver.Manage().Window.Maximize();

            IWebElement searchElement = wait.Until(d => d.FindElement(By.Id("SearchBar")));
            searchElement.Click();
            searchElement.SendKeys("Oak");
            IWebElement searchButtonElement = wait.Until(d => d.FindElement(By.Id("getSearchPlantsButton")));
            searchButtonElement.Click();

            IWebElement plantCard = wait.Until(d => d.FindElement(By.Id("plantDeck")));
            Assert.IsTrue(plantCard.Text.Contains("European turkey oak"));
        }




    }
}
