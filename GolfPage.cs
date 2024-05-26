using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
namespace PageObjectModel.Source.Pages
{
    public class GolfPage
    {
        private IWebDriver _driver;
        public static ExtentTest test;
        public static ExtentReports extent;
        
        
        [FindsBy(How = How.Name, Using = "SearchString")]
            private IWebElement searchtxt;
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[1]/tbody/tr/td[1]/form/button")]
        private IWebElement searchbtn;
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[2]/thead/tr/th[1]")]
        private IWebElement columnName;
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[2]/thead/tr/th[2]")] 
        private IWebElement columnAddress;
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[2]/thead/tr/th[3]")]
        private IWebElement columnDesc;
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[2]/tbody/tr/td[1]")]
        private IWebElement columnName_1;
        [FindsBy(How = How.ClassName, Using ="select")]
        private IWebElement selectCoutry;
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[2]/tbody/tr/td[2]")]
        private IWebElement address_1;
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[1]/tbody/tr/td[2]/form/fieldset/button")]
        private IWebElement filter;
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[1]/tbody/tr/td[5]/form/button")]
        private IWebElement addGolf;
        [FindsBy(How =How.Id, Using ="Name")]
        private IWebElement Name;
        [FindsBy(How = How.Id, Using = "Address")]
        private IWebElement Address;
        [FindsBy(How = How.Id, Using = "City")]
        private IWebElement City;
        [FindsBy(How = How.Id, Using = "Province")]
        private IWebElement Province;
        [FindsBy(How = How.Id, Using = "Country")]
        private IWebElement Country;
        [FindsBy(How = How.Id, Using = "Description")]
        private IWebElement Description;
        [FindsBy(How = How.Id, Using = "LongDes")]
        private IWebElement LongDes;
        [FindsBy(How = How.Id, Using = "Owner")]
        private IWebElement Owner;
        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement Email;
        [FindsBy(How = How.Id, Using = "PhoneNumber")]
        private IWebElement PhoneNumber;
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div[1]/div--/form/div[14]/input")]
        private IWebElement Create;
        [FindsBy(How = How.Id, Using = "Input_Email")]
        private IWebElement emailtxt;
        [FindsBy(How = How.Id, Using = "Input_Password")]
        private IWebElement passwordtxt;
        [FindsBy(How = How.Id, Using = "login-submit")]
        private IWebElement loginbtn;
        [FindsBy(How = How.XPath, Using = "/html/body/header/nav/ul/li/a")]
        private IWebElement loginLink;
        [FindsBy(How =How.XPath, Using = "/html/body/div/main/table[2]/tbody/tr/td[6]/a[2]")]
        private IWebElement editLink;
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div[1]/div/form/div[11]/input")]
        private IWebElement editSavebtn;
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[2]/tbody/tr/td[6]/a[3]")]
        private IWebElement deleteLink;
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/form/input[2]")]
        private IWebElement deleteSaveBtn;
        public GolfPage(IWebDriver driver) { _driver = driver; PageFactory.InitElements(driver, this); }
        /*public void search(string searchStr)
        {
            searchtxt.Clear(); searchtxt.SendKeys(searchStr); searchbtn.Click(); 
            
            Assert.That(columnName.Text, Is.EqualTo("Name ^incorrect"));
            Assert.That(columnAddress.Text, Is.EqualTo("Address"));
            Assert.That(columnDesc.Text, Is.EqualTo("Description"));
            Assert.That(columnName_1.Text, Is.EqualTo(searchStr));
            
        }*/
        public void search(string searchStr)
        {
            string screensh = @"C:\Users\ADM\source\repos\admTestProject\Screenshot\" + "Golf" + DateTime.Now.ToString("_MMddyyyy_hhmmt") + ".png";
            var extent = new ExtentReports();
            var spark = new ExtentSparkReporter(@"C:\Users\ADM\source\repos\admTestProject\Reports\"+"Golf"+ DateTime.Now.ToString("_MMddyyyy_hhmmt") + ".html");
            extent.AttachReporter(spark);
            //extent.CreateTest("MyFirstTest")
            //.Log(Status.Pass, "This is a logging event for MyFirstTest, and it passed!");
            var test = extent.CreateTest("SearchTest");
            test.Info("Starting search for Golf Courses"); extent.Flush();

            try { searchtxt.Clear(); searchtxt.SendKeys(searchStr); searchbtn.Click(); test.Pass("Search for Golf Course");extent.Flush(); }catch(NoSuchElementException e) { test.Fail("Search for Golf Course"); TakeScreenshot("Golf");test.AddScreenCaptureFromPath(screensh);extent.Flush(); }
            try{ Assert.That(columnName.Text, Is.EqualTo("Name ^"));
                Assert.That(columnAddress.Text, Is.EqualTo("Address"));
                Assert.That(columnDesc.Text, Is.EqualTo("Description"));
                Assert.That(columnName_1.Text, Is.EqualTo(searchStr)); test.Pass("Validate Golf Table"); extent.Flush();
            }catch(Exception e) { test.Fail("Validate Golf Table"); TakeScreenshot("Golf"); test.AddScreenCaptureFromPath(screensh); extent.Flush(); }
        }
        public void select(string country)
        {
            var selectElement = selectCoutry;
            var select = new SelectElement(selectElement);
            select.SelectByText(country);
            filter.Click();
            Assert.That(columnName.Text, Is.EqualTo("Name ^"));
            Assert.That(columnAddress.Text, Is.EqualTo("Address"));
            Assert.That(columnDesc.Text, Is.EqualTo("Description"));
            Assert.That(address_1.Text, Contains.Substring(country));
        }
        public void addGolfCourse()
        {
            addGolf.Click();
            string? User = TestContext.Parameters["user"];
            string? Password = TestContext.Parameters["password"];
            emailtxt.SendKeys(User);passwordtxt.SendKeys(Password);loginbtn.Click();
            Thread.Sleep(4000);            
            Name.SendKeys("Testing Golf Course A");
            Address.SendKeys("1200 AVE NW");
            City.SendKeys("Edmonton");
            Province.SendKeys("AB");
            Country.SendKeys("Canada");
            Description.SendKeys("It's nice golf course");
            LongDes.SendKeys("It's located in NW Edmonton. It's country style and full services.");
            Owner.SendKeys("Daniel John");
            Email.SendKeys("test2@admlucid.com");
            PhoneNumber.SendKeys("5878893349");_driver.Manage().Window.FullScreen();
            Create.Click();
        }
        public void addGolfCourseCase(string a, string b, string c, string d, string e, string f, string g, string h, string l, string m)
        {
            addGolf.Click();
            string? User = TestContext.Parameters["user"];
            string? Password = TestContext.Parameters["password"];
            emailtxt.SendKeys(User); passwordtxt.SendKeys(Password); loginbtn.Click();
            Thread.Sleep(4000);
            Name.SendKeys(a);
            Address.SendKeys(b);
            City.SendKeys(c);
            Province.SendKeys(d);
            Country.SendKeys(e);
            Description.SendKeys(f);
            LongDes.SendKeys(g);
            Owner.SendKeys(h);
            Email.SendKeys(l);
            PhoneNumber.SendKeys(m); _driver.Manage().Window.FullScreen();
            Create.Click();
        }
        public void editGolfCourse()
        {            
            loginLink.Click();
            string? User = TestContext.Parameters["user"];
            string? Password = TestContext.Parameters["password"];
            emailtxt.SendKeys(User); passwordtxt.SendKeys(Password); loginbtn.Click();
            Thread.Sleep(4000);
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]); Thread.Sleep(2000);
            searchtxt.SendKeys("Testing Golf Course A"); searchbtn.Click();
            editLink.Click(); Owner.Clear(); Owner.SendKeys("Adm Test2"); editSavebtn.Click();
        }
        public void deleteGolfCourse()
        {
            loginLink.Click();
            string? User = TestContext.Parameters["user"];
            string? Password = TestContext.Parameters["password"];
            emailtxt.SendKeys(User); passwordtxt.SendKeys(Password); loginbtn.Click();
            Thread.Sleep(4000);
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]); Thread.Sleep(2000);
            searchtxt.SendKeys("Testing Golf Course A"); searchbtn.Click();
            deleteLink.Click(); deleteSaveBtn.Click();Thread.Sleep(2000);
        }
        public void TakeScreenshot( string screenshotname)
        {   
            try
            {
                ITakesScreenshot ts = (ITakesScreenshot)_driver; 
                string filename = @"C:\Users\ADM\source\repos\admTestProject\Screenshot\" + screenshotname+ DateTime.Now.ToString("_MMddyyyy_hhmmt")+".png";
                ts.GetScreenshot().SaveAsFile(filename);Console.WriteLine(filename);
            }catch(InvalidCastException e) {Console.WriteLine("Screenshot: "+e.ToString());}
           
        }
    }
}
