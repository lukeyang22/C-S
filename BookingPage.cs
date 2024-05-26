using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
namespace PageObjectModel.Source.Pages
{
    public class BookingPage
    {
        private IWebDriver _driver;
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[1]/tbody/tr/td[4]/form/button")]
        private IWebElement Bookingbtn;
        [FindsBy(How = How.Id, Using = "GolfName")]
        private IWebElement GolfNameSelect;
        [FindsBy(How = How.Id, Using ="Customer")]
        private IWebElement Customertxt;
        [FindsBy(How = How.Id,Using ="Email")]
        private IWebElement Emailtxt;
        [FindsBy(How = How.Id, Using = "Phone")]
        private IWebElement Phonetxt;
        [FindsBy(How = How.Id, Using = "Date")]
        private IWebElement Datetxt;
        [FindsBy(How = How.Id, Using = "StartTime")]
        private IWebElement StartTimetxt;
        [FindsBy(How = How.Id, Using = "EndTime")]
        private IWebElement EndTimetxt;
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div[1]/div/form/div[8]/input")]
        private IWebElement Createbtn;

        public BookingPage(IWebDriver driver) { _driver = driver; PageFactory.InitElements(driver, this); }
        public void Booking()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            Bookingbtn.Click();
            var selectElement = GolfNameSelect;
            var select = new SelectElement(selectElement);
            select.SelectByText("Tiger A");
            Customertxt.SendKeys("John Smith");
            Emailtxt.SendKeys("johns@adminlucid.com");
            Phonetxt.SendKeys("780-2478899");
            Datetxt.SendKeys("2024"+Keys.ArrowRight+"03"+ Keys.ArrowRight+"18");
            StartTimetxt.SendKeys("08:30AM");
            EndTimetxt.SendKeys("09:30AM");
            Createbtn.Click();
        }
    }
}
