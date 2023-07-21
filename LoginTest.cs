using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // Enter button on homepage
            AndroidElement eButton = GetWebElement("android.widget.Button");
            eButton.Click();

            // Enter email Id on welcome button
            AndroidElement emailInputBox = GetWebElement("android.widget.EditText");
            emailInputBox.Click();
            emailInputBox.SendKeys(StringResources.EMAIL_ID);
            driver.HideKeyboard();

            // Click on email continue button
            By emailContinueButton = By.XPath("//android.widget.Button[@content-desc=\"Continue\"]");
            AndroidElement cbutton = driver.FindElement(emailContinueButton);
            cbutton.Click();

            // Enter password
            AndroidElement passwordInputBox = GetWebElement("android.widget.EditText");
            passwordInputBox.Click();
            passwordInputBox.SendKeys(StringResources.PASSWORD);
            driver.HideKeyboard();

            // Click on toggle button
            AndroidElement toogleButton = GetWebElementusingxpath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.widget.Switch");
            toogleButton.Click();

            // Click on password continue button
            AndroidElement passwordButton = GetWebElementusingxpath("//android.widget.Button[@content-desc=\"Continue\"]");
            passwordButton.Click();

            // Click on skip button
            AndroidElement sButton = GetWebElementusingxpath("//android.widget.Button[@content-desc=\"Skip\"]");
            sButton.Click();

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