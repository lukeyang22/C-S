
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using PageObjectModel.Source.Pages;
using System.Configuration;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using java.time;
namespace admTestProject
{
    public class TestsActionsAPI
    {
        private IWebDriver _driver;        
        [SetUp]
        public void Setup()
        {
            _driver = new EdgeDriver(); _driver.Manage().Window.Maximize();
        }

        [Test]
        public void ScrollDown()
        {
            _driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            Thread.Sleep(1000);
            IWebElement footer = _driver.FindElement(By.TagName("footer"));
            var scrollOrigin = new WheelInputDevice.ScrollOrigin
            {
                Element = footer,
                XOffset = 0,
                YOffset = -50
            };
            new Actions(_driver)
                 .ScrollFromOrigin(scrollOrigin, 0, 200)
                 .Perform();

        }
        [Test]
        public void CopyPaste()
        {
            _driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            var capabilities = ((WebDriver)_driver).Capabilities;
            String platformName = (string)capabilities.GetCapability("platformName");

            String cmdCtrl = platformName.Contains("mac") ? Keys.Command : Keys.Control;
            IWebElement textField = _driver.FindElement(By.Id("TextArea1"));
            new Actions(_driver)                
                .SendKeys(textField, "Welcome to Selenium Automation Testing!")
                .SendKeys(Keys.ArrowLeft)
                .KeyDown(Keys.Shift)
                .SendKeys(Keys.ArrowUp)
                .KeyUp(Keys.Shift)
                .KeyDown(cmdCtrl)
                .SendKeys("xvv")
                .KeyUp(cmdCtrl)
                .Perform();
        }
        [Test]
        public void mousePause()
        {
            _driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");
            IWebElement clickable = _driver.FindElement(By.Name("Text2"));
            Thread.Sleep(1000);
            new Actions(_driver)
                    .MoveToElement(clickable)                    
                    .ClickAndHold()                    
                    .SendKeys("abcdddddddddddddddddddddddddddddddddddddddddddddd")
                    .Perform();
        }
        [Test]  
        public void dragDrop()
        {
            _driver.Navigate().GoToUrl("https://www.w3schools.com/html/html5_draganddrop.asp");
            IWebElement draggable = _driver.FindElement(By.Id("drag1"));
            IWebElement droppable = _driver.FindElement(By.Id("div2"));
            new Actions(_driver)
                    .DragAndDrop(draggable, droppable)
                    .Perform();
        }
       
    }
}