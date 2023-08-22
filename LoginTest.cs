using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using StykuMobileTest.Comman;

namespace StykuMobileTest
{
    public class LoginTest : Caps
    {

        [SetUp]
        public void Setup()
        {
            AppiumSetup();
        }

        [Test]
        public void TestLoginSuccess()
        {
            LoginTest();
        }

        [Test]
        public void TestLoginWithInvalidEmail()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            AndroidElement eButton = GetWebElement("android.widget.Button");
            eButton.Click();

            AndroidElement emailInputBox = GetWebElement("android.widget.EditText");
            emailInputBox.Click();

            emailInputBox.SendKeys(StringResources.INVALID_EMAIL_ID);

            driver.HideKeyboard();

            AndroidElement element = driver.FindElementByXPath("//android.view.View[@content-desc=\"Please enter a valid email format\"]");
            string actResult = element.GetAttribute("content-desc");
            string expResult = StringResources.EMAIL_VALIDATION_MESSAGE;
            Assert.That(actResult, Is.EqualTo(expResult));
            driver.Quit();

        }

        [Test]
        public void TestLoginWithInvalidPassword()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            AndroidElement eButton = GetWebElement("android.widget.Button");
            eButton.Click();

            AndroidElement emailInputBox = GetWebElement("android.widget.EditText");
            emailInputBox.Click();
            emailInputBox.SendKeys(StringResources.EMAIL_ID);
            driver.HideKeyboard();

            By emailContinueButton = By.XPath("//android.widget.Button[@content-desc=\"Continue\"]");
            AndroidElement cbutton = driver.FindElement(emailContinueButton);
            cbutton.Click();

            AndroidElement passwordInputBox = GetWebElement("android.widget.EditText");
            passwordInputBox.Click();
            passwordInputBox.SendKeys(StringResources.INVALID_PASSWORD);
            driver.HideKeyboard();

            AndroidElement passwordButton = GetWebElementusingxpath("//android.widget.Button[@content-desc=\"Continue\"]");
            passwordButton.Click();
            AndroidElement element = driver.FindElementByXPath("/hierarchy/android.widget.Toast");

            string actResult = element.GetAttribute("text");
            string expResult = StringResources.INVALID_PASSWORD_MESSAGE;
            Assert.That(actResult, Is.EqualTo(expResult));
            driver.Quit();

        }

        private AndroidElement GetWebElement(string webElement)
        {
            By enterButton = By.ClassName(webElement);

            return driver.FindElement(enterButton);
        }

        private AndroidElement GetWebElementusingxpath(string webElement)
        {
            By enterButton = By.XPath(webElement);

            return driver.FindElement(enterButton);
        }

    }
}