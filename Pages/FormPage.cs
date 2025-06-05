using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ReqnrollProject1.Pages
{
    internal class FormPage
    {
        private readonly IWebDriver _driver;

        public FormPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Locators
        By NameField = By.XPath("//body/main/div[@class='container']/div[@class='row d-flex justify-content-center logindiv bg-white rounded']/div[@class='col-md-8 col-lg-8 col-xl-8']/form[@id='practiceForm']/div[1]/div[1]/input");
        By EmailField = By.XPath("//input[@id='email']");
        By GenderField = By.XPath("(//input[@id='gender'])[1]");
        By MobileField = By.XPath("//input[@id='mobile']");
        By DateField = By.XPath("//input[@id='dob']");
        By SubjectField = By.XPath("//input[@id='subjects']");

        // Differentiate picture input and address textarea by tag name
        By PictureField = By.XPath("//input[@id='picture']");
        By AddressField = By.XPath("//textarea[@id='picture']");

        By LoginFormLocator = By.XPath("//input[@value='Login']");
        By HomePageDisplayed = By.XPath("//h1[normalize-space()='Student Registration Form']");

        public void LaunchBrowser()
        {
            Thread.Sleep(3000);
            _driver.Navigate().GoToUrl("https://www.tutorialspoint.com/selenium/practice/selenium_automation_practice.php");
        }

        public void EnterInput(string name, string email, string dob, string mobile, string subject, string picturePath, string address, string city, string state, string hobbies)
        {
            
            var nameElement = _driver.FindElement(NameField);
            nameElement.Clear();
            nameElement.SendKeys(name);

            
            _driver.FindElement(EmailField).Clear();
            _driver.FindElement(EmailField).SendKeys(email);

            _driver.FindElement(GenderField).Click();

            var mobileElement = _driver.FindElement(MobileField);
            mobileElement.Clear();
            mobileElement.SendKeys(mobile);

            var dobElement = _driver.FindElement(DateField);
            dobElement.Clear();
            dobElement.SendKeys(dob);

            var subjectElement = _driver.FindElement(SubjectField);
            subjectElement.Clear();
            subjectElement.SendKeys(subject);

            
            string[] hobbyList = hobbies.Split(',');
            foreach (string hobby in hobbyList)
            {
                string trimmedHobby = hobby.Trim();
                By hobbyLocator = By.XPath($"//label[contains(text(), '{trimmedHobby}')]/preceding-sibling::input[@type='checkbox']");
                var hobbyElement = _driver.FindElement(hobbyLocator);
                if (!hobbyElement.Selected)
                {
                    hobbyElement.Click();
                }
            }

            
            _driver.FindElement(PictureField).SendKeys(picturePath);

            
            var addressElement = _driver.FindElement(AddressField);
            addressElement.Clear();
            addressElement.SendKeys(address);

            
            By dynamicState = By.XPath($"//select[@id='state']/option[contains(text(), '{state}')]");
            By dynamicCity = By.XPath($"//select[@id='city']/option[contains(text(), '{city}')]");

            _driver.FindElement(dynamicState).Click();
            _driver.FindElement(dynamicCity).Click();
        }

        public void Submit()
        {
            Thread.Sleep(2000);
            _driver.FindElement(LoginFormLocator).Click();
        }

        public void HomePageDisplay()
        {
            Thread.Sleep(3000);
            IWebElement homepage = _driver.FindElement(HomePageDisplayed);

            if (homepage.Displayed)
            {
                Console.WriteLine("Home page is displayed");
            }
            else
            {
                Console.WriteLine("Home page is not displayed");
            }
        }
    }
}
