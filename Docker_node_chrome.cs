
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
using TechTalk.SpecFlow;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Remote;
using java.rmi;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;

namespace admTestProject
{         
    public class TestsGolf_chromenode
    {
        private IWebDriver _driver;
        //private ScenarioContext _scenarioContext;
        public static ExtentTest test;        
        protected Uri GridUrl;
        //public static ExtentReports extent;
        [SetUp]
        public void Setup() 
        {
            GridUrl = new Uri( "http://localhost:4444");
            var options = new ChromeOptions();            
            try { _driver = new RemoteWebDriver(GridUrl, options); }catch(Exception ex) { Console.WriteLine(ex); }            
            _driver.Manage().Window.Maximize();
           
        }
               
        [Test]
        public void searchTest()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver); 
            try { g.search("Sky Golf Course");} catch (NoSuchElementException e) { g.TakeScreenshot("golf");}
        }       

        [Test]  
        public void selectTest()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);           
            GolfPage g = new GolfPage(_driver);
            try { g.select("United States"); } catch (NoSuchElementException e) { Console.WriteLine(e); }
        }       
       // [TearDown]
        //public void Close() {  _driver.Close(); }
    }
}