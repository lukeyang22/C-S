
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using PageObjectModel.Source.Pages;
using System.Configuration;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Edge;
namespace admTestProject
{
    public class TestsBooking_firefox
    {
        private IWebDriver _driver;        
        [SetUp]
        public void Setup()
        {
            _driver = new FirefoxDriver(); _driver.Manage().Window.Maximize();
        }

        [Test]
        public void Booking()
        {
            BookingPage b = new BookingPage(_driver);
            b.Booking();
        } 
       
    }
}