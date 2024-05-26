
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using PageObjectModel.Source.Pages;
using System.Configuration;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Edge;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Selenium.Axe;


namespace admTestProject
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class TestsAxe_edge
    {
        private IWebDriver _driver;
        public static ExtentTest test;
        //public static ExtentReports extent;
        [SetUp]
        public void Setup()
        {
            _driver = new EdgeDriver(); //_driver.Manage().Window.Maximize();            
            
        }

        [Test]
        public void searchTest()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver); //g.TakeScreenshot("golf");
            try { g.search("Sky Golf Course"); } catch (NoSuchElementException e) { g.TakeScreenshot("golf"); }
        }
        [Test]
        public void selectTest()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);
            try { g.select("United States"); } catch (NoSuchElementException e) { Console.WriteLine(e); }
        }
        [Test]
        public void addGolf()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);
            g.addGolfCourse();
        }
        [Test]
        public void editGolf()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);
            try { g.editGolfCourse(); } catch (NoSuchElementException e) { Console.WriteLine(e); };
        }
        [Test]
        public void deleteGolf()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);
            try { g.deleteGolfCourse(); } catch (NoSuchElementException e) { Console.WriteLine(e); };
        }

        [TearDown]
        public void Close() {  _driver.Close(); }
    }
}