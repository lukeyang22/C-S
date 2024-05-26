using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
namespace PageObjectModel.Source.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;
        [FindsBy(How = How.Id, Using = "Input_Email")]
            private IWebElement emailtxt;
        [FindsBy(How = How.Id, Using = "Input_Password")]
        private IWebElement passwordtxt;
        [FindsBy(How = How.Id, Using = "login-submit")]
        private IWebElement loginbtn;
        public LoginPage(IWebDriver driver) { _driver = driver; PageFactory.InitElements(driver, this); }
        public void login(string username, string password)
        {
            emailtxt.SendKeys(username);
            passwordtxt.SendKeys(password);
            loginbtn.Click();
        }
    }
}
