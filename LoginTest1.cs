
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using PageObjectModel.Source.Pages;
using System.Configuration;
using NUnit.Framework.Internal;
namespace admTestProject
{
    public class Tests
    {
        private IWebDriver _driver;
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            string? User = TestContext.Parameters["user"];
            string? Password = TestContext.Parameters["password"];
            LoginPage lg = new LoginPage(_driver);
            _driver.Navigate().GoToUrl(TestContext.Parameters["login_url"]);
            lg.login(User, Password);           ;
        }
    }
}