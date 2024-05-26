
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

//[Parallelizable(ParallelScope.All)] //add
namespace admTestProject
{
    
    public class TestsGolf
    {
        private IWebDriver _driver;
        public static ExtentTest test;
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
        public void searchTest()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver); 
            try { g.search("Sky Golf Course");} catch (NoSuchElementException e) { g.TakeScreenshot("golf");}
        }
        
        [TestCase("Sky Golf Course")]
        [TestCase("Tiger Golf")]
        [TestCase("Tiger B")]        
        [Parallelizable(ParallelScope.All)]
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