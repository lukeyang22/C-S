
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using PageObjectModel.Source.Pages;
using System.Configuration;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Edge;
namespace admTestProject
{
    public class TestsBooking
    {
        private IWebDriver _driver;        
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(); _driver.Manage().Window.Maximize();
        }

        [Test]
        public void Booking()
        {
            BookingPage b = new BookingPage(_driver);
            b.Booking();
        } 
       
    }
}