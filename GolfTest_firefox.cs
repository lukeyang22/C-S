
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using PageObjectModel.Source.Pages;
using System.Configuration;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Firefox;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;

//[assembly: Parallelizable(ParallelScope.All)] //add
namespace admTestProject
{
    public class TestsGolf_firefox
    {
        private IWebDriver _driver;
        public static ExtentTest test;
        //public static ExtentReports extent;
        [SetUp]
        public void Setup()
        {
            _driver = new FirefoxDriver(); _driver.Manage().Window.Maximize();            

        }
        public static List<TestCaseData> TestCases
        {
            get
            {
                var testCases = new List<TestCaseData>();

                using (var fs = File.OpenRead(@"C:\Users\ADM\source\repos\admTestProject\Data\golf.csv"))
                using (var sr = new StreamReader(fs))
                {
                    string line = string.Empty;
                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            string[] golf = line.Split(new char[] { ',' },
                                StringSplitOptions.None);
                                                        
                            var testCase = new TestCaseData(golf);
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
            GolfPage g = new GolfPage(_driver); //g.TakeScreenshot("golf");
            try { g.search("Sky Golf Course");} catch (NoSuchElementException e) { g.TakeScreenshot("golf");}
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
        [TestCaseSource("TestCases")]
        [Test]
        public void addGolfTestCases(string a, string b, string c, string d, string e, string f, string g, string h, string l, string m)
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage gf = new GolfPage(_driver);
            gf.addGolfCourseCase(a, b, c, d, e, f, g, h, l, m);
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