
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
//[Parallelizable(ParallelScope.All)] //add
namespace admTestProject
{  
    //[TestFixture]
    //[Parallelizable(ParallelScope.All)]
    [Binding]
    public class TestsGolf_parall
    {
        private IWebDriver _driver;
        //private ScenarioContext _scenarioContext;
        public static ExtentTest test;
        private readonly Dictionary<string, object> emptyDictionary = new();
        //public static ExtentReports extent;
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(); _driver.Manage().Window.Maximize();
           
        }
        public static List<TestCaseData> TestCases
        {
            get
            {
                var testCases = new List<TestCaseData>();

                using (var fs = File.OpenRead(@"C:\Users\ADM\source\repos\admTestProject\Data\countries.csv"))
                using (var sr = new StreamReader(fs))
                {
                    string line = string.Empty;
                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            string[] country = line.Split(new char[] { '\n' },
                                StringSplitOptions.None);                            

                            var testCase = new TestCaseData(country);
                            testCases.Add(testCase);
                        }
                    }
                }

                return testCases;
            }
        }
        [Test]
        public void PerformanceMetrics()
        {
            _driver.Url = "https://www.admlucid.com";

            ((ChromeDriver)_driver).ExecuteCdpCommand("Performance.enable", emptyDictionary);

            Dictionary<string, object> response = (Dictionary<string, object>)((ChromeDriver)_driver)
                .ExecuteCdpCommand("Performance.getMetrics", emptyDictionary);

            Object[] metricList = (object[])response["metrics"];
            var metrics = metricList.OfType<Dictionary<string, object>>()
                .ToDictionary(
                    dict => (string)dict["name"],
                    dict => dict["value"]
                    
                );
            Console.WriteLine(metrics);
           
            Assert.IsTrue((double)metrics["DevToolsCommandDuration"] > 0);
            Assert.That(metrics["Frames"], Is.EqualTo((long)2));
        }
        [Test]
        public void searchTest()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver); 
            try { g.search("Sky Golf Course");} catch (NoSuchElementException e) { g.TakeScreenshot("golf");}
        }
        
        [TestCase("Sky Golf Course")]
        [TestCase("Tiger Golf")]
        [TestCase("Tiger B")]                
        [Test]
        public void searchTestCases(string name)
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);
            try { g.search(name); } catch (NoSuchElementException e) { /*g.TakeScreenshot("golf");*/ }
        }

        [TestCaseSource("TestCases")]
        [Parallelizable(ParallelScope.All)]
        [Test]
        public void selectTestCases(string country)
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);
            try { g.select(country); } catch (NoSuchElementException e) { Console.WriteLine(e); }
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