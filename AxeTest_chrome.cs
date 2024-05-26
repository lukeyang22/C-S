
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
    public class TestsGolf_edge
    {
        private IWebDriver _driver;
        public static ExtentTest test;
        //public static ExtentReports extent;
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(); _driver.Manage().Window.Maximize();            

        }

        [Test]
        public void AxeTest_Golf()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);           
            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            
            string path = Path.Combine(@"C:\Users\ADM\source\repos\admTestProject\Reports\", "AxeReport_Golf.html");

            _driver.CreateAxeHtmlReport(axeResult, path);            
        }
        [Test]  
        public void AxeTest_Home()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["home_url"]);
            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            
            string path = Path.Combine(@"C:\Users\ADM\source\repos\admTestProject\Reports\", "AxeReport_Home.html");

            _driver.CreateAxeHtmlReport(axeResult, path);
        }
        [TearDown] public void TearDown() { _driver.Close(); }
    }
}