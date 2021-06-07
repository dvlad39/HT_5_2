using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace HT_5_2
{
    [TestFixture]
    public class HT_5_2
    {
        IWebDriver driver;

        [SetUp]

        public void BeforeTest()
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


        }

        [TearDown]

        public void AfterTest()
        {
            driver.Quit();
        }

        [TestCase("JohnDoe", "passw0rd")]
        [TestCase("LiliaJY", "isNotMe")]
        [TestCase("GoingTO", "BeAutol")]

        public void CheckValidation(string v1, string v2)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            string loginPageUrl = "http://automationpractice.com/";
            driver.Navigate().GoToUrl(loginPageUrl);

            wait.Until(x => x.FindElement(By.Id("footer")).Displayed);

            IWebElement signInButtonXPath = driver.FindElement(By.XPath("//a[@class = 'login']"));
            IWebElement signInButtonCss = driver.FindElement(By.CssSelector(".login"));

            signInButtonXPath.Click();

            wait.Until(x => x.FindElement(By.Name("email")).Displayed);

            IWebElement emailBox = driver.FindElement(By.Id("email"));
            IWebElement emailBoxXPath = driver.FindElement(By.XPath("//input[@id = 'email']"));
            IWebElement emailBoxCss = driver.FindElement(By.CssSelector("#email"));

            emailBox.Click();
            emailBox.SendKeys(v1);

            IWebElement passwordBoxId = driver.FindElement(By.Id("passwd"));
            IWebElement passwordBoxName = driver.FindElement(By.Name("passwd"));
            IWebElement passwordBoxXPath = driver.FindElement(By.XPath("//input[@data-validate = 'isPasswd']"));
            IWebElement passwordBoxCss = driver.FindElement(By.CssSelector("input[type = 'password']"));

            passwordBoxId.Click();
            passwordBoxId.SendKeys(v2);

            IWebElement logInButtonId = driver.FindElement(By.Id("SubmitLogin"));
            IWebElement logInButtonXPath = driver.FindElement(By.XPath("//button[@name = 'SubmitLogin']"));
            IWebElement logInButtonCss = driver.FindElement(By.CssSelector("#SubmitLogin"));

            logInButtonId.Click();

            IWebElement allertMessage = driver.FindElement(By.XPath("//p[text() = 'There is 1 error']"));

            Assert.That(allertMessage.Displayed, "Invalid email address");

        }

        public static IEnumerable<TestCaseData> LoginData
        {
            get
            {
                yield return new TestCaseData("JohnDoe", "passw0rd");
                yield return new TestCaseData("LiliaJY", "isNotMe");
                yield return new TestCaseData("GoingTO", "BeAutol");
            }
        }

        [TestCaseSource("LoginData")]
        public void CheckValidatin2(string v1, string v2)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            string loginPageUrl = "http://automationpractice.com/";
            driver.Navigate().GoToUrl(loginPageUrl);

            wait.Until(x => x.FindElement(By.Id("footer")).Displayed);

            IWebElement signInButtonXPath = driver.FindElement(By.XPath("//a[@class = 'login']"));
            IWebElement signInButtonCss = driver.FindElement(By.CssSelector(".login"));

            signInButtonXPath.Click();

            wait.Until(x => x.FindElement(By.Name("email")).Displayed);

            IWebElement emailBox = driver.FindElement(By.Id("email"));
            IWebElement emailBoxXPath = driver.FindElement(By.XPath("//input[@id = 'email']"));
            IWebElement emailBoxCss = driver.FindElement(By.CssSelector("#email"));

            emailBox.Click();
            emailBox.SendKeys(v1);

            IWebElement passwordBoxId = driver.FindElement(By.Id("passwd"));
            IWebElement passwordBoxName = driver.FindElement(By.Name("passwd"));
            IWebElement passwordBoxXPath = driver.FindElement(By.XPath("//input[@data-validate = 'isPasswd']"));
            IWebElement passwordBoxCss = driver.FindElement(By.CssSelector("input[type = 'password']"));

            passwordBoxId.Click();
            passwordBoxId.SendKeys(v2);

            IWebElement logInButtonId = driver.FindElement(By.Id("SubmitLogin"));
            IWebElement logInButtonXPath = driver.FindElement(By.XPath("//button[@name = 'SubmitLogin']"));
            IWebElement logInButtonCss = driver.FindElement(By.CssSelector("#SubmitLogin"));

            logInButtonId.Click();

            IWebElement allertMess = driver.FindElement(By.XPath("//p[text() = 'There is 1 error']"));

            Assert.That(allertMess.Displayed, "Invalid email address");


        }
    }
}
